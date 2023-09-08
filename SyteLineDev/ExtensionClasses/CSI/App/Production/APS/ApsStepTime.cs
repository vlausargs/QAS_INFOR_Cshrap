//PROJECT NAME: Production
//CLASS NAME: ApsStepTime.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsStepTime : IApsStepTime
	{
		readonly IApplicationDB appDB;
		
		public ApsStepTime(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsStepTimeFn(
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PForceFixed = 0)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			Flag _PForceFixed = PForceFixed;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsStepTime](@PJob, @PSuffix, @POperNum, @PForceFixed)";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForceFixed", _PForceFixed, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
