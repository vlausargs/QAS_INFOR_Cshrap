//PROJECT NAME: Production
//CLASS NAME: IApsIsPlnTiedToConfiguredJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsIsPlnTiedToConfiguredJob
	{
		int? ApsIsPlnTiedToConfiguredJobFn(
			int? pMatltag);
	}
}

