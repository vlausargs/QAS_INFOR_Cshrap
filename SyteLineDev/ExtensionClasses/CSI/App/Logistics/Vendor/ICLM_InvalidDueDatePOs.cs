//PROJECT NAME: Logistics
//CLASS NAME: ICLM_InvalidDueDatePOs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_InvalidDueDatePOs
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_InvalidDueDatePOsSp(string OrderType,
		string Status,
		string StartOrderNum,
		string EndOrderNum,
		int? StartLine,
		int? EndLine,
		int? StartRelease,
		int? EndRelease,
		string StartVendor,
		string EndVendor,
		DateTime? StartOrderDate,
		DateTime? EndOrderDate,
		DateTime? StartReleaseDate,
		DateTime? EndReleaseDate,
		DateTime? StartDueDate,
		DateTime? EndDueDate,
		int? MoveDirection);
	}
}

