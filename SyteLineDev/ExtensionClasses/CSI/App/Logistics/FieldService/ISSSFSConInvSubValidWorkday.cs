//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubValidWorkday.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubValidWorkday
	{
		int? SSSFSConInvSubValidWorkdayFn(
			DateTime? WorkDay);
	}
}

