//PROJECT NAME: Data
//CLASS NAME: IRemoteCoHld4.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRemoteCoHld4
	{
		(int? ReturnCode,
			string Infobar,
			int? Counter) RemoteCoHld4Sp(
			string StartingCustNum,
			string EndingCustNum,
			string StartingOrder,
			string EndingOrder,
			int? SubCustomer,
			string Infobar = null,
			int? Counter = 0);
	}
}

