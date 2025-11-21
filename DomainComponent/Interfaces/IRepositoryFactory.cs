using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainComponent.Interfaces
{
    public interface IRepositoryFactory<TRepository, TExtraData>
    {
        public TRepository Create(TExtraData extraData);
    }
}
 