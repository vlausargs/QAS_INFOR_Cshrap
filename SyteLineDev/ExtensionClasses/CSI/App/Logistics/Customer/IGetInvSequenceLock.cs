//PROJECT NAME: Logistics
//CLASS NAME: IGetInvSequenceLock.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetInvSequenceLock
	{
		(int? ReturnCode,
		string InfoBar) GetInvSequenceLockSp(
			string InvNum,
			string InfoBar);
	}
}

