//PROJECT NAME: BusInterface
//CLASS NAME: ESBGetOperationKey.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class ESBGetOperationKey : IESBGetOperationKey
	{
		readonly IApplicationDB appDB;
		
		public ESBGetOperationKey(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ESBGetOperationKeyFn(
			string Job,
			int? Suffix,
			int? OperNum)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ESBGetOperationKey](@Job, @Suffix, @OperNum)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
