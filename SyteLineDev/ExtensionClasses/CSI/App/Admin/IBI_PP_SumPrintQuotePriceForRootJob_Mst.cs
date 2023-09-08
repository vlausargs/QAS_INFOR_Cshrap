//PROJECT NAME: Admin
//CLASS NAME: IBI_PP_SumPrintQuotePriceForRootJob_Mst.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IBI_PP_SumPrintQuotePriceForRootJob_Mst
	{
		decimal? BI_PP_SumPrintQuotePriceForRootJob_MstFn(
			string RefType,
			string RootJob,
			int? RootSuffix,
			string Site);
	}
}

