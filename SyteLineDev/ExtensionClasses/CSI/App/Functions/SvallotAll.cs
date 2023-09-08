//PROJECT NAME: Data
//CLASS NAME: SvallotAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SvallotAll : ISvallotAll
	{
		readonly IApplicationDB appDB;
		
		public SvallotAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? AddLot,
			string PromptAddMsg,
			string PromptAddButtons,
			string PromptExpLotMsg,
			string PromptExpLotButtons,
			string Infobar) SvallotAllSp(
			string Whse,
			string Item,
			string Loc,
			string Lot,
			string Action,
			int? NoPerm = 0,
			string Title = null,
			int? AddLot = null,
			string PromptAddMsg = null,
			string PromptAddButtons = null,
			string PromptExpLotMsg = null,
			string PromptExpLotButtons = null,
			string Infobar = null,
			string Site = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			LongListType _Action = Action;
			ListYesNoType _NoPerm = NoPerm;
			LongListType _Title = Title;
			ByteType _AddLot = AddLot;
			InfobarType _PromptAddMsg = PromptAddMsg;
			InfobarType _PromptAddButtons = PromptAddButtons;
			InfobarType _PromptExpLotMsg = PromptExpLotMsg;
			InfobarType _PromptExpLotButtons = PromptExpLotButtons;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SvallotAllSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoPerm", _NoPerm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Title", _Title, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddLot", _AddLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptAddMsg", _PromptAddMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptAddButtons", _PromptAddButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptExpLotMsg", _PromptExpLotMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptExpLotButtons", _PromptExpLotButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AddLot = _AddLot;
				PromptAddMsg = _PromptAddMsg;
				PromptAddButtons = _PromptAddButtons;
				PromptExpLotMsg = _PromptExpLotMsg;
				PromptExpLotButtons = _PromptExpLotButtons;
				Infobar = _Infobar;
				
				return (Severity, AddLot, PromptAddMsg, PromptAddButtons, PromptExpLotMsg, PromptExpLotButtons, Infobar);
			}
		}
	}
}
