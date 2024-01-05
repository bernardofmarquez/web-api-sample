using BCrypt.Net;
using WebApiSample.Model;
using WebApiSample;
using WebApiSample.Repository;
using WebApiSample.ViewModel;

namespace WebApiSample.Service {
  public class AuthService : IAuthService {

    private readonly UserRepository _userRepository;

    public AuthService(UserRepository userRepository) {
      _userRepository = userRepository ?? throw new ArgumentNullException();
    }
    public User AuthenticateUser(UserView userView) {
      User? user = _userRepository.VerifyUsername(userView.username);
      if (user == null) {
        throw new UserDoesNotExist("There is no user with this name.");
      }
      
      bool validPassword = BCrypt.Net.BCrypt.Verify(userView.password, user.password);
      if (!validPassword) {
        throw new IncorrectPassword("Incorrect password.");
      }

      return user;
    }

    public void RegisterUser(UserView userView) {
      User? userExists = _userRepository.VerifyUsername(userView.username);
      if(userExists is User) {
        throw new UserAlreadyExists("User with this name already exists.");
      }

      string hashPassword = BCrypt.Net.BCrypt.HashPassword(userView.password);

      User userHash = new User(userView.username, hashPassword);

      _userRepository.Add(userHash);
    }
  }
}