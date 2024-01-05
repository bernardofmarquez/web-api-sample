using BCrypt.Net;
using WebApiSample.Model;
using WebApiSample;
using WebApiSample.Repository;
using WebApiSample.ViewModel;

namespace WebApiSample.Service {
  public class AuthService {

    private readonly UserRepository _userRepository;

    public AuthService(UserRepository userRepository) {
      _userRepository = userRepository ?? throw new ArgumentNullException();
    }
    public User AuthenticateUser(UserView userView) {
      User? user = _userRepository.VerifyUsername(userView.username);
      if (user == null) {
        throw new UserDoesNotExist("Não existe usuário com esse nome.");
      }
      
      bool validPassword = BCrypt.Net.BCrypt.Verify(userView.password, user.password);
      if (!validPassword) {
        throw new IncorrectPassword("Senha incorreta.");
      }

      return user;
    }
  }
}