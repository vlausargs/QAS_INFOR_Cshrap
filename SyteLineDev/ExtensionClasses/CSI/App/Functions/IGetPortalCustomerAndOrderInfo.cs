//PROJECT NAME: Data
//CLASS NAME: IGetPortalCustomerAndOrderInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPortalCustomerAndOrderInfo
	{
		(int? ReturnCode,
			Guid? CoRowPointer,
			int? CustSeq,
			string CustName,
			int? B2B,
			string CoType,
			string CurrCode,
			string CoNum,
			string PaymentMethod,
			string ShippingMethod,
			Guid? CustomerCatalogRowPointer,
			string Infobar) GetPortalCustomerAndOrderInfoSp(
			string CustNum,
			Guid? CoRowPointer,
			int? CustSeq,
			string CustName,
			int? B2B,
			string CoType,
			string CurrCode,
			string CoNum,
			string PaymentMethod,
			string ShippingMethod,
			Guid? CustomerCatalogRowPointer,
			string Infobar);
	}
}

