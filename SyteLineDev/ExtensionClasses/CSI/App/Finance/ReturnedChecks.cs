//PROJECT NAME: Finance
//CLASS NAME: ReturnedChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class ReturnedChecks : IReturnedChecks
	{
		readonly IApplicationDB appDB;
		
		
		public ReturnedChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ReturnedChecksSp(string pBankCode,
		string pProcess,
		int? pProcessReturnedCheck,
		int? pProcessReturnedCheckDeposit,
		string Infobar)
		{
			BankCodeType _pBankCode = pBankCode;
			StringType _pProcess = pProcess;
			ListYesNoType _pProcessReturnedCheck = pProcessReturnedCheck;
			ListYesNoType _pProcessReturnedCheckDeposit = pProcessReturnedCheckDeposit;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReturnedChecksSp";
				
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pProcess", _pProcess, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pProcessReturnedCheck", _pProcessReturnedCheck, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pProcessReturnedCheckDeposit", _pProcessReturnedCheckDeposit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
