//PROJECT NAME: Logistics
//CLASS NAME: IGetLatestCOReleasePromiseDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetLatestCOReleasePromiseDate
	{
		DateTime? GetLatestCOReleasePromiseDateFn(
			string CoNum,
			int? CoLine);
	}
}

