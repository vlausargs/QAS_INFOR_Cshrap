//PROJECT NAME: Production
//CLASS NAME: PsitemSetGloVar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PsitemSetGloVar : IPsitemSetGloVar
	{
		readonly IApplicationDB appDB;
		
		
		public PsitemSetGloVar(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PsitemSetGloVarSp(string JobWhse = null,
		string JobRevision = null)
		{
			WhseType _JobWhse = JobWhse;
			RevisionType _JobRevision = JobRevision;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PsitemSetGloVarSp";
				
				appDB.AddCommandParameter(cmd, "JobWhse", _JobWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRevision", _JobRevision, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
