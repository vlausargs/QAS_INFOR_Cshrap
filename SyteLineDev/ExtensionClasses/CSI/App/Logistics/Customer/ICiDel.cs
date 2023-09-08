//PROJECT NAME: Logistics
//CLASS NAME: ICiDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICiDel
	{
		(int? ReturnCode,
			string Infobar) CiDelSp(
			string BeginCustomerNum,
			string EndCustomerNum,
			int? ProcessCustOrders,
			string BeginCONum,
			string EndCONum,
			int? ProcessDelOrders,
			string BeginDONum,
			string EndDONum,
			string BeginCustPONum,
			string EndCustPONum,
			int? ProcessShipments,
			decimal? BeginShipment,
			decimal? EndShipment,
			string Infobar);
	}
}

