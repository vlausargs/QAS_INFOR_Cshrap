//PROJECT NAME: Logistics
//CLASS NAME: PoBlnItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoBlnItem : IPoBlnItem
	{
		readonly IApplicationDB appDB;
		
		
		public PoBlnItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Description,
		string UM,
		int? DerItemExists,
		string PromptMsgNI,
		string PromptMsgOS,
		string PromptBtnsOS,
		string Infobar) PoBlnItemSp(string Item,
		string Description,
		string UM,
		int? DerItemExists,
		string PromptMsgNI,
		string PromptMsgOS,
		string PromptBtnsOS,
		string Infobar)
		{
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			UMType _UM = UM;
			ListYesNoType _DerItemExists = DerItemExists;
			Infobar _PromptMsgNI = PromptMsgNI;
			Infobar _PromptMsgOS = PromptMsgOS;
			Infobar _PromptBtnsOS = PromptBtnsOS;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoBlnItemSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DerItemExists", _DerItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgNI", _PromptMsgNI, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgOS", _PromptMsgOS, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptBtnsOS", _PromptBtnsOS, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Description = _Description;
				UM = _UM;
				DerItemExists = _DerItemExists;
				PromptMsgNI = _PromptMsgNI;
				PromptMsgOS = _PromptMsgOS;
				PromptBtnsOS = _PromptBtnsOS;
				Infobar = _Infobar;
				
				return (Severity, Description, UM, DerItemExists, PromptMsgNI, PromptMsgOS, PromptBtnsOS, Infobar);
			}
		}
	}
}
