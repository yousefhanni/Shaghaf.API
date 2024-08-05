using Shaghaf.Core.Entities.Cart_Entities;
using Shaghaf.Core.Repositories.Contract;
using StackExchange.Redis;
using System.Text.Json;

namespace Shaghaf.Infrastructure.Repositories.Implementation
{
    // Performs CRUD operations (Create, Get, Update, Delete) on the underlying data storage
    public class CartRepository : ICartRepository
    {
        private readonly IDatabase _database;

        // Constructor: Initializes the Redis database connection
        public CartRepository(IConnectionMultiplexer redisConnection)
        {
            _database = redisConnection.GetDatabase(); // Gets the Redis database
        }

        // Retrieves a customer Cart from a Redis database based on the provided Cart ID
        public async Task<CustomerCart?> GetCartAsync(string cartId)
        {
            var cart = await _database.StringGetAsync(cartId); // Fetches the Cart from Redis
            return cart.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerCart>(cart); // Deserializes the JSON to CustomerCart object if not empty
        }

        // Updates or creates a customer Cart in a Redis database
        public async Task<CustomerCart?> UpdateCartAsync(CustomerCart cart)
        {
            var createdOrUpdated = await _database.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(30)); // Sets the Cart in Redis with a 30-day expiration
            if (!createdOrUpdated) return null; // Returns null if update/create fails

            return await GetCartAsync(cart.Id); // Retrieves the updated/created Cart
        }

        // Deletes a customer Cart from a Redis database based on the provided Cart ID
        public async Task<bool> DeleteCartAsync(string cartId)
        {
            return await _database.KeyDeleteAsync(cartId); // Deletes the Cart from Redis
        }
    }
}
