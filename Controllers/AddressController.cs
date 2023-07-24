using AdventureWorksAPI.Models;
using AdventureWorksAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {

    
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IConfiguration configuration,IUnitOfWork unitOfWork)
        {
            _configuration= configuration;
            _unitOfWork= unitOfWork;
        }

        [Route("PivotSalesTable")]
        [HttpGet]
        public async Task<IActionResult>PivotSalesTable()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Select country," +
                "\r\n\tAVG(ISNULL(q1, 0)) as 'Average of quarter1'," +
                "\r\n\tAVG(ISNULL(q1, 0)) 'Average of quarter2',\r\n\tAVG(ISNULL(q1, 0)) " +
                "'Average of quarter1' \r\n\tfrom AdventureWorks2019.dbo.sales\r\n\tPivot(sum(sales) " +
                "for quarter in ([q1],[q2],[q3])) as PivotTable group by country\r\n\t", conn);
            
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                Console.WriteLine(dt.Rows[i]["Country"].ToString());
            }



            return Ok();
        }


        [Route("GetAllAddress")]
        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            return Ok(_unitOfWork.AddressRepository.GetAll());
        }


        [Route("GetOneAddress")]
        [HttpGet]
        public async Task<IActionResult> GetOneAddress(int id)
        {

            return Ok(_unitOfWork.AddressRepository.GetOne(id));
        }


        [HttpPost]
        [Route("AddContactType")]
        public async Task<IActionResult> AddContactType(ContactType address)
        {


            try 
            {
                return Ok(_unitOfWork.ContactTypeRepository.Create(address)) ;
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            

        }
        [HttpPost]
        [Route("UpdateContactType")]
        public async Task<IActionResult> UpdateContactType(ContactType address)
        {
            try
            { 
       
                return Ok(_unitOfWork.ContactTypeRepository.Update(address));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteContactType")]
        public async Task<IActionResult> DeleteContactType(ContactType address)
        {
            
            try
            {
                return Ok(_unitOfWork.ContactTypeRepository.Delete(address));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
