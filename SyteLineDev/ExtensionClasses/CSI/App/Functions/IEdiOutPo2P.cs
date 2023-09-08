//PROJECT NAME: Data
//CLASS NAME: IEdiOutPo2P.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutPo2P
	{
		int? EdiOutPo2PSp(
			decimal? ProcessId,
			string TranType);
	}
}

