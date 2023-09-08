//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_PartnerSchedule.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_PartnerSchedule
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_PartnerScheduleSp(string BeginSRONum = null,
		string EndSRONum = null,
		DateTime? BeginSchedDate = null,
		DateTime? EndSchedDate = null,
		string BeginPartnerID = null,
		string EndPartnerID = null,
		string BeginIncident = null,
		string EndIncident = null,
		int? ScheduleDetailYN = null,
		int? CustomerDetailYN = null,
		int? ScheduleTextYN = null,
		int? PageBreak = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		int? MiscRef = 1,
		int? SRORef = 1,
		int? IncRef = 1,
		string OrderBy = "P",
		string pSite = null);
	}
}

