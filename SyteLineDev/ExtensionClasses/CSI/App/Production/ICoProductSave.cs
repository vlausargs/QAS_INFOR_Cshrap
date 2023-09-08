//PROJECT NAME: Production
//CLASS NAME: ICoProductSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICoProductSave
	{
		(int? ReturnCode, string Infobar) CoProductSaveSp(Guid? TmpCoProduct = null,
		string RefStr = null,
		string Infobar = null,
		string Item = null,
		decimal? QtyComplete = null,
		decimal? QtyScrapped = null,
		decimal? QtyMoved = null,
		string ReasonCode = null,
		int? NextOper = null,
		string Loc = null,
		string Lot = null);
	}
}

