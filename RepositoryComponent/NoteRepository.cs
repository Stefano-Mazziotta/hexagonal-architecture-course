using DomainComponent.Entities;
using DomainComponent.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class NoteRepository : ICommonRepository<Note>
    {
        private readonly ItemsDbContext _context;
        public NoteRepository(ItemsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Note note)
        {
            var model = new NoteModel()
            {
                Id = note.Id,
                ItemId = note.ItemId,
                Message = note.Message,
                CreatedAt = DateTime.Now
            };
            _context.NotesModel.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _context.NotesModel
                .Select(e => new Note(e.Id, e.ItemId, e.Message))
                .ToListAsync();
        }
    }
}
