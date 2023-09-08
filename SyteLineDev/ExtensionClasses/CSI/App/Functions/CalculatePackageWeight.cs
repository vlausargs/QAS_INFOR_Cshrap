//PROJECT NAME: Data
//CLASS NAME: CalculatePackageWeight.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalculatePackageWeight : ICalculatePackageWeight
	{
		readonly IApplicationDB appDB;
		
		public CalculatePackageWeight(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PackageWeight,
			string Infobar) CalculatePackageWeightSp(
			decimal? Shipment,
			int? PackageID,
			decimal? PackageWeight,
			string Infobar)
		{
			ShipmentIDType _Shipment = Shipment;
			PackageIDType _PackageID = PackageID;
			LineWeightType _PackageWeight = PackageWeight;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalculatePackageWeightSp";
				
				appDB.AddCommandParameter(cmd, "Shipment", _Shipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageID", _PackageID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackageWeight", _PackageWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PackageWeight = _PackageWeight;
				Infobar = _Infobar;
				
				return (Severity, PackageWeight, Infobar);
			}
		}
	}
}
