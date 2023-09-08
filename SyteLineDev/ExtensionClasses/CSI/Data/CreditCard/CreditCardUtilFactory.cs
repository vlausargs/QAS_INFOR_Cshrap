using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CreditCard
{
    public class CreditCardUtilFactory : ICreditCardUtilFactory
    {
        public ICreditCardUtil Create(IApplicationDB appDB)
        {
            return new CreditCardUtil(appDB);
        }
    }
}
