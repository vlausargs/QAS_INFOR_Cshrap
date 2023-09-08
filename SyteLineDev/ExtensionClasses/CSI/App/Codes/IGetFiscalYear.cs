//PROJECT NAME: Codes
//CLASS NAME: IGetFiscalYear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetFiscalYear
	{
		(int? ReturnCode, int? pFiscalYear) GetFiscalYearSp(int? pFiscalYear);

		int? GetFiscalYearFn();
	}
}

