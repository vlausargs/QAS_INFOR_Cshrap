//PROJECT NAME: Production
//CLASS NAME: IPojob3P.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPojob3P
	{
		(int? ReturnCode, string TToLoc,
		string TToLot,
		int? RestartPoint,
		int? TCoby,
		decimal? XJobtranTransNum,
		string PromptMsg,
		string PromptButtons,
		string Infobar) Pojob3PSp(string TJob,
		int? TSuffix,
		int? TOper,
		DateTime? TTransDate,
		decimal? TComplete,
		string TCompleteUM,
		decimal? TScrapped,
		string TScrappedUM,
		decimal? TMove,
		string TMovedUM,
		int? TNextOper,
		string TRsnCode,
		int? TOperComplete,
		int? TCloseJob,
		int? TIssueParent,
		string TCurWhse,
		Guid? JobMatSessionID,
		string TToLoc,
		string TToLot,
		int? RestartPoint,
		int? TCoby,
		decimal? XJobtranTransNum,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

