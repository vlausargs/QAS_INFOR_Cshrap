//PROJECT NAME: Data
//CLASS NAME: IItemNotUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemNotUsed
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ItemNotUsedSp(
			string TransactionType = "ABCDEFGHILMNOPRSTW",
			string RefType = "IORPJTSKWCF",
			DateTime? TransDateStarting = null,
			DateTime? TransDateEnding = null,
			string WarehouseStarting = null,
			string WarehouseEnding = null,
			string ProductCodeStarting = null,
			string ProductCodeEnding = null,
			string ItemStarting = null,
			string ItemEnding = null,
			string LocationStarting = null,
			string LocationEnding = null,
			string PlannerCodeStarting = null,
			string PlannerCodeEnding = null,
			decimal? TransNumStarting = null,
			decimal? TransNumEnding = null,
			string ReasonCodeStarting = null,
			string ReasonCodeEnding = null,
			int? TransDateStartingOffset = null,
			int? TransDateEndingOffset = null,
			int? DisplayHeader = null);
	}
}

