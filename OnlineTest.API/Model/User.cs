using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineTest.API.Model
{
    public class User
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Designation { get; set; } = null!;

        public string Company { get; set; } = null!;

    }
}
