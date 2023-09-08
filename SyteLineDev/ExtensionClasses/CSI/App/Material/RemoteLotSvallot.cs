//PROJECT NAME: Material
//CLASS NAME: RemoteLotSvallot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IRemoteLotSvallot
	{
		(int? ReturnCode, byte? AddLot, string PromptMsg, string PromptButtons, string PromptExpLotMsg, string PromptExpLotButtons, string Infobar) RemoteLotSvallotSp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string Title,
		string RemoteSiteLot,
		byte? AddLot,
		string PromptMsg,
		string PromptButtons,
		string PromptExpLotMsg,
		string PromptExpLotButtons,
		string Infobar,
		string Site = null);
	}
	
	public class RemoteLotSvallot : IRemoteLotSvallot
	{
		readonly IApplicationDB appDB;
		
		public RemoteLotSvallot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? AddLot, string PromptMsg, string PromptButtons, string PromptExpLotMsg, string PromptExpLotButtons, string Infobar) RemoteLotSvallotSp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string Title,
		string RemoteSiteLot,
		byte? AddLot,
		string PromptMsg,
		string PromptButtons,
		string PromptExpLotMsg,
		string PromptExpLotButtons,
		string Infobar,
		string Site = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			LongListType _Title = Title;
			ListExistingCreateBothType _RemoteSiteLot = RemoteSiteLot;
			ByteType _AddLot = AddLot;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _PromptExpLotMsg = PromptExpLotMsg;
			InfobarType _PromptExpLotButtons = PromptExpLotButtons;
			InfobarType _Infobar = Infobar;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteLotSvallotSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Title", _Title, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RemoteSiteLot", _RemoteSiteLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AddLot", _AddLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptExpLotMsg", _PromptExpLotMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptExpLotButtons", _PromptExpLotButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AddLot = _AddLot;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				PromptExpLotMsg = _PromptExpLotMsg;
				PromptExpLotButtons = _PromptExpLotButtons;
				Infobar = _Infobar;
				
				return (Severity, AddLot, PromptMsg, PromptButtons, PromptExpLotMsg, PromptExpLotButtons, Infobar);
			}
		}
	}
}
