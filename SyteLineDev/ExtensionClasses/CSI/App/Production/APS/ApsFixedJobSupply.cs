//PROJECT NAME: Production
//CLASS NAME: ApsFixedJobSupply.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsFixedJobSupply : IApsFixedJobSupply
	{
		readonly IApplicationDB appDB;
		
		public ApsFixedJobSupply(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsFixedJobSupplyFn(
			string PJob,
			int? PSuffix)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsFixedJobSupply](@PJob, @PSuffix)";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
