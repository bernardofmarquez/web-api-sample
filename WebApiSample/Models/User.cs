using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiSample.Model {
  public class User {
    [Key]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }
    public string username { get; set; }
    public string password { get; set; }

    public User(string username, string password) {
      this.username = username ?? throw new ArgumentNullException(nameof(username));
      this.password = password;
    }
  }
}