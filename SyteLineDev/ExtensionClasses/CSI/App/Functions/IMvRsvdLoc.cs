//PROJECT NAME: Data
//CLASS NAME: IMvRsvdLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMvRsvdLoc
	{
		(int? ReturnCode,
			string Infobar) MvRsvdLocSp(
			string PItem,
			string PWhse,
			string Loc,
			string Lot,
			decimal? PQty,
			int? Fctr,
			string Infobar,
			string ImportDocId);
	}
}

