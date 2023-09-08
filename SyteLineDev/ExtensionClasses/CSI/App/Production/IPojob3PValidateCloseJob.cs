//PROJECT NAME: Production
//CLASS NAME: IPojob3PValidateCloseJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPojob3PValidateCloseJob
	{
		(int? ReturnCode, int? ResponseNum,
		int? ResponseSeq,
		string PromptMsg,
		string PromptButtons,
		string Infobar) Pojob3PValidateCloseJobSp(string TJob,
		int? TSuffix,
		int? TOper,
		decimal? TMove,
		int? TNextOper,
		int? TCloseJob,
		int? ResponseNum,
		int? ResponseSeq,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

