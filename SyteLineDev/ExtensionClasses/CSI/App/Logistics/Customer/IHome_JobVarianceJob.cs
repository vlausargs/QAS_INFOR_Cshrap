//PROJECT NAME: Logistics
//CLASS NAME: IHome_JobVarianceJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_JobVarianceJob
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_JobVarianceJobSp(string FilterString = null,
		string Acct = null,
		DateTime? PeriodStartDate = null,
		DateTime? PeriodEndDate = null,
		string SiteGroup = null);
	}
}

