//PROJECT NAME: Logistics
//CLASS NAME: ICLM_CustomerTop5Sales.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_CustomerTop5Sales
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_CustomerTop5SalesSp();
	}
}

