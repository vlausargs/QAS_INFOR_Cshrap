//PROJECT NAME: Data
//CLASS NAME: IEdiProcessLog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiProcessLog
	{
		int? EdiProcessLogSp(
			decimal? ProcessId,
			string PElement,
			string PMsgStack,
			int? PStdMsg,
			int? PDemandSide);
	}
}

