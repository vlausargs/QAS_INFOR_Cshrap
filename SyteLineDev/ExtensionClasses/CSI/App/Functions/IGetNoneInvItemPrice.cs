//PROJECT NAME: Data
//CLASS NAME: IGetNoneInvItemPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetNoneInvItemPrice
	{
		(int? ReturnCode,
			decimal? ItemPrice,
			string Infobar) GetNoneInvItemPriceSp(
			string Item,
			string ItemUM,
			decimal? ItemQty,
			decimal? ItemPrice,
			string Infobar);
	}
}

