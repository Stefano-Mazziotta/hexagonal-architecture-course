using DomainComponent.Entities;
using DomainComponent.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class ItemRepository : IRepository, IGetRepository<Item>, ICompleteRepository
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

        public async Task<Item?> GetByIdAsync(int id)
        {
            var model = await _context.ItemsModel.FindAsync(id);
            if (model == null)
            {
                return null;
            }
            return new Item(model.Id, model.Title, model.IsCompleted);
        }

        public async Task CompleteAsync(int id)
        {
            var model = await _context.ItemsModel.FindAsync(id);
            if (model == null)
            {
                throw new KeyNotFoundException($"Item with id {id} not found.");
            }

            model.IsCompleted = true;
            await _context.SaveChangesAsync();
        }
    }
}
