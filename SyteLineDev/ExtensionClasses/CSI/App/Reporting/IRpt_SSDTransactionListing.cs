//PROJECT NAME: Reporting
//CLASS NAME: IRpt_SSDTransactionListing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_SSDTransactionListing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_SSDTransactionListingSp(DateTime? PeriodStarting = null,
		DateTime? PeriodEnding = null,
		string ExOptszTransIndicator = null,
		string ExOptszSsdRefType = null,
		int? ExOptszSortByTransaction = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string VendorStarting = null,
		string VendorEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		int? PeriodStartingOffset = null,
		int? PeriodEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

