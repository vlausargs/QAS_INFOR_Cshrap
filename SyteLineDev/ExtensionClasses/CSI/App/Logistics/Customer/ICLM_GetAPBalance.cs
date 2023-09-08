//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetAPBalance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetAPBalance
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetAPBalanceSp(string Site = null);
	}
}

