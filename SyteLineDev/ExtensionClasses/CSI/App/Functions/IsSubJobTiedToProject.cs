//PROJECT NAME: Data
//CLASS NAME: IsSubJobTiedToProject.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsSubJobTiedToProject : IIsSubJobTiedToProject
	{
		readonly IApplicationDB appDB;
		
		public IsSubJobTiedToProject(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsSubJobTiedToProjectFn(
			string pJob,
			int? pSuffix,
			int? CheckJobStatus)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			ListYesNoType _CheckJobStatus = CheckJobStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsSubJobTiedToProject](@pJob, @pSuffix, @CheckJobStatus)";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckJobStatus", _CheckJobStatus, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
