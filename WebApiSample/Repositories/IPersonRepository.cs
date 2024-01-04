using WebApiSample.Model;

namespace WebApiSample.Repository {
  public interface IPersonrepository {
    void Add(Person person);

    List<Person> Get();
  }
}