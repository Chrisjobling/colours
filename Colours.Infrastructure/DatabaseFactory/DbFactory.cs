using Colours.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Colours.Infrastructure.Repository
{
    public class DbFactory : IDbConnectionFactory
    {
        public SqlConnection SqlServeConnection() { 
                 SqlConnection connection = new SqlConnection("Data Source=ANS-A424\\SQLEXPRESS;Initial Catalog=TechTest;Integrated Security=True");
                return connection;
            
        }
    }
}
