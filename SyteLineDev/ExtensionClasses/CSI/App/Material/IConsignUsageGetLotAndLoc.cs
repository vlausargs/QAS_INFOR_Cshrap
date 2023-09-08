//PROJECT NAME: Material
//CLASS NAME: IConsignUsageGetLotAndLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IConsignUsageGetLotAndLoc
	{
		(int? ReturnCode, string Loc,
		string Lot,
		string ImportDocId,
		string TrxRestrictCode) ConsignUsageGetLotAndLocSp(string CurrWhse,
		string Item,
		string ConsignWhse,
		string ConsignLoc,
		string Loc,
		string Lot,
		string ImportDocId,
		string TrxRestrictCode);
	}
}

