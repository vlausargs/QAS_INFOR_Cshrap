//PROJECT NAME: Production
//CLASS NAME: IJobJobPJobtPcI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobJobPJobtPcI
	{
		(int? ReturnCode, string Infobar) JobJobPJobtPcISp(decimal? pTransNum,
		Guid? SessionId,
		string Infobar);
	}
}

