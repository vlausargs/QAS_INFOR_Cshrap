//PROJECT NAME: Logistics
//CLASS NAME: IGetCoitemLinePriceNoCONum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCoitemLinePriceNoCONum
	{
		(int? ReturnCode, decimal? CoitemDisc,
		decimal? CoitemLinePrice,
		string Infobar,
		decimal? LineTaxAmount,
		decimal? CoitemPrice,
		int? CurrencyPlaces,
		string TaxAmountLabel,
		string SiteLanguageID) GetCoitemLinePriceNoCONumSp(string PCustomerNum,
		string CoitemItem,
		string PAtlItemUM,
		string PShipSite,
		DateTime? POrderDate,
		decimal? CoitemDisc,
		decimal? CoitemQtyOrdered,
		string CustCurCode,
		string ItemPriceCode,
		decimal? CoitemLinePrice,
		string Infobar,
		decimal? LineTaxAmount = null,
		decimal? CoitemPrice = null,
		int? CurrencyPlaces = null,
		Guid? CoitemRowPointer = null,
		string TaxAmountLabel = null,
		string SiteLanguageID = null);
	}
}

