//PROJECT NAME: Finance
//CLASS NAME: ExternalFinancialChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExternalFinancialChk : IExternalFinancialChk
	{
		readonly IApplicationDB appDB;
		
		
		public ExternalFinancialChk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ExtFinEnabled,
		int? ExtFinUseExternalAR,
		string ExtFinExtFinancial,
		string Infobar) ExternalFinancialChkSp(int? ExtFinEnabled,
		int? ExtFinUseExternalAR,
		string ExtFinExtFinancial,
		string Infobar)
		{
			ListYesNoType _ExtFinEnabled = ExtFinEnabled;
			ListYesNoType _ExtFinUseExternalAR = ExtFinUseExternalAR;
			ExtFinNameType _ExtFinExtFinancial = ExtFinExtFinancial;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExternalFinancialChkSp";
				
				appDB.AddCommandParameter(cmd, "ExtFinEnabled", _ExtFinEnabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtFinUseExternalAR", _ExtFinUseExternalAR, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtFinExtFinancial", _ExtFinExtFinancial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExtFinEnabled = _ExtFinEnabled;
				ExtFinUseExternalAR = _ExtFinUseExternalAR;
				ExtFinExtFinancial = _ExtFinExtFinancial;
				Infobar = _Infobar;
				
				return (Severity, ExtFinEnabled, ExtFinUseExternalAR, ExtFinExtFinancial, Infobar);
			}
		}
	}
}
