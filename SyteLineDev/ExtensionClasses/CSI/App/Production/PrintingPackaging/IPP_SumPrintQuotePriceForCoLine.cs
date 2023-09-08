//PROJECT NAME: Production
//CLASS NAME: IPP_SumPrintQuotePriceForCoLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_SumPrintQuotePriceForCoLine
	{
		decimal? PP_SumPrintQuotePriceForCoLineFn(
			string RefType,
			string CoNum,
			int? CoLine,
			int? CoRelease);
	}
}

