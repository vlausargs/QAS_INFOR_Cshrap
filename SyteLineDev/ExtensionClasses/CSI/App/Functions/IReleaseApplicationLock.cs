//PROJECT NAME: Data
//CLASS NAME: IReleaseApplicationLock.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IReleaseApplicationLock
	{
		int? ReleaseApplicationLockSp(
			string Resource);
	}
}

