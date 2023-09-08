//PROJECT NAME: Production
//CLASS NAME: IPmfValidateItemLotLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfValidateItemLotLoc
	{
		(int? ReturnCode,
			string InfoBar,
			string Lot) PmfValidateItemLotLocSp(
			string InfoBar = null,
			string Item = null,
			string Whse = null,
			string Lot = null,
			string Loc = null);
	}
}

