using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Colours.Models;
using Colours.Domain.Repository;
using Colours.Domain.Model;

namespace Colours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        readonly IColourRepository colourRepo;

        public ColourController(IColourRepository colourRepo)
        {
            this.colourRepo = colourRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var colours = colourRepo.GetColours();
            return this.Ok(colours);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Colour colour)
        {
            Colour oldColour = colourRepo.FindById(id);
            if (oldColour == null)
            {
                return NotFound("Colour Not Found");
            }
            
            oldColour.IsEnabled = colour.IsEnabled;
            colourRepo.Update(oldColour);
            
            return NoContent();
        }

    }
       

}
