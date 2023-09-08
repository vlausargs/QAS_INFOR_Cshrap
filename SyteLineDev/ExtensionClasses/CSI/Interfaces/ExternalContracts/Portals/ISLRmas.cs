using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLRmas
    {
        int CreateRmaRequestSp(string CustNum, string TakenBy, string LineItem, string LineCustItem, decimal? LineQtyToReturnConv, string CoNum, short? CoLine, short? CoRelease, string LineReasonText, string LineOrigInvNum, ref string Infobar);

        int PortalValidateRmaRequestSp(string CustNum, string TakenBy, string LineItem, string LineCustItem, decimal? LineQtyToReturnConv, string CoNum, short? CoLine, short? CoRelease, string LineReasonText, string LineOrigInvNum, ref string Infobar);
    }
}
