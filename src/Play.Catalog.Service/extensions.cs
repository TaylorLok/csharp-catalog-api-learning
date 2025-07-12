using Microsoft.AspNetCore.StaticAssets;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;

namespace Play.Catalog.Service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new ItemDto(
                item.Id,
                item.Name,
                item.Description,
                item.Price,
                item.CreatedDate,
                item.UpdatedDate
            );
        } 
    }
}