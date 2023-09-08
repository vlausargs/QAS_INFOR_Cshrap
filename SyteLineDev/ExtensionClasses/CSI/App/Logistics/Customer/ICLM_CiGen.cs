//PROJECT NAME: Logistics
//CLASS NAME: ICLM_CiGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_CiGen
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_CiGenSp(string BeginCustomerNum,
		string EndCustomerNum,
		int? OtherInvFreq,
		int? DailyInvFreq,
		int? WeeklyInvFreq,
		int? BiMonthlyInvFreq,
		int? MonthlyInvFreq,
		int? HoldInvFreq,
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
		Guid? SessionId,
		string Infobar);
	}
}

