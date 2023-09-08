//PROJECT NAME: Production
//CLASS NAME: IApsCopyPlannerData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsCopyPlannerData
	{
		int? ApsCopyPlannerDataSp(int? AltNo);
	}
}

