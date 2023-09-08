//PROJECT NAME: Production
//CLASS NAME: IRSQC_SetProjectedDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_SetProjectedDate
	{
		(int? ReturnCode, DateTime? projected_date) RSQC_SetProjectedDateSp(string flow_num,
		DateTime? projected_date);
	}
}

