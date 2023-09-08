//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubAddDay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubAddDay
	{
		DateTime? SSSFSConInvSubAddDayFn(
			DateTime? WorkDay,
			int? Days);
	}
}

