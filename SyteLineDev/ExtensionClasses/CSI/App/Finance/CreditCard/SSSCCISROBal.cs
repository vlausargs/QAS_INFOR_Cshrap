//PROJECT NAME: Finance
//CLASS NAME: SSSCCISROBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCISROBal : ISSSCCISROBal
	{
		readonly IApplicationDB appDB;
		
		
		public SSSCCISROBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? Balance,
		decimal? TaxAmt,
		decimal? ExchRate,
		decimal? ForAmt,
		int? CustSeq,
		string Infobar) SSSCCISROBalSp(string SroNum,
		decimal? Balance,
		decimal? TaxAmt,
		decimal? ExchRate,
		decimal? ForAmt,
		int? CustSeq,
		string Infobar)
		{
			InvNumType _SroNum = SroNum;
			AmountType _Balance = Balance;
			AmountType _TaxAmt = TaxAmt;
			ExchRateType _ExchRate = ExchRate;
			AmountType _ForAmt = ForAmt;
			CustSeqType _CustSeq = CustSeq;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCISROBalSp";
				
				appDB.AddCommandParameter(cmd, "SroNum", _SroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxAmt", _TaxAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForAmt", _ForAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Balance = _Balance;
				TaxAmt = _TaxAmt;
				ExchRate = _ExchRate;
				ForAmt = _ForAmt;
				CustSeq = _CustSeq;
				Infobar = _Infobar;
				
				return (Severity, Balance, TaxAmt, ExchRate, ForAmt, CustSeq, Infobar);
			}
		}
	}
}
