//PROJECT NAME: Material
//CLASS NAME: IWhseQtyList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IWhseQtyList
	{
		(int? ReturnCode, decimal? PTotalOnHand,
		string PWhseOnHand) WhseQtyListSp(string PWhse = null,
		string PIitem = null,
		decimal? PTotalOnHand = null,
		string PWhseOnHand = null);
	}
}

