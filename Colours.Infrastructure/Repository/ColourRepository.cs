using Colours.Domain.Model;
using Colours.Domain.Repository;
using Dapper;
using System.Collections.Generic;

namespace Colours.Infrastructure.Repository
{
    public class ColourRepository : IColourRepository
    {
        public ColourRepository(IDbConnectionFactory dbFactory)
        {
            this.DbFactory = dbFactory;
        }

        private IDbConnectionFactory DbFactory { get; }

        public IEnumerable<Colour> GetColours()
        {
            string sql = @"SELECT [ColourId],[Name],[IsEnabled] FROM Colours";
            using (var connection = DbFactory.SqlServeConnection())
            {
                var allColours = connection.Query<Colour>(sql); ;
                return allColours;
            }
        }

        public void Update(Colour colour)
        {
            using (var connection = DbFactory.SqlServeConnection())
            {
                string updateQuery = @"
                UPDATE [dbo].[Colours] SET 
                IsEnabled = @IsEnabled 
                WHERE ColourId = @ColourId";
                var result = connection.Execute(updateQuery, new
                {
                    colour.IsEnabled,
                    colour.ColourId
                });
            }
        }

        public IEnumerable<Colour> FaveColours()
    {

        var sql = "SELECT P.PersonId as id ,A.[Name] ,A.[IsEnabled]," +
            "A.ColourId AS ColourId  " +
            "FROM FavouriteColours P " +
            "INNER JOIN Colours A ON A.ColourId = P.ColourId; ";

        using (var connection = DbFactory.SqlServeConnection())
        {
            var allColours = connection.Query<Colour>(sql); 
            return allColours;
        }
    }

        public Colour FindById(int id)
        {
         string sql = @"SELECT [ColourId],[Name],[IsEnabled] 
                        FROM Colours  WHERE ColourId = @Id";
          using (var connection = DbFactory.SqlServeConnection())
          {
                var colour = connection.QuerySingle<Colour>(sql, new
                    {
                        id
                    });
                return colour;
              }
          }
    }   
 }
