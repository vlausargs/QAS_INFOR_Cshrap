//PROJECT NAME: Material
//CLASS NAME: IItemAvailability.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemAvailability
	{
		(int? ReturnCode, decimal? pQtyOnHandPhysical,
		decimal? pQtyOnHandAvailable,
		decimal? pQtyAllocCo,
		decimal? pQtyAllocMfg,
		decimal? pQtyOnOrder,
		decimal? pQtyWip,
		string Infobar) ItemAvailabilitySp(string pSite,
		string pItem,
		decimal? pQtyOnHandPhysical,
		decimal? pQtyOnHandAvailable,
		decimal? pQtyAllocCo,
		decimal? pQtyAllocMfg,
		decimal? pQtyOnOrder,
		decimal? pQtyWip,
		string Infobar);
	}
}

