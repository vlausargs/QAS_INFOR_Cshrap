//PROJECT NAME: Production
//CLASS NAME: PP_SetQuotePrintQuotePrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_SetQuotePrintQuotePrice : IPP_SetQuotePrintQuotePrice
	{
		readonly IApplicationDB appDB;
		
		public PP_SetQuotePrintQuotePrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PP_SetQuotePrintQuotePriceSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			int? SectionNum,
			int? PriceQuoteLine,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			PP_QuoteSectionType _SectionNum = SectionNum;
			PP_QuoteLineType _PriceQuoteLine = PriceQuoteLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_SetQuotePrintQuotePriceSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SectionNum", _SectionNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceQuoteLine", _PriceQuoteLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
