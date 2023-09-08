//PROJECT NAME: Data
//CLASS NAME: IDisallowPageLocks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDisallowPageLocks
	{
		int? DisallowPageLocksSp(
			string DatabaseName = null);
	}
}

