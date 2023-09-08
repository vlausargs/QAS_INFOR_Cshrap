//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueGetLocQtyOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IMiscIssueGetLocQtyOnHand
	{
		(int? ReturnCode, decimal? LocQtyOnHand, string PromptMsg, string PromptButtons, string Infobar, int? CallForm) MiscIssueGetLocQtyOnHandSp(string Whse,
		string Item,
		string Loc,
		decimal? QtyIssued,
		string Site,
		decimal? LocQtyOnHand,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? CallForm = 0,
		string UM = null);
	}
	
	public class MiscIssueGetLocQtyOnHand : IMiscIssueGetLocQtyOnHand
	{
		readonly IApplicationDB appDB;
		
		public MiscIssueGetLocQtyOnHand(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? LocQtyOnHand, string PromptMsg, string PromptButtons, string Infobar, int? CallForm) MiscIssueGetLocQtyOnHandSp(string Whse,
		string Item,
		string Loc,
		decimal? QtyIssued,
		string Site,
		decimal? LocQtyOnHand,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? CallForm = 0,
		string UM = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			QtyUnitType _QtyIssued = QtyIssued;
			SiteType _Site = Site;
			QtyUnitType _LocQtyOnHand = LocQtyOnHand;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			IntType _CallForm = CallForm;
			UMType _UM = UM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MiscIssueGetLocQtyOnHandSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyIssued", _QtyIssued, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocQtyOnHand", _LocQtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LocQtyOnHand = _LocQtyOnHand;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				CallForm = _CallForm;
				
				return (Severity, LocQtyOnHand, PromptMsg, PromptButtons, Infobar, CallForm);
			}
		}
	}
}
