//PROJECT NAME: Production
//CLASS NAME: ITransAddPre.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ITransAddPre
	{
		(int? ReturnCode, string PRefNum,
		int? PRefLineSuf,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar) TransAddPreSp(string PTrnNum,
		string PItem,
		string PFromSite,
		string PFromWhse,
		string PToSite,
		string PToWhse,
		string PJob,
		int? PSuffix,
		int? POperNum,
		int? PSequence,
		decimal? POrderQty,
		string PRefNum,
		int? PRefLineSuf,
		string TrnLoc,
		string FOBSite,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

