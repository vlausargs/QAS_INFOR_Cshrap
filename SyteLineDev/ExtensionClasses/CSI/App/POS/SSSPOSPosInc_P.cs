//PROJECT NAME: POS
//CLASS NAME: SSSPOSPosInc_P.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPosInc_P : ISSSPOSPosInc_P
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSPosInc_P(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InvNum,
			string Infobar) SSSPOSPosInc_PSp(
			string CoNum,
			string InvCred,
			string PosNum,
			string Mode,
			decimal? UserID,
			string ParmCurrCode,
			Guid? SessionID,
			string POSMCredInvNum,
			string InvNum,
			string Infobar,
			int? PackNum)
		{
			CoNumType _CoNum = CoNum;
			StringType _InvCred = InvCred;
			POSMNumType _PosNum = PosNum;
			StringType _Mode = Mode;
			TokenType _UserID = UserID;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			RowPointer _SessionID = SessionID;
			InvNumType _POSMCredInvNum = POSMCredInvNum;
			InvNumType _InvNum = InvNum;
			InfobarType _Infobar = Infobar;
			PackNumType _PackNum = PackNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSPosInc_PSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PosNum", _PosNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Mode", _Mode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCredInvNum", _POSMCredInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvNum = _InvNum;
				Infobar = _Infobar;
				
				return (Severity, InvNum, Infobar);
			}
		}
	}
}
