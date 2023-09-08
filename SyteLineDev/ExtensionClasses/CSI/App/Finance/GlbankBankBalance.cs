//PROJECT NAME: CSIFinance
//CLASS NAME: GlbankBankBalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IGlbankBankBalance
	{
		(int? ReturnCode, string Infobar, decimal? NewDomBalance, decimal? NewForBalance) GlbankBankBalanceSp(string BankCode,
		string Infobar,
		decimal? NewDomBalance = null,
		decimal? NewForBalance = null);
	}
	
	public class GlbankBankBalance : IGlbankBankBalance
	{
		readonly IApplicationDB appDB;
		
		public GlbankBankBalance(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, decimal? NewDomBalance, decimal? NewForBalance) GlbankBankBalanceSp(string BankCode,
		string Infobar,
		decimal? NewDomBalance = null,
		decimal? NewForBalance = null)
		{
			BankCodeType _BankCode = BankCode;
			Infobar _Infobar = Infobar;
			AmountType _NewDomBalance = NewDomBalance;
			AmountType _NewForBalance = NewForBalance;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlbankBankBalanceSp";
				
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewDomBalance", _NewDomBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewForBalance", _NewForBalance, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				NewDomBalance = _NewDomBalance;
				NewForBalance = _NewForBalance;
				
				return (Severity, Infobar, NewDomBalance, NewForBalance);
			}
		}
	}
}
