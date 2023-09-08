//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBCalendar.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBCalendar
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBCalendarSp(string DocumentID);
	}
}

