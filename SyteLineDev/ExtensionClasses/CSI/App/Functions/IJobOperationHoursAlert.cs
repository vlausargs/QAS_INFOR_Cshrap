//PROJECT NAME: Data
//CLASS NAME: IJobOperationHoursAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobOperationHoursAlert
	{
		(int? ReturnCode,
			string Infobar) JobOperationHoursAlertSp(
			string AJob,
			int? ASuffix,
			int? AOperNum,
			decimal? PlannedRunHrs,
			decimal? ActualRunHrs,
			string Infobar);
	}
}

