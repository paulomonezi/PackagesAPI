using Microsoft.AspNetCore.Mvc;
using PackagesAPI.Entities;
using PackagesAPI.Models;
using PackagesAPI.Persistence;

namespace PackagesAPI.Controllers
{
    [ApiController]
    [Route("api/packages")]
    public class PackagesController : ControllerBase
    {
        private readonly DataContext _context;
        public PackagesController(DataContext context)
        {
            _context = context;
        }

        // GET api/packages
        [HttpGet]
        public IActionResult GetAll()
        {
            var packages = _context.Packages;

            return Ok(packages);
        }

        // GET api/packages/"code (guid)"
        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            var package = _context
                .Packages
                .SingleOrDefault(p => p.Code == code);

            if (package == null)
            {
                return NotFound();
            }

            return Ok();
        }

        //POST api/packages
        [HttpPost]
        public IActionResult Post(AddPackageInputModel model)
        {
            if (model.Title.Length < 10)
            {
                return BadRequest("Title lenght must have at least 10 characters.");
            }

            var package = new Package(model.Title, model.Weight);
            _context.Packages.Add(package);

            return CreatedAtAction("GetByCode",
                new { code = package.Code },
                package);
        }

        [HttpPost("{code}/updates")]
        public IActionResult PostUpdate(string code, AddPackageUpdateInputModel model)
        {
            var package = _context
                 .Packages
                 .SingleOrDefault(p => p.Code == code);

            if (package == null)
            {
                return NotFound();
            }

            package.AddUpdate(model.Status, model.Delivered);

            return NoContent();
        }
    }
}
