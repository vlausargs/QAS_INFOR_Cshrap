//PROJECT NAME: Logistics
//CLASS NAME: ICiGenP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICiGenP
	{
		(int? ReturnCode, string Infobar) CiGenPSp(string BeginCustomerNum,
		string EndCustomerNum,
		string InvFreq,
		int? ProcessCustOrders,
		string BeginCONum,
		string EndCONum,
		int? ProcessDelOrders,
		string BeginDONum,
		string EndDONum,
		string BeginCustPONum,
		string EndCustPONum,
		int? GenerateByShipDate,
		DateTime? ShipDate,
		int? ProcessShipments,
		decimal? BeginShipment,
		decimal? EndShipment,
		string Infobar,
		string ProcessMode = null,
		Guid? SessionId = null);
	}
}

