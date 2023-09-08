//PROJECT NAME: Data
//CLASS NAME: IRemoteDataPull.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRemoteDataPull
	{
		(int? ReturnCode,
			string Infobar) RemoteDataPullSp(
			string TargetSite,
			string SourceSite,
			Guid? SessionID,
			string PreLoadSp = null,
			string Table = null,
			string Where = null,
			string Infobar = null);
	}
}

