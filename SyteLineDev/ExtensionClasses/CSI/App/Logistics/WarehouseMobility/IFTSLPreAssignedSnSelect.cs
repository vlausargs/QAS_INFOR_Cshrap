//PROJECT NAME: Logistics
//CLASS NAME: IFTSLPreAssignedSnSelect.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLPreAssignedSnSelect
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) FTSLPreAssignedSnSelectSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		string Infobar);
	}
}

