//PROJECT NAME: Data
//CLASS NAME: IRemoteLoadSiteTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRemoteLoadSiteTmpSer
	{
		(int? ReturnCode,
			string Infobar) RemoteLoadSiteTmpSerSp(
			string Site = null,
			string Infobar = null);
	}
}

