//PROJECT NAME: Material
//CLASS NAME: ValidateNonNettableItemLoc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ValidateNonNettableItemLoc : IValidateNonNettableItemLoc
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateNonNettableItemLoc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateNonNettableItemLocSp(string Item,
		string Whse,
		string Loc,
		decimal? TcQtuToReceive,
		int? TtRcvDrReturn,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			QtyUnitType _TcQtuToReceive = TcQtuToReceive;
			ListYesNoType _TtRcvDrReturn = TtRcvDrReturn;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateNonNettableItemLoc";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcQtuToReceive", _TcQtuToReceive, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TtRcvDrReturn", _TtRcvDrReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
