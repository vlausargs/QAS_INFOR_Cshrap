//PROJECT NAME: Data
//CLASS NAME: IEdiInPoinvIn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiInPoinvIn
	{
		int? EdiInPoinvInSp(
			decimal? ProcessId,
			string Username);
	}
}

