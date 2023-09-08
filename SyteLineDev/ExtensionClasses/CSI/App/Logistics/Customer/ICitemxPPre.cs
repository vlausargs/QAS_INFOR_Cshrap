//PROJECT NAME: Logistics
//CLASS NAME: ICitemxPPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICitemxPPre
	{
		(int? ReturnCode,
			int? PoChangeOrd,
			string PromptMsg1,
			string PromptButtons1,
			string PromptMsg2,
			string PromptButtons2,
			string PromptMsg3,
			string PromptButtons3,
			string PromptMsg4,
			string PromptButtons4,
			string Infobar) CitemxPPreSp(
			string SourceRefType,
			string SourceRefNum,
			int? SourceRefLineSuf,
			string SourceItem,
			DateTime? PDueDate,
			int? PoChangeOrd,
			string PromptMsg1,
			string PromptButtons1,
			string PromptMsg2,
			string PromptButtons2,
			string PromptMsg3,
			string PromptButtons3,
			string PromptMsg4,
			string PromptButtons4,
			string Infobar);
	}
}

