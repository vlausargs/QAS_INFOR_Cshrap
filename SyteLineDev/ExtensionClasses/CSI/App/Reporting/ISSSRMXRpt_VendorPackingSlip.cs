//PROJECT NAME: Reporting
//CLASS NAME: ISSSRMXRpt_VendorPackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSRMXRpt_VendorPackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRMXRpt_VendorPackingSlipSp(string CalledType,
		int? BegPackNum,
		int? EndPackNum,
		int? PrintDisp,
		int? PrintLineReleaseText,
		int? PrintExternalNotes,
		int? PrintInternalNotes,
		int? DisplayHeader,
		int? PrintItemOverview = 0,
		string Whse = null,
		int? RefTypeM = null,
		int? RefTypeP = null,
		string BegVendNum = null,
		string EndBendNum = null,
		string BegRefNum = null,
		string EndRefNum = null,
		string pSite = null);
	}
}

