//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubCalcEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubCalcEndDate
	{
		DateTime? SSSFSConInvSubCalcEndDateFn(
			string IUnitOfRate,
			DateTime? IStartDate,
			int? INumOfTimes);
	}
}

