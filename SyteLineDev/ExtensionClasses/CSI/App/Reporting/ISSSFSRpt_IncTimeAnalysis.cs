//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_IncTimeAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_IncTimeAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_IncTimeAnalysisSp(DateTime? StartingCloseDate,
		DateTime? EndingCloseDate,
		string StartingIncident,
		string EndingIncident,
		string StartingCustomer,
		string EndingCustomer,
		string StartingOwner,
		string EndingOwner,
		string StartingReasonCode1,
		string EndingReasonCode1,
		string StartingReasonCode2,
		string EndingReasonCode2,
		string StartingUnit,
		string EndingUnit,
		string StartingItem,
		string EndingItem,
		int? PrintIncident,
		int? PrintReasRes,
		int? PrintReason,
		int? PrintRes,
		int? PrintEvents,
		int? PrintInternal,
		int? PrintExternal,
		string pSite = null);
	}
}

