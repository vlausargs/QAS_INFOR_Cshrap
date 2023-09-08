//PROJECT NAME: Data
//CLASS NAME: IChangeReportsTo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsTo
	{
		(int? ReturnCode,
			string Infobar) ChangeReportsToSp(
			string pReportsTo,
			DateTime? pCutoffDate,
			DateTime? pCurrTransDate,
			int? pPostBalances,
			int? pMaintainMap,
			int? pSummaryOrDetail,
			string Infobar);
	}
}

