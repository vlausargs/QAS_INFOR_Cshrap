//PROJECT NAME: Production
//CLASS NAME: IProjPmatlX.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjPmatlX
	{
		(int? ReturnCode, string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		string PAction,
		string PToLaunch,
		int? PoChangeOrd,
		string Infobar,
		string PromptMsg,
		string PromptButtons,
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
		string PFromSite,
		string PFromWhse,
		string PCurRefNum,
		string PCurRefLineSuf) ProjPmatlXSp(int? PAsk,
		string PProjNum,
		int? PTaskNum,
		int? PSeq,
		string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		string PAction,
		string PToLaunch,
		int? PoChangeOrd,
		string Infobar,
		string PromptMsg,
		string PromptButtons,
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
		string ExportType,
		string PFromSite,
		string PFromWhse,
		string PToSite,
		string PToWhse,
		decimal? PQtyOrdered,
		DateTime? PDueDate,
		string PCurRefNum,
		string PCurRefLineSuf,
		string TrnLoc,
		string FOBSite);
	}
}

