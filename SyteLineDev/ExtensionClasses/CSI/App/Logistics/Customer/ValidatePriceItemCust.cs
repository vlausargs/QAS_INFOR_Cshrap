//PROJECT NAME: Logistics
//CLASS NAME: ValidatePriceItemCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidatePriceItemCust : IValidatePriceItemCust
	{
		readonly IApplicationDB appDB;
		
		
		public ValidatePriceItemCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string NewItem,
		int? ItemCustExists,
		int? ItemCustUpdate,
		int? ItemCustAdd,
		string WarningMsg,
		string PromptMsg,
		string PromptButtons,
		string Infobar) ValidatePriceItemCustSp(string CustNum,
		string CustItem,
		string Item,
		string NewItem,
		int? ItemCustExists,
		int? ItemCustUpdate,
		int? ItemCustAdd,
		string WarningMsg,
		string PromptMsg,
		string PromptButtons,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustItemType _CustItem = CustItem;
			ItemType _Item = Item;
			ItemType _NewItem = NewItem;
			ListYesNoType _ItemCustExists = ItemCustExists;
			ListYesNoType _ItemCustUpdate = ItemCustUpdate;
			ListYesNoType _ItemCustAdd = ItemCustAdd;
			InfobarType _WarningMsg = WarningMsg;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidatePriceItemCustSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewItem", _NewItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCustExists", _ItemCustExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCustUpdate", _ItemCustUpdate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemCustAdd", _ItemCustAdd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WarningMsg", _WarningMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewItem = _NewItem;
				ItemCustExists = _ItemCustExists;
				ItemCustUpdate = _ItemCustUpdate;
				ItemCustAdd = _ItemCustAdd;
				WarningMsg = _WarningMsg;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, NewItem, ItemCustExists, ItemCustUpdate, ItemCustAdd, WarningMsg, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
