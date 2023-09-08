//PROJECT NAME: Material
//CLASS NAME: IHome_MRPOrderAction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IHome_MRPOrderAction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_MRPOrderActionSp(string Item = null,
		DateTime? EndDate = null,
		string Source = null,
		string FilterString = null,
		string SiteGroup = null);
	}
}

