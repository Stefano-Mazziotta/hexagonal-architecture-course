using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports.Primary
{
    public interface IService
    {
        void Register(string name, decimal price);
        IEnumerable<Product> GetAll();
    }
}
