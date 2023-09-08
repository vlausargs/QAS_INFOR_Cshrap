//PROJECT NAME: Data
//CLASS NAME: ITH_InventoryBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITH_InventoryBalance
	{
		int? TH_InventoryBalanceSp(
			string ItemStarting = null,
			string ItemEnding = null,
			DateTime? TransDateStarting = null,
			DateTime? TransDateEnding = null,
			string WhseStarting = null,
			string WhseEnding = null,
			string LocStarting = null,
			string LocEnding = null);
	}
}

