//PROJECT NAME: Admin
//CLASS NAME: IRefreshWrapper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IRefreshWrapper
    {
		(int, string) PreRefresh();
		int PostRefresh(string PreRefreshData);
	}
}
