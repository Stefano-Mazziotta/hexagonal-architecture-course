using DomainComponent.Entities;
using DomainComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationComponent
{
    public class CompleteItemService : ICompleteService
    {
        private readonly ICompleteRepository _completeRepository;
        private readonly IGetRepository<Item> _getRepository;

        public CompleteItemService(
            ICompleteRepository completeRepository,
            IGetRepository<Item> getRepository)
        {
            _completeRepository = completeRepository;
            _getRepository = getRepository;
        }

        public async Task Complete(int id)
        {
            var item = await _getRepository.GetByIdAsync(id);
            
            if (item == null)
            {
                throw new ArgumentException("Item not found");
            }

            await _completeRepository.CompleteAsync(id);

        }
    }
}
