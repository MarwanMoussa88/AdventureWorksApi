using Microsoft.Data.SqlClient;

namespace AdventureWorksAPI.Repository
{
    public class Repository
    {
        private readonly IConfiguration _configuration;
        protected readonly SqlConnection _conn;
        public Repository(IConfiguration configuration) 
        {
            _configuration = configuration;
            _conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

    }
}
