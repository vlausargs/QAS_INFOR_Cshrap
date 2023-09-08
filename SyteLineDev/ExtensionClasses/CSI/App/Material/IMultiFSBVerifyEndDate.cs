//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBVerifyEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBVerifyEndDate
	{
		(int? ReturnCode,
			string Infobar) MultiFSBVerifyEndDateSp(
			string PeriodName,
			int? PFiscalYear,
			string Infobar);
	}
}

