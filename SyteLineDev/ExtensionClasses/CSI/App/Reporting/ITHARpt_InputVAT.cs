//PROJECT NAME: Reporting
//CLASS NAME: ITHARpt_InputVAT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ITHARpt_InputVAT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THARpt_InputVATSp(string BegTaxCode,
		string EndTaxCode,
		DateTime? BegDistDate,
		DateTime? EndDistDate,
		DateTime? BegInvDate,
		DateTime? EndInvDate,
		string BegVendNum,
		string EndVendNum,
		string CompName,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string TaxID,
		string Description = null,
		int? DisplayHeader = null,
		int? DisplaySummaryInvoice = null,
		string Infobar = null,
		string pSite = null,
        int? UnpostedVAT = 0,
        int? PostedVAT = 1,
        string BranchId = null);
	}
}

