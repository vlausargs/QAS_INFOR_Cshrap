//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_Discrepancy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_Discrepancy
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_DiscrepancySp(
			string BegItem = null,
			string EndItem = null,
			string BegDisc = null,
			string EndDisc = null,
			int? BegRcvr = null,
			int? EndRcvr = null,
			DateTime? BegDate = null,
			DateTime? EndDate = null,
			string BegPO = null,
			string EndPO = null,
			string BegJob = null,
			string EndJob = null,
			string BegCO = null,
			string EndCO = null,
			string BegLot = null,
			string EndLot = null,
			string RefType = null,
			string SortBy = null,
			int? DiscOnly = null);
	}
}

