//PROJECT NAME: Production
//CLASS NAME: IPmfCalcGrossOfLoss.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfCalcGrossOfLoss
	{
		decimal? PmfCalcGrossOfLossFn(
			decimal? NetQty,
			decimal? LossPerc,
			decimal? LossConstant);
	}
}

