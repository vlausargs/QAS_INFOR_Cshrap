//PROJECT NAME: DataCollection
//CLASS NAME: IDcACyccnt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcACyccnt
	{
		(int? ReturnCode, string Infobar) DcACyccntSp(string TTermId,
		string TEmpNum,
		DateTime? TTransDate,
		string TItem,
		string TLocation,
		string TLot,
		string TCurWhse,
		decimal? TQty,
		string Infobar);
	}
}

