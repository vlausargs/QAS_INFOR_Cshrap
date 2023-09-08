//PROJECT NAME: Production
//CLASS NAME: IApsPlannerNeedsRoute.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPlannerNeedsRoute
	{
		int? ApsPlannerNeedsRouteFn(
			string pJob,
			int? pSuffix);
	}
}

