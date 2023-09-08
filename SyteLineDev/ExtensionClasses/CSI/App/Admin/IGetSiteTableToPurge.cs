//PROJECT NAME: Admin
//CLASS NAME: IGetSiteTableToPurge.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IGetSiteTableToPurge
	{
		(int? ReturnCode,
		string TableName,
		int? OriginRowAmount,
		int? PendingTableRemaining) GetSiteTableToPurgeSp(string DeleteSite,
		string TableName,
		int? OriginRowAmount,
		int? PendingTableRemaining);
	}
}

