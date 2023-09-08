//PROJECT NAME: Production
//CLASS NAME: PP_SumPrintQuotePriceForSection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_SumPrintQuotePriceForSection : IPP_SumPrintQuotePriceForSection
	{
		readonly IApplicationDB appDB;
		
		public PP_SumPrintQuotePriceForSection(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? PP_SumPrintQuotePriceForSectionFn(
			string CoNum,
			int? CoLIne,
			int? CoRelease,
			int? SectionNum)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLIne = CoLIne;
			CoReleaseType _CoRelease = CoRelease;
			PP_QuoteSectionType _SectionNum = SectionNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PP_SumPrintQuotePriceForSection](@CoNum, @CoLIne, @CoRelease, @SectionNum)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLIne", _CoLIne, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SectionNum", _SectionNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
