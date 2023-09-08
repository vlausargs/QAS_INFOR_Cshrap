//PROJECT NAME: Production
//CLASS NAME: IApsRouteId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsRouteId
	{
		string ApsRouteIdFn(
			string PJob,
			int? PSuffix);
	}
}

