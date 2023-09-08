//PROJECT NAME: Production
//CLASS NAME: IApsCtpPlanOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsCtpPlanOrder
	{
		int? ApsCtpPlanOrderSp(string PSite,
		string POrder,
		int? AltNo);
	}
}

