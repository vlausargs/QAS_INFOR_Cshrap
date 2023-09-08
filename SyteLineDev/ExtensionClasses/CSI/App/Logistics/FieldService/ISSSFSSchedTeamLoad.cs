//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedTeamLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSchedTeamLoad
	{
		ICollectionLoadResponse SSSFSSchedTeamLoadFn(
			string PartnerId,
			DateTime? SchedDate,
			decimal? Hrs,
			int? CheckConflicts,
			Guid? RowPointer);
	}
}

