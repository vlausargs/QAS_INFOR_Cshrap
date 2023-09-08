//PROJECT NAME: Finance
//CLASS NAME: IBankStmtPurgeUtility.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Bank
{
	public interface IBankStmtPurgeUtility
	{
		(int? ReturnCode,
			string InfoBar) BankStmtPurgeUtilitySp(
			DateTime? PeriodStartingDate,
			DateTime? PeriodEndingDate,
			string ReferenceTypeStarting,
			string ReferenceTypeEnding,
			string ReferenceNumberStarting,
			string ReferenceNumberEnding,
			int? PeriodEndingDateOffset,
			string InfoBar);
	}
}

