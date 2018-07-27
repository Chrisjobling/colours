using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Colours.Models;
using Colours.Domain.Repository;

namespace Colours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        readonly IPersonRepository personRepo;

        public PersonController(IPersonRepository personRepo)
        {
            this.personRepo = personRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var people = personRepo.GetPeople();
       
            return this.Ok(people);
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public ActionResult<Person> FindById(int id)
        {
            Person person = personRepo.FindById(id);

            if (person == null)
            {
                return NotFound("Person Does Not Exist");
            }
            return this.Ok(person);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Person person)
        {
            Person oldPerson = personRepo.FindById(id);
            if (oldPerson == null)
            {
                return NotFound("Person Does Not Exist");
            }

            person.IsAuthorised = person.IsAuthorised;
            person.IsEnabled = person.IsEnabled;
            person.IsValid = person.IsValid;

            personRepo.UpdatePerson(person);

            var colours = person.FaveColours;
            personRepo.DeleteCurrentData(person);
            foreach (var p in colours)
            {
                personRepo.UpdateFavoriteColour(id, p.ColourId);
            }
          
            return NoContent();
        }
     }

}


