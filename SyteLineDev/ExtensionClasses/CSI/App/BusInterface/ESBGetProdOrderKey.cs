//PROJECT NAME: BusInterface
//CLASS NAME: ESBGetProdOrderKey.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class ESBGetProdOrderKey : IESBGetProdOrderKey
	{
		readonly IApplicationDB appDB;
		
		public ESBGetProdOrderKey(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ESBGetProdOrderKeyFn(
			string Job,
			int? Suffix)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ESBGetProdOrderKey](@Job, @Suffix)";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
