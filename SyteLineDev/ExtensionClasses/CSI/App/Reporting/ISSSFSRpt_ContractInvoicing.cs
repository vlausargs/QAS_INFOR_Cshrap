//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_ContractInvoicing.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_ContractInvoicing
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_ContractInvoicingSp(string Mode = "PROCESS",
		string StartInvNum = null,
		string EndInvNum = null,
		DateTime? StartInvDate = null,
		DateTime? EndInvDate = null,
		string StartCustNum = null,
		string EndCustNum = null,
		string MooreForm = "N",
		int? TransToDomCurr = 0,
		int? PrintEuroTotal = 0,
		int? PrintCustomerNotes = 0,
		int? PrintContractNotes = 0,
		int? PrintContLineNotes = 0,
		int? PrintInternalNotes = 0,
		int? PrintExternalNotes = 0,
		int? PrintFixedContLines = 0,
		int? Summarize = 0,
		string pSite = null);
	}
}

