//PROJECT NAME: Production
//CLASS NAME: IApsJobOrderStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsJobOrderStatus
	{
		(int? ReturnCode, int? PStatus) ApsJobOrderStatusSp(string PJob,
		int? PSuffix,
		int? PStatus);
	}
}

