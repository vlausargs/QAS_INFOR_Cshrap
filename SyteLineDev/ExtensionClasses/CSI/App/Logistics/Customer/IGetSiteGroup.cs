//PROJECT NAME: Logistics
//CLASS NAME: IGetSiteGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetSiteGroup
	{
		(int? ReturnCode, string SiteGroup) GetSiteGroupSp(string SiteGroup);
	}
}

