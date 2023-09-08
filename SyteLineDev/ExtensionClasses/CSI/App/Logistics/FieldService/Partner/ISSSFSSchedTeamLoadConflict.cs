//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedTeamLoadConflict.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedTeamLoadConflict
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSFSSchedTeamLoadConflictSp(string PartnerId,
		string SchedDate,
		string Hrs,
		string NewApptRowPtr,
		string NewApptRowNum,
		string Infobar,
		string FilterString = null);
	}
}

