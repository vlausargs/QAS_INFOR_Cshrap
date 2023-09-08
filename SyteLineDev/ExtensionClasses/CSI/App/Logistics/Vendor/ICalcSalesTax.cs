//PROJECT NAME: Logistics
//CLASS NAME: ICalcSalesTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICalcSalesTax
	{
		(int? ReturnCode, decimal? PSalesTax) CalcSalesTaxSp(int? PTaxSystem,
		string PTaxCode,
		decimal? PTaxBasis,
		string PVendNum,
		decimal? PSalesTax);
	}
}

