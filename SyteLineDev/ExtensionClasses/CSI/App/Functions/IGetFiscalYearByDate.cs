//PROJECT NAME: Data
//CLASS NAME: IGetFiscalYearByDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetFiscalYearByDate
	{
		int? GetFiscalYearByDateFn(
			DateTime? DateToStartDepr);
	}
}

