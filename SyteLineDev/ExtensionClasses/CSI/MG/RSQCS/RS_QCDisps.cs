//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCDisps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.RSQCS
{
    [IDOExtensionClass("RS_QCDisps")]
    public class RS_QCDisps : CSIExtensionClassBase, IExtFTRS_QCDisps
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_CreateDispositionEsigSp(Guid? RcvrRowpointer,
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
		string HoldReason)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_CreateDispositionEsigExt = new RSQC_CreateDispositionEsigFactory().Create(appDb);
				
				var result = iRSQC_CreateDispositionEsigExt.RSQC_CreateDispositionEsigSp(RcvrRowpointer,
				UserName,
				ReasonCode,
				EsigRowpointer,
				RefType,
				InspNum,
				Qty_Accepted,
				AcceptReason,
				AcceptDisp,
				Qty_Rejected,
				RejectReason,
				RejectDisp,
				RejectCause,
				Qty_Hold,
				HoldReason);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_DeletetmpserSp(ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_DeletetmpserExt = new RSQC_DeletetmpserFactory().Create(appDb);
				
				var result = iRSQC_DeletetmpserExt.RSQC_DeletetmpserSp(Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetItemhAlertsSp(string RcvrNum,
		ref string Messages,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetItemhAlertsExt = new RSQC_GetItemhAlertsFactory().Create(appDb);
				
				var result = iRSQC_GetItemhAlertsExt.RSQC_GetItemhAlertsSp(RcvrNum,
				Messages,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Messages = result.Messages;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetItemUMSp(int? RcvrNum,
			ref string NewUM)
		{
			var iRSQC_GetItemUMExt = this.GetService<IRSQC_GetItemUM>();
			
			var result = iRSQC_GetItemUMExt.RSQC_GetItemUMSp(RcvrNum,
				NewUM);
			
			NewUM = result.NewUM;
			
			return result.ReturnCode??0;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetJobDataSp(int? i_rcvr,
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
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetJobDataExt = new RSQC_GetJobDataFactory().Create(appDb);
				
				var result = iRSQC_GetJobDataExt.RSQC_GetJobDataSp(i_rcvr,
				o_ref_type,
				o_ref_num,
				o_ref_line_suf,
				o_ref_release,
				o_description,
				o_item_cost_conv,
				o_um,
				o_po_line,
				o_po_release,
				o_accept_to_jobtran,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_ref_type = result.o_ref_type;
				o_ref_num = result.o_ref_num;
				o_ref_line_suf = result.o_ref_line_suf;
				o_ref_release = result.o_ref_release;
				o_description = result.o_description;
				o_item_cost_conv = result.o_item_cost_conv;
				o_um = result.o_um;
				o_po_line = result.o_po_line;
				o_po_release = result.o_po_release;
				o_accept_to_jobtran = result.o_accept_to_jobtran;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetMaxSerialNumSp(string SerNumPrefix,
		[Optional] string Site,
		ref string SerNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetMaxSerialNumExt = new RSQC_GetMaxSerialNumFactory().Create(appDb);
				
				var result = iRSQC_GetMaxSerialNumExt.RSQC_GetMaxSerialNumSp(SerNumPrefix,
				Site,
				SerNum);
				
				int Severity = result.ReturnCode.Value;
				SerNum = result.SerNum;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetUserIDSp(ref string EmpNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetUserIDExt = new RSQC_GetUserIDFactory().Create(appDb);
				
				var result = iRSQC_GetUserIDExt.RSQC_GetUserIDSp(EmpNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				EmpNum = result.EmpNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_ItemDataSp(string i_Item,
		ref string i_Description,
		ref string i_UM,
		ref int? i_LotTracked,
		ref int? i_SerialTracked,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_ItemDataExt = new RSQC_ItemDataFactory().Create(appDb);
				
				var result = iRSQC_ItemDataExt.RSQC_ItemDataSp(i_Item,
				i_Description,
				i_UM,
				i_LotTracked,
				i_SerialTracked,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				i_Description = result.i_Description;
				i_UM = result.i_UM;
				i_LotTracked = result.i_LotTracked;
				i_SerialTracked = result.i_SerialTracked;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_PreDispositionSp(string i_RefType,
		string i_RefNum,
		int? i_RefLine,
		string i_Item,
		string i_Entity,
		int? i_RcvrNum,
		int? i_TestSeq,
		ref string o_InspectorAuthorize,
		ref int? o_AcceptReasonReqd,
		ref string o_AcceptReason,
		ref string o_AcceptReasonDesc,
		ref int? o_RejectReasonReqd,
		ref string o_RejectReason,
		ref string o_RejectReasonDesc,
		ref string o_QCHoldReason,
		ref string o_QCHoldReasonDesc,
		ref int? o_PrintTagDefault,
		ref string o_CreateMRR,
		ref string o_QtyCheck,
		ref string o_CheckTestResults,
		ref int? o_HasTestPlan,
		ref int? o_HasTestResults,
		ref decimal? o_JobrouteQty,
		ref string o_ActionJobTran,
		ref string o_EditJobtran,
		ref int? o_JobrouteOperComplete,
		ref int? o_CreateCOC,
		ref Guid? o_SessionId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_PreDispositionExt = new RSQC_PreDispositionFactory().Create(appDb);
				
				var result = iRSQC_PreDispositionExt.RSQC_PreDispositionSp(i_RefType,
				i_RefNum,
				i_RefLine,
				i_Item,
				i_Entity,
				i_RcvrNum,
				i_TestSeq,
				o_InspectorAuthorize,
				o_AcceptReasonReqd,
				o_AcceptReason,
				o_AcceptReasonDesc,
				o_RejectReasonReqd,
				o_RejectReason,
				o_RejectReasonDesc,
				o_QCHoldReason,
				o_QCHoldReasonDesc,
				o_PrintTagDefault,
				o_CreateMRR,
				o_QtyCheck,
				o_CheckTestResults,
				o_HasTestPlan,
				o_HasTestResults,
				o_JobrouteQty,
				o_ActionJobTran,
				o_EditJobtran,
				o_JobrouteOperComplete,
				o_CreateCOC,
				o_SessionId,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_InspectorAuthorize = result.o_InspectorAuthorize;
				o_AcceptReasonReqd = result.o_AcceptReasonReqd;
				o_AcceptReason = result.o_AcceptReason;
				o_AcceptReasonDesc = result.o_AcceptReasonDesc;
				o_RejectReasonReqd = result.o_RejectReasonReqd;
				o_RejectReason = result.o_RejectReason;
				o_RejectReasonDesc = result.o_RejectReasonDesc;
				o_QCHoldReason = result.o_QCHoldReason;
				o_QCHoldReasonDesc = result.o_QCHoldReasonDesc;
				o_PrintTagDefault = result.o_PrintTagDefault;
				o_CreateMRR = result.o_CreateMRR;
				o_QtyCheck = result.o_QtyCheck;
				o_CheckTestResults = result.o_CheckTestResults;
				o_HasTestPlan = result.o_HasTestPlan;
				o_HasTestResults = result.o_HasTestResults;
				o_JobrouteQty = result.o_JobrouteQty;
				o_ActionJobTran = result.o_ActionJobTran;
				o_EditJobtran = result.o_EditJobtran;
				o_JobrouteOperComplete = result.o_JobrouteOperComplete;
				o_CreateCOC = result.o_CreateCOC;
				o_SessionId = result.o_SessionId;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_PostDispositionSp(int? i_RcvrNum,
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
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_PostDispositionExt = new RSQC_PostDispositionFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_PostDispositionExt.RSQC_PostDispositionSp(i_RcvrNum,
				i_Item,
				i_Entity,
				i_TestSeq,
				i_RefType,
				i_RefNum,
				i_RefLine,
				i_RefRelease,
				i_TransDate,
				i_HoursWorked,
				i_AddlQtyReceived,
				i_AcceptPrinted,
				i_Complete,
				i_UserCode,
				i_InspID,
				i_AcceptQuantity,
				i_AcceptReason,
				i_AcceptDisp,
				i_COCNum,
				i_CreateCOC,
				i_QCHoldQuantity,
				i_QCHoldReason,
				i_MRRNum,
				i_RejectQuantity,
				i_RejectReason,
				i_RejectDisp,
				i_RejectCause,
				i_DispType,
				i_QtyScrapped,
				i_ReasonCode,
				i_OperComplete,
				o_AcceptMatlMove,
				o_RejectMatlMove,
				o_Messages,
				o_ErrorCode,
				o_Mrr,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_AcceptMatlMove = result.o_AcceptMatlMove;
				o_RejectMatlMove = result.o_RejectMatlMove;
				o_Messages = result.o_Messages;
				o_ErrorCode = result.o_ErrorCode;
				o_Mrr = result.o_Mrr;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_PrintTagssp(int? i_rcvrnum,
		string i_item,
		string i_itmdesc,
		string i_reftype,
		string i_entity,
		string i_entityname,
		string i_insp,
		string i_inspname,
		DateTime? i_inspdate,
		string i_refnum,
		int? i_refline,
		int? i_refrel,
		decimal? i_acceptqty,
		string i_a_reason,
		string i_a_reason_descr,
		string i_a_dcode,
		string i_a_dcode_descr,
		int? i_accepttags,
		int? i_acceptnum,
		decimal? i_rejectqty,
		string i_r_reason,
		string i_r_reason_descr,
		string i_r_dcode,
		string i_r_dcode_descr,
		string i_r_cause,
		string i_r_cause_descr,
		int? i_rejecttags,
		int? i_rejectnum,
		decimal? i_holdqty,
		string i_h_reason,
		string i_h_reason_descr,
		int? i_holdtags,
		int? i_holdnum,
		string i_lot,
		string i_psnum,
		string i_wcdescr)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_PrintTagsExt = new RSQC_PrintTagsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_PrintTagsExt.RSQC_PrintTagssp(i_rcvrnum,
				i_item,
				i_itmdesc,
				i_reftype,
				i_entity,
				i_entityname,
				i_insp,
				i_inspname,
				i_inspdate,
				i_refnum,
				i_refline,
				i_refrel,
				i_acceptqty,
				i_a_reason,
				i_a_reason_descr,
				i_a_dcode,
				i_a_dcode_descr,
				i_accepttags,
				i_acceptnum,
				i_rejectqty,
				i_r_reason,
				i_r_reason_descr,
				i_r_dcode,
				i_r_dcode_descr,
				i_r_cause,
				i_r_cause_descr,
				i_rejecttags,
				i_rejectnum,
				i_holdqty,
				i_h_reason,
				i_h_reason_descr,
				i_holdtags,
				i_holdnum,
				i_lot,
				i_psnum,
				i_wcdescr);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
