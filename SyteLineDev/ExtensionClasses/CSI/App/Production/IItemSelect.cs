//PROJECT NAME: Production
//CLASS NAME: IItemSelect.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IItemSelect
	{
		(int? ReturnCode, string Infobar,
		string Prompt,
		string PromptButtons) ItemSelectSp(string Item,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null);
	}
}

