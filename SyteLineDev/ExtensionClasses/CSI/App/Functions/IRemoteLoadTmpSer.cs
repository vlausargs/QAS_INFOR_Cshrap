//PROJECT NAME: Data
//CLASS NAME: IRemoteLoadTmpSer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRemoteLoadTmpSer
	{
		int? RemoteLoadTmpSerSp(
			Guid? TmpSerId,
			string SerNum,
			string RefStr,
			string TrxRestrictCode);
	}
}

