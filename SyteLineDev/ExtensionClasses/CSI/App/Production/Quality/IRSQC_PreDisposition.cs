//PROJECT NAME: Production
//CLASS NAME: IRSQC_PreDisposition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_PreDisposition
	{
		(int? ReturnCode, string o_InspectorAuthorize,
		int? o_AcceptReasonReqd,
		string o_AcceptReason,
		string o_AcceptReasonDesc,
		int? o_RejectReasonReqd,
		string o_RejectReason,
		string o_RejectReasonDesc,
		string o_QCHoldReason,
		string o_QCHoldReasonDesc,
		int? o_PrintTagDefault,
		string o_CreateMRR,
		string o_QtyCheck,
		string o_CheckTestResults,
		int? o_HasTestPlan,
		int? o_HasTestResults,
		decimal? o_JobrouteQty,
		string o_ActionJobTran,
		string o_EditJobtran,
		int? o_JobrouteOperComplete,
		int? o_CreateCOC,
		Guid? o_SessionId,
		string Infobar) RSQC_PreDispositionSp(string i_RefType,
		string i_RefNum,
		int? i_RefLine,
		string i_Item,
		string i_Entity,
		int? i_RcvrNum,
		int? i_TestSeq,
		string o_InspectorAuthorize,
		int? o_AcceptReasonReqd,
		string o_AcceptReason,
		string o_AcceptReasonDesc,
		int? o_RejectReasonReqd,
		string o_RejectReason,
		string o_RejectReasonDesc,
		string o_QCHoldReason,
		string o_QCHoldReasonDesc,
		int? o_PrintTagDefault,
		string o_CreateMRR,
		string o_QtyCheck,
		string o_CheckTestResults,
		int? o_HasTestPlan,
		int? o_HasTestResults,
		decimal? o_JobrouteQty,
		string o_ActionJobTran,
		string o_EditJobtran,
		int? o_JobrouteOperComplete,
		int? o_CreateCOC,
		Guid? o_SessionId,
		string Infobar);
	}
}

