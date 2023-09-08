//PROJECT NAME: Production
//CLASS NAME: IJustInTimeTransactionSetVars.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJustInTimeTransactionSetVars
	{
		(int? ReturnCode, string Infobar) JustInTimeTransactionSetVarsSp(string SET,
		string TItem,
		decimal? TcQtuQty,
		string TWhse,
		string TLoc,
		string TLot,
		DateTime? TTransDate,
		string TShift,
		string TEmpNum,
		int? PPostNeg,
		string SerialPrefix,
		Guid? SessionID,
		string Infobar,
		string DocumentNum = null);
	}
}

