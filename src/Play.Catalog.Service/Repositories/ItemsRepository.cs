using MongoDB.Driver;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{

    public class ItemsRepository : IItemsRepository
    {
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> dbCollection;

        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;

        //connect to mongo db
        public ItemsRepository(IMongoDatabase database)
        {
            dbCollection = database.GetCollection<Item>(collectionName);
        }

        //Get All
        public async Task<IReadOnlyCollection<Item>> GetAllItemAsync()
        {
            return await dbCollection.
                Find(filterBuilder.Empty)
                .ToListAsync();
        }

        //Get By Id
        public async Task<Item?> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await dbCollection
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        //Create
        public async Task CreateItemAsync(Item item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            await dbCollection.InsertOneAsync(item);
        }

        //Update
        public async Task UpdateItemAsync(Item item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item), "Item cannot be found");
            }
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await dbCollection.ReplaceOneAsync(filter, item);
        }

        //Delete
        public async Task DeleteItemAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id), "Id cannot be empty or not found");
            }
            var filter = filterBuilder.Eq(item => item.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}
