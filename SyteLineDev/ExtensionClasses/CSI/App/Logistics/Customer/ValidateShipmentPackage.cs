//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateShipmentPackage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IValidateShipmentPackage
	{
		int ValidateShipmentPackageSp(decimal? ShipmentID,
		                              int? PackageId,
		                              ref string Infobar);
	}
	
	public class ValidateShipmentPackage : IValidateShipmentPackage
	{
		readonly IApplicationDB appDB;
		
		public ValidateShipmentPackage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateShipmentPackageSp(decimal? ShipmentID,
		                                     int? PackageId,
		                                     ref string Infobar)
		{
			ShipmentIDType _ShipmentID = ShipmentID;
			PackageIDType _PackageId = PackageId;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateShipmentPackageSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentID", _ShipmentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageId", _PackageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
