//PROJECT NAME: BusInterface
//CLASS NAME: ILoadProcessSalesOrderLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadProcessSalesOrderLine
	{
		(int? ReturnCode, Guid? RowPointer,
		string Infobar) LoadProcessSalesOrderLineSp(string pCoNum,
		int? pCoLine,
		string pConfirmationRef,
		string pActionCode,
		string pStat,
		string pItem,
		decimal? pQtyOrderedConv,
		string pISOUM,
		string pFixedPriceItemIndicator,
		decimal? pUnitPriceConv,
		string pCurrCode,
		decimal? pExtPrice,
		decimal? pTotPretaxAmt,
		string pDesc,
		string pReservationRef,
		string pWhse,
		DateTime? pRequiredDeliveryDateTime,
		string pDropShipCustNum = null,
		Guid? RowPointer = null,
		string Infobar = null);
	}
}

