//PROJECT NAME: Production
//CLASS NAME: RSQC_PostDisposition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_PostDisposition : IRSQC_PostDisposition
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_PostDisposition(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_AcceptMatlMove,
		string o_RejectMatlMove,
		string o_Messages,
		int? o_ErrorCode,
		string o_Mrr,
		string Infobar) RSQC_PostDispositionSp(int? i_RcvrNum,
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
		string o_AcceptMatlMove,
		string o_RejectMatlMove,
		string o_Messages,
		int? o_ErrorCode,
		string o_Mrr,
		string Infobar)
		{
			QCRcvrNumType _i_RcvrNum = i_RcvrNum;
			ItemType _i_Item = i_Item;
			QCDocNumType _i_Entity = i_Entity;
			QCTestSeqType _i_TestSeq = i_TestSeq;
			QCRefType _i_RefType = i_RefType;
			QCRefNumType _i_RefNum = i_RefNum;
			QCRefLineType _i_RefLine = i_RefLine;
			QCRefReleaseType _i_RefRelease = i_RefRelease;
			DateType _i_TransDate = i_TransDate;
			QtyUnitType _i_HoursWorked = i_HoursWorked;
			QtyUnitType _i_AddlQtyReceived = i_AddlQtyReceived;
			ListYesNoType _i_AcceptPrinted = i_AcceptPrinted;
			ListYesNoType _i_Complete = i_Complete;
			UserCodeType _i_UserCode = i_UserCode;
			EmpNumType _i_InspID = i_InspID;
			QtyUnitType _i_AcceptQuantity = i_AcceptQuantity;
			QCCodeType _i_AcceptReason = i_AcceptReason;
			QCCodeType _i_AcceptDisp = i_AcceptDisp;
			QCDocNumType _i_COCNum = i_COCNum;
			ListYesNoType _i_CreateCOC = i_CreateCOC;
			QtyUnitType _i_QCHoldQuantity = i_QCHoldQuantity;
			QCCodeType _i_QCHoldReason = i_QCHoldReason;
			QCDocNumType _i_MRRNum = i_MRRNum;
			QtyUnitType _i_RejectQuantity = i_RejectQuantity;
			QCCodeType _i_RejectReason = i_RejectReason;
			QCCodeType _i_RejectDisp = i_RejectDisp;
			QCCodeType _i_RejectCause = i_RejectCause;
			QCCharType _i_DispType = i_DispType;
			QtyUnitType _i_QtyScrapped = i_QtyScrapped;
			ReasonCodeType _i_ReasonCode = i_ReasonCode;
			ListYesNoType _i_OperComplete = i_OperComplete;
			QCCharType _o_AcceptMatlMove = o_AcceptMatlMove;
			QCCharType _o_RejectMatlMove = o_RejectMatlMove;
			InfobarType _o_Messages = o_Messages;
			ListYesNoType _o_ErrorCode = o_ErrorCode;
			QCDocNumType _o_Mrr = o_Mrr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_PostDispositionSp";
				
				appDB.AddCommandParameter(cmd, "i_RcvrNum", _i_RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Item", _i_Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Entity", _i_Entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_TestSeq", _i_TestSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RefType", _i_RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RefNum", _i_RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RefLine", _i_RefLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RefRelease", _i_RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_TransDate", _i_TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_HoursWorked", _i_HoursWorked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_AddlQtyReceived", _i_AddlQtyReceived, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_AcceptPrinted", _i_AcceptPrinted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_Complete", _i_Complete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_UserCode", _i_UserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_InspID", _i_InspID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_AcceptQuantity", _i_AcceptQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_AcceptReason", _i_AcceptReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_AcceptDisp", _i_AcceptDisp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_COCNum", _i_COCNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_CreateCOC", _i_CreateCOC, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_QCHoldQuantity", _i_QCHoldQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_QCHoldReason", _i_QCHoldReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_MRRNum", _i_MRRNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RejectQuantity", _i_RejectQuantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RejectReason", _i_RejectReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RejectDisp", _i_RejectDisp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_RejectCause", _i_RejectCause, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_DispType", _i_DispType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_QtyScrapped", _i_QtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_ReasonCode", _i_ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_OperComplete", _i_OperComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_AcceptMatlMove", _o_AcceptMatlMove, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_RejectMatlMove", _o_RejectMatlMove, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_Messages", _o_Messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_ErrorCode", _o_ErrorCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_Mrr", _o_Mrr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_AcceptMatlMove = _o_AcceptMatlMove;
				o_RejectMatlMove = _o_RejectMatlMove;
				o_Messages = _o_Messages;
				o_ErrorCode = _o_ErrorCode;
				o_Mrr = _o_Mrr;
				Infobar = _Infobar;
				
				return (Severity, o_AcceptMatlMove, o_RejectMatlMove, o_Messages, o_ErrorCode, o_Mrr, Infobar);
			}
		}
	}
}
