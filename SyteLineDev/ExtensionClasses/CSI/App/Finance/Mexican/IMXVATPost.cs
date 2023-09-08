//PROJECT NAME: Finance
//CLASS NAME: IMXVATPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXVATPost
	{
		int? MXVATPostSp(
			string JournalID,
			string CustNum,
			string InvNum,
			int? InvSeq,
			DateTime? DistDate,
			DateTime? EffDate,
			string VatAcct,
			decimal? AmountPaid,
			decimal? AmountInvoice,
			string CurrCode,
			decimal? TaxAmount,
			decimal? TaxForAmount,
			decimal? DomVATTaxBasis,
			decimal? ForVATTaxBasis,
			decimal? DomInvTaxAmount,
			decimal? ForInvTaxAmount,
			decimal? DomInvTaxBasis,
			decimal? ForInvTaxBasis,
			decimal? DomArCheckAmt,
			decimal? ForArCheckAmt,
			decimal? DomArInvCheckAmt,
			decimal? ForArInvCheckAmt,
			int? TaxSeq,
			string TaxCode,
			decimal? TaxRate,
			string VendNum,
			int? Voucher,
			int? CheckNum,
			decimal? InvExchRate,
			decimal? ChkExchRate,
			decimal? GainLose);
	}
}

