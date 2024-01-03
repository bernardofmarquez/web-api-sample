using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiSample.Model {
  public class Person {
    [Key]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }
    public string name { get; set; }
    public int age { get; set; }

    public Person(string name, int age) {
      this.name = name ?? throw new ArgumentNullException(nameof(name));
      this.age = age;
    }
  }
}