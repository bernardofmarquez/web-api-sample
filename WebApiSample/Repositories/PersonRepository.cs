using WebApiSample.Model;

namespace WebApiSample.Repository {
  public interface IPersonRepository {
    void add(Person person);

    List<Person> get();
  }
}