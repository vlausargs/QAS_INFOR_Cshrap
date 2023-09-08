//PROJECT NAME: Production
//CLASS NAME: IPP_GetItemInfoAndPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_GetItemInfoAndPrice
	{
		(int? ReturnCode, string ItemItem,
		string ItemUM,
		decimal? ItemLengthLinearDimension,
		decimal? ItemWidthLinearDimension,
		decimal? ItemHeightLinearDimension,
		string ItemLinearDimensionUM,
		decimal? ItemWeight,
		string ItemWeightUM,
		decimal? ItemPrice) PP_GetItemInfoAndPriceSp(string Item,
		string CustNum,
		decimal? ItemQtyOrdered,
		string MaterialSource,
		string PaperSource,
		string ItemItem,
		string ItemUM,
		decimal? ItemLengthLinearDimension,
		decimal? ItemWidthLinearDimension,
		decimal? ItemHeightLinearDimension,
		string ItemLinearDimensionUM,
		decimal? ItemWeight,
		string ItemWeightUM,
		decimal? ItemPrice);
	}
}

