//PROJECT NAME: Logistics
//CLASS NAME: IGenerateUnpackInventoryTmpShipSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateUnpackInventoryTmpShipSeq
	{
		(int? ReturnCode, string InfoBar) GenerateUnpackInventoryTmpShipSeqSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? ShipmentLine,
		int? ShipmentSeq,
		decimal? QtyPackages,
		decimal? QtyPerPackage,
		string ToLoc,
		string Lot,
		decimal? QtyPicked,
		decimal? QtyShipped,
		int? PackageId,
		string Loc,
		int? ReturnToPickList,
		int? ReduceQtyOnly,
		string InfoBar);
	}
}

