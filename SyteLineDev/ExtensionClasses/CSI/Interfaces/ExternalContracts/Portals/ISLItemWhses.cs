using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLItemWhses
    {
        int GetVendConsignmentUsageByItemSp(string pVendNum, string pItem, DateTime? pStartDate, DateTime? pEndDate, ref decimal? BeginBalance, ref decimal? Received, ref decimal? Consumed, ref decimal? EndBalance, ref string Infobar);
    }
}
