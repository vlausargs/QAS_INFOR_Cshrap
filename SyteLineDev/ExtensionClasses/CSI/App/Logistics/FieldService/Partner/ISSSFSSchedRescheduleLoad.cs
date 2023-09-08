//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedRescheduleLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedRescheduleLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSSchedRescheduleLoadSp(string RowPointers,
		string PartnerID,
		decimal? MoveAmount,
		string MoveUnit,
		int? SchedMethod,
		string ApptStat,
		int? UseMaxHrs,
		int? UseProfileEndOfDay);
	}
}

