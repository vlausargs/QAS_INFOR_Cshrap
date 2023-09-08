//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubGetNextValidWorkday.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubGetNextValidWorkday
	{
		DateTime? SSSFSConInvSubGetNextValidWorkdayFn(
			DateTime? WorkDay);
	}
}

