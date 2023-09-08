//PROJECT NAME: Production
//CLASS NAME: IProjGetMsPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjGetMsPeriod
	{
		(int? ReturnCode, int? CurrentPeriod,
		DateTime? CurrentPeriodStart,
		DateTime? CurrentPeriodEnd,
		string Infobar) ProjGetMsPeriodSp(DateTime? MsPlanDate,
		DateTime? MsActDate,
		int? CurrentPeriod,
		DateTime? CurrentPeriodStart,
		DateTime? CurrentPeriodEnd,
		string Infobar);
	}
}

