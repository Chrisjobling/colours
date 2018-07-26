using Colours.Domain.Model;
using Colours.Domain.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Colours.Infrastructure.Repository
{
    public class ColourRepository : IColourRepository
    {
        public IEnumerable<Colour> GetColours()
        {
            string sql = @"SELECT [ColourId] as id,[Name],[IsEnabled] FROM Colours";
            using (SqlConnection connection = new SqlConnection("Data Source=ANS-A424\\SQLEXPRESS;Initial Catalog=TechTest;Integrated Security=True"))
            {
                var allColours = connection.Query<Colour>(sql); ;




                return allColours;
            }
        }
    

    public IEnumerable<Colour> FaveColours()
    {

        var sql = "SELECT P.PersonId as id ,A.[Name] ,A.[IsEnabled]," +
            "A.ColourId AS ColourId  " +
            "FROM FavouriteColours P INNER JOIN Colours A ON A.ColourId = P.ColourId; ";

        using (SqlConnection connection = new SqlConnection("Data Source=ANS-A424\\SQLEXPRESS;Initial Catalog=TechTest;Integrated Security=True"))
        {
            var allColours = connection.Query<Colour>(sql); 
            return allColours;
        }
    }
    }   
 }
