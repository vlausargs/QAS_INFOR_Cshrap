//PROJECT NAME: Production
//CLASS NAME: IPP_GetEstimateLinePrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_GetEstimateLinePrice
	{
		decimal? PP_GetEstimateLinePriceFn(
			string RootJob,
			int? RootSuffix);
	}
}

