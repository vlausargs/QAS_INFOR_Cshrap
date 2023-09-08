//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubCalcHrs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubCalcHrs
	{
		int? SSSFSConInvSubCalcHrsFn(
			DateTime? StartDateTime,
			DateTime? EndDateTime,
			decimal? ContMaxHrs);
	}
}

