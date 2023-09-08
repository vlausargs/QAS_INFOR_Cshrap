//PROJECT NAME: CSIMOIndPack
//CLASS NAME: MO_ResourceMaintenanceStatusChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.MOIndPack
{
	public interface IMO_ResourceMaintenanceStatusChange
	{
		int MO_ResourceMaintenanceStatusChangeSp(string FromMaintenanceId,
		                                         string ToMaintenanceId,
		                                         string FromMaintenanceType,
		                                         string ToMaintenanceType,
		                                         string FromResourceType,
		                                         string ToResourceType,
		                                         ref string Infobar);
	}
	
	public class MO_ResourceMaintenanceStatusChange : IMO_ResourceMaintenanceStatusChange
	{
		readonly IApplicationDB appDB;
		
		public MO_ResourceMaintenanceStatusChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int MO_ResourceMaintenanceStatusChangeSp(string FromMaintenanceId,
		                                                string ToMaintenanceId,
		                                                string FromMaintenanceType,
		                                                string ToMaintenanceType,
		                                                string FromResourceType,
		                                                string ToResourceType,
		                                                ref string Infobar)
		{
			MO_MaintenanceIDType _FromMaintenanceId = FromMaintenanceId;
			MO_MaintenanceIDType _ToMaintenanceId = ToMaintenanceId;
			MO_MaintenanceType _FromMaintenanceType = FromMaintenanceType;
			MO_MaintenanceType _ToMaintenanceType = ToMaintenanceType;
			ApsRestypeType _FromResourceType = FromResourceType;
			ApsRestypeType _ToResourceType = ToResourceType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_ResourceMaintenanceStatusChangeSp";
				
				appDB.AddCommandParameter(cmd, "FromMaintenanceId", _FromMaintenanceId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToMaintenanceId", _ToMaintenanceId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromMaintenanceType", _FromMaintenanceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToMaintenanceType", _ToMaintenanceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromResourceType", _FromResourceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToResourceType", _ToResourceType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
