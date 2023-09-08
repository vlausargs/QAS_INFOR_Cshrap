//PROJECT NAME: Logistics
//CLASS NAME: IBuildTmpCoShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IBuildTmpCoShip
	{
		int? BuildTmpCoShipSp(Guid? ProcessId,
		int? COTypeA,
		int? COTypeB,
		string Status,
		string StartingOrder,
		string EndingOrder,
		string StartingCustomer,
		string EndingCustomer,
		DateTime? StartingOrderDate,
		DateTime? EndingOrderDate,
		DateTime? StartingDueDate,
		DateTime? EndingDueDate,
		string CoitemStatus,
		int? StartingLine,
		int? EndingLine,
		int? StartingRelease,
		int? EndingRelease,
		int? SelectShipments,
		string Whse);
	}
}

