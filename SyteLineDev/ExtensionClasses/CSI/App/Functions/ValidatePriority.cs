//PROJECT NAME: Data
//CLASS NAME: ValidatePriority.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidatePriority : IValidatePriority
	{
		readonly IApplicationDB appDB;
		
		public ValidatePriority(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ValidatePrioritySp(
			string PApsSite,
			int? PNewPriority,
			int? POldPriority)
		{
			ApsSiteType _PApsSite = PApsSite;
			MrpPriorityType _PNewPriority = PNewPriority;
			MrpPriorityType _POldPriority = POldPriority;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidatePrioritySp";
				
				appDB.AddCommandParameter(cmd, "PApsSite", _PApsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewPriority", _PNewPriority, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldPriority", _POldPriority, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
