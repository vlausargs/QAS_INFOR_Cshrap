//PROJECT NAME: Production
//CLASS NAME: IApsGetDemandID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetDemandID
	{
		string ApsGetDemandIDFn(
			string ApsOrderId);
	}
}

