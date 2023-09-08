//PROJECT NAME: Logistics
//CLASS NAME: ICLM_InvalidDueDateOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_InvalidDueDateOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_InvalidDueDateOrdersSp(string OrderType,
		string Status,
		string StartOrderNum,
		string EndOrderNum,
		int? StartLine,
		int? EndLine,
		int? StartRelease,
		int? EndRelease,
		string StartCustomer,
		string EndCustomer,
		DateTime? StartOrderDate,
		DateTime? EndOrderDate,
		DateTime? StartReleaseDate,
		DateTime? EndReleaseDate,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		int? IsForward,
		string Site);
	}
}

