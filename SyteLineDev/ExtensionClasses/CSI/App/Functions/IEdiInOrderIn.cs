//PROJECT NAME: Data
//CLASS NAME: IEdiInOrderIn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiInOrderIn
	{
		int? EdiInOrderInSp(
			decimal? ProcessId,
			string Username);
	}
}

