//PROJECT NAME: CSIPPIndPack
//CLASS NAME: PP_GetNextQuoteSectionNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_GetNextQuoteSectionNumber
	{
		int PP_GetNextQuoteSectionNumberSp(string QuoteTemplate,
		                                   ref short? NextQuoteTemplateSection);
	}
	
	public class PP_GetNextQuoteSectionNumber : IPP_GetNextQuoteSectionNumber
	{
		readonly IApplicationDB appDB;
		
		public PP_GetNextQuoteSectionNumber(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PP_GetNextQuoteSectionNumberSp(string QuoteTemplate,
		                                          ref short? NextQuoteTemplateSection)
		{
			PP_QuoteTemplateType _QuoteTemplate = QuoteTemplate;
			PP_QuoteTemplateSectionType _NextQuoteTemplateSection = NextQuoteTemplateSection;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_GetNextQuoteSectionNumberSp";
				
				appDB.AddCommandParameter(cmd, "QuoteTemplate", _QuoteTemplate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextQuoteTemplateSection", _NextQuoteTemplateSection, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextQuoteTemplateSection = _NextQuoteTemplateSection;
				
				return Severity;
			}
		}
	}
}
