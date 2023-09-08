//PROJECT NAME: Admin
//CLASS NAME: IGetOpportunityTaskCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IGetOpportunityTaskCount
	{
		(int? ReturnCode, int? TaskCount,
		int? DueCount,
		string Infobar) GetOpportunityTaskCountSp(string OppID,
		string Slsman,
		DateTime? StartDate,
		DateTime? EndDate,
		int? TaskCount,
		int? DueCount,
		string Infobar = null);
	}
}

