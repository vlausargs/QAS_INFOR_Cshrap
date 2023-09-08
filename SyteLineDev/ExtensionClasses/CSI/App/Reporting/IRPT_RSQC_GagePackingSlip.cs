//PROJECT NAME: Reporting
//CLASS NAME: IRPT_RSQC_GagePackingSlip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_RSQC_GagePackingSlip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_GagePackingSlipSp(
			string BegGage = null,
			string EndGage = null,
			string BegStat = null,
			string EndStat = null,
			DateTime? BegCalDate = null,
			DateTime? EndCalDate = null,
			int? PrintInternal = null,
			int? PrintExternal = null,
			int? PrintCalNotes = null,
			int? DisplayHeader = null);
	}
}

