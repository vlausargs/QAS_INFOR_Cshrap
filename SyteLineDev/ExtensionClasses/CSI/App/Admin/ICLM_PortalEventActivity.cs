//PROJECT NAME: Admin
//CLASS NAME: ICLM_PortalEventActivity.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_PortalEventActivity
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PortalEventActivitySp(DateTime? BeginDate = null,
		DateTime? EndDate = null,
		string AppName = null,
		int? ChartData = 0,
		string FilterString = null);
	}
}

