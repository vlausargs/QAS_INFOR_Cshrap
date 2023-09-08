//PROJECT NAME: Production
//CLASS NAME: IJobtPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtPost
	{
		(int? ReturnCode, string Infobar) JobtPostSp(Guid? SessionId,
		string CallFrom,
		decimal? PTransNum,
		int? PTransSeq,
		string Infobar,
		string DocumentNum = null);
	}
}

