using ApplicationComponent.DTOs;
using DomainComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationComponent
{
    public class NoteDTOService : ICommonService<NoteDTO>
    {
        private readonly ICommonRepository<NoteDTO> _repository;

        public NoteDTOService(ICommonRepository<NoteDTO> repository)
        {
            _repository = repository;
        }

        public Task AddAsync(NoteDTO dto)
        {
            return _repository.AddAsync(dto);
        }

        public Task<IEnumerable<NoteDTO>> GetAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
