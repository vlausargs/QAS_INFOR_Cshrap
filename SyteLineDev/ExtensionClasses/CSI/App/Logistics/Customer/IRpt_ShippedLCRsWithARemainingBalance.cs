//PROJECT NAME: Logistics
//CLASS NAME: IRpt_ShippedLCRsWithARemainingBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRpt_ShippedLCRsWithARemainingBalance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ShippedLCRsWithARemainingBalanceSp(string PCustomerStarting,
		string PCustomerEnding,
		string PLCRStarting,
		string PLCREnding,
		DateTime? PIssueDateStarting,
		DateTime? PIssueDateEnding,
		DateTime? PExpireDateStarting,
		DateTime? PExpireDateEnding,
		string PCurrency,
		string PSite = null);
	}
}

