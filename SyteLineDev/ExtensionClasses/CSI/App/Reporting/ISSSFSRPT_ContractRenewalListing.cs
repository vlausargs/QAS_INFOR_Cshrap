//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRPT_ContractRenewalListing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRPT_ContractRenewalListing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRPT_ContractRenewalListingSp(string StartingContract,
		string EndingContract,
		string StartingCustomer,
		string EndingCustomer,
		string StartingItem,
		string EndingItem,
		int? t_Period,
		int? t_Year,
		string pSite = null,
		string BillingFrequencies = null,
		int? DaysLookAhead = 0);
	}
}

