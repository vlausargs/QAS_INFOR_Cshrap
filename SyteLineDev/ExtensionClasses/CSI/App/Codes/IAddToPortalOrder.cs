//PROJECT NAME: Codes
//CLASS NAME: IAddToPortalOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IAddToPortalOrder
	{
		(int? ReturnCode, int? CoCustSeq,
		string CoType,
		Guid? CoRowPointer,
		string CoNum,
		string PaymentMethod,
		string CurrCode,
		string ShippingMethod,
		int? CoLine,
		Guid? CoLineRowPointer,
		int? ItemNotPriced,
		string ItmAutoJob,
		string CfgModel,
		string CustName,
		int? B2B,
		Guid? CatalogRowPointer,
		string Infobar) AddToPortalOrderSp(string CoCustNum,
		DateTime? CoOrderDate,
		string CoWhse,
		int? CoConsignment,
		string ColItem,
		string ColUM,
		decimal? ColQtyOrdered,
		string CoShipFromSite = null,
		decimal? ItemPriceConv = null,
		string PortalUsername = null,
		DateTime? ColProjectedDate = null,
		DateTime? ColDueDate = null,
		DateTime? ColPromiseDate = null,
		int? CoCustSeq = null,
		string CoType = null,
		Guid? CoRowPointer = null,
		string CoNum = null,
		string PaymentMethod = null,
		string CurrCode = null,
		string ShippingMethod = null,
		int? CoLine = null,
		Guid? CoLineRowPointer = null,
		int? ItemNotPriced = null,
		string ItmAutoJob = null,
		string CfgModel = null,
		string CustName = null,
		int? B2B = 0,
		Guid? CatalogRowPointer = null,
		string Infobar = null);
	}
}

