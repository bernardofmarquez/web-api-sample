using MongoDB.Driver;
using MongoDB.Bson;

namespace WebApiSample.Config
{
  public class ConnectionContext 
  { 
    public static IMongoDatabase ConnectToMongoDB()
    {
        DotNetEnv.Env.Load();
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
        MongoClient client = new MongoClient(connectionString);
        IMongoDatabase database = client.GetDatabase("web-api-sample");
        return database;
    }
  }
}