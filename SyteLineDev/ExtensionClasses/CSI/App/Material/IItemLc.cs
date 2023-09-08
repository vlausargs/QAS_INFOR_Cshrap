//PROJECT NAME: Material
//CLASS NAME: IItemLc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemLc
	{
		(int? ReturnCode, int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar) ItemLcSp(string PItem,
		string PWhse,
		string PSite,
		string PTrnLoc,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

