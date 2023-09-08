//PROJECT NAME: POS
//CLASS NAME: SSSPOSPostPmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPostPmt : ISSSPOSPostPmt
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSPostPmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPOSPostPmtSp(
			string POSNum,
			string CustNum,
			int? POSMCredit,
			string POSMDrawerOrderType,
			Guid? SessionID,
			decimal? UserID,
			string Infobar)
		{
			POSMNumType _POSNum = POSNum;
			CustNumType _CustNum = CustNum;
			ListYesNoType _POSMCredit = POSMCredit;
			POSMOrdTypeType _POSMDrawerOrderType = POSMDrawerOrderType;
			RowPointerType _SessionID = SessionID;
			TokenType _UserID = UserID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSPostPmtSp";
				
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCredit", _POSMCredit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMDrawerOrderType", _POSMDrawerOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
