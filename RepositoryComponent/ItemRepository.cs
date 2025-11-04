using DomainComponent.Entities;
using DomainComponent.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class ItemRepository : IRepository
    {
        private readonly ItemsDbContext _context;

        public ItemRepository(ItemsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item item)
        {
            var model = new ItemModel()
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted,
                CreatedAt = DateTime.Now
            };

            _context.ItemsModel.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.ItemsModel
                .Select(e => new Item(e.Id, e.Title, e.IsCompleted))
                .ToListAsync();
        }
    }
}
