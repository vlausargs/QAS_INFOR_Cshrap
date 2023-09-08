//PROJECT NAME: Finance
//CLASS NAME: IMTDTransactionsResetUtility.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMTDTransactionsResetUtility
	{
		int? MTDTransactionsResetUtilitySp(string PeriodKey);
	}
}

