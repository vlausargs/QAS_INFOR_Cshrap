//PROJECT NAME: Logistics
//CLASS NAME: IValidatePriceItemCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidatePriceItemCust
	{
		(int? ReturnCode, string NewItem,
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
		string Infobar);
	}
}

