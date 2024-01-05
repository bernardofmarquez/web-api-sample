using WebApiSample.Model;

namespace WebApiSample.Repository {
  public interface IUserRepository {
    void Add(User user);

    User? VerifyUsername(string username);
  }
}