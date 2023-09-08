//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueGetLotQtyOnHand.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IMiscIssueGetLotQtyOnHand
	{
		(int? ReturnCode, decimal? LotQtyOnHand, string PromptMsg, string PromptButtons, string Infobar, int? CallForm) MiscIssueGetLotQtyOnHandSp(string Whse,
		string Item,
		string Loc,
		string Lot,
		decimal? QtyIssued,
		string Site,
		decimal? LotQtyOnHand,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId,
		int? CallForm = 0);
	}
	
	public class MiscIssueGetLotQtyOnHand : IMiscIssueGetLotQtyOnHand
	{
		readonly IApplicationDB appDB;
		
		public MiscIssueGetLotQtyOnHand(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? LotQtyOnHand, string PromptMsg, string PromptButtons, string Infobar, int? CallForm) MiscIssueGetLotQtyOnHandSp(string Whse,
		string Item,
		string Loc,
		string Lot,
		decimal? QtyIssued,
		string Site,
		decimal? LotQtyOnHand,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ImportDocId,
		int? CallForm = 0)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			QtyUnitType _QtyIssued = QtyIssued;
			SiteType _Site = Site;
			QtyUnitType _LotQtyOnHand = LotQtyOnHand;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			IntType _CallForm = CallForm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MiscIssueGetLotQtyOnHandSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyIssued", _QtyIssued, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotQtyOnHand", _LotQtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LotQtyOnHand = _LotQtyOnHand;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				CallForm = _CallForm;
				
				return (Severity, LotQtyOnHand, PromptMsg, PromptButtons, Infobar, CallForm);
			}
		}
	}
}
