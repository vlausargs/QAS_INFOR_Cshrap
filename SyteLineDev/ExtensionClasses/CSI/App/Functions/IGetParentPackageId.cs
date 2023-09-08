//PROJECT NAME: Data
//CLASS NAME: IGetParentPackageId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetParentPackageId
	{
		int? GetParentPackageIdFn(
			decimal? ShipmentId,
			int? PackageID);
	}
}

