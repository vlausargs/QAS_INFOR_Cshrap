//PROJECT NAME: Reporting
//CLASS NAME: IRpt_InvoiceRegisterbyAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_InvoiceRegisterbyAccount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InvoiceRegisterbyAccountSp(string AccountStarting,
		string AccountEnding,
		string InvNumStarting,
		string InvNumEnding,
		DateTime? InvoiceDateStarting,
		DateTime? InvoiceDateEnding,
		string OrderStarting,
		string OrderEnding,
		string CustomerStarting,
		string CustomerEnding,
		string StateStarting,
		string StateEnding,
		string ItemStarting,
		string ItemEnding,
		string InvoiceSourceOrder,
		string InvoiceSourceAR,
		int? TranslateToDomesticCurrency,
		int? InvoiceDateStartingOffset = null,
		int? InvoiceDateEndingOffset = null,
		int? ShowPrice = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		int? SSSFSIncludeSourceSRO = null,
		int? SSSFSIncludeSourceContract = null,
		string SSSFSSROStarting = null,
		string SSSFSSROEnding = null,
		string SSSFSContractStarting = null,
		string SSSFSContractEnding = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

