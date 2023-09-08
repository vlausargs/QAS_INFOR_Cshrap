//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemwhseCheckCntInProc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemwhseCheckCntInProc
	{
		(int? ReturnCode, string Description, string UM, byte? ItemSerialTracked, byte? ItemLotTracked, decimal? QtyOnHand, string Infobar, string Prompt, string PromptButtons) ItemwhseCheckCntInProcSp(string Whse,
		string Item,
		byte? CheckLotTracked,
		byte? CheckSerialTracked,
		string FormTitle,
		string Description,
		string UM,
		byte? ItemSerialTracked,
		byte? ItemLotTracked,
		decimal? QtyOnHand,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null);
	}
	
	public class ItemwhseCheckCntInProc : IItemwhseCheckCntInProc
	{
		readonly IApplicationDB appDB;
		
		public ItemwhseCheckCntInProc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Description, string UM, byte? ItemSerialTracked, byte? ItemLotTracked, decimal? QtyOnHand, string Infobar, string Prompt, string PromptButtons) ItemwhseCheckCntInProcSp(string Whse,
		string Item,
		byte? CheckLotTracked,
		byte? CheckSerialTracked,
		string FormTitle,
		string Description,
		string UM,
		byte? ItemSerialTracked,
		byte? ItemLotTracked,
		decimal? QtyOnHand,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null)
		{
			WhseType _Whse = Whse;
			ItemType _Item = Item;
			ListYesNoType _CheckLotTracked = CheckLotTracked;
			ListYesNoType _CheckSerialTracked = CheckSerialTracked;
			LongListType _FormTitle = FormTitle;
			DescriptionType _Description = Description;
			UMType _UM = UM;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			QtyTotlType _QtyOnHand = QtyOnHand;
			InfobarType _Infobar = Infobar;
			InfobarType _Prompt = Prompt;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemwhseCheckCntInProcSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckLotTracked", _CheckLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSerialTracked", _CheckSerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormTitle", _FormTitle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyOnHand", _QtyOnHand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				UM = _UM;
				ItemSerialTracked = _ItemSerialTracked;
				ItemLotTracked = _ItemLotTracked;
				QtyOnHand = _QtyOnHand;
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, Description, UM, ItemSerialTracked, ItemLotTracked, QtyOnHand, Infobar, Prompt, PromptButtons);
			}
		}
	}
}
