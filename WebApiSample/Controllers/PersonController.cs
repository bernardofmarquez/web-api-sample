using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiSample.Model;
using WebApiSample.Repository;
using WebApiSample.ViewModel;

namespace WebApiSample.Controller {
  [ApiController]
  [Route("api/v1/person")]

  public class PersonController : ControllerBase {
    private readonly PersonRepository _personRepository;

    public PersonController(PersonRepository personRepository) {
      _personRepository = personRepository ?? throw new ArgumentNullException();
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult Add(PersonView personView) {

      Person person = new Person(personView.name, personView.age);

      _personRepository.Add(person);

      return Ok(person);
    }

    [Authorize]
    [HttpGet]

    public IActionResult Get() {
      List<Person> response = _personRepository.Get();
      
      return Ok(response);
    }
  }
}