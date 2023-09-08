//PROJECT NAME: Data
//CLASS NAME: IMvRsvd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMvRsvd
	{
		(int? ReturnCode,
			string Infobar) MvRsvdSp(
			decimal? PQty,
			string PItem,
			string PWhse,
			string FrLoc,
			string FrLot,
			string ToLoc,
			string ToLot,
			string PWorkkey = null,
			string Infobar = null,
			string FrImportDocId = null,
			string ToImportDocId = null);
	}
}

