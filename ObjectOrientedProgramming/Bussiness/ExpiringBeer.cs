using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgramming.Bussiness
{
    internal class ExpiringBeer : Beer
    {
        DateTime expirationDate;

        public ExpiringBeer(string name, string type, double alcoholContent, DateTime expirationDate)
            : base(name, type, alcoholContent, 0)
        {
            this.expirationDate = expirationDate;
        }

        public override string GetName()
        {
            return base.GetName() + " " + "override!!!";
        }
        
    }
}
