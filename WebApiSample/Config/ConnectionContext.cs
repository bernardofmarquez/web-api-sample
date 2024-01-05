using MongoDB.Driver;
using MongoDB.Bson;
using DotNetEnv;

namespace WebApiSample.Config
{
  public class ConnectionContext 
  { 
    public static IMongoDatabase ConnectToMongoDB()
    {
        Env.Load();
        var connectionString = Env.GetString("MONGO_URI");
        MongoClient client = new MongoClient(connectionString);
        IMongoDatabase database = client.GetDatabase("web-api-sample");
        return database;
    }
  }
}