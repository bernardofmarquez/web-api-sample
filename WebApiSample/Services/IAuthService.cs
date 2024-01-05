using WebApiSample.Model;
using WebApiSample.ViewModel;

namespace WebApiSample.Service {
  public interface IAuthService {
    public User AuthenticateUser(UserView userView);

    public void RegisterUser(UserView userView);
  }
}