//PROJECT NAME: Reporting
//CLASS NAME: ITHARpt_WithholdingTaxDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ITHARpt_WithholdingTaxDetails
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THARpt_WithholdingTaxDetailsSp(string StartingTaxCode = null,
		string EndingTaxCode = null,
		DateTime? DistDateStart = null,
		DateTime? DistDateEnd = null,
		string StartingVendor = null,
		string EndingVendor = null,
		int? WithhodingTaxType = 1,
		int? DistDateStartingOffset = null,
		int? DistDateEndingOffset = null,
		string WhtType = null,
		int? Reprint = null,
		string pSite = null);
	}
}

