//PROJECT NAME: BusInterface
//CLASS NAME: ILoadESBJobOperation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ILoadESBJobOperation
	{
		(int? ReturnCode, int? OperNum,
		string Infobar) LoadESBJobOperationSp(string Job,
		int? Suffix,
		string OperationID,
		string ActionExpression,
		DateTime? StartDate,
		DateTime? EndDate,
		string RunTimeDurationPerUnit,
		string QueueDuration,
		string QueueOverlapDuration,
		string MoveDuration,
		string FixedDuration,
		decimal? RejectPercent,
		string BackFlushInicator,
		string WC,
		string LaborSetupTimeDuration,
		int? OperNum,
		string Infobar);
	}
}

