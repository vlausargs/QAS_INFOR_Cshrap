
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLWcs
    {

        int WcItemValidSp(ref string Item,
                string Whse,
                ref string TItemDesc,
                ref byte? TSerTracked,
                ref byte? TLotTracked,
                ref string TLoc,
                ref string TLot,
                ref string TUM,
                ref double? UomConvFactor,
                ref byte? NonInvItem,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar,
                ref decimal? MatlCost,
                ref decimal? LbrCost,
                ref decimal? FovhdCost,
                ref decimal? VovhdCost,
                ref decimal? OutCost,
                ref byte? TrackPieces,
                ref string DimensionGroup,
                ref string TrxRestrictCode); 

        int WcmatlQtyValidSp(decimal? NewQty,
                string PItem,
                string UM,
                double? UomConvFactor,
                ref decimal? TQty,
                ref string Infobar); 

        int WcUMValidSp(string PItem,
                decimal? PMatlQty,
                ref string PUM,
                ref double? UomConvFactor,
                ref decimal? TQty,
                ref string Infobar); 

    }
}
    
