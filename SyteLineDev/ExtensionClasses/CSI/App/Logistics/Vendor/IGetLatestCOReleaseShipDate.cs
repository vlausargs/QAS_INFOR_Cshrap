//PROJECT NAME: Logistics
//CLASS NAME: IGetLatestCOReleaseShipDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetLatestCOReleaseShipDate
	{
		DateTime? GetLatestCOReleaseShipDateFn(
			string CoNum,
			int? CoLine);
	}
}

