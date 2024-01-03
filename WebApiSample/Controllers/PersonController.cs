using Microsoft.AspNetCore.Mvc;
using WebApiSample.Model;
using WebApiSample.Repository;

namespace WebApiSample.Controller {
  [ApiController]
  [Route("api/v1/person")]

  public class PersonController : ControllerBase {
    private readonly PersonRepository _personRepository;

    public PersonController(PersonRepository personRepository) {
      _personRepository = personRepository ?? throw new ArgumentNullException();
    }
    
    [HttpPost]
    public IActionResult Add(string name, int age) {

      Person person = new Person(name, age);

      _personRepository.Add(person);

      return Ok(person);
    }

    [HttpGet]

    public IActionResult Get() {
      List<Person> response = _personRepository.Get();
      
      return Ok(response);
    }
  }
}