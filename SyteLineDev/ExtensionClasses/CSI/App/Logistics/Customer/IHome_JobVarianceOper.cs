//PROJECT NAME: Logistics
//CLASS NAME: IHome_JobVarianceOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_JobVarianceOper
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_JobVarianceOperSp(string FilterString = null,
		string JobJob = null,
		int? JobSuffix = null,
		string Item = null,
		decimal? JobQtyReleased = null,
		string SiteGroup = null);
	}
}

