using Colours.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Colours.Domain.Repository
{
    public interface IPersonRepository
    {
      
       IEnumerable<Person> GetPeople();
       Person FindById(int id);
        void Update(Person person);
    }
}
