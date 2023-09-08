//PROJECT NAME: Production
//CLASS NAME: PP_SumPrintQuotePriceForCoLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_SumPrintQuotePriceForCoLine : IPP_SumPrintQuotePriceForCoLine
	{
		readonly IApplicationDB appDB;
		
		public PP_SumPrintQuotePriceForCoLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PP_SumPrintQuotePriceForCoLineFn(
			string RefType,
			string CoNum,
			int? CoLine,
			int? CoRelease)
		{
			RefTypeIJKPRTType _RefType = RefType;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PP_SumPrintQuotePriceForCoLine](@RefType, @CoNum, @CoLine, @CoRelease)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
