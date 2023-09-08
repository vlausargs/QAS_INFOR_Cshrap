//PROJECT NAME: Production
//CLASS NAME: IPP_SetJobPrintQuotePrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_SetJobPrintQuotePrice
	{
		(int? ReturnCode,
			string Infobar) PP_SetJobPrintQuotePriceSp(
			string Job,
			int? Suffix,
			string Infobar);
	}
}

