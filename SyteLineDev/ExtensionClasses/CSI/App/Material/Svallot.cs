//PROJECT NAME: Material
//CLASS NAME: Svallot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface ISvallot
	{
		(int? ReturnCode, string PromptAddMsg, string PromptAddButtons, string PromptExpLotMsg, string PromptExpLotButtons, string Infobar, string TrxRestrictCode) SvallotSp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string Action,
		byte? NoPerm = (byte)0,
		string Title = null,
		string PromptAddMsg = null,
		string PromptAddButtons = null,
		string PromptExpLotMsg = null,
		string PromptExpLotButtons = null,
		string Infobar = null,
		byte? JobPreassignLots = null,
		string TrxRestrictCode = null);
	}
	
	public class Svallot : ISvallot
	{
		readonly IApplicationDB appDB;
		
		public Svallot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptAddMsg, string PromptAddButtons, string PromptExpLotMsg, string PromptExpLotButtons, string Infobar, string TrxRestrictCode) SvallotSp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string Action,
		byte? NoPerm = (byte)0,
		string Title = null,
		string PromptAddMsg = null,
		string PromptAddButtons = null,
		string PromptExpLotMsg = null,
		string PromptExpLotButtons = null,
		string Infobar = null,
		byte? JobPreassignLots = null,
		string TrxRestrictCode = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			LongListType _Action = Action;
			ListYesNoType _NoPerm = NoPerm;
			LongListType _Title = Title;
			InfobarType _PromptAddMsg = PromptAddMsg;
			InfobarType _PromptAddButtons = PromptAddButtons;
			InfobarType _PromptExpLotMsg = PromptExpLotMsg;
			InfobarType _PromptExpLotButtons = PromptExpLotButtons;
			InfobarType _Infobar = Infobar;
			ListYesNoType _JobPreassignLots = JobPreassignLots;
			TransRestrictionCodeType _TrxRestrictCode = TrxRestrictCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SvallotSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoPerm", _NoPerm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Title", _Title, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptAddMsg", _PromptAddMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptAddButtons", _PromptAddButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptExpLotMsg", _PromptExpLotMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptExpLotButtons", _PromptExpLotButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobPreassignLots", _JobPreassignLots, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxRestrictCode", _TrxRestrictCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptAddMsg = _PromptAddMsg;
				PromptAddButtons = _PromptAddButtons;
				PromptExpLotMsg = _PromptExpLotMsg;
				PromptExpLotButtons = _PromptExpLotButtons;
				Infobar = _Infobar;
				TrxRestrictCode = _TrxRestrictCode;
				
				return (Severity, PromptAddMsg, PromptAddButtons, PromptExpLotMsg, PromptExpLotButtons, Infobar, TrxRestrictCode);
			}
		}
	}
}
