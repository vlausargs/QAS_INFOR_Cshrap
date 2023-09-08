//PROJECT NAME: Finance
//CLASS NAME: IFaDispGetPurchaseAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.FixedAssets
{
	public interface IFaDispGetPurchaseAmt
	{
		decimal? FaDispGetPurchaseAmtFn(
			string pFaNum);
	}
}

