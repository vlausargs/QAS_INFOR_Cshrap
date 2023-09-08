//PROJECT NAME: Production
//CLASS NAME: IApsUpdateResSched.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsUpdateResSched
	{
		int? ApsUpdateResSchedSp(string EditCode,
		string ResourceID,
		string GroupID,
		DateTime? StartDate,
		string StartCode,
		DateTime? EndDate,
		string EndCode,
		int? Jobtag,
		int? Seqnum,
		string StatusCode,
		Guid? RowPointer);
	}
}

