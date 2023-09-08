//PROJECT NAME: Data
//CLASS NAME: IInventoryBalanceByPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInventoryBalanceByPeriod
	{
		(ICollectionLoadResponse Data, int? ReturnCode) InventoryBalanceByPeriodSp(
			string WarehouseStarting = null,
			string WarehouseENDing = null,
			string ItemStarting = null,
			string ItemEnding = null,
			string ProductCodeStarting = null,
			string ProductCodeENDing = null,
			string PlanCodeStarting = null,
			string PlanCodeENDing = null,
			string MaterialType = null,
			string Source = null,
			string pStocked = null,
			string ABCCode = null,
			int? ExcludeZeroNetRequirements = null,
			int? IncludeTransfers = null,
			int? DisplayHeader = null);
	}
}

