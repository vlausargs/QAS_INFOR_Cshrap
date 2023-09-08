
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLRsvdInvs
    {

        int CoResValidateQtySp(string PItem,
                decimal? PQtyRsvd,
                [Optional, DefaultParameterValue(0)] decimal? PQtyRsvdOld,
                ref string PUM,
                string PCoNum,
                int? PLotTracked,
                string PCurWhse,
                string PLot,
                string PLoc,
                ref string Infobar,
                string PImportDocId,
                int? PTaxFreeMatl); 

        int GetCoItemDetailSp(string CoNum,
                short? CoLine,
                short? CoRelease,
                ref string CoCustNum,
                ref string CoCustName,
                ref string CoItem,
                ref string CoItemDesc,
                ref string CoStat,
                ref DateTime? CoDueDate,
                ref decimal? CoQtyOrderedConv,
                ref string CoUM,
                ref decimal? CoQtyResv,
                ref byte? CoLotTracked,
                ref byte? CoSNTracked,
                ref string CoWhse,
                ref string CoItemUM,
                ref byte? CoItemReservable,
                ref string Infobar,
                ref byte? CoTaxFreeMatl); 

        int ResforOrderUpdateSp(string PCmd,
                ref decimal? RsvdNum,
                string Item,
                string Whse,
                string RefNum,
                short? RefLine,
                short? RefRelease,
                string CustNum,
                string Loc,
                string Lot,
                decimal? Qty,
                string UM,
                Guid? SessionID,
                ref string Infobar,
                string ImportDocId); 

        int ValidateCoReservationSp(decimal? RsvdNum,
                string CoNum,
                short? CoLine,
                short? CoRelease,
                string CoItem,
                string CoWhse,
                string CoLoc,
                byte? CoLotTracked,
                string CoLot,
                decimal? CoQty,
                string CoUM,
                string CoCustNum,
                ref string Infobar,
                string ImportDocId,
                byte? TaxFreeMatl); 

        int ValidateCoRsvdQtySp(string PCoNum,
                int? PCoLine,
                int? PCoRelease,
                decimal? PQtyRsvd,
                decimal? PQtyRsvdOld,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar); 

    }
}
    
