//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBFinancialCalendarDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBFinancialCalendarDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBFinancialCalendarDetailSp(int? FiscalYear);
	}
}

