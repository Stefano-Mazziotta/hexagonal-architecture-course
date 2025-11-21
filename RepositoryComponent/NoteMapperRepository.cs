using DomainComponent.Interfaces;
using RepositoryComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryComponent
{
    public class NoteMapperRepository : IAddRepository<NoteModel>
    {
        private readonly ItemsDbContext _context;
        public NoteMapperRepository(ItemsDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(NoteModel model)
        {
            _context.NotesModel.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}
