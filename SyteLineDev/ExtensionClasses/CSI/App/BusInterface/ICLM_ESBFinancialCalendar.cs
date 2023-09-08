//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBFinancialCalendar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBFinancialCalendar
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBFinancialCalendarSp();
	}
}

