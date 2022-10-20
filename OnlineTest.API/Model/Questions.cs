using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OnlineTest.API.Models
{
    public class Questions
    {
		[BsonId]
		//[System.Text.Json.Serialization.JsonIgnore]
		public int QuestionID { get; set; }
		public string? Question { get; set; }
		public string? ImageName { get; set; }
		public string? Option1 { get; set; }
		public string? Option2 { get; set; }
		public string? Option3 { get; set; }
		public string? Option4 { get; set; }
		public int Answer { get; set; }
	}

}
