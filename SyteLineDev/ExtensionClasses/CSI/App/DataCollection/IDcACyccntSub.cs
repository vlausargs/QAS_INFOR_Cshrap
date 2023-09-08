//PROJECT NAME: DataCollection
//CLASS NAME: IDcACyccntSub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcACyccntSub
	{
		int? DcACyccntSubSp(
			string TTermId,
			string TEmpNum,
			DateTime? TTransDate,
			string TItem,
			string TLocation,
			string TLot,
			string TCurWhse,
			decimal? TQty);
	}
}

