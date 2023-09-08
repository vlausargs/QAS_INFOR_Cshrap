//PROJECT NAME: Production
//CLASS NAME: ICLM_ResGanttSchedule.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ResGanttSchedule
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ResGanttScheduleSp(DateTime? StartDate,
		DateTime? EndDate,
		int? AltNum = 0,
		string FilterString = null,
		string CustNum = null,
		string Item = null,
		string Material = null);
	}
}

