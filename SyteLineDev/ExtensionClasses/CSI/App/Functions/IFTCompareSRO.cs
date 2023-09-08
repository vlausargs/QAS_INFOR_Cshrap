//PROJECT NAME: Data
//CLASS NAME: IFTCompareSRO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTCompareSRO
	{
		(int? ReturnCode,
			string Infobar) FTCompareSROSp(
			string EmpNum = null,
			DateTime? report_date = null,
			DateTime? start_date_time = null,
			DateTime? end_date_time = null,
			Guid? SessionID = null,
			string Infobar = null);
	}
}

