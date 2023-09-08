//PROJECT NAME: Production
//CLASS NAME: IHome_ResourcePlan.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IHome_ResourcePlan
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_ResourcePlanSp(int? AltNum = 0,
		string FilterString = null,
		string SiteGroup = null);
	}
}

