using ApplicationComponent.DTOs;
using DomainComponent.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryComponent
{
    public class NoteDTORepository : ICommonRepository<NoteDTO>
    {
        private readonly ItemsDbContext _context;

        public NoteDTORepository(ItemsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(NoteDTO dto)
        {
            var model = new NoteModel
            {
                ItemId = dto.ItemId,
                Message = dto.Message,
                Color = dto.Color,
                CreatedAt = DateTime.UtcNow
            };

            _context.NotesModel.Add(model);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<NoteDTO>> GetAllAsync()
        {
            return await _context.NotesModel
                .Select(n => new NoteDTO
                {
                    Id = n.Id,
                    ItemId = n.ItemId,
                    Message = n.Message,
                    Color = n.Color,
                }).ToListAsync();
        }
    }
}
