//PROJECT NAME: Production
//CLASS NAME: IApsCoJobRouteID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsCoJobRouteID
	{
		string ApsCoJobRouteIDFn(
			string PJob);
	}
}

