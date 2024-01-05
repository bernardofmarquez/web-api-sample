using WebApiSample.Model;

namespace WebApiSample.Repository {
  public interface IUserrepository {
    void Add(User user);

    User? VerifyUsername(string username);
  }
}