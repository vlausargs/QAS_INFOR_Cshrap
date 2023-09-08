//PROJECT NAME: Material
//CLASS NAME: ITrcombCheckItemwhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ITrcombCheckItemwhse
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons) TrcombCheckItemwhseSp(string Item,
		string FromSite,
		string FromWhse,
		string ToSite,
		string ToWhse,
		string PromptMsg,
		string PromptButtons);
	}
}

