//PROJECT NAME: Data
//CLASS NAME: IEdiOutInvP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutInvP
	{
		int? EdiOutInvPSp(
			decimal? ProcessId);
	}
}

