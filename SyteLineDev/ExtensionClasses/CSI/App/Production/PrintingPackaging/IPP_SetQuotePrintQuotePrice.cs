//PROJECT NAME: Production
//CLASS NAME: IPP_SetQuotePrintQuotePrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_SetQuotePrintQuotePrice
	{
		(int? ReturnCode,
			string Infobar) PP_SetQuotePrintQuotePriceSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			int? SectionNum,
			int? PriceQuoteLine,
			string Infobar);
	}
}

