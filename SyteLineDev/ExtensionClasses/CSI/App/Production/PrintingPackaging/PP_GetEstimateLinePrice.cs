//PROJECT NAME: Production
//CLASS NAME: PP_GetEstimateLinePrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_GetEstimateLinePrice : IPP_GetEstimateLinePrice
	{
		readonly IApplicationDB appDB;
		
		public PP_GetEstimateLinePrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PP_GetEstimateLinePriceFn(
			string RootJob,
			int? RootSuffix)
		{
			JobType _RootJob = RootJob;
			SuffixType _RootSuffix = RootSuffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PP_GetEstimateLinePrice](@RootJob, @RootSuffix)";
				
				appDB.AddCommandParameter(cmd, "RootJob", _RootJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootSuffix", _RootSuffix, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
