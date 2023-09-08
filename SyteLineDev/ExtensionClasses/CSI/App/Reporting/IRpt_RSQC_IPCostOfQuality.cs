//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPCostOfQuality.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPCostOfQuality
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPCostOfQualitySp(
			string begitem = null,
			string enditem = null,
			DateTime? begddate = null,
			DateTime? endddate = null,
			string begmrr = null,
			string endmrr = null,
			string begcar = null,
			string endcar = null,
			int? displayheader = 0);
	}
}

