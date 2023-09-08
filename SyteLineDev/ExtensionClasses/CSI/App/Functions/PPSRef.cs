//PROJECT NAME: Data
//CLASS NAME: PPSRef.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PPSRef : IPPSRef
	{
		readonly IApplicationDB appDB;
		
		public PPSRef(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string PPSRefFn(
			string job,
			int? suffix)
		{
			JobType _job = job;
			SuffixType _suffix = suffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PPSRef](@job, @suffix)";
				
				appDB.AddCommandParameter(cmd, "job", _job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "suffix", _suffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
