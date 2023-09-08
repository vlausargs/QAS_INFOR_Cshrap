//PROJECT NAME: Production
//CLASS NAME: IPP_SumPrintQuotePriceForRootJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPP_SumPrintQuotePriceForRootJob
	{
		(int? ReturnCode, decimal? PriceForRootJob,
		decimal? CoitemExtPrice,
		string Infobar) PP_SumPrintQuotePriceForRootJobSp(string RootJob,
		int? RootSuffix,
		decimal? PriceForRootJob,
		decimal? CoitemExtPrice,
		string Infobar);

		decimal? PP_SumPrintQuotePriceForRootJobFn(
			string RefType,
			string RootJob,
			int? RootSuffix);
	}
}

