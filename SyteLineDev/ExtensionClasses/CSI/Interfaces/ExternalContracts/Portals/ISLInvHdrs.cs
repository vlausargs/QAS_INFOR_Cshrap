using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLInvHdrs
    {
        int ReprintInvoiceSp(string InvNum,
                                    string BillType,
                                    string UserName1,
                                    string LangCode);
    }
}
