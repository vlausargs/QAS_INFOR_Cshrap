//PROJECT NAME: Data
//CLASS NAME: IECOMM_OrderHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IECOMM_OrderHeader
	{
		(int? ReturnCode,
			string OrdNumber,
			int? ErrorOccured,
			string Infobar,
			decimal? InvoiceAmount) ECOMM_OrderHeaderSp(
			string CustomerNumber,
			int? ShipToNumber,
			string PONumber,
			string CarrierCode,
			string WarehouseID,
			string OrderType,
			string Comment,
			string ShippingInstr,
			string EmailAddress,
			string OrdNumber,
			int? ErrorOccured,
			string Infobar,
			decimal? InvoiceAmount);
	}
}

