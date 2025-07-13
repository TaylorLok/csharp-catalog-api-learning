using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service.Repositories
{
    public interface IItemsRepository
    {
        Task CreateItemAsync(Item item);
        Task DeleteItemAsync(Guid id);
        Task<IReadOnlyCollection<Item>> GetAllItemAsync();
        Task<Item?> GetItemAsync(Guid id);
        Task UpdateItemAsync(Item item);
    }
}
