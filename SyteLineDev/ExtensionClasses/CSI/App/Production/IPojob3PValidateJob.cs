//PROJECT NAME: Production
//CLASS NAME: IPojob3PValidateJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPojob3PValidateJob
	{
		(int? ReturnCode, string TCompleteUM,
		string TScrappedUM,
		string TMovedUM,
		int? TPromptForLoc,
		int? TPromptForLot,
		int? TPromptCloseJob,
		int? TPromptIssueParent,
		int? TSerNumTracked,
		string TSerNumPrefix,
		string Infobar) Pojob3PValidateJobSp(string TJob,
		int? TSuffix,
		int? TOper,
		int? TNextOper,
		string TCompleteUM,
		string TScrappedUM,
		string TMovedUM,
		int? TPromptForLoc,
		int? TPromptForLot,
		int? TPromptCloseJob,
		int? TPromptIssueParent,
		int? TSerNumTracked,
		string TSerNumPrefix,
		string Infobar);
	}
}

