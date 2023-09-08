//PROJECT NAME: Data
//CLASS NAME: ICustomerStatementsBG.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerStatementsBG
	{
		int? CustomerStatementsBGSp(
			DateTime? StatementDate = null,
			int? ShowActive = null,
			string BeginCustNum = null,
			string EndCustNum = null,
			string SiteGroup = null,
			string StateCycle = null,
			int? PrZeroBal = null,
			int? PrCreditBal = null,
			int? PrAgedTot = null,
			string PrOpenItem2 = null,
			string InvDue = null,
			int? SortByInv = null,
			int? HidePaid = null,
			string StComm1 = null,
			string StComm2 = null,
			int? PrOpenPay = null,
			int? AgeDays1 = null,
			int? AgeDays2 = null,
			int? AgeDays3 = null,
			int? AgeDays4 = null,
			int? AgeDays5 = null,
			string AgeDays1Desc = null,
			string AgeDays2Desc = null,
			string AgeDays3Desc = null,
			string AgeDays4Desc = null,
			string AgeDays5Desc = null,
			int? PrintEuro = null,
			int? StatementDateOffset = null,
			int? DisplayHeader = null,
			string LangCode = null,
			int? UseProfile = null,
			string pSite = null,
			string BGUser = null,
			int? CustStateTemplate = null);
	}
}

