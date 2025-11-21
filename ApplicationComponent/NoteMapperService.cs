using DomainComponent.Entities;
using DomainComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationComponent
{
    public class NoteMapperService<TDTO, TModel> : IAddService<TDTO, TModel>
    {
        private readonly IAddRepository<TModel> _repository;
        private readonly IMapper<TDTO, Note> _mapperEntity;
        private readonly IMapper<TDTO, TModel> _mapperModel;

        public NoteMapperService(
            IAddRepository<TModel> repository,
            IMapper<TDTO, Note> mapperEntity,
            IMapper<TDTO, TModel> mapperModel
        )
        {
            _repository = repository;
            _mapperEntity = mapperEntity;
            _mapperModel = mapperModel;
        }

        public async Task AddAsync(TDTO dto)
        {
            var note = _mapperEntity.Map(dto);
            var model = _mapperModel.Map(dto);

            if(note.Message.Length < 3)
            {
                throw new ArgumentException("Message is too short");
            }

            await _repository.AddAsync(model);
        }
    }
}
