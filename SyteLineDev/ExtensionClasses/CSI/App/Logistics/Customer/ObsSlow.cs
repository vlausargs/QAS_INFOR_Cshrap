//PROJECT NAME: Logistics
//CLASS NAME: ObsSlow.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ObsSlow : IObsSlow
	{
		readonly IApplicationDB appDB;
		
		public ObsSlow(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			string Prompt,
			string PromptButtons) ObsSlowSp(
			string Item,
			int? WarnIfSlowMoving = 1,
			int? ErrorIfSlowMoving = 0,
			int? WarnIfObsolete = 0,
			int? ErrorIfObsolete = 1,
			string Infobar = null,
			string Prompt = null,
			string PromptButtons = null,
			string Site = null)
		{
			ItemType _Item = Item;
			Flag _WarnIfSlowMoving = WarnIfSlowMoving;
			Flag _ErrorIfSlowMoving = ErrorIfSlowMoving;
			Flag _WarnIfObsolete = WarnIfObsolete;
			Flag _ErrorIfObsolete = ErrorIfObsolete;
			Infobar _Infobar = Infobar;
			Infobar _Prompt = Prompt;
			Infobar _PromptButtons = PromptButtons;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ObsSlowSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarnIfSlowMoving", _WarnIfSlowMoving, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorIfSlowMoving", _ErrorIfSlowMoving, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarnIfObsolete", _WarnIfObsolete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorIfObsolete", _ErrorIfObsolete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Prompt", _Prompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Prompt = _Prompt;
				PromptButtons = _PromptButtons;
				
				return (Severity, Infobar, Prompt, PromptButtons);
			}
		}
	}
}
