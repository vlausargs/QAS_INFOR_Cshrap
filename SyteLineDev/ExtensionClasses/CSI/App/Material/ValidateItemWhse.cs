//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateItemWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IValidateItemWhse
	{
		int ValidateItemWhseSp(string Item,
		                       string Whse,
		                       ref string Infobar,
		                       ref string PromptMsg,
		                       ref string PromptButtons);
	}
	
	public class ValidateItemWhse : IValidateItemWhse
	{
		readonly IApplicationDB appDB;
		
		public ValidateItemWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateItemWhseSp(string Item,
		                              string Whse,
		                              ref string Infobar,
		                              ref string PromptMsg,
		                              ref string PromptButtons)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			Infobar _Infobar = Infobar;
			Infobar _PromptMsg = PromptMsg;
			Infobar _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateItemWhseSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return Severity;
			}
		}
	}
}
