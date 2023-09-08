//PROJECT NAME: Material
//CLASS NAME: istkrPreAddUpdVal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IistkrPreAddUpdVal
	{
		(int? ReturnCode, decimal? ItmMatlCost, decimal? ItmLbrCost, decimal? ItmFovhdCost, decimal? ItmVovhdCost, decimal? ItmOutCost, string Infobar, string Prompt, string Buttons, short? NextRank) istkrPreAddUpdValSp(string Whse = null,
		string Item = null,
		string Action = "@%add",
		byte? ShowCost = null,
		decimal? ItmMatlCost = 0,
		decimal? ItmLbrCost = 0,
		decimal? ItmFovhdCost = 0,
		decimal? ItmVovhdCost = 0,
		decimal? ItmOutCost = 0,
		string Infobar = null,
		string Prompt = null,
		string Buttons = null,
		short? NextRank = null);
	}
	
	public class istkrPreAddUpdVal : IistkrPreAddUpdVal
	{
		readonly IApplicationDB appDB;
		
		public istkrPreAddUpdVal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ItmMatlCost, decimal? ItmLbrCost, decimal? ItmFovhdCost, decimal? ItmVovhdCost, decimal? ItmOutCost, string Infobar, string Prompt, string Buttons, short? NextRank) istkrPreAddUpdValSp(string Whse = null,
		string Item = null,
		string Action = "@%add",
		byte? ShowCost = null,
		decimal? ItmMatlCost = 0,
		decimal? ItmLbrCost = 0,
		decimal? ItmFovhdCost = 0,
		decimal? ItmVovhdCost = 0,
		decimal? ItmOutCost = 0,
		string Infobar = null,
		string Prompt = null,
		string Buttons = null,
		short? NextRank = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			StringType _Action = Action;
			ListYesNoType _ShowCost = ShowCost;
			CostPrcType _ItmMatlCost = ItmMatlCost;
			CostPrcType _ItmLbrCost = ItmLbrCost;
			CostPrcType _ItmFovhdCost = ItmFovhdCost;
			CostPrcType _ItmVovhdCost = ItmVovhdCost;
			CostPrcType _ItmOutCost = ItmOutCost;
			Infobar _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _Buttons = Buttons;
			ItemlocRankType _NextRank = NextRank;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "istkrPreAddUpdValSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowCost", _ShowCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItmMatlCost", _ItmMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItmLbrCost", _ItmLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItmFovhdCost", _ItmFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItmVovhdCost", _ItmVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItmOutCost", _ItmOutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NextRank", _NextRank, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItmMatlCost = _ItmMatlCost;
				ItmLbrCost = _ItmLbrCost;
				ItmFovhdCost = _ItmFovhdCost;
				ItmVovhdCost = _ItmVovhdCost;
				ItmOutCost = _ItmOutCost;
				Infobar = _Infobar;
				Prompt = _Prompt;
				Buttons = _Buttons;
				NextRank = _NextRank;
				
				return (Severity, ItmMatlCost, ItmLbrCost, ItmFovhdCost, ItmVovhdCost, ItmOutCost, Infobar, Prompt, Buttons, NextRank);
			}
		}
	}
}
