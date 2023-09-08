//PROJECT NAME: CSIMaterial
//CLASS NAME: MSQtyMoveQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IMSQtyMoveQtyValid
	{
		(int? ReturnCode, string PromptButtons, string PromptMsg, string Infobar, int? CallForm) MSQtyMoveQtyValidSp(string FromSite,
		string ToSite,
		string FromWhse,
		string ToWhse,
		string Item,
		decimal? QtyToMove,
		string FromLoc,
		string FromLot,
		string PromptButtons,
		string PromptMsg,
		string Infobar,
		string ImportDocId,
		int? CallForm = 0);
	}
	
	public class MSQtyMoveQtyValid : IMSQtyMoveQtyValid
	{
		readonly IApplicationDB appDB;
		
		public MSQtyMoveQtyValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptButtons, string PromptMsg, string Infobar, int? CallForm) MSQtyMoveQtyValidSp(string FromSite,
		string ToSite,
		string FromWhse,
		string ToWhse,
		string Item,
		decimal? QtyToMove,
		string FromLoc,
		string FromLot,
		string PromptButtons,
		string PromptMsg,
		string Infobar,
		string ImportDocId,
		int? CallForm = 0)
		{
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			WhseType _FromWhse = FromWhse;
			WhseType _ToWhse = ToWhse;
			ItemType _Item = Item;
			QtyUnitType _QtyToMove = QtyToMove;
			LocType _FromLoc = FromLoc;
			LotType _FromLot = FromLot;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _ImportDocId = ImportDocId;
			IntType _CallForm = CallForm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MSQtyMoveQtyValidSp";
				
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyToMove", _QtyToMove, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLoc", _FromLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromLot", _FromLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptButtons = _PromptButtons;
				PromptMsg = _PromptMsg;
				Infobar = _Infobar;
				CallForm = _CallForm;
				
				return (Severity, PromptButtons, PromptMsg, Infobar, CallForm);
			}
		}
	}
}
