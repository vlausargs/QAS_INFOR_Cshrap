//PROJECT NAME: Data
//CLASS NAME: IGetKitItemBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetKitItemBOM
	{
		int? GetKitItemBOMSP(
			string KitItem,
			string KitComponent,
			decimal? Item_Qty = 1M,
			int? Expand_Phantom = 1,
			int? BomType = 0);
	}
}

