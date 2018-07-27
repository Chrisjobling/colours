using Colours.Domain.Model;
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
        void UpdatePerson(Person person);
        void UpdateFavoriteColour(int id, int colourId);
        void DeleteCurrentData(Person person);
    }
}
