//PROJECT NAME: Material
//CLASS NAME: ItemLc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemLc : IItemLc
	{
		readonly IApplicationDB appDB;
		
		
		public ItemLc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar) ItemLcSp(string PItem,
		string PWhse,
		string PSite,
		string PTrnLoc,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			ItemType _PItem = PItem;
			WhseType _PWhse = PWhse;
			SiteType _PSite = PSite;
			LocType _PTrnLoc = PTrnLoc;
			FlagNyType _ItemLocQuestionAsked = ItemLocQuestionAsked;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemLcSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLoc", _PTrnLoc, ParameterDirection.Input);
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
