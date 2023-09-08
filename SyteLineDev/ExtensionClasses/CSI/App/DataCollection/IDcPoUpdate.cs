//PROJECT NAME: DataCollection
//CLASS NAME: IDcPoUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcPoUpdate
	{
		(int? ReturnCode, string Infobar) DcPoUpdateSp(string TTermId,
		int? TTransType,
		string TEmpNum,
		string TPoNum,
		int? TPoLine,
		int? TPoRelease,
		string TItem,
		string TLocation,
		string TLot,
		string TCurWhse,
		string TReasonCode,
		string TUM,
		decimal? TQtyReceived,
		decimal? TQtyRejected,
		decimal? TQtyReturned,
		string SerNumList,
		string Infobar);
	}
}

