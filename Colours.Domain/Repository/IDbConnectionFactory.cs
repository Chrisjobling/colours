using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Colours.Domain.Repository
{
   public interface IDbConnectionFactory
    {
        SqlConnection SqlServeConnection();
    }
}
