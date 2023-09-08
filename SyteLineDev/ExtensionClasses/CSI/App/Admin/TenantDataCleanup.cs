//PROJECT NAME: Admin
//CLASS NAME: TenantDataCleanup.cs

using System;
using System.Data;
using System.Collections.Generic;
using CSI.Data.SQL.UDDT;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class TenantDataCleanup : ITenantDataCleanup
	{
		IApplicationDB appDB;
		
		public TenantDataCleanup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int ReturnCode, string Infobar) CleanupDataset(string datasetsJson)
		{
			// Initial implementation : do nothing
			return (0, String.Empty);
		}
	}
}
