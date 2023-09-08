//PROJECT NAME: Data
//CLASS NAME: IGetARBatchCounter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetARBatchCounter
	{
		(int? ReturnCode,
			decimal? OperationCounter,
			string Infobar) GetARBatchCounterSp(
			decimal? OperationCounter,
			string Infobar);
	}
}

