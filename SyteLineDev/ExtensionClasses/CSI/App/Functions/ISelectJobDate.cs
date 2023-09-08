//PROJECT NAME: Data
//CLASS NAME: ISelectJobDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISelectJobDate
	{
		DateTime? SelectJobDateFn(
			DateTime? pEndDate,
			DateTime? pCompDate,
			int? pScheduled,
			int? pMrpParmDynLead,
			int? pUseSchedTimesInPlanning,
			string pApsMode);
	}
}

