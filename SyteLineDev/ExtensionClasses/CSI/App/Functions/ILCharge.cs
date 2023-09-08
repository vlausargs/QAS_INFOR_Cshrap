//PROJECT NAME: Data
//CLASS NAME: ILCharge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILCharge
	{
		(int? ReturnCode,
			decimal? PNetAmt,
			decimal? PAmtDisc,
			decimal? PAmtPrepaid,
			decimal? PAmtMiscCharges,
			decimal? PAmtSalesTax,
			decimal? PAmtSalesTax2,
			decimal? PAmtFreight,
			decimal? PAmtTotal) LChargeSp(
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

