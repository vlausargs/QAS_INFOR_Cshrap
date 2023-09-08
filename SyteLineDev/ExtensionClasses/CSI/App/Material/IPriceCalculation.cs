//PROJECT NAME: Material
//CLASS NAME: IPriceCalculation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPriceCalculation
	{
		(int? ReturnCode, decimal? pPrice,
		string pCurrencyCode,
		string Infobar) PriceCalculationSp(string pSite,
		string pItem,
		string pCustNum,
		DateTime? pOrderDate,
		decimal? pQuantityOrdered,
		string pUOM,
		decimal? pPrice,
		string pCurrencyCode,
		string Infobar);
	}
}

