//PROJECT NAME: Production
//CLASS NAME: ICLM_JobsReferencingProjects.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_JobsReferencingProjects
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_JobsReferencingProjectsSp(string ProjMgr = null,
		DateTime? CutoffDate = null,
		string WBSNum = null,
		string FilterString = null,
		string SiteGroup = null);
	}
}

