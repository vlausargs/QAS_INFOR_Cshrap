//PROJECT NAME: DataCollection
//CLASS NAME: IDcsfcItemSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcsfcItemSave
	{
		int? DcsfcItemSaveSp(int? TransNum,
		string Item,
		decimal? QtyComplete,
		decimal? QtyMoved,
		decimal? QtyScrapped,
		string Reason,
		int? NextOper,
		string Location,
		string Lot);
	}
}

