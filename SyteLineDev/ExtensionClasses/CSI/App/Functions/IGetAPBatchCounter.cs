//PROJECT NAME: Data
//CLASS NAME: IGetAPBatchCounter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetAPBatchCounter
	{
		(int? ReturnCode,
			decimal? OperationCounter,
			string Infobar) GetAPBatchCounterSp(
			decimal? OperationCounter,
			string Infobar);
	}
}

