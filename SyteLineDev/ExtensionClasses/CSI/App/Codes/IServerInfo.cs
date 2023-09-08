//PROJECT NAME: Codes
//CLASS NAME: IServerInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IServerInfo
	{
		(int? ReturnCode, string SystemStatistics) ServerInfoSp(string pSite = null,
		string SystemStatistics = null);
	}
}

