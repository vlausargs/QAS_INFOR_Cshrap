//PROJECT NAME: Production
//CLASS NAME: IPP_ParseOperationTypeFormulas.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_ParseOperationTypeFormulas
	{
		(int? ReturnCode,
			decimal? PrintQuotePrice,
			decimal? QuoteLineAmount,
			decimal? PaperConsumption,
			decimal? SetupHrs,
			decimal? FinishHrs,
			decimal? PcsPerHr,
			string Infobar) PP_ParseOperationTypeFormulasSp(
			string Job,
			int? Suffix,
			int? OperNum,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			int? SectionNum,
			int? PriceQuoteLine,
			string OperType = null,
			string OperTypeCode = null,
			decimal? PrintQuotePrice = null,
			decimal? QuoteLineAmount = null,
			decimal? PaperConsumption = null,
			decimal? SetupHrs = null,
			decimal? FinishHrs = null,
			decimal? PcsPerHr = null,
			string Infobar = null);
	}
}

