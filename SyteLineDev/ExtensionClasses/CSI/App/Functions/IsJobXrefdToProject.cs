//PROJECT NAME: Data
//CLASS NAME: IsJobXrefdToProject.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsJobXrefdToProject : IIsJobXrefdToProject
	{
		readonly IApplicationDB appDB;
		
		public IsJobXrefdToProject(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsJobXrefdToProjectFn(
			string pJob,
			int? pSuffix,
			int? CheckRootJob,
			int? CheckJobStatus)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			ListYesNoType _CheckRootJob = CheckRootJob;
			ListYesNoType _CheckJobStatus = CheckJobStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsJobXrefdToProject](@pJob, @pSuffix, @CheckRootJob, @CheckJobStatus)";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckRootJob", _CheckRootJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckJobStatus", _CheckJobStatus, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
