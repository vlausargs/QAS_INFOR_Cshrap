//PROJECT NAME: Production
//CLASS NAME: EngWBGetJobVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class EngWBGetJobVar : IEngWBGetJobVar
	{
		readonly IApplicationDB appDB;
		
		
		public EngWBGetJobVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Job) EngWBGetJobVarSp(string Job = null)
		{
			JobType _Job = Job;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EngWBGetJobVarSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Job = _Job;
				
				return (Severity, Job);
			}
		}
	}
}
