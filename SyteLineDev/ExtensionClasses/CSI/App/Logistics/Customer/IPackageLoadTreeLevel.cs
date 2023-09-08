//PROJECT NAME: Logistics
//CLASS NAME: IPackageLoadTreeLevel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPackageLoadTreeLevel
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PackageLoadTreeLevelSp(decimal? ShipmentId,
		string Type,
		int? PackageID,
		string Item,
		string Lot,
		string Process);
	}
}

