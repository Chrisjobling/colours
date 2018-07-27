﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Colours.Domain.Model;
using Colours.Domain.Repository;
using Colours.Infrastructure.Repository;
using Colours.Models;
using Dapper;

namespace Colours.Infrastructure
{
    public class PersonRepository : IPersonRepository
    {
        DbFactory dbFactory = new DbFactory();
        public IEnumerable<Person> GetPeople()
        {
            var lookup = new Dictionary<int, Person>();
            
            using (SqlConnection connection = dbFactory.SqlServeConnection())
            {
                var sql = @"
                SELECT 
               a.[PersonId] as Id
              ,a.[FirstName]
              ,a.[LastName]
              ,a.[IsAuthorised]
              ,a.[IsValid]
              ,a.[IsEnabled]
              ,c.[ColourId]
              ,c.[Name]
              ,c.[IsEnabled]
                  FROM People a 
                 LEFT JOIN FavouriteColours fc 
                    ON ( a.[PersonId] = fc.PersonId )
                 LEFT JOIN Colours c 
                    ON ( fc.ColourId = c.ColourId )
                ";

                Person person;
                var data = connection.Query<Person, Colour, Person>(
                    sql,
                    (p, c) =>
                {
                    // Person ID already exists - grab and append
                    if (!lookup.TryGetValue(p.Id, out person))
                    {
                        lookup.Add(p.Id, person = p);
                    }
                    // Person ID does not exist- add
                    if (person.FaveColours == null)
                    {
                        person.FaveColours = new List<Colour>();
                    }

                    person.FaveColours.Add(c);
                    return person;
                },
                    splitOn: "ColourId"
                )
                .Distinct()
                .ToList();

                return data;
            }
        }

        public Person FindById(int id)
        {
            var lookup = new Dictionary<int, Person>();
            using (SqlConnection connection = dbFactory.SqlServeConnection())
            {
                string sql = @"
         SELECT 
               a.[PersonId] as Id
              ,a.[FirstName]
              ,a.[LastName]
              ,a.[IsAuthorised]
              ,a.[IsValid]
              ,a.[IsEnabled]
              ,c.[ColourId]
              ,c.[Name]
              ,c.[IsEnabled] 
                  FROM People a 
                 LEFT JOIN FavouriteColours fc 
                    ON ( a.[PersonId] = fc.PersonId )
                 LEFT JOIN Colours c 
                    ON ( fc.ColourId = c.ColourId )
                WHERE a.[PersonId] =" + id + "";

                Person person;
                var data = connection.Query<Person, Colour, Person>(
                    sql,
                    (p, c) =>
                {
                    
                    // Person ID already exists - grab and append
                    if (!lookup.TryGetValue(p.Id, out person))
                    {
                        lookup.Add(p.Id, person = p);
                    }
                    // Person ID does not exist- add
                    if (person.FaveColours == null)
                    {
                        person.FaveColours = new List<Colour>();
                    }

                    person.FaveColours.Add(c);
                    return person;
                },
                    splitOn: "ColourId"
                )
                .Distinct();

                try
                {
                    return data.First();
                }
                catch (InvalidOperationException e)
                { 
                    return null;
                }

            }
        }

        public void Update(Person person)
        {


            using (SqlConnection connection = dbFactory.SqlServeConnection())
            {
                string updateQuery = @"
                UPDATE [dbo].[People] SET 
                IsAuthorised = @IsAuthorised, 
                IsEnabled = @IsEnabled, 
                IsValid = @IsValid WHERE PersonId = @Id";
                var result = connection.Execute(updateQuery, new
                {
                    person.IsEnabled,
                    person.IsValid,
                    person.IsAuthorised,
                    person.Id

                });
            }
        }
      
    }
}



