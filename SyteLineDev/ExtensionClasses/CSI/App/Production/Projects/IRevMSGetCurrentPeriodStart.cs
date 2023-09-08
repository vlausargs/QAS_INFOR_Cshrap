//PROJECT NAME: Production
//CLASS NAME: IRevMSGetCurrentPeriodStart.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSGetCurrentPeriodStart
	{
		DateTime? RevMSGetCurrentPeriodStartFn(
			DateTime? MsPlanDate,
			DateTime? MsActDate);
	}
}

