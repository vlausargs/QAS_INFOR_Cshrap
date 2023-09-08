//PROJECT NAME: Logistics
//CLASS NAME: IVendorRebalYTD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendorRebalYTD
	{
		(ICollectionLoadResponse Data, int? ReturnCode) VendorRebalYTDSp(string StartingVendor,
		string EndingVendor,
		DateTime? YearStart,
		DateTime? YearEnd,
		DateTime? LastYearStart,
		DateTime? LastYearEnd,
		int? ResetPurchYTD,
		int? ResetPurchLstYr,
		int? ResetPayYTD,
		int? ResetPayLstYr,
		int? ResetDiscYTD,
		int? ResetDiscLstYr,
		DateTime? FiscalYearStart,
		DateTime? FiscalYearEnd,
		DateTime? LastFiscalYearStart,
		DateTime? LastFiscalYearEnd,
		int? ResetPayFiscalYTD,
		int? ResetPayFiscalLstYr,
		int? Reset1099PayYTD,
		int? Reset1099PayLstYr,
		string ProcessVar,
		int? ExceptionsOnly);
	}
}

