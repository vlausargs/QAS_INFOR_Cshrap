//PROJECT NAME: Production
//CLASS NAME: ISetPrintQuoteSectionPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface ISetPrintQuoteSectionPrice
	{
		(int? ReturnCode, string Infobar) SetPrintQuoteSectionPriceSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		int? SectionNum,
		string Infobar);
	}
}

