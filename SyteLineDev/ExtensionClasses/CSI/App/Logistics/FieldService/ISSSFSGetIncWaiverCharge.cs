//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetIncWaiverCharge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetIncWaiverCharge
	{
		int? SSSFSGetIncWaiverChargeFn(
			string Contract,
			string Item,
			string UnitOfRate = null);
	}
}

