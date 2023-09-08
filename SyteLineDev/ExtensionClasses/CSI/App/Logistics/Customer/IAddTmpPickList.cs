//PROJECT NAME: Logistics
//CLASS NAME: IAddTmpPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAddTmpPickList
	{
		(int? ReturnCode, string Infobar) AddTmpPickListSp(Guid? ProcessID,
		string CoNum,
		int? CoLIne,
		int? CoRelease,
		DateTime? DueDate,
		string Item,
		string UM,
		decimal? PickQty,
		string CustNum,
		int? CustSeq,
		int? Group,
		string Whse,
		string PackLoc,
		string Picker,
		string Infobar);
	}
}

