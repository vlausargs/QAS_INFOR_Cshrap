//PROJECT NAME: Production
//CLASS NAME: IApsJobmatlEffDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsJobmatlEffDate
	{
		DateTime? ApsJobmatlEffDateFn(
			DateTime? PriEffDate,
			DateTime? AltEffDate);
	}
}

