//PROJECT NAME: Data
//CLASS NAME: ISumCol.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISumCol
	{
		(int? ReturnCode,
			decimal? PNetAmt,
			decimal? PAmtDisc,
			decimal? PAmtPrepaid,
			decimal? PAmtMiscCharges,
			decimal? PAmtSalesTax,
			decimal? PAmtSalesTax2,
			decimal? PAmtFreight,
			decimal? PAmtTotal) SumColSp(
			string PTable,
			string PSite,
			string PCoNum,
			int? PCalcTax,
			decimal? PNetAmt,
			decimal? PAmtDisc,
			decimal? PAmtPrepaid,
			decimal? PAmtMiscCharges,
			decimal? PAmtSalesTax,
			decimal? PAmtSalesTax2,
			decimal? PAmtFreight,
			decimal? PAmtTotal);
	}
}

