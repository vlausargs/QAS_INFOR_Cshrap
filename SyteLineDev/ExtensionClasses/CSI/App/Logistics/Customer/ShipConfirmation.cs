//PROJECT NAME: Logistics
//CLASS NAME: ShipConfirmation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ShipConfirmation : IShipConfirmation
	{
		readonly IApplicationDB appDB;
		
		
		public ShipConfirmation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InfoBar) ShipConfirmationSp(decimal? ShipmentId,
		DateTime? Curdate,
		int? IgnoreLCR,
		int? IgnoreCount,
		string InfoBar)
		{
			ShipmentIDType _ShipmentId = ShipmentId;
			DateTimeType _Curdate = Curdate;
			ListYesNoType _IgnoreLCR = IgnoreLCR;
			ListYesNoType _IgnoreCount = IgnoreCount;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShipConfirmationSp";
				
				appDB.AddCommandParameter(cmd, "ShipmentId", _ShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Curdate", _Curdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IgnoreLCR", _IgnoreLCR, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IgnoreCount", _IgnoreCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
