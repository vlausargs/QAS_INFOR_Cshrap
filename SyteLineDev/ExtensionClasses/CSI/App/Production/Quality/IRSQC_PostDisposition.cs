//PROJECT NAME: Production
//CLASS NAME: IRSQC_PostDisposition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_PostDisposition
	{
		(int? ReturnCode, string o_AcceptMatlMove,
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
		string Infobar);
	}
}

