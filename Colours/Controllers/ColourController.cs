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

    }
}