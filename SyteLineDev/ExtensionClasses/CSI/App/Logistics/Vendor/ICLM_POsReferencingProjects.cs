//PROJECT NAME: Logistics
//CLASS NAME: ICLM_POsReferencingProjects.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_POsReferencingProjects
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_POsReferencingProjectsSp(string ProjMgr = null,
		DateTime? CutoffDate = null,
		string WBSNum = null,
		string FilterString = null,
		string SiteGroup = null);
	}
}

