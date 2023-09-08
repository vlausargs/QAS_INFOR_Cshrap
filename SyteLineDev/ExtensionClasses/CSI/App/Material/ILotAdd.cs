//PROJECT NAME: Material
//CLASS NAME: ILotAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ILotAdd
	{
		(int? ReturnCode, string Infobar) LotAddSp(string Item,
		string Lot,
		decimal? RcvdQty,
		int? FromPO = 0,
		string VendLot = null,
		int? CreateNonUnique = 1,
		string Revision = null,
		string Infobar = null,
		string Site = null,
		DateTime? ManufacturedDate = null,
		DateTime? ExpirationDate = null,
		string LotTrxRestrictCode = null);
	}
}

