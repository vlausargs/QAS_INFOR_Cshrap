//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SalespersonTop5CreditHold.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_SalespersonTop5CreditHold
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SalespersonTop5CreditHoldSp(string Slsman);
	}
}

