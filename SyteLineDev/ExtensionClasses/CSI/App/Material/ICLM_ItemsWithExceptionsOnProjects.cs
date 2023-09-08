//PROJECT NAME: Material
//CLASS NAME: ICLM_ItemsWithExceptionsOnProjects.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_ItemsWithExceptionsOnProjects
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ItemsWithExceptionsOnProjectsSp(string ProjMgr = null,
		string FilterString = null,
		string SiteGroup = null);
	}
}

