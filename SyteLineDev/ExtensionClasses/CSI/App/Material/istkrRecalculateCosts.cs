//PROJECT NAME: Material
//CLASS NAME: istkrRecalculateCosts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IistkrRecalculateCosts
	{
		(int? ReturnCode, decimal? QtyOnHand, decimal? MatlCost, decimal? LbrCost, decimal? FovhdCost, decimal? VovhdCost, decimal? OutCost, string Infobar, string Prompt, string PromptButtons) istkrRecalculateCostsSp(string Item,
		string UM,
		decimal? QtyOnHand,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		byte? WarnIfSlowMoving,
		byte? ErrorIfSlowMoving,
		byte? WarnIfObsolete,
		byte? ErrorIfObsolete,
		string Infobar,
		string Prompt,
		string PromptButtons);
	}
	
	public class istkrRecalculateCosts : IistkrRecalculateCosts
	{
		readonly IApplicationDB appDB;
		
		public istkrRecalculateCosts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? QtyOnHand, decimal? MatlCost, decimal? LbrCost, decimal? FovhdCost, decimal? VovhdCost, decimal? OutCost, string Infobar, string Prompt, string PromptButtons) istkrRecalculateCostsSp(string Item,
		string UM,
		decimal? QtyOnHand,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		byte? WarnIfSlowMoving,
		byte? ErrorIfSlowMoving,
		byte? WarnIfObsolete,
		byte? ErrorIfObsolete,
		string Infobar,
		string Prompt,
		string PromptButtons)
		{
			ItemType _Item = Item;
			UMType _UM = UM;
			QtyUnitType _QtyOnHand = QtyOnHand;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			ListYesNoType _WarnIfSlowMoving = WarnIfSlowMoving;
			ListYesNoType _ErrorIfSlowMoving = ErrorIfSlowMoving;
			ListYesNoType _WarnIfObsolete = WarnIfObsolete;
			ListYesNoType _ErrorIfObsolete = ErrorIfObsolete;
			Infobar _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "istkrRecalculateCostsSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WarnIfSlowMoving", _WarnIfSlowMoving, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorIfSlowMoving", _ErrorIfSlowMoving, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarnIfObsolete", _WarnIfObsolete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorIfObsolete", _ErrorIfObsolete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				QtyOnHand = _QtyOnHand;
				MatlCost = _MatlCost;
				LbrCost = _LbrCost;
				FovhdCost = _FovhdCost;
				VovhdCost = _VovhdCost;
				OutCost = _OutCost;
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, QtyOnHand, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, Infobar, Prompt, PromptButtons);
			}
		}
	}
}
