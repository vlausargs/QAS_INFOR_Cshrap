//PROJECT NAME: Production
//CLASS NAME: JobRouteGetPerm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobRouteGetPerm : IJobRouteGetPerm
	{
		readonly IApplicationDB appDB;
		
		
		public JobRouteGetPerm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PAnyCanAdd,
		int? PAnyCanDelete,
		int? PAnyCanUpdate) JobRouteGetPermSp(int? PAnyCanAdd,
		int? PAnyCanDelete,
		int? PAnyCanUpdate)
		{
			ListYesNoType _PAnyCanAdd = PAnyCanAdd;
			ListYesNoType _PAnyCanDelete = PAnyCanDelete;
			ListYesNoType _PAnyCanUpdate = PAnyCanUpdate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobRouteGetPermSp";
				
				appDB.AddCommandParameter(cmd, "PAnyCanAdd", _PAnyCanAdd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAnyCanDelete", _PAnyCanDelete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAnyCanUpdate", _PAnyCanUpdate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAnyCanAdd = _PAnyCanAdd;
				PAnyCanDelete = _PAnyCanDelete;
				PAnyCanUpdate = _PAnyCanUpdate;
				
				return (Severity, PAnyCanAdd, PAnyCanDelete, PAnyCanUpdate);
			}
		}
	}
}
