using DomainComponent.Entities;
using DomainComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationComponent
{
    public class NoteWithFactoryService<TDTO, TExtraData> : IAddService<TDTO, TExtraData>
    {
        private readonly IRepositoryFactory<IAddRepository<Note>, TExtraData> _repositoryFactory;
        private readonly IMapper<TDTO, Note> _mapperEntity;
        private readonly IMapper<TDTO, TExtraData> _mapperExtraData;

        public NoteWithFactoryService(
            IRepositoryFactory<IAddRepository<Note>, TExtraData> repositoryFactory,
            IMapper<TDTO, Note> mapperEntity,
            IMapper<TDTO, TExtraData> mapperExtraData)
        {
            _repositoryFactory = repositoryFactory;
            _mapperEntity = mapperEntity;
            _mapperExtraData = mapperExtraData;
        }

        public async Task AddAsync(TDTO dto)
        {
            var note = _mapperEntity.Map(dto);
            var extraData = _mapperExtraData.Map(dto);
            var repository = _repositoryFactory.Create(extraData);

            await repository.AddAsync(note);
        }
    }
}
