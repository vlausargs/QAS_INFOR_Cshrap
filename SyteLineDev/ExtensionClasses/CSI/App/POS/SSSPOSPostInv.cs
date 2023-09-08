//PROJECT NAME: POS
//CLASS NAME: SSSPOSPostInv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPostInv : ISSSPOSPostInv
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSPostInv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPOSPostInvSp(
			string InvNum,
			int? InvSeq,
			string InvCred,
			string CoNum,
			string POSNum,
			string CustNum,
			decimal? UserID,
			string ParmCurrCode,
			Guid? SessionID,
			string POSMCredInvNum,
			string Infobar)
		{
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			StringType _InvCred = InvCred;
			CoNumType _CoNum = CoNum;
			POSMNumType _POSNum = POSNum;
			CustNumType _CustNum = CustNum;
			TokenType _UserID = UserID;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			RowPointer _SessionID = SessionID;
			InvNumType _POSMCredInvNum = POSMCredInvNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSPostInvSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCredInvNum", _POSMCredInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
