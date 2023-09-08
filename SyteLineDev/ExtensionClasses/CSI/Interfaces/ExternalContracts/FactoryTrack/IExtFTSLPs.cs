
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLPs
    {

        int PsItemValidSp(ref string Item,
                string Whse,
                ref string TItemDesc,
                ref int? TSerTracked,
                ref int? TLotTracked,
                ref string TLotPrefix,
                ref string TLoc,
                ref string TLot,
                ref string TUM,
                ref decimal? UomConvFactor,
                ref string PromptMsg,
                ref string PromptButtons,
                ref string Infobar,
                [Optional, DefaultParameterValue(0)] ref int? EnableContainer); 

        int PsQtyValidSp(decimal? Qty,
                string PItem,
                [Optional, DefaultParameterValue((byte)0)] byte? CmplFlag,
                [Optional, DefaultParameterValue((byte)0)] byte? ScrpFlag,
                ref string Infobar); 

        int PSVal10Sp(string PSItem,
                [Optional, DefaultParameterValue((byte)0)] byte? Cmpl,
                ref string PSNum,
                ref string UM,
                ref byte? LotTracked,
                ref byte? SerTracked,
                ref string Whse,
                ref string Wc,
                ref int? OperNum,
                ref string PSItemJob,
                ref short? PSItemSuffix,
                ref string Infobar); 

        int PSVal3Sp(string PSNum,
                string PSItem,
                [Optional, DefaultParameterValue((byte)0)] byte? Cmpl,
                ref string Whse,
                ref string Wc,
                ref int? OperNum,
                ref string PSItemJob,
                ref short? PSItemSuffix,
                ref string Infobar); 

        int PSVal4Sp(string PSNum,
                string PSItem,
                string Wc,
                [Optional, DefaultParameterValue((byte)0)] byte? Cmpl,
                ref int? OperNum,
                ref string Infobar); 

        int PSVal5Sp(string PSNum,
                string PSItem,
                int? OperNum,
                [Optional, DefaultParameterValue((byte)0)] byte? Cmpl,
                ref string Wc,
                ref string Infobar,
                [Optional] ref byte? IsLastOper,
                [Optional, DefaultParameterValue((byte)0)] byte? ValidateCycle,
                [Optional] DateTime? TransDate,
                [Optional] ref string Prompt,
                [Optional] ref string PromptButtons); 

    }
}
    
