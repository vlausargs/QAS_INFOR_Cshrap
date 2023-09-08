//PROJECT NAME: Production
//CLASS NAME: IJobPMessages.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobPMessages
	{
		(int? ReturnCode, string Infobar) JobPMessagesSp(int? TNone,
		int? TMatCount,
		int? TClsCount,
		int? ErrorOccurred,
		decimal? CurTransNum,
		string Infobar);
	}
}

