//PROJECT NAME: Production
//CLASS NAME: RSQC_PreDisposition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_PreDisposition : IRSQC_PreDisposition
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_PreDisposition(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_InspectorAuthorize,
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
		string Infobar)
		{
			QCRefType _i_RefType = i_RefType;
			QCDocNumType _i_RefNum = i_RefNum;
			QCRefLineType _i_RefLine = i_RefLine;
			ItemType _i_Item = i_Item;
			QCDocNumType _i_Entity = i_Entity;
			QCRcvrNumType _i_RcvrNum = i_RcvrNum;
			QCTestSeqType _i_TestSeq = i_TestSeq;
			QCCharType _o_InspectorAuthorize = o_InspectorAuthorize;
			ListYesNoType _o_AcceptReasonReqd = o_AcceptReasonReqd;
			QCCodeType _o_AcceptReason = o_AcceptReason;
			DescriptionType _o_AcceptReasonDesc = o_AcceptReasonDesc;
			ListYesNoType _o_RejectReasonReqd = o_RejectReasonReqd;
			QCCodeType _o_RejectReason = o_RejectReason;
			DescriptionType _o_RejectReasonDesc = o_RejectReasonDesc;
			QCCodeType _o_QCHoldReason = o_QCHoldReason;
			DescriptionType _o_QCHoldReasonDesc = o_QCHoldReasonDesc;
			ListYesNoType _o_PrintTagDefault = o_PrintTagDefault;
			QCCharType _o_CreateMRR = o_CreateMRR;
			QCCharType _o_QtyCheck = o_QtyCheck;
			QCCharType _o_CheckTestResults = o_CheckTestResults;
			ListYesNoType _o_HasTestPlan = o_HasTestPlan;
			ListYesNoType _o_HasTestResults = o_HasTestResults;
			QtyUnitType _o_JobrouteQty = o_JobrouteQty;
			QCCharType _o_ActionJobTran = o_ActionJobTran;
			QCCharType _o_EditJobtran = o_EditJobtran;
			ListYesNoType _o_JobrouteOperComplete = o_JobrouteOperComplete;
			ListYesNoType _o_CreateCOC = o_CreateCOC;
			RowPointerType _o_SessionId = o_SessionId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_PreDispositionSp";
				
				appDB.AddCommandParameter(cmd, "i_RefType", _i_RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RefNum", _i_RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RefLine", _i_RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Item", _i_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Entity", _i_Entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RcvrNum", _i_RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_TestSeq", _i_TestSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_InspectorAuthorize", _o_InspectorAuthorize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_AcceptReasonReqd", _o_AcceptReasonReqd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_AcceptReason", _o_AcceptReason, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_AcceptReasonDesc", _o_AcceptReasonDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_RejectReasonReqd", _o_RejectReasonReqd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_RejectReason", _o_RejectReason, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_RejectReasonDesc", _o_RejectReasonDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_QCHoldReason", _o_QCHoldReason, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_QCHoldReasonDesc", _o_QCHoldReasonDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_PrintTagDefault", _o_PrintTagDefault, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_CreateMRR", _o_CreateMRR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_QtyCheck", _o_QtyCheck, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_CheckTestResults", _o_CheckTestResults, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_HasTestPlan", _o_HasTestPlan, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_HasTestResults", _o_HasTestResults, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_JobrouteQty", _o_JobrouteQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_ActionJobTran", _o_ActionJobTran, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_EditJobtran", _o_EditJobtran, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_JobrouteOperComplete", _o_JobrouteOperComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_CreateCOC", _o_CreateCOC, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_SessionId", _o_SessionId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_InspectorAuthorize = _o_InspectorAuthorize;
				o_AcceptReasonReqd = _o_AcceptReasonReqd;
				o_AcceptReason = _o_AcceptReason;
				o_AcceptReasonDesc = _o_AcceptReasonDesc;
				o_RejectReasonReqd = _o_RejectReasonReqd;
				o_RejectReason = _o_RejectReason;
				o_RejectReasonDesc = _o_RejectReasonDesc;
				o_QCHoldReason = _o_QCHoldReason;
				o_QCHoldReasonDesc = _o_QCHoldReasonDesc;
				o_PrintTagDefault = _o_PrintTagDefault;
				o_CreateMRR = _o_CreateMRR;
				o_QtyCheck = _o_QtyCheck;
				o_CheckTestResults = _o_CheckTestResults;
				o_HasTestPlan = _o_HasTestPlan;
				o_HasTestResults = _o_HasTestResults;
				o_JobrouteQty = _o_JobrouteQty;
				o_ActionJobTran = _o_ActionJobTran;
				o_EditJobtran = _o_EditJobtran;
				o_JobrouteOperComplete = _o_JobrouteOperComplete;
				o_CreateCOC = _o_CreateCOC;
				o_SessionId = _o_SessionId;
				Infobar = _Infobar;
				
				return (Severity, o_InspectorAuthorize, o_AcceptReasonReqd, o_AcceptReason, o_AcceptReasonDesc, o_RejectReasonReqd, o_RejectReason, o_RejectReasonDesc, o_QCHoldReason, o_QCHoldReasonDesc, o_PrintTagDefault, o_CreateMRR, o_QtyCheck, o_CheckTestResults, o_HasTestPlan, o_HasTestResults, o_JobrouteQty, o_ActionJobTran, o_EditJobtran, o_JobrouteOperComplete, o_CreateCOC, o_SessionId, Infobar);
			}
		}
	}
}
