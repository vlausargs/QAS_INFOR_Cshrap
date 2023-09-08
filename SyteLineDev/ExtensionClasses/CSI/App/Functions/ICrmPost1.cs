//PROJECT NAME: Data
//CLASS NAME: ICrmPost1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICrmPost1
	{
		(int? ReturnCode,
			decimal? BalAdj,
			decimal? DAmt,
			int? TDistSeq,
			decimal? TSubTotal,
			string TInvNum,
			decimal? TAccRestTaxBasis,
			decimal? TAccRestTax1,
			decimal? TAccRestTax2,
			string Infobar,
			decimal? TolAmtTax1,
			decimal? TolAmtTax2,
			int? CommDueUpdateFlag) CrmPost1Sp(
			DateTime? TCrmDate,
			int? BRmaLine,
			int? ERmaLine,
			DateTime? BLastReturnDate,
			DateTime? ELastReturnDate,
			Guid? RmaRec,
			Guid? ArinvRec,
			Guid? InvHdrRec,
			Guid? RestockFeeTaxProcessId,
			decimal? BalAdj,
			decimal? DAmt,
			int? TDistSeq,
			decimal? TSubTotal,
			string TInvNum,
			decimal? TAccRestTaxBasis,
			decimal? TAccRestTax1,
			decimal? TAccRestTax2,
			int? LinesPerDoc,
			string Infobar,
			decimal? TolAmtTax1,
			decimal? TolAmtTax2,
			int? CommDueUpdateFlag);
	}
}

