using System.Data;

namespace Colours.Domain.Repository
{
    public interface IDbConnectionFactory
    {
        IDbConnection SqlServeConnection();
    }
}
