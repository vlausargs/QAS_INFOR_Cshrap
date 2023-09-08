//PROJECT NAME: Data
//CLASS NAME: IChangeSiteAndSiteGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeSiteAndSiteGroup
	{
		(int? ReturnCode,
			string Infobar) ChangeSiteAndSiteGroupSp(
			string SiteName,
			string NewSiteGroup = null,
			string Infobar = null);
	}
}

