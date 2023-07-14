using AdventureWorksAPI.Models;
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

        public AddressController(IConfiguration configuration)
        {
            _configuration= configuration;
        }


        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<IActionResult> GetAllAddress() 
        {
            List<Address> addresses = new List<Address>();
 
            DataTable dt= new DataTable();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Select * from Person.Address ", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            for(int i=0;i<dt.Rows.Count;i++)
            {
                addresses.Add(new Address
                {
                    AddressId = (int)dt.Rows[i]["AddressId"],
                    AddressLine1 = (string)dt.Rows[i]["AddressLine1"],
                    City = (string)dt.Rows[i]["City"],
                    StateProvinceId = (int)dt.Rows[i]["StateProvinceId"],
                    PostalCode = (string)dt.Rows[i]["PostalCode"],
                    Rowguid = (Guid)dt.Rows[i]["Rowguid"],
                    ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"]
                });

            }
            return Ok(addresses);
        }


        [Route("GetOneAddress")]
        [HttpGet]
        public async Task<IActionResult> GetOneAddress(int id)
        {
            List<Address> addresses = new List<Address>();

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Select * from Person.Address where AddressId="+id, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                addresses.Add(new Address
                {
                    AddressId = (int)dt.Rows[i]["AddressId"],
                    AddressLine1 = (string)dt.Rows[i]["AddressLine1"],
                    City = (string)dt.Rows[i]["City"],
                    StateProvinceId = (int)dt.Rows[i]["StateProvinceId"],
                    PostalCode = (string)dt.Rows[i]["PostalCode"],
                    Rowguid = (Guid)dt.Rows[i]["Rowguid"],
                    ModifiedDate = (DateTime)dt.Rows[i]["ModifiedDate"]
                });

            }
            return Ok(addresses);
        }


        [HttpPost]
        [Route("AddContactType")]
        public async Task<IActionResult> AddContactType(ContactType address)
        {
            try 
            { 
            SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                SqlCommand cmd = new SqlCommand("INSERT INTO Person.ContactType (Name, ModifiedDate) VALUES (@Name, @CreatedDate)", conn);
                cmd.Parameters.AddWithValue("@Name", address.Name);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();


                return Ok(address);
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
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                SqlCommand cmd = new SqlCommand("UPDATE Person.ContactType SET Name = @Name, ModifiedDate = @ModifiedDate WHERE ContactTypeID = @ContactTypeId", conn);
                cmd.Parameters.AddWithValue("@Name", address.Name);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ContactTypeId", address.ContactTypeId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return Ok(address);
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
                SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                SqlCommand cmd = new SqlCommand("DELETE FROM Person.ContactType WHERE ContactTypeID = @ContactTypeId", conn);
                cmd.Parameters.AddWithValue("@ContactTypeId", address.ContactTypeId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return Ok(address);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}
