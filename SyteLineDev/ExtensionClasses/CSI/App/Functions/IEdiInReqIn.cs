//PROJECT NAME: Data
//CLASS NAME: IEdiInReqIn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiInReqIn
	{
		int? EdiInReqInSp(
			decimal? ProcessId,
			string Username);
	}
}

