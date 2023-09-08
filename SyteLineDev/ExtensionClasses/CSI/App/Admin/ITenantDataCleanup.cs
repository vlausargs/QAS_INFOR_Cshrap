//PROJECT NAME: Admin
//CLASS NAME: ITenantDataCleanup.cs

using System;
using System.Data;
using System.Collections.Generic;
using CSI.MG;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ITenantDataCleanup
	{
		(int ReturnCode, string Infobar) CleanupDataset(string datasetsJson);
	}
}
