//PROJECT NAME: Production
//CLASS NAME: IApsPlannerNeedsBom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPlannerNeedsBom
	{
		int? ApsPlannerNeedsBomFn(
			string pJob,
			int? pSuffix);
	}
}

