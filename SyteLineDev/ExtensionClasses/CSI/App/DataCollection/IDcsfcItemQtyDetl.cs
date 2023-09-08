//PROJECT NAME: DataCollection
//CLASS NAME: IDcsfcItemQtyDetl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcsfcItemQtyDetl
	{
		(int? ReturnCode,
			string Infobar) DcsfcItemQtyDetlSp(
			string Whse,
			string Item,
			string Loc,
			string Lot,
			decimal? DeltaQty,
			int? Override,
			string Infobar);
	}
}

