//PROJECT NAME: Production
//CLASS NAME: IChkMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IChkMatl
	{
		(int? ReturnCode, string Infobar,
		string Prompt,
		string PromptButtons) ChkMatlSp(string Item,
		string ItmItem,
		string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		string Infobar,
		string Prompt = null,
		string PromptButtons = null);
	}
}

