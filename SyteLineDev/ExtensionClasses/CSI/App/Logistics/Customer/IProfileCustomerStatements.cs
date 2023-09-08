//PROJECT NAME: Logistics
//CLASS NAME: IProfileCustomerStatements.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IProfileCustomerStatements
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileCustomerStatementsSP(DateTime? StatementDate = null,
		int? ShowActive = null,
		string BeginCustNum = null,
		string EndCustNum = null,
		string SiteGroup = null,
		string StateCycle = null,
		int? PrZeroBal = null,
		int? PrCreditBal = null,
		string PrOpenItem2 = null,
		string InvDue = null,
		int? HidePaid = null,
		int? PrOpenPay = null,
		int? StatementDateOffset = null);
	}
}

