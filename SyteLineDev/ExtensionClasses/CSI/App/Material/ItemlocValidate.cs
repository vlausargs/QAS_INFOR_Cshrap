//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemlocValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemlocValidate
	{
		(int? ReturnCode, string Infobar, string Prompt, string PromptButtons, decimal? ItemQtyOnHand) ItemlocValidateSp(string Item,
		string Whse,
		string Loc,
		byte? VerifyAccounts = (byte)0,
		byte? CheckUserAccount = (byte)0,
		string UserAcct = null,
		string Infobar = null,
		string Prompt = null,
		string PromptButtons = null,
		byte? Outgoing = (byte)1,
		decimal? ItemQtyOnHand = null,
		string OldLoc = null,
		string CoNum = null,
		short? CoLine = null,
		short? CoRelease = null,
		string Lot = null);
	}
	
	public class ItemlocValidate : IItemlocValidate
	{
		readonly IApplicationDB appDB;
		
		public ItemlocValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, string Prompt, string PromptButtons, decimal? ItemQtyOnHand) ItemlocValidateSp(string Item,
		string Whse,
		string Loc,
		byte? VerifyAccounts = (byte)0,
		byte? CheckUserAccount = (byte)0,
		string UserAcct = null,
		string Infobar = null,
		string Prompt = null,
		string PromptButtons = null,
		byte? Outgoing = (byte)1,
		decimal? ItemQtyOnHand = null,
		string OldLoc = null,
		string CoNum = null,
		short? CoLine = null,
		short? CoRelease = null,
		string Lot = null)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			ListYesNoType _VerifyAccounts = VerifyAccounts;
			ListYesNoType _CheckUserAccount = CheckUserAccount;
			AcctType _UserAcct = UserAcct;
			InfobarType _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			ListYesNoType _Outgoing = Outgoing;
			QtyUnitType _ItemQtyOnHand = ItemQtyOnHand;
			LocType _OldLoc = OldLoc;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			LotType _Lot = Lot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemlocValidateSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VerifyAccounts", _VerifyAccounts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckUserAccount", _CheckUserAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserAcct", _UserAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Outgoing", _Outgoing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemQtyOnHand", _ItemQtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OldLoc", _OldLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				ItemQtyOnHand = _ItemQtyOnHand;
				
				return (Severity, Infobar, Prompt, PromptButtons, ItemQtyOnHand);
			}
		}
	}
}
