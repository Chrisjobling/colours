using Colours.Domain.Repository;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Colours.Infrastructure.Repository
{
    public class DbFactory : IDbConnectionFactory
    {
       private IConfiguration Configuration { get; }

        public DbFactory(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IDbConnection SqlServeConnection()
        {
            return new SqlConnection(this.Configuration.GetConnectionString("TechTest"));
        }
    }
}
