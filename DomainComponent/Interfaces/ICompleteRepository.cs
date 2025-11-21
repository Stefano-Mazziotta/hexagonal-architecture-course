using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainComponent.Interfaces
{
    public interface ICompleteRepository
    {
        public Task CompleteAsync(int id);
    }
}
