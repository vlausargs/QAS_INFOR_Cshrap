//PROJECT NAME: Finance
//CLASS NAME: IPortal_SSSCCIArInvBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_SSSCCIArInvBal
	{
		(int? ReturnCode,
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
			string Infobar);
	}
}

