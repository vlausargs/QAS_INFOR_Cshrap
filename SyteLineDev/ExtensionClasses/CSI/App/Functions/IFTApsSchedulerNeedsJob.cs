//PROJECT NAME: Data
//CLASS NAME: IFTApsSchedulerNeedsJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTApsSchedulerNeedsJob
	{
		int? FTApsSchedulerNeedsJobFn(
			string pJob,
			int? pSuffix);
	}
}

