//PROJECT NAME: Data
//CLASS NAME: IItemlocDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemlocDelete
	{
		(int? ReturnCode,
			string Infobar,
			int? WasRecordDeleted,
			int? DeletedRank,
			string PromptMsg) ItemlocDeleteSp(
			string Whse,
			string Item,
			string Loc,
			int? DelPermLocs = 0,
			int? Resequence = 0,
			string Infobar = null,
			int? ItemLotTracked = null,
			int? WasRecordDeleted = 0,
			int? CallFromMassDelete = 0,
			int? DeletedRank = 0,
			string PromptMsg = null);
	}
}

