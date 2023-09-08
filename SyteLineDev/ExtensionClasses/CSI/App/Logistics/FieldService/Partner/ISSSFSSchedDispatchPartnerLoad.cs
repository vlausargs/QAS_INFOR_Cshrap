//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSchedDispatchPartnerLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ISSSFSSchedDispatchPartnerLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSSchedDispatchPartnerLoadSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? RefSeq,
		Guid? RefRowPointer,
		DateTime? RequestDate,
		int? DaysToLookAhead,
		decimal? ApptHrs,
		string FilterString = null);
	}
}

