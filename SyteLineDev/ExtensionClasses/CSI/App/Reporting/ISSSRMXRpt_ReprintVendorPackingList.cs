//PROJECT NAME: Reporting
//CLASS NAME: ISSSRMXRpt_ReprintVendorPackingList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSRMXRpt_ReprintVendorPackingList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRMXRpt_ReprintVendorPackingListSp(int? BegPackNum,
		int? EndPackNum,
		DateTime? BegPackDate,
		DateTime? EndPackDate,
		string BegWhse,
		string EndWhse,
		string BegVendor,
		string EndVendor,
		int? DisplayHeaderVar,
		int? PrintDispVar,
		int? PrintLineReleaseTextVar,
		int? PrintInternalNotesVar,
		int? PrintExternalNotesVar,
		int? PrintItemOverviewVar = 0,
		string Infobar = null,
		string pSite = null);
	}
}

