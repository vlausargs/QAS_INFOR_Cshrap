//PROJECT NAME: Finance
//CLASS NAME: ARPaymentDistPostingChargebacks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARPaymentDistPostingChargebacks : IARPaymentDistPostingChargebacks
	{
		readonly IApplicationDB appDB;
		
		public ARPaymentDistPostingChargebacks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TotalChargebackAmount,
			string Infobar) ARPaymentDistPostingChargebacksSp(
			string PCustNum,
			string PBankCode,
			int? PCheckNum,
			DateTime? TransDate,
			string PInvNum,
			decimal? TotalChargebackAmount,
			string Infobar,
			string ArpmtType,
			string ArpmtCreditMemoNum,
			string ArpmtRef)
		{
			CustNumType _PCustNum = PCustNum;
			BankCodeType _PBankCode = PBankCode;
			ArCheckNumType _PCheckNum = PCheckNum;
			DateType _TransDate = TransDate;
			InvNumType _PInvNum = PInvNum;
			AmountType _TotalChargebackAmount = TotalChargebackAmount;
			Infobar _Infobar = Infobar;
			ArpmtTypeType _ArpmtType = ArpmtType;
			InvNumType _ArpmtCreditMemoNum = ArpmtCreditMemoNum;
			ReferenceType _ArpmtRef = ArpmtRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARPaymentDistPostingChargebacksSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TotalChargebackAmount", _TotalChargebackAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArpmtType", _ArpmtType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtCreditMemoNum", _ArpmtCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArpmtRef", _ArpmtRef, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TotalChargebackAmount = _TotalChargebackAmount;
				Infobar = _Infobar;
				
				return (Severity, TotalChargebackAmount, Infobar);
			}
		}
	}
}
