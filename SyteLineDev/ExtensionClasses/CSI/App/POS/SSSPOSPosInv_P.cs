//PROJECT NAME: POS
//CLASS NAME: SSSPOSPosInv_P.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPosInv_P : ISSSPOSPosInv_P
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSPosInv_P(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InvNum,
			string Infobar) SSSPOSPosInv_PSp(
			string SRONum,
			int? SROLine,
			int? SROOper,
			string InvCred,
			string POSNum,
			string Mode,
			decimal? UserID,
			string ParmCurrCode,
			Guid? SessionID,
			string POSMCredInvNum,
			string InvNum,
			string Infobar)
		{
			FSSRONumType _SRONum = SRONum;
			FSSROLineType _SROLine = SROLine;
			FSSROOperType _SROOper = SROOper;
			StringType _InvCred = InvCred;
			POSMNumType _POSNum = POSNum;
			StringType _Mode = Mode;
			TokenType _UserID = UserID;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			RowPointer _SessionID = SessionID;
			InvNumType _POSMCredInvNum = POSMCredInvNum;
			InvNumType _InvNum = InvNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSPosInv_PSp";
				
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCredInvNum", _POSMCredInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvNum = _InvNum;
				Infobar = _Infobar;
				
				return (Severity, InvNum, Infobar);
			}
		}
	}
}
