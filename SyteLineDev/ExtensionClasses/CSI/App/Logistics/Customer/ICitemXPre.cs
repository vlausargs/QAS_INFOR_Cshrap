//PROJECT NAME: Logistics
//CLASS NAME: ICitemXPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICitemXPre
	{
		(int? ReturnCode, string RefNum,
		string FromSite,
		string ParmSite,
		int? PoChangeOrd,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2,
		string PromptMsg3,
		string PromptButtons3,
		string PromptMsg4,
		string PromptButtons4,
		string PromptMsg5,
		string PromptButtons5,
		string Infobar,
		string FromWhse) CitemXPreSp(string SourceFile,
		string SourceRefType,
		string SourceRefNum,
		int? SourceRefLineSuf,
		int? SourceRefRelease,
		string SourceItem,
		DateTime? PDueDate,
		string RefNum,
		string FromSite,
		string ParmSite,
		int? PoChangeOrd,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2,
		string PromptMsg3,
		string PromptButtons3,
		string PromptMsg4,
		string PromptButtons4,
		string PromptMsg5,
		string PromptButtons5,
		string Infobar,
		string FromWhse = null);
	}
}

