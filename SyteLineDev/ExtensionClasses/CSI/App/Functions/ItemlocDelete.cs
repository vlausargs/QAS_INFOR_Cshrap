//PROJECT NAME: Data
//CLASS NAME: ItemlocDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemlocDelete : IItemlocDelete
	{
		readonly IApplicationDB appDB;
		
		public ItemlocDelete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string PromptMsg = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			ListYesNoType _DelPermLocs = DelPermLocs;
			ListYesNoType _Resequence = Resequence;
			InfobarType _Infobar = Infobar;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			ListYesNoType _WasRecordDeleted = WasRecordDeleted;
			ListYesNoType _CallFromMassDelete = CallFromMassDelete;
			ItemlocRankType _DeletedRank = DeletedRank;
			InfobarType _PromptMsg = PromptMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemlocDeleteSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DelPermLocs", _DelPermLocs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Resequence", _Resequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WasRecordDeleted", _WasRecordDeleted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CallFromMassDelete", _CallFromMassDelete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeletedRank", _DeletedRank, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				WasRecordDeleted = _WasRecordDeleted;
				DeletedRank = _DeletedRank;
				PromptMsg = _PromptMsg;
				
				return (Severity, Infobar, WasRecordDeleted, DeletedRank, PromptMsg);
			}
		}
	}
}
