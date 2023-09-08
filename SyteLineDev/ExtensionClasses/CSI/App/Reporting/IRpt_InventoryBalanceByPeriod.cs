//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InventoryBalanceByPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InventoryBalanceByPeriod
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InventoryBalanceByPeriodSp(string ItemStarting = null,
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
		int? DisplayHeader = null,
		string pSite = null);
	}
}

