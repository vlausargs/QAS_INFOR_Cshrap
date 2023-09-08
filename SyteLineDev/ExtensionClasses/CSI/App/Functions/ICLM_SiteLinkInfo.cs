//PROJECT NAME: Data
//CLASS NAME: ICLM_SiteLinkInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_SiteLinkInfo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SiteLinkInfoSp(
			string Intranet,
			string Site,
			string DatabaseName = null,
			string FilterString = null,
			string pSite = null);
	}
}

