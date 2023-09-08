//PROJECT NAME: Logistics
//CLASS NAME: IICCreateOrUpdatePo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IICCreateOrUpdatePo
	{
		(int? ReturnCode, string PPoNum,
		int? PPoLine,
		string Infobar) ICCreateOrUpdatePoSp(string PPoNum,
		int? PPoLine,
		string PVendNum,
		string PItem,
		decimal? PQty,
		string Infobar);
	}
}

