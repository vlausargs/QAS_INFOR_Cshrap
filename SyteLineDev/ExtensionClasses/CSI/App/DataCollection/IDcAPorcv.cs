//PROJECT NAME: DataCollection
//CLASS NAME: IDcAPorcv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAPorcv
	{
		(int? ReturnCode, string Infobar) DcAPorcvSp(string TTermId,
		int? TTransType,
		string TEmpNum,
		DateTime? TTransDate,
		string TPoNum,
		int? TPoLine,
		int? TPoRelease,
		string TItem,
		string TLocation,
		string TLot,
		string TCurWhse,
		string TReasonCode,
		string TUM,
		decimal? TQty,
		decimal? TQtyRejected,
		string Infobar);
	}
}

