//PROJECT NAME: Data
//CLASS NAME: IItemWhseCostsIup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemWhseCostsIup
	{
		(int? ReturnCode,
			string Infobar) ItemWhseCostsIupSp(
			string Item,
			string ItemUtil,
			int? InsertFlag,
			int? NewLotTracked,
			int? MatltranAvail,
			decimal? QtyOnHand,
			decimal? QtyMrb,
			Guid? RowPointer,
			string OldCostMethod,
			string NewCostMethod,
			string OldCostType,
			string NewCostType,
			string OldPMTCode,
			string NewPMTCode,
			string OldMatlType,
			string NewMatlType,
			string Infobar);
	}
}

