//PROJECT NAME: Data
//CLASS NAME: IEdiOutAsnP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutAsnP
	{
		int? EdiOutAsnPSp(
			decimal? ProcessId);
	}
}

