//PROJECT NAME: Logistics
//CLASS NAME: GenerateShipment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateShipment : IGenerateShipment
	{
		readonly IApplicationDB appDB;
		
		
		public GenerateShipment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) GenerateShipmentSP(Guid? ProcessId,
		string ShipLoc,
		int? Packages,
		decimal? Weight,
		string WeightUm,
		string InfoBar,
		string ShipmentStatus = null)
		{
			RowPointerType _ProcessId = ProcessId;
			LocType _ShipLoc = ShipLoc;
			PackagesType _Packages = Packages;
			TotalWeightType _Weight = Weight;
			UMType _WeightUm = WeightUm;
			InfobarType _InfoBar = InfoBar;
			ShipmentStatusType _ShipmentStatus = ShipmentStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateShipmentSP";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipLoc", _ShipLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Packages", _Packages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WeightUm", _WeightUm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentStatus", _ShipmentStatus, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
