//PROJECT NAME: Data
//CLASS NAME: IGetPhantomItemBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPhantomItemBOM
	{
		int? GetPhantomItemBOMSP(
			string Item,
			string PhantomComponent,
			decimal? PhantomItem_Qty = 1M,
			int? Explore_Phantom = 1,
			int? BomType = 0);
	}
}

