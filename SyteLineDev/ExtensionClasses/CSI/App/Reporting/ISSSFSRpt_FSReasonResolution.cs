//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_FSReasonResolution.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_FSReasonResolution
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_FSReasonResolutionSp(string Incident,
		string StartingReasonCode1,
		string EndingReasonCode1,
		string StartingReasonCode2,
		string EndingReasonCode2,
		int? PrintReason,
		int? PrintRes,
		string pSite = null);
	}
}

