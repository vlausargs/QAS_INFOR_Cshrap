//PROJECT NAME: CSIProduct
//CLASS NAME: EngWBSetSessionVars.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IEngWBSetSessionVars
	{
		int? EngWBSetSessionVarsSp(string Job = "");
	}
	
	public class EngWBSetSessionVars : IEngWBSetSessionVars
	{
		readonly IApplicationDB appDB;
		
		public EngWBSetSessionVars(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EngWBSetSessionVarsSp(string Job = "")
		{
			JobType _Job = Job;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EngWBSetSessionVarsSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
