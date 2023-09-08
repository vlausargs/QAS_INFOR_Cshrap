//PROJECT NAME: Logistics
//CLASS NAME: ITmpApQuickPaymentsCleanUp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ITmpApQuickPaymentsCleanUp
	{
		int? TmpApQuickPaymentsCleanUpSp(Guid? SessionId);
	}
}

