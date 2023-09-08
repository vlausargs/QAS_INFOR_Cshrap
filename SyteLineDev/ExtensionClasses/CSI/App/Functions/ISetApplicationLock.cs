//PROJECT NAME: Data
//CLASS NAME: ISetApplicationLock.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetApplicationLock
	{
		int? SetApplicationLockSp(
			string Resource);
	}
}

