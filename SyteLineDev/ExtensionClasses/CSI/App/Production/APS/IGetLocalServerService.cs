//PROJECT NAME: Production
//CLASS NAME: IGetLocalServerService.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IGetLocalServerService
	{
		(int? ReturnCode, string pServerName,
		int? pPortNo) GetLocalServerServiceSp(int? AltNo,
		string pServerName,
		int? pPortNo);
	}
}

