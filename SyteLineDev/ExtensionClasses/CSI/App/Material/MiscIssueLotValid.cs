//PROJECT NAME: CSIMaterial
//CLASS NAME: MiscIssueLotValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IMiscIssueLotValid
	{
		(int? ReturnCode, string PromptExpLotMsg, string PromptExpLotButtons, string Infobar, string LotTrxRestrictCode) MiscIssueLotValidSp(string Lot,
		string Item,
		string Whse,
		string Loc,
		string Action,
		string Title = null,
		string PromptExpLotMsg = null,
		string PromptExpLotButtons = null,
		string Infobar = null,
		string LotTrxRestrictCode = null);
	}
	
	public class MiscIssueLotValid : IMiscIssueLotValid
	{
		readonly IApplicationDB appDB;
		
		public MiscIssueLotValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptExpLotMsg, string PromptExpLotButtons, string Infobar, string LotTrxRestrictCode) MiscIssueLotValidSp(string Lot,
		string Item,
		string Whse,
		string Loc,
		string Action,
		string Title = null,
		string PromptExpLotMsg = null,
		string PromptExpLotButtons = null,
		string Infobar = null,
		string LotTrxRestrictCode = null)
		{
			LotType _Lot = Lot;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			InfobarType _Action = Action;
			LongListType _Title = Title;
			InfobarType _PromptExpLotMsg = PromptExpLotMsg;
			InfobarType _PromptExpLotButtons = PromptExpLotButtons;
			InfobarType _Infobar = Infobar;
			TransRestrictionCodeType _LotTrxRestrictCode = LotTrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MiscIssueLotValidSp";
				
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Title", _Title, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptExpLotMsg", _PromptExpLotMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptExpLotButtons", _PromptExpLotButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTrxRestrictCode", _LotTrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptExpLotMsg = _PromptExpLotMsg;
				PromptExpLotButtons = _PromptExpLotButtons;
				Infobar = _Infobar;
				LotTrxRestrictCode = _LotTrxRestrictCode;
				
				return (Severity, PromptExpLotMsg, PromptExpLotButtons, Infobar, LotTrxRestrictCode);
			}
		}
	}
}
