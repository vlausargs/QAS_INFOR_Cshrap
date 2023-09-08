//PROJECT NAME: Data
//CLASS NAME: ISumCoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISumCoitem
	{
		int? SumCoitemSp(
			string ParmCoNum,
			decimal? ParmOldQtyOrdered,
			decimal? ParmOldDisc,
			decimal? ParmOldPrice,
			decimal? ParmOldLbrCost,
			decimal? ParmOldMatlCost,
			decimal? ParmOldFovhdCost,
			decimal? ParmOldVovhdCost,
			decimal? ParmOldOutCost,
			decimal? ParmNewDisc,
			decimal? ParmNewQtyOrdered,
			decimal? ParmNewPrice);
	}
}

