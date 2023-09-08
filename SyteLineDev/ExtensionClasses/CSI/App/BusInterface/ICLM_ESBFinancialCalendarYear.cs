//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBFinancialCalendarYear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBFinancialCalendarYear
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBFinancialCalendarYearSp();
	}
}

