//PROJECT NAME: Production
//CLASS NAME: IHome_ResourceSchedule.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IHome_ResourceSchedule
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_ResourceScheduleSp(DateTime? StartDate,
		DateTime? EndDate,
		int? AltNum = 0,
		string FilterString = null,
		string SiteGroup = null);
	}
}

