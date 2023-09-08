//PROJECT NAME: DataCollection
//CLASS NAME: ISetQtyForInvAdj.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface ISetQtyForInvAdj
	{
		(int? ReturnCode, decimal? QtyOnHand) SetQtyForInvAdjSP(string Item = null,
		string Whse = null,
		string Loc = null,
		string TransType = null,
		decimal? QtyOnHand = null);
	}
}

