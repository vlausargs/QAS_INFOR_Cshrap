//PROJECT NAME: Admin
//CLASS NAME: IBI_PP_SumPrintQuotePriceForCoLine_Mst.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IBI_PP_SumPrintQuotePriceForCoLine_Mst
	{
		decimal? BI_PP_SumPrintQuotePriceForCoLine_MstFn(
			string RefType,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string Site);
	}
}

