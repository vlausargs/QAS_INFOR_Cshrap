//PROJECT NAME: Production
//CLASS NAME: ItemSelect.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ItemSelect : IItemSelect
	{
		readonly IApplicationDB appDB;
		
		
		public ItemSelect(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		string Prompt,
		string PromptButtons) ItemSelectSp(string Item,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null)
		{
			ItemType _Item = Item;
			Infobar _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemSelectSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, Prompt, PromptButtons);
			}
		}
	}
}
