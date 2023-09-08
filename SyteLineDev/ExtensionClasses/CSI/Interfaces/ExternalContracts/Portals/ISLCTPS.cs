using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLCtps
    {
        long PortalGetCTP(string sSiteID, string sItemID, double dQuantity, DateTime datDueDate, ref DateTime datProjectedDate, ref string Infobar);
    }
}
