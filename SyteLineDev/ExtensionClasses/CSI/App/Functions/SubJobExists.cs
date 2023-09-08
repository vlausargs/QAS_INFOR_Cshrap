//PROJECT NAME: Data
//CLASS NAME: SubJobExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SubJobExists : ISubJobExists
	{
		readonly IApplicationDB appDB;
		
		public SubJobExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SubJobExistsFn(
			string Job,
			int? Suffix)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SubJobExists](@Job, @Suffix)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
