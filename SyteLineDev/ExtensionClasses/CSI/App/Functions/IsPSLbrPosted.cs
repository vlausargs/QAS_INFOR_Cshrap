//PROJECT NAME: Data
//CLASS NAME: IsPSLbrPosted.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsPSLbrPosted : IIsPSLbrPosted
	{
		readonly IApplicationDB appDB;
		
		public IsPSLbrPosted(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsPSLbrPostedFn(
			string Job,
			int? Suffix,
			string Type)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			JobTypeType _Type = Type;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsPSLbrPosted](@Job, @Suffix, @Type)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
