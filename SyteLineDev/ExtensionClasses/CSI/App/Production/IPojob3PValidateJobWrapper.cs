//PROJECT NAME: Production
//CLASS NAME: IPojob3PValidateJobWrapper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPojob3PValidateJobWrapper
	{
		(int? ReturnCode, int? TNextOper,
		string TCompleteUM,
		string TScrappedUM,
		string TMovedUM,
		int? TPromptForLoc,
		int? TPromptForLot,
		int? TPromptCloseJob,
		int? TPromptIssueParent,
		int? TSerNumTracked,
		string TSerNumPrefix,
		int? TIsLastOper,
		string TToLoc,
		string TToLocDescription,
		string TToLot,
		string JobItem,
		int? TPreassignLots,
		string Infobar,
		string JobRevision,
		int? TItemTrackECN) Pojob3PValidateJobWrapperSp(string TJob,
		int? TSuffix,
		int? TOper,
		decimal? TMove,
		string TCurWhse,
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
		int? TIsLastOper,
		string TToLoc,
		string TToLocDescription,
		string TToLot,
		string JobItem,
		int? TPreassignLots,
		string Infobar,
		string JobRevision = null,
		int? TItemTrackECN = null);
	}
}

