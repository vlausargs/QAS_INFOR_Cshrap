//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_CheckCustCreditHold.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_CheckCustCreditHold
	{
		(int? ReturnCode, int? CreditHold) Homepage_CheckCustCreditHoldSp(string CustNum, int? CreditHold);
	}
}

