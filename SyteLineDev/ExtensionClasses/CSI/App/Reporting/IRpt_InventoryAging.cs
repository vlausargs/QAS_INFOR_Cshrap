//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InventoryAging.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InventoryAging
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Rpt_InventoryAgingSp(
			string ItemStarting = null,
			string ItemEnding = null,
			string ProductCodeStarting = null,
			string ProductCodeEnding = null,
			string WhseStarting = null,
			string WhseEnding = null,
			string LocStarting = null,
			string LocEnding = null,
			string AgingBasis = null,
			int? DisplayHeader = null,
			int? AgeDays1 = null,
			int? AgeDays2 = null,
			int? AgeDays3 = null,
			int? AgeDays4 = null,
			int? AgeDays5 = null,
			string AgeDesc1 = null,
			string AgeDesc2 = null,
			string AgeDesc3 = null,
			string AgeDesc4 = null,
			string AgeDesc5 = null,
			string pSite = null,
			string DocumentNumStarting = null,
			string DocumentNumEnding = null);
	}
}

