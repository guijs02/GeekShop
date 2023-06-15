using Microsoft.AspNetCore.Mvc;
using RESTAspNetCore.Model;
using RESTAspNetCore.Services.Interface;

namespace RESTAspNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personService.GetById(id);

            if (person is null) return NotFound();

            return Ok(person);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.GetAll());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person is null) return BadRequest();

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person is null) return BadRequest();

            return Ok(_personService.Update(person));
        }    

        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] int id)
        {
            var person = _personService.GetById(id);

            if (person is null) return NotFound();

            return NoContent();
        }
    }
}