//PROJECT NAME: Production
//CLASS NAME: GenerateTmpShipSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class GenerateTmpShipSeq : IGenerateTmpShipSeq
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateTmpShipSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) GenerateTmpShipSeqSp(Guid? ProcessId,
		int? Select,
		decimal? ShipmentId,
		int? ShipmentLine,
		int? ShipmentSeq,
		decimal? QtyPackages,
		decimal? QtyPerPackage,
		string Loc,
		string Lot,
		decimal? QtyPicked,
		decimal? QtyShipped,
		int? PackageId,
		string InfoBar)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _Select = Select;
			ShipmentIDType _ShipmentId = ShipmentId;
			ShipmentLineType _ShipmentLine = ShipmentLine;
			ShipmentSequenceType _ShipmentSeq = ShipmentSeq;
			QtyUnitNoNegType _QtyPackages = QtyPackages;
			QtyUnitNoNegType _QtyPerPackage = QtyPerPackage;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyUnitNoNegType _QtyPicked = QtyPicked;
			QtyUnitNoNegType _QtyShipped = QtyShipped;
			PackageIDType _PackageId = PackageId;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateTmpShipSeqSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Select", _Select, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentLine", _ShipmentLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentSeq", _ShipmentSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPackages", _QtyPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPerPackage", _QtyPerPackage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPicked", _QtyPicked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyShipped", _QtyShipped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageId", _PackageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
