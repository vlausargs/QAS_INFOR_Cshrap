//PROJECT NAME: Production
//CLASS NAME: IApsPlannerNeedsJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPlannerNeedsJob
	{
		int? ApsPlannerNeedsJobFn(
			string PJob,
			int? PSuffix);
	}
}

