//PROJECT NAME: Production
//CLASS NAME: IApsSyncRouteOpr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncRouteOpr
	{
		int? ApsSyncRouteOprSp(
			Guid? Partition);
	}
}

