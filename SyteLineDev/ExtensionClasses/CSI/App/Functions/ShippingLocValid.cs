//PROJECT NAME: Data
//CLASS NAME: ShippingLocValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ShippingLocValid : IShippingLocValid
	{
		readonly IApplicationDB appDB;
		
		public ShippingLocValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? ItemLocQuestionAsked,
			string PromptMsg,
			string PromptButtons,
			string Infobar) ShippingLocValidSp(
			string Item,
			string Whse,
			string Site,
			string Loc,
			int? ItemLocQuestionAsked,
			string PromptMsg,
			string PromptButtons,
			string Infobar)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			SiteType _Site = Site;
			LocType _Loc = Loc;
			FlagNyType _ItemLocQuestionAsked = ItemLocQuestionAsked;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ShippingLocValidSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLocQuestionAsked", _ItemLocQuestionAsked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemLocQuestionAsked = _ItemLocQuestionAsked;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, ItemLocQuestionAsked, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
