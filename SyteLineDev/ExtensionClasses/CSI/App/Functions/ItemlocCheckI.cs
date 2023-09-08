//PROJECT NAME: Data
//CLASS NAME: ItemlocCheckI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemlocCheckI : IItemlocCheckI
	{
		readonly IApplicationDB appDB;
		
		public ItemlocCheckI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			string Prompt,
			string PromptButtons) ItemlocCheckISp(
			string Item,
			string Whse,
			string Site,
			string Loc,
			int? ForTransitLoc = 0,
			int? Outgoing = 0,
			string Infobar = null,
			string Prompt = null,
			string PromptButtons = null)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			SiteType _Site = Site;
			LocType _Loc = Loc;
			ListYesNoType _ForTransitLoc = ForTransitLoc;
			ListYesNoType _Outgoing = Outgoing;
			InfobarType _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemlocCheckISp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForTransitLoc", _ForTransitLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Outgoing", _Outgoing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, Prompt, PromptButtons);
			}
		}
	}
}
