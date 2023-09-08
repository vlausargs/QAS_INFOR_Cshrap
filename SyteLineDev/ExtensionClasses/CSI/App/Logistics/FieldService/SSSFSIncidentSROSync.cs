//PROJECT NAME: Logistics
//CLASS NAME: SSSFSIncidentSROSync.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSIncidentSROSync : ISSSFSIncidentSROSync
	{
		readonly IApplicationDB appDB;
		
		public SSSFSIncidentSROSync(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSIncidentSROSyncSp(
			string iMode,
			string iIncSroNum,
			int? iParmSyncOptIndex = 0)
		{
			StringType _iMode = iMode;
			FSSRONumType _iIncSroNum = iIncSroNum;
			IntType _iParmSyncOptIndex = iParmSyncOptIndex;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSIncidentSROSyncSp";
				
				appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iIncSroNum", _iIncSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iParmSyncOptIndex", _iParmSyncOptIndex, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
