//PROJECT NAME: Data
//CLASS NAME: IRemoteOrderCreditHold.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRemoteOrderCreditHold
	{
		(int? ReturnCode,
			int? Counter) RemoteOrderCreditHoldSp(
			string StartingOrder,
			string EndingOrder,
			string cust_num,
			string Reason,
			string Infobar,
			int? Counter = 0,
			decimal? UserId = null);
	}
}

