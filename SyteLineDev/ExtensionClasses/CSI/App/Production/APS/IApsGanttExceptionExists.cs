//PROJECT NAME: Production
//CLASS NAME: IApsGanttExceptionExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsGanttExceptionExists
	{
		int? ApsGanttExceptionExistsFn(
			DateTime? StartDate,
			DateTime? EndDate,
			int? AltNum,
			string Job,
			int? Suffix,
			int? OperNum,
			int? ExceptionType);
	}
}

