//PROJECT NAME: Logistics
//CLASS NAME: ICLM_AccountBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_AccountBalance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_AccountBalanceSp(DateTime? StartDate,
		DateTime? EndDate,
		string Acct,
		string SiteRef);
	}
}

