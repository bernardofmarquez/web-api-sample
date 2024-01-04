using MongoDB.Driver;
using WebApiSample.Config;
using WebApiSample.Model;

namespace WebApiSample.Repository {
  public class PersonRepository : IPersonrepository {
    private readonly IMongoCollection<Person> _personCollection;

    public PersonRepository() {
        IMongoDatabase database = ConnectionContext.ConnectToMongoDB();
        _personCollection = database.GetCollection<Person>("person");
    }
    public void Add(Person person) {
        _personCollection.InsertOne(person);
    }

    public List<Person> Get(){
      FilterDefinition<Person> filter = Builders<Person>.Filter.Empty;
      List<Person> result = _personCollection.Find(filter).ToList();
      return result;
    }
  }
}