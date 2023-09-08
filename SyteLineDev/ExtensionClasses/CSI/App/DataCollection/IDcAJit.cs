//PROJECT NAME: DataCollection
//CLASS NAME: IDcAJit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAJit
	{
		(int? ReturnCode, string Infobar) DcAJitSp(string TTermId,
		string TTransType,
		string TEmpNum,
		DateTime? TTransDate,
		decimal? TCompleted,
		string TItem,
		string TShift,
		string TLocation,
		string TLot,
		string TCurWhse,
		string Infobar);
	}
}

