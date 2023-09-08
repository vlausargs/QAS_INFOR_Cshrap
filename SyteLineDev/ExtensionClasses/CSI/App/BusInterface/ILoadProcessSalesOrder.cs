//PROJECT NAME: BusInterface
//CLASS NAME: ILoadProcessSalesOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadProcessSalesOrder
	{
		(int? ReturnCode, Guid? RowPointer,
		string Infobar) LoadProcessSalesOrderSp(string pCoNum,
		string pActionCode,
		string pOrderType,
		string pStat,
		string pCustNum,
		DateTime? pOrderDate,
		string pContact,
		string pPhone,
		string pWhse,
		string pShipCode,
		string pTermsCode,
		string pSlsman,
		string pCustPo,
		string pConfirmationRef,
		string pShipPartial,
		string pShipEarly,
		string pUseSyteLinePrice,
		string pEstNum,
		string pMerchantID,
		decimal? pTotalAmt,
		string pGatewayStoredToken,
		string pLast4,
		string pCardType,
		decimal? pGatewayTransNum,
		Guid? RowPointer,
		string Infobar);
	}
}

