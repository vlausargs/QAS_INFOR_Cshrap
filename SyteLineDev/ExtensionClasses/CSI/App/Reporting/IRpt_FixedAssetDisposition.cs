//PROJECT NAME: Reporting
//CLASS NAME: IRpt_FixedAssetDisposition.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_FixedAssetDisposition
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetDispositionSp(DateTime? PStartingDisposalDate = null,
		DateTime? PEndingDisposalDate = null,
		string PAssetTypes = "R",
		string PStartingAssetNum = null,
		string PEndingAssetNum = null,
		string PStartingClassCode = null,
		string PEndingClassCode = null,
		string PStartingDepartment = null,
		string PEndingDepartment = null,
		string PStartingLocation = null,
		string PEndingLocation = null,
		int? PStartingDisposalDateOffset = null,
		int? PEndingDisposalDateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

