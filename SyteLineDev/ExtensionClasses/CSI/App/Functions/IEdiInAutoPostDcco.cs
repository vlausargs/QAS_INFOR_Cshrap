//PROJECT NAME: Data
//CLASS NAME: IEdiInAutoPostDcco.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiInAutoPostDcco
	{
		int? EdiInAutoPostDccoSp(
			decimal? ProcessId,
			string Username);
	}
}

