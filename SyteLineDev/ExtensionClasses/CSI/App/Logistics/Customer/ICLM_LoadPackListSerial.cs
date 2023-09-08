//PROJECT NAME: Logistics
//CLASS NAME: ICLM_LoadPackListSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_LoadPackListSerial
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_LoadPackListSerialSp(decimal? PickListId,
		string Item,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Whse,
		string Loc,
		string Lot,
		decimal? Qty,
		string ParentContainerNum,
		int? Gen,
		decimal? GenQty,
		string Infobar);
	}
}

