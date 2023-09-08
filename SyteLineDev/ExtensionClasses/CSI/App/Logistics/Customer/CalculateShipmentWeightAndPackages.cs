//PROJECT NAME: Logistics
//CLASS NAME: CalculateShipmentWeightAndPackages.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CalculateShipmentWeightAndPackages : ICalculateShipmentWeightAndPackages
	{
		readonly IApplicationDB appDB;
		
		
		public CalculateShipmentWeightAndPackages(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CalculateShipmentWeightAndPackagesSp(decimal? Shipment,
		int? Recalcflag,
		string Infobar)
		{
			ShipmentIDType _Shipment = Shipment;
			ListYesNoType _Recalcflag = Recalcflag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalculateShipmentWeightAndPackagesSp";
				
				appDB.AddCommandParameter(cmd, "Shipment", _Shipment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Recalcflag", _Recalcflag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
