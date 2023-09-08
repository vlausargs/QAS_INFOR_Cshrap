//PROJECT NAME: Data
//CLASS NAME: IHome_ResourcePlanSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHome_ResourcePlanSub
	{
		int? Home_ResourcePlanSubSp(
			int? AltNum = 0,
			string FilterString = null);
	}
}

