//PROJECT NAME: Production
//CLASS NAME: IRevMSGetCurrentPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMSGetCurrentPeriod
	{
		int? RevMSGetCurrentPeriodFn(
			DateTime? MsPlanDate,
			DateTime? MsActDate);
	}
}

