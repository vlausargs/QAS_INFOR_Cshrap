//PROJECT NAME: Production
//CLASS NAME: IApsJobmatlObsDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsJobmatlObsDate
	{
		DateTime? ApsJobmatlObsDateFn(
			DateTime? PriObsDate,
			DateTime? AltObsDate);
	}
}

