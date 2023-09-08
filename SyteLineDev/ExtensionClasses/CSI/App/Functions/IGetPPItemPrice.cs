//PROJECT NAME: Data
//CLASS NAME: IGetPPItemPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPPItemPrice
	{
		(int? ReturnCode,
			decimal? ItemPrice,
			string Infobar) GetPPItemPriceSp(
			string MaterialSource,
			string CustNum,
			string Item,
			string ItemUM,
			decimal? ItemQty,
			string CurrCode,
			decimal? ItemPrice,
			string Infobar);
	}
}

