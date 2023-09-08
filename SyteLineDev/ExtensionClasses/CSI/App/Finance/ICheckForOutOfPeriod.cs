//PROJECT NAME: Finance
//CLASS NAME: ICheckForOutOfPeriod.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICheckForOutOfPeriod
	{
		(int? ReturnCode, int? OutOfPeriod,
		int? Closed,
		int? FiscalYear,
		string Infobar,
		int? TransPeriod) CheckForOutOfPeriodSp(string PJournalId,
		Guid? PSessionID,
		int? OutOfPeriod,
		int? Closed,
		int? FiscalYear,
		string Infobar,
		int? PSingleDateForTnx = 0,
		DateTime? PSingleDateToUse = null,
		int? TransPeriod = null);
	}
}

