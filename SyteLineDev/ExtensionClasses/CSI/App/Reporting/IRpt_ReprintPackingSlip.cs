//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ReprintPackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ReprintPackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) Rpt_ReprintPackingSlipSp(int? PStartSlipNum = null,
		int? PEndSlipNum = null,
		int? PrintLineReleaseDescription = null,
		int? PPrPlanItemMatl = null,
		int? PPrSerialNumber = null,
		int? PrintOrderNotes = null,
		int? PrintLineReleaseNotes = null,
		int? PrintinternalNotes = null,
		int? PrintExternalNotes = null,
		int? DisplayHeader = null,
		int? PrintItemOverview = null,
		string InfoBar = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null);
	}
}

