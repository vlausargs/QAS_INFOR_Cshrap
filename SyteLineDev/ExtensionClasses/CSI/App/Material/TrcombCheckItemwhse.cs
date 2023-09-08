//PROJECT NAME: Material
//CLASS NAME: TrcombCheckItemwhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class TrcombCheckItemwhse : ITrcombCheckItemwhse
	{
		readonly IApplicationDB appDB;
		
		
		public TrcombCheckItemwhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg,
		string PromptButtons) TrcombCheckItemwhseSp(string Item,
		string FromSite,
		string FromWhse,
		string ToSite,
		string ToWhse,
		string PromptMsg,
		string PromptButtons)
		{
			ItemType _Item = Item;
			SiteType _FromSite = FromSite;
			WhseType _FromWhse = FromWhse;
			SiteType _ToSite = ToSite;
			WhseType _ToWhse = ToWhse;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TrcombCheckItemwhseSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWhse", _FromWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWhse", _ToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, PromptMsg, PromptButtons);
			}
		}
	}
}
