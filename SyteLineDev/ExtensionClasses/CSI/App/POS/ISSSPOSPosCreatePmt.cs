//PROJECT NAME: POS
//CLASS NAME: ISSSPOSPosCreatePmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSPosCreatePmt
	{
		(int? ReturnCode,
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
			string Infobar);
	}
}

