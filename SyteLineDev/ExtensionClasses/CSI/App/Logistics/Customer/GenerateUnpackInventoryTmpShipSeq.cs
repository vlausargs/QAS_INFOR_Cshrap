//PROJECT NAME: Logistics
//CLASS NAME: GenerateUnpackInventoryTmpShipSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateUnpackInventoryTmpShipSeq : IGenerateUnpackInventoryTmpShipSeq
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateUnpackInventoryTmpShipSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) GenerateUnpackInventoryTmpShipSeqSp(Guid? ProcessId,
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
		string InfoBar)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _Select = Select;
			ShipmentIDType _ShipmentId = ShipmentId;
			ShipmentLineType _ShipmentLine = ShipmentLine;
			ShipmentSequenceType _ShipmentSeq = ShipmentSeq;
			QtyUnitNoNegType _QtyPackages = QtyPackages;
			QtyUnitNoNegType _QtyPerPackage = QtyPerPackage;
			LocType _ToLoc = ToLoc;
			LotType _Lot = Lot;
			QtyUnitNoNegType _QtyPicked = QtyPicked;
			QtyUnitNoNegType _QtyShipped = QtyShipped;
			PackageIDType _PackageId = PackageId;
			LocType _Loc = Loc;
			ListYesNoType _ReturnToPickList = ReturnToPickList;
			ListYesNoType _ReduceQtyOnly = ReduceQtyOnly;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateUnpackInventoryTmpShipSeqSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentSeq", _ShipmentSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPackages", _QtyPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPerPackage", _QtyPerPackage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLoc", _ToLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPicked", _QtyPicked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageId", _PackageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnToPickList", _ReturnToPickList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReduceQtyOnly", _ReduceQtyOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
