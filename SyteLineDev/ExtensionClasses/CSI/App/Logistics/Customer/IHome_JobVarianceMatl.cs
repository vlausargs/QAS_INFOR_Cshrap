//PROJECT NAME: Logistics
//CLASS NAME: IHome_JobVarianceMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_JobVarianceMatl
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_JobVarianceMatlSp(string FilterString = null,
		string JobJob = null,
		int? JobSuffix = null,
		string Item = null,
		decimal? JobQtyReleased = null,
		string SiteGroup = null);
	}
}

