//PROJECT NAME: Admin
//CLASS NAME: BI_PP_SumPrintQuotePriceForRootJob_Mst.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class BI_PP_SumPrintQuotePriceForRootJob_Mst : IBI_PP_SumPrintQuotePriceForRootJob_Mst
	{
		readonly IApplicationDB appDB;
		
		public BI_PP_SumPrintQuotePriceForRootJob_Mst(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? BI_PP_SumPrintQuotePriceForRootJob_MstFn(
			string RefType,
			string RootJob,
			int? RootSuffix,
			string Site)
		{
			RefTypeIJKPRTType _RefType = RefType;
			JobType _RootJob = RootJob;
			SuffixType _RootSuffix = RootSuffix;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BI_PP_SumPrintQuotePriceForRootJob_Mst](@RefType, @RootJob, @RootSuffix, @Site)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootJob", _RootJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootSuffix", _RootSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
