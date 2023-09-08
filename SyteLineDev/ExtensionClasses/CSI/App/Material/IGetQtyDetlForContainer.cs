//PROJECT NAME: Material
//CLASS NAME: IGetQtyDetlForContainer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetQtyDetlForContainer
	{
		(int? ReturnCode, decimal? TotalQtyContained,
		decimal? OtherQtyContained,
		decimal? QtyOnHand,
		decimal? QtyRvsd,
		decimal? ForUseQtyContained,
		decimal? QtyContained,
		string Infobar) GetQtyDetlForContainerSp(string ContainNum,
		string Whse,
		string Loc,
		string Item,
		string Lot,
		decimal? TotalQtyContained,
		decimal? OtherQtyContained,
		decimal? QtyOnHand,
		decimal? QtyRvsd,
		decimal? ForUseQtyContained,
		decimal? QtyContained,
		string Infobar);
	}
}

