using AdventureWorksAPI.Models;
using AdventureWorksAPI.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace AdventureWorksAPI.Repository
{
    public class ContactTypeRepository : Repository, IContactTypeRepository
    {
        public ContactTypeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public ContactType Create(ContactType entity)
        {
                SqlCommand cmd = new SqlCommand("INSERT INTO Person.ContactType (Name, ModifiedDate) VALUES (@Name, @CreatedDate)", _conn);
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                _conn.Open();
                cmd.ExecuteNonQuery();
                _conn.Close();
            return entity;
        }

        public ContactType Delete(ContactType entity)
        {
            
                SqlCommand cmd = new SqlCommand("DELETE FROM Person.ContactType WHERE ContactTypeID = @ContactTypeId", _conn);
                cmd.Parameters.AddWithValue("@ContactTypeId", entity.ContactTypeId);
                _conn.Open();
                cmd.ExecuteNonQuery();
                _conn.Close();
                return entity;

              
            
        }

        public IEnumerable<ContactType> GetAll()
        {
            throw new NotImplementedException();
        }

        public ContactType GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public ContactType Update(ContactType entity)
        {

                SqlCommand cmd = new SqlCommand("UPDATE Person.ContactType SET Name = @Name, ModifiedDate = @ModifiedDate WHERE ContactTypeID = @ContactTypeId", _conn);
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@ContactTypeId", entity.ContactTypeId);

                _conn.Open();
                cmd.ExecuteNonQuery();
                _conn.Close();
            return entity;

                
           

        }

     
    }
}
