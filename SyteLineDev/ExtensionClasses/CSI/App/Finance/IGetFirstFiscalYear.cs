//PROJECT NAME: Finance
//CLASS NAME: IGetFirstFiscalYear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetFirstFiscalYear
	{
		(int? ReturnCode, int? FirstFiscalYear) GetFirstFiscalYearSp(int? FirstFiscalYear);
	}
}

