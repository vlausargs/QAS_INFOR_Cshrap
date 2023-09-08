//PROJECT NAME: Production
//CLASS NAME: IProjJobXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjJobXref
	{
		(int? ReturnCode,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PAction,
			string PToLaunch,
			string Infobar,
			string PromptMsg,
			string PromptButtons) ProjJobXrefSp(
			int? PAsk,
			string PProjNum,
			int? PTaskNum,
			int? PSeq,
			string PRefType,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PAction,
			string PToLaunch,
			string Infobar,
			string PromptMsg,
			string PromptButtons,
			string ExportType);
	}
}

