//PROJECT NAME: Finance
//CLASS NAME: IGetNextFiscalYear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetNextFiscalYear
	{
		(int? ReturnCode, int? NextFiscalYear) GetNextFiscalYearSp(int? NextFiscalYear);
	}
}

