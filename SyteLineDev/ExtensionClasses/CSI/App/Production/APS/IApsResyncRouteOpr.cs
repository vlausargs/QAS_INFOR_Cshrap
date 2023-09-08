//PROJECT NAME: Production
//CLASS NAME: IApsResyncRouteOpr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsResyncRouteOpr
	{
		int? ApsResyncRouteOprSp(
			Guid? Partition);
	}
}

