//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateMrrDispositionEsig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateMrrDispositionEsig : IRSQC_CreateMrrDispositionEsig
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_CreateMrrDispositionEsig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RSQC_CreateMrrDispositionEsigSp(Guid? RcvrRowpointer,
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
		string RejectCause)
		{
			RowPointerType _RcvrRowpointer = RcvrRowpointer;
			UsernameType _UserName = UserName;
			ReasonCodeType _ReasonCode = ReasonCode;
			RowPointerType _EsigRowpointer = EsigRowpointer;
			QCRefType _RefType = RefType;
			EmpNumType _InspNum = InspNum;
			QtyUnitType _Qty_Accepted = Qty_Accepted;
			QCCodeType _AcceptReason = AcceptReason;
			QCCodeType _AcceptDisp = AcceptDisp;
			QtyUnitType _Qty_Rejected = Qty_Rejected;
			QCCodeType _RejectReason = RejectReason;
			QCCodeType _RejectDisp = RejectDisp;
			QCCodeType _RejectCause = RejectCause;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_CreateMrrDispositionEsigSp";
				
				appDB.AddCommandParameter(cmd, "RcvrRowpointer", _RcvrRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EsigRowpointer", _EsigRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InspNum", _InspNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty_Accepted", _Qty_Accepted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcceptReason", _AcceptReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcceptDisp", _AcceptDisp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty_Rejected", _Qty_Rejected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RejectReason", _RejectReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RejectDisp", _RejectDisp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RejectCause", _RejectCause, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
