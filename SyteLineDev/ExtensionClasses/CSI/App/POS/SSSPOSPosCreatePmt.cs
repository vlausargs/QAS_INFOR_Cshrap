//PROJECT NAME: POS
//CLASS NAME: SSSPOSPosCreatePmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPosCreatePmt : ISSSPOSPosCreatePmt
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSPosCreatePmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSPOSPosCreatePmtSp(
			string POSNum,
			string ParmCurrCode,
			string ParmSite,
			Guid? SessionID,
			decimal? POSMTotalPrepaidAmt,
			decimal? POSMPaymentTotalAmount,
			int? POSMCredit,
			string POSMCustNum,
			int? POSMCustSeq,
			string TRefNum,
			string TInvNum,
			string CustomerBankCode,
			int? SL702,
			string CustAddrCurrCode,
			string CustAddrBalMethod,
			Guid? PosmPaymentRowpointer,
			string Infobar)
		{
			POSMNumType _POSNum = POSNum;
			CurrCodeType _ParmCurrCode = ParmCurrCode;
			SiteType _ParmSite = ParmSite;
			RowPointerType _SessionID = SessionID;
			AmountType _POSMTotalPrepaidAmt = POSMTotalPrepaidAmt;
			AmountType _POSMPaymentTotalAmount = POSMPaymentTotalAmount;
			ListYesNoType _POSMCredit = POSMCredit;
			CustNumType _POSMCustNum = POSMCustNum;
			CustSeqType _POSMCustSeq = POSMCustSeq;
			StringType _TRefNum = TRefNum;
			InvNumType _TInvNum = TInvNum;
			BankCodeType _CustomerBankCode = CustomerBankCode;
			ListYesNoType _SL702 = SL702;
			CurrCodeType _CustAddrCurrCode = CustAddrCurrCode;
			BalMethodType _CustAddrBalMethod = CustAddrBalMethod;
			RowPointerType _PosmPaymentRowpointer = PosmPaymentRowpointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSPosCreatePmtSp";
				
				appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmSite", _ParmSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMTotalPrepaidAmt", _POSMTotalPrepaidAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMPaymentTotalAmount", _POSMPaymentTotalAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCredit", _POSMCredit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustNum", _POSMCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POSMCustSeq", _POSMCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRefNum", _TRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TInvNum", _TInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerBankCode", _CustomerBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SL702", _SL702, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddrCurrCode", _CustAddrCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustAddrBalMethod", _CustAddrBalMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PosmPaymentRowpointer", _PosmPaymentRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
