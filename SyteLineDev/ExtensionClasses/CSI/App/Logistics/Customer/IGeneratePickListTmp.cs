//PROJECT NAME: Logistics
//CLASS NAME: IGeneratePickListTmp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGeneratePickListTmp
	{
		(int? ReturnCode, string InfoBar) GeneratePickListTmpSp(Guid? ProcessId,
		int? Select,
		decimal? PickListId,
		string CustNum,
		int? CustSeq,
		string Whse,
		int? Group,
		string Packer,
		string ParentContainerNum,
		string InfoBar,
		string RefNum = null,
		int? RefLine = null,
		int? RefRelease = null,
		string RefType = null,
		decimal? Qty = 0,
		string Loc = null,
		string Lot = null);
	}
}

