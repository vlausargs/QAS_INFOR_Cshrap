//PROJECT NAME: Production
//CLASS NAME: IApsSchedulerNeedsJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSchedulerNeedsJob
	{
		int? ApsSchedulerNeedsJobFn(
			string pJob,
			int? pSuffix);
	}
}

