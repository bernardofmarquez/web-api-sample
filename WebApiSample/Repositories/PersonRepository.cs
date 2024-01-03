using MongoDB.Driver;
using WebApiSample.Config;
using WebApiSample.Model;

namespace WebApiSample.Repository {
  public class PersonRepository {
    private readonly IMongoCollection<Person> _personCollection;

    public PersonRepository() {
        IMongoDatabase database = ConnectionContext.ConnectToMongoDB();
        _personCollection = database.GetCollection<Person>("person");
    }
    public async void Add(Person person) {
      try {
        await _personCollection.InsertOneAsync(person);
      } catch (Exception ex) {
        throw new Exception("Ocorreu um erro ao inserir a pessoa.", ex);
      }
    }

    async List<Person> Get(){
      try {
        FilterDefinition<Person> filter = Builders<Person>.Filter.Empty;
        await _personCollection.FindAsync(filter);

      }
    }
  }
}