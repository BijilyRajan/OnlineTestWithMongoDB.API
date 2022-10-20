using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineTest.API;
using OnlineTest.API.Models;

namespace OnlineTestWithMongoDB.API.Service
{
    public class QuestionService
    {
        private readonly IMongoCollection<Questions> _questionCollection;


        public QuestionService(
            IOptions<DataBaseSettings> dabaseSettings)
        {
            var mongoClient = new MongoClient(dabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dabaseSettings.Value.DatabaseName);

            _questionCollection = mongoDatabase.GetCollection<Questions>("Questions");
        }

        public async Task<List<Questions>> GetAsync() =>
      await _questionCollection.Find(_ => true).ToListAsync();

        public async Task<Questions?> GetAsync(int id) =>
            await _questionCollection.Find(x => x.QuestionID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Questions newuser) =>
            await _questionCollection.InsertOneAsync(newuser);

        public async Task UpdateAsync(int id, Questions updateduser) =>
            await _questionCollection.ReplaceOneAsync(x => x.QuestionID == id, updateduser);

        public async Task RemoveAsync(int id) => await _questionCollection.DeleteOneAsync(x => x.QuestionID == id);


    }
}
