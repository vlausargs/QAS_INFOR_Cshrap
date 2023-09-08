//PROJECT NAME: Production
//CLASS NAME: IWBSPercComplete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IWBSPercComplete
	{
		(ICollectionLoadResponse Data, int? ReturnCode) WBSPercCompleteSP(string WbsNum,
		string SiteGroup,
		string FilterString = null);
	}
}

