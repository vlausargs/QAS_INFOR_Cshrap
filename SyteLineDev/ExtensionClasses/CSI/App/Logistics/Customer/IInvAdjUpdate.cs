//PROJECT NAME: Logistics
//CLASS NAME: IInvAdjUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvAdjUpdate
	{
		(int? ReturnCode, string Infobar) InvAdjUpdateSp(Guid? PRowPointer,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		decimal? PQtyAdj,
		decimal? PNewDisc,
		decimal? PNewPrice,
		decimal? PNewPriceConv,
		decimal? PNewQtyConv,
		decimal? PNewLineNet,
		decimal? PNetAdjust,
		string PTransNat,
		string PTransNatDesc,
		string PTransNat2,
		string PTransNat2Desc,
		string POrigInvNum,
		string PReasonText,
		string Infobar);
	}
}

