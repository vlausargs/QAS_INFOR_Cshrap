//PROJECT NAME: Material
//CLASS NAME: IPlanningDetailSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPlanningDetailSave
	{
		int? PlanningDetailSaveSp(Guid? SessionID,
		string Item,
		DateTime? DueDate,
		decimal? QtyReq,
		decimal? OrigQty,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? RefSeq,
		string OrderType);
	}
}

