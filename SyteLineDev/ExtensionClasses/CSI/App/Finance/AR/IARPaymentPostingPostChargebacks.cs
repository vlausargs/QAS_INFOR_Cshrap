//PROJECT NAME: Finance
//CLASS NAME: IARPaymentPostingPostChargebacks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARPaymentPostingPostChargebacks
	{
		(int? ReturnCode,
			string Infobar) ARPaymentPostingPostChargebacksSp(
			Guid? PSessionID,
			string PCustNum,
			string PBankCode,
			int? PCheckNum,
			string Infobar,
			string ArpmtType,
			string ArpmtCreditMemoNum);
	}
}

