using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;
using Play.Catalog.Service.Entities;
using Play.Catalog.Service.Repositories;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsRepository itemsRepository = new();

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = (await itemsRepository.GetAllItemAsync())
                        .Select(item => item.AsDto())
                        .ToList();
            return items;
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await itemsRepository.GetItemAsync(id);

            // If item is not found, return null or throw an exception
            if (item is null)
            {
                return NotFound(); // or throw an exception
            }
            return item.AsDto();
        }

        //POST /items/create
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ItemDto>> CreateAsync(CreateItemDto itemDto)
        {
            var item = new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow,
                UpdatedDate = DateTimeOffset.UtcNow
            };

            await itemsRepository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }

        //PUT /items/{id}/update
        [HttpPut("{id}")]
        public async Task<ActionResult<ItemDto>> UpdateAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await itemsRepository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }
            // Update the existing item with the new values
            existingItem.Name = itemDto.Name;
            existingItem.Description = itemDto.Description;
            existingItem.Price = itemDto.Price;
            existingItem.UpdatedDate = DateTimeOffset.UtcNow;

            await itemsRepository.UpdateItemAsync(existingItem);

            return NoContent();
        }

        //DELETE /items/{id}/delete
        [HttpDelete("{id}")]
        public async Task <ActionResult> DeleteAsync(Guid id)
        {
            var item = await itemsRepository.GetItemAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            await itemsRepository.DeleteItemAsync(id);
            return NoContent();
        }

    }
}