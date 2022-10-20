using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlineTest.API;
using OnlineTest.API.Model;

namespace OnlineTestWithMongoDB.API.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService(
            IOptions<DataBaseSettings> dabaseSettings)
        {
            var mongoClient = new MongoClient(dabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dabaseSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>("User");
        }

        public async Task<List<User>> GetAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<User?> GetAsync(string id) =>
            await _userCollection.Find(x => x.UserId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User newuser) =>
            await _userCollection.InsertOneAsync(newuser);

        public async Task UpdateAsync(string id, User updateduser) =>
            await _userCollection.ReplaceOneAsync(x => x.UserId == id, updateduser);

        public async Task RemoveAsync(string id) => await _userCollection.DeleteOneAsync(x => x.UserId == id);
    }
}
