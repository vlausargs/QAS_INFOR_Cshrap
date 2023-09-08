//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetCoNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetCoNum
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_GetCoNumSp(
			string CustNum,
			string BankRouting,
			string BankAccount);
	}
}

