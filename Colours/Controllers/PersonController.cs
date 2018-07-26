using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Dapper;
using Colours.Models;
using Colours.Infrastructure;
using Colours.Domain.Repository;
using Colours.Domain.Model;

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
                return NotFound();
            }
            return this.Ok(person);
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Person person)
        {
            Person oldPerson = personRepo.FindById(id);
            if (oldPerson == null)
            {
                return NotFound();
            }

            person.IsAuthorised = person.IsAuthorised;
            person.IsEnabled = person.IsEnabled;
            person.IsValid = person.IsValid;

            personRepo.Update(person);
          
            return NoContent();
        }
     }

}


