//PROJECT NAME: Logistics
//CLASS NAME: IEstimateLinesGetExtAmts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstimateLinesGetExtAmts
	{
		(int? ReturnCode, decimal? TcAmtExtPrice,
		decimal? TcAmtNetPrice,
		decimal? TcAmtTotCost,
		string Infobar) EstimateLinesGetExtAmtsSp(string PEstNum,
		decimal? PQtyOrdered,
		decimal? PPriceConv,
		decimal? PDisc,
		decimal? PCostConv,
		decimal? TcAmtExtPrice,
		decimal? TcAmtNetPrice,
		decimal? TcAmtTotCost,
		string Infobar);
	}
}

