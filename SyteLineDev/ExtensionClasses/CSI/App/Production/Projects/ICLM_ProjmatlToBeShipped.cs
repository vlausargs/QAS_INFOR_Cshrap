//PROJECT NAME: Production
//CLASS NAME: ICLM_ProjmatlToBeShipped.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICLM_ProjmatlToBeShipped
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ProjmatlToBeShippedSp(string ProjMgr = null,
		DateTime? CutoffDate = null,
		string WBSNum = null,
		string FilterString = null,
		string SiteGroup = null);
	}
}

