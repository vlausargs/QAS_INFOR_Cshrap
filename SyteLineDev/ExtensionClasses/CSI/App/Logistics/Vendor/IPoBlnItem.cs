//PROJECT NAME: Logistics
//CLASS NAME: IPoBlnItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoBlnItem
	{
		(int? ReturnCode, string Description,
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
		string Infobar);
	}
}

