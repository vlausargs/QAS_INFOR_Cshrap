//PROJECT NAME: Production
//CLASS NAME: IApsGetDemandID4.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGetDemandID4
	{
		string ApsGetDemandID4Fn(
			string ApsOrderId,
			string ApsOrderTable);
	}
}

