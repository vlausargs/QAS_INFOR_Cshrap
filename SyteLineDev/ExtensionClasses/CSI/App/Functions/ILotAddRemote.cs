//PROJECT NAME: Data
//CLASS NAME: ILotAddRemote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILotAddRemote
	{
		int? LotAddRemoteSp(
			string Item,
			string Lot,
			decimal? RcvdQty,
			string VendLot,
			string Revision = null,
			DateTime? ManufacturedDate = null,
			DateTime? ExpirationDate = null,
			string LotTrxRestrictCode = null);
	}
}

