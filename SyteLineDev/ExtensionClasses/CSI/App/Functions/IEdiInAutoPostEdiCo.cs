//PROJECT NAME: Data
//CLASS NAME: IEdiInAutoPostEdiCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiInAutoPostEdiCo
	{
		int? EdiInAutoPostEdiCoSp(
			decimal? ProcessId,
			string Username);
	}
}

