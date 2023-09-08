//PROJECT NAME: Data
//CLASS NAME: ILotLocAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILotLocAdd
	{
		(int? ReturnCode,
			string Infobar) LotLocAddSp(
			string PWhse,
			string PItem,
			string PLoc,
			string PLot,
			decimal? PUnitCost,
			decimal? PMatlCost,
			decimal? PLbrCost,
			decimal? PFovhdCost,
			decimal? PVovhdCost,
			decimal? POutCost,
			string Infobar,
			decimal? LotLocQtyOnHand = 0);
	}
}

