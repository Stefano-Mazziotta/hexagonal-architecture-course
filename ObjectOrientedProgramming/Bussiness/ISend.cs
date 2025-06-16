using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming.Bussiness
{
    public interface ISend
    {
        public void Send(string destinationAddress, string messageContent);
    }
}
