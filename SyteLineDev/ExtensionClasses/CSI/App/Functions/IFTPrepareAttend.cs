//PROJECT NAME: Data
//CLASS NAME: IFTPrepareAttend.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTPrepareAttend
	{
		int? FTPrepareAttendSp(
			string EmpNum = null,
			DateTime? start_date_time = null,
			DateTime? end_date_time = null,
			DateTime? report_date = null,
			int? processed = null,
			int? PostOffsets = null,
			Guid? SessionID = null);
	}
}

