using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLPlanningDetails
    {
        int FirmPlnSp(Guid? SessionId, string VendNum, string UserName, ref string Infobar);

        int PlanningDetailDeleteSp(Guid? SessionID);

        int PlanningDetailSaveSp(Guid? SessionID, string Item, DateTime? DueDate, decimal? QtyReq, decimal? OrigQty, string RefType, string RefNum, int? RefLineSuf, int? RefRelease, int? RefSeq, string OrderType);
    }
}
