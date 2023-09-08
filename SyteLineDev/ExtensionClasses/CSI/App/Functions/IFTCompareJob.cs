//PROJECT NAME: Data
//CLASS NAME: IFTComparejob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTComparejob
	{
		int? FTComparejobSp(
			string EmpNum = null,
			DateTime? report_date = null,
			Guid? SessionID = null);
	}
}

