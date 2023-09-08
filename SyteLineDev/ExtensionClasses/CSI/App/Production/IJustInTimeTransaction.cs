//PROJECT NAME: Production
//CLASS NAME: IJustInTimeTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJustInTimeTransaction
	{
		(int? ReturnCode,
		string Infobar) JustInTimeTransactionSp(
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
			string ContainerNum = null,
			string DocumentNum = null);
	}
}

