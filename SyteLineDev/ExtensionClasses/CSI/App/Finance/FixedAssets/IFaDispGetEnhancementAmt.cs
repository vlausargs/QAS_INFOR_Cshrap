//PROJECT NAME: Finance
//CLASS NAME: IFaDispGetEnhancementAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.FixedAssets
{
	public interface IFaDispGetEnhancementAmt
	{
		decimal? FaDispGetEnhancementAmtFn(
			string pFaNum);
	}
}

