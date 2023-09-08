//PROJECT NAME: CSICCI
//CLASS NAME: SSSCCIArInvBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIArInvBal
	{
		int SSSCCIArInvBalSp(string InvNum,
		                     string CustNum,
		                     ref string TransType,
		                     ref decimal? Balance,
		                     ref decimal? TaxAmt,
		                     ref decimal? ExchRate,
		                     ref decimal? ForAmt,
		                     ref int? CustSeq,
		                     ref string Infobar);
	}
	
	public class SSSCCIArInvBal : ISSSCCIArInvBal
	{
		readonly IApplicationDB appDB;
		
		public SSSCCIArInvBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSCCIArInvBalSp(string InvNum,
		                            string CustNum,
		                            ref string TransType,
		                            ref decimal? Balance,
		                            ref decimal? TaxAmt,
		                            ref decimal? ExchRate,
		                            ref decimal? ForAmt,
		                            ref int? CustSeq,
		                            ref string Infobar)
		{
			InvNumType _InvNum = InvNum;
			CustNumType _CustNum = CustNum;
			CCITransTypeType _TransType = TransType;
			AmountType _Balance = Balance;
			AmountType _TaxAmt = TaxAmt;
			ExchRateType _ExchRate = ExchRate;
			AmountType _ForAmt = ForAmt;
			CustSeqType _CustSeq = CustSeq;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCIArInvBalSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Balance", _Balance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxAmt", _TaxAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForAmt", _ForAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TransType = _TransType;
				Balance = _Balance;
				TaxAmt = _TaxAmt;
				ExchRate = _ExchRate;
				ForAmt = _ForAmt;
				CustSeq = _CustSeq;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
