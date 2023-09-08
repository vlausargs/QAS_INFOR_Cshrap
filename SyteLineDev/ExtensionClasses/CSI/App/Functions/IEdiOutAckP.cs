//PROJECT NAME: Data
//CLASS NAME: IEdiOutAckP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutAckP
	{
		int? EdiOutAckPSp(
			decimal? ProcessId);
	}
}

