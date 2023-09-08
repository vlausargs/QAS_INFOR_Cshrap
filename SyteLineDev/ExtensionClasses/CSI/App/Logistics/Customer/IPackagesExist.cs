//PROJECT NAME: Logistics
//CLASS NAME: IPackagesExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPackagesExist
	{
		(int? ReturnCode,
		int? UbPackagesExist) PackagesExistSp(
			decimal? ShipmentID,
			int? UbPackagesExist);
	}
}

