using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.CreditCard
{
    public interface ICreditCardUtilFactory
    {
        ICreditCardUtil Create(IApplicationDB appDB);
    }
}
