//PROJECT NAME: Finance
//CLASS NAME: IARPaymentDistPostingChargebacks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARPaymentDistPostingChargebacks
	{
		(int? ReturnCode,
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
			string ArpmtRef);
	}
}

