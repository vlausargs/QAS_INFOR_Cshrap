//PROJECT NAME: Logistics
//CLASS NAME: IICCreateOrUpdateBlanketPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IICCreateOrUpdateBlanketPo
	{
		(int? ReturnCode, string PPoNum,
		int? PPoLine,
		int? PPoLineRelease,
		string Infobar) ICCreateOrUpdateBlanketPoSp(string PPoNum,
		int? PPoLine,
		int? PPoLineRelease,
		string PVendNum,
		string PItem,
		decimal? PQty,
		string Infobar);
	}
}

