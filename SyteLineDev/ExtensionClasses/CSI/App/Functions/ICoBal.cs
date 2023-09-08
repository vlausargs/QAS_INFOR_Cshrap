//PROJECT NAME: Data
//CLASS NAME: ICoBalSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoBal
	{
		decimal? CoBalSp(
			decimal? MiscCharges,
			decimal? Freight,
			decimal? SalesTax,
			decimal? SalesTax2);
	}
}

