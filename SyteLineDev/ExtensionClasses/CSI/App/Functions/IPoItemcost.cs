//PROJECT NAME: Data
//CLASS NAME: IPoItemcost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoItemcost
	{
		(int? ReturnCode,
			decimal? PPlanCost,
			string Infobar) PoItemcostSp(
			string PItem,
			decimal? PQtyOrdered,
			string PCurrCode,
			string PVendNum,
			DateTime? EffectiveDate,
			decimal? PPlanCost,
			string Infobar);
	}
}

