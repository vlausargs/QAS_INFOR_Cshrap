//PROJECT NAME: DataCollection
//CLASS NAME: IDcAMatlmv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcAMatlmv
	{
		(int? ReturnCode, string Infobar) DcAMatlmvSp(string TTermId,
		string TEmpNum,
		DateTime? TTransDate,
		string TItem,
		string TCurWhse,
		string TLoc1,
		string TLot1,
		string TLoc2,
		string TLot2,
		decimal? TQty,
		string TUM,
		string DocumentNum,
		string Infobar);
	}
}

