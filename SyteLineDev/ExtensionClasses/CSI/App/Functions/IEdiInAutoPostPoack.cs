//PROJECT NAME: Data
//CLASS NAME: IEdiInAutoPostPoack.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiInAutoPostPoack
	{
		int? EdiInAutoPostPoackSp(
			decimal? ProcessId,
			string Username);
	}
}

