using DomainComponent.Entities;
using DomainComponent.Interfaces;
using RepositoryComponent.ExtraData;
using RepositoryComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryComponent
{
    internal class NoteFactoriedRepository : IAddRepository<Note>
    {
        private NoteExtraData _extraData;
        private readonly ItemsDbContext _context;

        public NoteFactoriedRepository(ItemsDbContext context, NoteExtraData extraData)
        {
            _context = context;
            _extraData = extraData;
        }

        public async Task AddAsync(Note note)
        {
            var model = new NoteModel()
            {
                ItemId = note.ItemId,
                Message = note.Message,
                CreatedAt = DateTime.Now,
                Color = _extraData.Color
            };

            _context.NotesModel.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
