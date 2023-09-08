//PROJECT NAME: Production
//CLASS NAME: ApsPSAttribId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPSAttribId : IApsPSAttribId
	{
		readonly IApplicationDB appDB;
		
		public ApsPSAttribId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsPSAttribIdFn(
			string PJob,
			int? PSuffix)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsPSAttribId](@PJob, @PSuffix)";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
