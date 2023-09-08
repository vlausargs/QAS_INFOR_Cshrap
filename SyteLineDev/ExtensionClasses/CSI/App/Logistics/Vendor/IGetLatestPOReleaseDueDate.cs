//PROJECT NAME: Logistics
//CLASS NAME: IGetLatestPOReleaseDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetLatestPOReleaseDueDate
	{
		DateTime? GetLatestPOReleaseDueDateFn(
			string PoNum,
			int? PoLine);
	}
}

