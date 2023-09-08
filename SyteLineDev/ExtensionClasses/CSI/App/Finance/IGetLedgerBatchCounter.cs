//PROJECT NAME: Finance
//CLASS NAME: IGetLedgerBatchCounter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetLedgerBatchCounter
	{
		(int? ReturnCode, decimal? OperationCounter,
		string Infobar) GetLedgerBatchCounterSp(decimal? OperationCounter,
		string Infobar);
	}
}

