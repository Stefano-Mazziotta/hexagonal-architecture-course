using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationComponent
{
    public interface IAddService<TDTO, TModel>
    {
        Task AddAsync(TDTO dto);
    }
}
