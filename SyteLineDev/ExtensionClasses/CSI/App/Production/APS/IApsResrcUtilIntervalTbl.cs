//PROJECT NAME: Production
//CLASS NAME: IApsResrcUtilIntervalTbl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsResrcUtilIntervalTbl
	{
		ICollectionLoadResponse ApsResrcUtilIntervalTblFn(
			int? IntervalType,
			int? IntervalCount,
			DateTime? StartDate,
			DateTime? BeginDate);
	}
}

