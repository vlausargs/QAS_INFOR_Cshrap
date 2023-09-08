//PROJECT NAME: Production
//CLASS NAME: IPP_SumPrintQuotePriceForSection.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_SumPrintQuotePriceForSection
	{
		decimal? PP_SumPrintQuotePriceForSectionFn(
			string CoNum,
			int? CoLIne,
			int? CoRelease,
			int? SectionNum);
	}
}

