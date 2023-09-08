//PROJECT NAME: Production
//CLASS NAME: IRSQC_CalcInterval.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CalcInterval
	{
		(int? ReturnCode,
		DateTime? NewDate,
		string Infobar) RSQC_CalcIntervalSp(
			DateTime? Date,
			int? Interval,
			DateTime? NewDate,
			string Infobar);
	}
}

