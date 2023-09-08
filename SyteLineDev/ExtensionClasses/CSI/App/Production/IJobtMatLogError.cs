//PROJECT NAME: Production
//CLASS NAME: IJobtMatLogError.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtMatLogError
	{
		int? JobtMatLogErrorSp(Guid? SessionId,
		decimal? PTransNum,
		int? PTransSeq,
		string ErrorMsg);
	}
}

