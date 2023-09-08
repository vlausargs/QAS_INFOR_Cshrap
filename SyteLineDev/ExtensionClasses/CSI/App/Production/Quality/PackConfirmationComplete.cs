//PROJECT NAME: CSIRSQCS
//CLASS NAME: PackConfirmationComplete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public interface IPackConfirmationComplete
	{
		(int? ReturnCode, string Infobar) PackConfirmationCompleteSp(decimal? ShipmentID,
		string ShipLoc,
		short? QtyPackages,
		decimal? Weight,
		string WeightUM,
		string Packer,
		string Infobar);
	}
	
	public class PackConfirmationComplete : IPackConfirmationComplete
	{
		readonly IApplicationDB appDB;
		
		public PackConfirmationComplete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PackConfirmationCompleteSp(decimal? ShipmentID,
		string ShipLoc,
		short? QtyPackages,
		decimal? Weight,
		string WeightUM,
		string Packer,
		string Infobar)
		{
			ShipmentIDType _ShipmentID = ShipmentID;
			LocType _ShipLoc = ShipLoc;
			PackagesType _QtyPackages = QtyPackages;
			TotalWeightType _Weight = Weight;
			UMType _WeightUM = WeightUM;
			UsernameType _Packer = Packer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PackConfirmationCompleteSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipLoc", _ShipLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyPackages", _QtyPackages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Weight", _Weight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WeightUM", _WeightUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Packer", _Packer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
