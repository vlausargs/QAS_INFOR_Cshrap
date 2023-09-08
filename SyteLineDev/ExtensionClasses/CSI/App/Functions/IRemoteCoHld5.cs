//PROJECT NAME: Data
//CLASS NAME: IRemoteCoHld5.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRemoteCoHld5
	{
		int? RemoteCoHld5Sp(
			string PCustNum,
			string PCoNum);
	}
}

