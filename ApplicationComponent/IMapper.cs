using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationComponent
{
    public interface IMapper<TIn, TOut>
    {
        public TOut Map(TIn data);
    }
}
