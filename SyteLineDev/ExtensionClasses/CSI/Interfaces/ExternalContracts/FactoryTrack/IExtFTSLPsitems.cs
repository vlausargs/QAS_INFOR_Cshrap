
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTSLPsitems
    {

        int PSCmplTransGetVarsSp(ref decimal? JobtranTransNum,
                ref byte? TCoby,
                ref string Infobar,
                [Optional] ref string PromptMsg,
                [Optional] ref string PromptButtons); 

        int PSCmplTransSetVarsSp(string SET,
                string Item,
                decimal? Qty,
                DateTime? TransDate,
                string PsNum,
                string Employee,
                int? OperNum,
                string Wc,
                string Shift,
                string Loc,
                string Lot,
                string SerialPrefix,
                Guid? SessionID,
                ref decimal? JobtranTransNum,
                ref byte? TCoby,
                ref string Infobar,
                [Optional] ref string PromptMsg,
                [Optional] ref string PromptButtons,
                [Optional, DefaultParameterValue((byte)0)] byte? CreateMatPostRecord,
                [Optional] string ContainerNum,
                [Optional] string DocumentNum); 

        int PSCmplTransSp(string Item,
                decimal? Qty,
                DateTime? TransDate,
                string PsNum,
                string Employee,
                int? OperNum,
                string Wc,
                string Shift,
                string Loc,
                string Lot,
                string SerialPrefix,
                Guid? SessionID,
                ref decimal? JobtranTransNum,
                ref byte? TCoby,
                ref string Infobar,
                [Optional] ref string PromptMsg,
                [Optional] ref string PromptButtons,
                [Optional, DefaultParameterValue((byte)0)] byte? CreateMatPostRecord,
                [Optional] string ContainerNum,
                [Optional] string DocumentNum); 

        int PSScrapTransSp(string Item,
                decimal? ScrapQty,
                DateTime? TransDate,
                string PsNum,
                string ReasonCode,
                string Employee,
                int? OperNum,
                string Wc,
                string Shift,
                Guid? SessionID,
                ref decimal? JobtranTransNum,
                ref byte? TCoby,
                ref string Infobar,
                [Optional] string DocumentNum); 

    }
}
    
