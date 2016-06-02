using DeadlockSample.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeadlockSample.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PeopleController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPeopleAsync()
        {
            var sampleFilter = "Low Street";
            var result = await _personRepository.GetPersonCountAsync(sampleFilter);
            return Ok(result);
        }
    }
}
