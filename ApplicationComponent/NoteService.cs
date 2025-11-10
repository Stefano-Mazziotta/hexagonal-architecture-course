using DomainComponent.Entities;
using DomainComponent.Interfaces;

namespace ApplicationComponent
{
    public class NoteService : ICommonService<Note>
    {
        private readonly ICommonRepository<Note> _repository;

        public NoteService(ICommonRepository<Note> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Note note)
        {
            await _repository.AddAsync(note);
        }

        public async Task<IEnumerable<Note>> GetAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
