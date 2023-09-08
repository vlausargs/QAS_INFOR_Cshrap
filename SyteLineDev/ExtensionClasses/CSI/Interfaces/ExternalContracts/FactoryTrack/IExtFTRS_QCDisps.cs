
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSI.ExternalContracts.FactoryTrack
{
    public interface IExtFTRS_QCDisps
    {

        int RSQC_CreateDispositionEsigSp(Guid? RcvrRowpointer,
                string UserName,
                string ReasonCode,
                Guid? EsigRowpointer,
                string RefType,
                string InspNum,
                decimal? Qty_Accepted,
                string AcceptReason,
                string AcceptDisp,
                decimal? Qty_Rejected,
                string RejectReason,
                string RejectDisp,
                string RejectCause,
                decimal? Qty_Hold,
                string HoldReason); 

        int RSQC_GetJobDataSp(int? i_rcvr,
                ref string o_ref_type,
                ref string o_ref_num,
                ref int? o_ref_line_suf,
                ref int? o_ref_release,
                ref string o_description,
                ref decimal? o_item_cost_conv,
                ref string o_um,
                ref int? o_po_line,
                ref int? o_po_release,
                ref string o_accept_to_jobtran,
                ref string Infobar); 

        int RSQC_PostDispositionSp(int? i_RcvrNum,
                string i_Item,
                string i_Entity,
                int? i_TestSeq,
                string i_RefType,
                string i_RefNum,
                int? i_RefLine,
                int? i_RefRelease,
                DateTime? i_TransDate,
                decimal? i_HoursWorked,
                decimal? i_AddlQtyReceived,
                int? i_AcceptPrinted,
                int? i_Complete,
                string i_UserCode,
                string i_InspID,
                decimal? i_AcceptQuantity,
                string i_AcceptReason,
                string i_AcceptDisp,
                string i_COCNum,
                int? i_CreateCOC,
                decimal? i_QCHoldQuantity,
                string i_QCHoldReason,
                string i_MRRNum,
                decimal? i_RejectQuantity,
                string i_RejectReason,
                string i_RejectDisp,
                string i_RejectCause,
                string i_DispType,
                decimal? i_QtyScrapped,
                string i_ReasonCode,
                int? i_OperComplete,
                ref string o_AcceptMatlMove,
                ref string o_RejectMatlMove,
                ref string o_Messages,
                ref int? o_ErrorCode,
                ref string o_Mrr,
                ref string Infobar); 

    }
}
    
