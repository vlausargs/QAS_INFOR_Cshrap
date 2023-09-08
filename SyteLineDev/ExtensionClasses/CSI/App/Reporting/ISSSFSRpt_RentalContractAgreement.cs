//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_RentalContractAgreement.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_RentalContractAgreement
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_RentalContractAgreementSp(string ContractStarting = null,
		string ContractEnding = null,
		string CustNumStarting = null,
		string CustNumEnding = null,
		int? DispContractNotes = 1,
		int? DispLineNotes = 1,
		int? ShowInternal = 0,
		int? ShowExternal = 1,
		int? DispLineDetail = 1,
		int? DispLineSurcharge = 1,
		int? DispContractWaiver = 1,
		int? DispContractPricing = 0,
		string pSite = null);
	}
}

