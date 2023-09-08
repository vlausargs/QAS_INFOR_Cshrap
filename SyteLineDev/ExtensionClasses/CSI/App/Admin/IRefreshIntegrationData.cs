//PROJECT NAME: Admin
//CLASS NAME: IRefreshIntegrationData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRefreshIntegrationData
    {
		(int, string) PreRefresh();
		int PostRefresh(string PreRefreshData);
	}
}

