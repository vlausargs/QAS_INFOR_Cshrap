//PROJECT NAME: Production
//CLASS NAME: ITickCal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ITickCal
	{
		int? TickCalSp(string StartCal,
		string EndCal = null,
		int? AltNo = null,
		DateTime? StartDate = null);
	}
}

