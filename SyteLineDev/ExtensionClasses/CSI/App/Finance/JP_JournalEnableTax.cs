//PROJECT NAME: CSIFinance
//CLASS NAME: JP_JournalEnableTax.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IJP_JournalEnableTax
	{
		(int? ReturnCode, byte? JPDerAccount, string TaxCode, decimal? TaxRate) JP_JournalEnableTaxSp(string Acct = null,
		byte? Taxable = null,
		byte? JPDerAccount = null,
		string TaxCode = null,
		decimal? TaxRate = null);
	}
	
	public class JP_JournalEnableTax : IJP_JournalEnableTax
	{
		readonly IApplicationDB appDB;
		
		public JP_JournalEnableTax(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? JPDerAccount, string TaxCode, decimal? TaxRate) JP_JournalEnableTaxSp(string Acct = null,
		byte? Taxable = null,
		byte? JPDerAccount = null,
		string TaxCode = null,
		decimal? TaxRate = null)
		{
			AcctType _Acct = Acct;
			ListYesNoType _Taxable = Taxable;
			ListYesNoType _JPDerAccount = JPDerAccount;
			TaxCodeType _TaxCode = TaxCode;
			TaxRateType _TaxRate = TaxRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JP_JournalEnableTaxSp";
				
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Taxable", _Taxable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JPDerAccount", _JPDerAccount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode", _TaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxRate", _TaxRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JPDerAccount = _JPDerAccount;
				TaxCode = _TaxCode;
				TaxRate = _TaxRate;
				
				return (Severity, JPDerAccount, TaxCode, TaxRate);
			}
		}
	}
}
