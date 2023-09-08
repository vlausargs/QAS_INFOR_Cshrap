//PROJECT NAME: Production
//CLASS NAME: IApsGeneratePlannedOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGeneratePlannedOrders
	{
		int? ApsGeneratePlannedOrdersSp(
			int? AltNo);
	}
}

