//PROJECT NAME: Data
//CLASS NAME: IRemoteOrderCreditRelease.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRemoteOrderCreditRelease
	{
		int? RemoteOrderCreditReleaseSp(
			string StartingCustomer,
			string EndingCustomer,
			string StartingOrder,
			string EndingOrder,
			string Infobar);
	}
}

