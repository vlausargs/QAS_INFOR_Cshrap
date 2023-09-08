//PROJECT NAME: Data
//CLASS NAME: IBatchUseExchRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBatchUseExchRate
	{
		int? BatchUseExchRateFn(
			int? PBatchId);
	}
}

