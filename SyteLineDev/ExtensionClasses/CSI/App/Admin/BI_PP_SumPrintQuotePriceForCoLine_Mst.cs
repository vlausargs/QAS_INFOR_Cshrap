//PROJECT NAME: Admin
//CLASS NAME: BI_PP_SumPrintQuotePriceForCoLine_Mst.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class BI_PP_SumPrintQuotePriceForCoLine_Mst : IBI_PP_SumPrintQuotePriceForCoLine_Mst
	{
		readonly IApplicationDB appDB;
		
		public BI_PP_SumPrintQuotePriceForCoLine_Mst(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? BI_PP_SumPrintQuotePriceForCoLine_MstFn(
			string RefType,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string Site)
		{
			RefTypeIJKPRTType _RefType = RefType;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[BI_PP_SumPrintQuotePriceForCoLine_Mst](@RefType, @CoNum, @CoLine, @CoRelease, @Site)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
