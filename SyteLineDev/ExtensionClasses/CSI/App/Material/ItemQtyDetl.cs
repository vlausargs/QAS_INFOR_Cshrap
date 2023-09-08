//PROJECT NAME: Material
//CLASS NAME: ItemQtyDetl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemQtyDetl : IItemQtyDetl
	{
		readonly IApplicationDB appDB;
		
		
		public ItemQtyDetl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? CallForm) ItemQtyDetlSp(string Site,
		string Type,
		string WhseType,
		string Whse,
		string Item,
		string Loc,
		string Lot,
		decimal? DeltaQty,
		int? Return,
		string Action,
		string TrnNum,
		int? TrnLine,
		decimal? TransNum,
		decimal? RsvdNum,
		string Stat,
		int? Byprod,
		string Workkey,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId = null,
		int? CallForm = 0)
		{
			SiteType _Site = Site;
			LongListType _Type = Type;
			LongListType _WhseType = WhseType;
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyUnitNoNegType _DeltaQty = DeltaQty;
			FlagNyType _Return = Return;
			LongListType _Action = Action;
			TrnNumType _TrnNum = TrnNum;
			TrnLineType _TrnLine = TrnLine;
			HugeTransNumType _TransNum = TransNum;
			RsvdNumType _RsvdNum = RsvdNum;
			LongListType _Stat = Stat;
			FlagNyType _Byprod = Byprod;
			LongListType _Workkey = Workkey;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			IntType _CallForm = CallForm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemQtyDetlSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseType", _WhseType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeltaQty", _DeltaQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Return", _Return, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RsvdNum", _RsvdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Byprod", _Byprod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Workkey", _Workkey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				CallForm = _CallForm;
				
				return (Severity, PromptMsg, PromptButtons, Infobar, CallForm);
			}
		}
	}
}
