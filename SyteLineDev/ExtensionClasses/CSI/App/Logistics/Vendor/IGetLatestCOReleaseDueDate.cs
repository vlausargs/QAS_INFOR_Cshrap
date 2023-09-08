//PROJECT NAME: Logistics
//CLASS NAME: IGetLatestCOReleaseDueDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetLatestCOReleaseDueDate
	{
		DateTime? GetLatestCOReleaseDueDateFn(
			string CoNum,
			int? CoLine);
	}
}

