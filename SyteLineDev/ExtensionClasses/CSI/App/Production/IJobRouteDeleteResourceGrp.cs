//PROJECT NAME: Production
//CLASS NAME: IJobRouteDeleteResourceGrp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobRouteDeleteResourceGrp
	{
		int? JobRouteDeleteResourceGrpSp(string PJob,
		int? PSuffix,
		int? POperNum);
	}
}

