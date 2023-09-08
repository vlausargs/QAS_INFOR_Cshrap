using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLPortalProducts_H_Views
    {
        int PortalProductsCriteriaSaveSp(Guid? SessionID, string Criteria, string CriterionTypes, string ResellerCustNum, string CustNum);
    }
}
