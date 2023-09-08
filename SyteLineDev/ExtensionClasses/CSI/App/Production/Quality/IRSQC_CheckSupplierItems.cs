//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckSupplierItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CheckSupplierItems
	{
		(int? ReturnCode,
			int? AutoAccept,
			int? NeedsQC,
			string EndingLoc,
			string Infobar) RSQC_CheckSupplierItemsSp(
			string Item,
			string VendNum,
			string Function,
			decimal? Qty,
			string StartingLoc,
			string Whse,
			int? AutoAccept,
			int? NeedsQC,
			string EndingLoc,
			string Infobar);
	}
}

