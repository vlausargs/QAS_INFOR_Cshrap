//PROJECT NAME: DataCollection
//CLASS NAME: IDcCycleValLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcCycleValLoc
	{
		(int? ReturnCode, int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar) DcCycleValLocSP(string DCItemItem,
		string DCItemWhse,
		string DCItemLoc,
		string DCItemLot,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

