//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetDemandSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetDemandSummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetDemandSummarySp(DateTime? PStartDate,
		DateTime? PEndDate,
		string PDemandType,
		string PDemandID,
		string PItem,
		string PCustomer,
		string PLateness,
		string PCriticalItem,
		int? PShowPLN,
		string PPlanCode,
		string PWildCardChar,
		int? AltNo,
		string FilterString = null);
	}
}

