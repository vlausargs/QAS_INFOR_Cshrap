//PROJECT NAME: Data
//CLASS NAME: CopyBatchRoute.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopyBatchRoute : ICopyBatchRoute
	{
		readonly IApplicationDB appDB;
		
		public CopyBatchRoute(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CopyBatchRouteSp(
			string OldJob,
			int? OldSuffix,
			string NewJob,
			int? NewSuffix)
		{
			JobType _OldJob = OldJob;
			SuffixType _OldSuffix = OldSuffix;
			JobType _NewJob = NewJob;
			SuffixType _NewSuffix = NewSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBatchRouteSp";
				
				appDB.AddCommandParameter(cmd, "OldJob", _OldJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldSuffix", _OldSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewJob", _NewJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSuffix", _NewSuffix, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
