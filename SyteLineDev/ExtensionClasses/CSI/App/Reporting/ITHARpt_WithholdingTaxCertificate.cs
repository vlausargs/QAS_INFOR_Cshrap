//PROJECT NAME: Reporting
//CLASS NAME: ITHARpt_WithholdingTaxCertificate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ITHARpt_WithholdingTaxCertificate
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THARpt_WithholdingTaxCertificateSp(string StartingBankCode = null,
		string StartingVendor = null,
		string EndingVendor = null,
		string StartingTHVendInvNum = null,
		string EndingTHVendInvNum = null,
		DateTime? StartingWHTDate = null,
		DateTime? EndingWHTDate = null,
		int? WHTDateStartingOffset = null,
		int? WHTDateEndingOffset = null,
		int? Reprint = null,
		string pSite = null);
	}
}

