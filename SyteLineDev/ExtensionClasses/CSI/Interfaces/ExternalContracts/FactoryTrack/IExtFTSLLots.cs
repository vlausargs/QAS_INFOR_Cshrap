
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLLots
    {

        int BflushLotSaveSp(decimal? TransNum,
                string Whse,
                string Lot,
                byte? Selected,
                string Job,
                short? Suffix,
                int? OperNum,
                short? Sequence,
                string EmpNum,
                string JobMatlItem,
                string Loc,
                decimal? QtyNeeded,
                decimal? QtyRequired,
                string JobRouteWc,
                string UM,
                string TransClass,
                [Optional] int? TransSeq,
                ref string Infobar,
                [Optional] Guid? SessionId); 

        int LotAddSp(string Item,
                string Lot,
                decimal? RcvdQty,
                [Optional, DefaultParameterValue(0)] int? FromPO,
                [Optional] string VendLot,
                [Optional, DefaultParameterValue(1)] int? CreateNonUnique,
                [Optional] string Revision,
                ref string Infobar,
                [Optional] string Site,
                [Optional] DateTime? ManufacturedDate,
                [Optional] DateTime? ExpirationDate,
                [Optional] string LotTrxRestrictCode); 

        int LotValidSp(string Whse,
                string Item,
                string Lot,
                ref string Infobar); 

    }
}
    
