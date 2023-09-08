//PROJECT NAME: Production
//CLASS NAME: IApsGetOrderID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetOrderID
	{
		string ApsGetOrderIDFn(
			string DemandType,
			string DemandRef);
	}
}

