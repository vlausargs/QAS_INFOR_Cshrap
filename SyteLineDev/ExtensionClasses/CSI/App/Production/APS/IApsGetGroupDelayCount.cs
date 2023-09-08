//PROJECT NAME: Production
//CLASS NAME: IApsGetGroupDelayCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetGroupDelayCount
	{
		int? ApsGetGroupDelayCountFn(
			string Group,
			DateTime? StartDate,
			DateTime? EndDate);
	}
}

