//PROJECT NAME: Data
//CLASS NAME: ICLM_ServerInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_ServerInfo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ServerInfoSp(
			string FilterString = null,
			string pSite = null);
	}
}

