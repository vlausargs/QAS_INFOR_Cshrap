//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_CreateJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_CreateJob
	{
		int? BOMBulkImport_CreateJobSp();
	}
}

