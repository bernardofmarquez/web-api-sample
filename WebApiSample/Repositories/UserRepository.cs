using MongoDB.Driver;
using WebApiSample.Config;
using WebApiSample.Model;

namespace WebApiSample.Repository {
  public class UserRepository : IUserrepository {
    private readonly IMongoCollection<User> _userRepository;

    public UserRepository() {
        IMongoDatabase database = ConnectionContext.ConnectToMongoDB();
        _userRepository = database.GetCollection<User>("user");
    }

    public void Add(User user) {
      _userRepository.InsertOne(user);
    }

    public User? VerifyUsername(string username) {
      FilterDefinition<User> filter = Builders<User>.Filter.Eq(r => r.username, username);
      User result = _userRepository.Find(filter).FirstOrDefault();
      return result;
    }
  }
}