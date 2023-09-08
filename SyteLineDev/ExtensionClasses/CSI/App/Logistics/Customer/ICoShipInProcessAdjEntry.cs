//PROJECT NAME: Logistics
//CLASS NAME: ICoShipInProcessAdjEntry.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoShipInProcessAdjEntry
	{
		(int? ReturnCode, string Infobar) CoShipInProcessAdjEntrySp(Guid? CurCoShipRowPointer,
		decimal? QtyApprove,
		DateTime? ApproveDate,
		string Infobar);
	}
}

