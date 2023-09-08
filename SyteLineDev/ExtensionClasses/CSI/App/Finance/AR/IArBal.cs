//PROJECT NAME: Finance
//CLASS NAME: IArBalSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArBal
	{
		decimal? ArBalSp(
			string Type,
			decimal? MiscCharges,
			decimal? Freight,
			decimal? SalesTax,
			decimal? Amount,
			decimal? SalesTax2);
	}
}

