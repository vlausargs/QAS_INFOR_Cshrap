
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLMSMoves
    {

        int MsmpSetVarsSp(string SET,
                string PType,
                DateTime? PDate,
                decimal? PQty,
                string PItem,
                string PFromSite,
                string PFromWhse,
                string PFromLoc,
                string PFromLot,
                string PToSite,
                string PToWhse,
                string PToLoc,
                string PToLot,
                byte? PZeroCost,
                string PTrnNum,
                short? PTrnLine,
                decimal? PTransNum,
                decimal? PRsvdNum,
                string PStat,
                string PRefNum,
                short? PRefLineSuf,
                short? PRefRelease,
                [Optional] string RemoteSiteLot,
                [Optional] string PReasonCode,
                ref decimal? PUnitCost,
                ref decimal? PMatlCost,
                ref decimal? PLbrCost,
                ref decimal? PFovhdCost,
                ref decimal? PVovhdCost,
                ref decimal? POutCost,
                ref decimal? PTotCost,
                ref string Infobar,
                string PImportDocId,
                [Optional, DefaultParameterValue((byte)0)] byte? MoveZeroCostItem,
                [Optional] string EmpNum,
                [Optional, DefaultParameterValue(0)] int? CheckExternalWhseFlag,
                [Optional] string DocumentNum); 

        int RloclotSp(string Site,
                string Item,
                string Whse,
                string Loc,
                string RefNum,
                short? RefLine,
                short? RefRelease,
                string RefType,
                byte? LotTracked,
                ref string Lot,
                ref string Infobar,
                [Optional] string Acct); 

        int ValidateSiteMoveSp(string FromSite,
                string ToSite,
                ref string Infobar); 

    }
}
    
