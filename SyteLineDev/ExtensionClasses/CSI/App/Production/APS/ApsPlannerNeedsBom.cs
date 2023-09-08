//PROJECT NAME: Production
//CLASS NAME: ApsPlannerNeedsBom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsPlannerNeedsBom : IApsPlannerNeedsBom
	{
		readonly IApplicationDB appDB;
		
		public ApsPlannerNeedsBom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsPlannerNeedsBomFn(
			string pJob,
			int? pSuffix)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsPlannerNeedsBom](@pJob, @pSuffix)";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
