//PROJECT NAME: Finance
//CLASS NAME: Portal_SSSCCIArInvBal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_SSSCCIArInvBal : IPortal_SSSCCIArInvBal
	{
		readonly IApplicationDB appDB;
		
		public Portal_SSSCCIArInvBal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TransType,
			decimal? Balance,
			decimal? TaxAmt,
			decimal? ExchRate,
			decimal? ForAmt,
			int? CustSeq,
			string Infobar) Portal_SSSCCIArInvBalSp(
			string InvNum,
			string CustNum,
			string TransType,
			decimal? Balance,
			decimal? TaxAmt,
			decimal? ExchRate,
			decimal? ForAmt,
			int? CustSeq,
			string Infobar)
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
				cmd.CommandText = "Portal_SSSCCIArInvBalSp";
				
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
				
				return (Severity, TransType, Balance, TaxAmt, ExchRate, ForAmt, CustSeq, Infobar);
			}
		}
	}
}
