using AdventureWorksAPI.Models;
using AdventureWorksAPI.Repository.IRepository;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace AdventureWorksAPI.Repository
{
    public class AddressRepository : Repository,IAddressRepository
    {

        public AddressRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Address Create(Address address)
        {
            throw new NotImplementedException();
        }

        public Address Delete(Address address)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAll()
        {



            List<Address> addresses = new List<Address>();

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from Person.Address where AddressId <10 ", _conn);
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
            return addresses;
            
        }

        public Address GetOne(int id)
        {
            List<Address> addresses = new List<Address>();

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * from Person.Address where AddressId=" + id, _conn);
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
            return addresses[0];
        }
        public Address Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }

}

    

