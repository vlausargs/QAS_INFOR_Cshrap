//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBPreDeleteCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBPreDeleteCheck
	{
		(int? ReturnCode,
			string Infobar) MultiFSBPreDeleteCheckSp(
			string PeriodName,
			int? FiscalYear,
			string Infobar);
	}
}

