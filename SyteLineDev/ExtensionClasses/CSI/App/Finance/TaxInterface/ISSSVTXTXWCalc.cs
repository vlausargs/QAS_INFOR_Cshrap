//PROJECT NAME: Finance
//CLASS NAME: ISSSVTXTXWCalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.TaxInterface
{
	public interface ISSSVTXTXWCalc
	{
		(int? ReturnCode,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar) SSSVTXTXWCalcSp(
			string PInvType,
			DateTime? PInvDate,
			string PRefType,
			Guid? pHdrPtr,
			decimal? PSalesTax1,
			decimal? PSalesTax2,
			string Infobar);
	}
}

