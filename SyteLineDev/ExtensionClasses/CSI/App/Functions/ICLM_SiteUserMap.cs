//PROJECT NAME: Data
//CLASS NAME: ICLM_SiteUserMap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_SiteUserMap
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SiteUserMapSp(
			string Intranet,
			string Site,
			string DataBaseName = null,
			string FilterString = null,
			string pSite = null);
	}
}

