//PROJECT NAME: Production
//CLASS NAME: IPmfCalcNetOfLoss.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfCalcNetOfLoss
	{
		decimal? PmfCalcNetOfLossFn(
			decimal? GrossQty,
			decimal? LossPerc,
			decimal? LossConstant);
	}
}

