//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConCalcEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConCalcEndDate
	{
		DateTime? SSSFSConCalcEndDateFn(
			string IUnitOfRate,
			DateTime? IStartDate,
			int? INumOfTimes);
	}
}

