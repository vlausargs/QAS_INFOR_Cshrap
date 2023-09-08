//PROJECT NAME: Data
//CLASS NAME: IMvRsvdCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMvRsvdCo
	{
		(int? ReturnCode,
			string Infobar) MvRsvdCoSp(
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
			string ToImportDocId = null,
			string PRsvdInvRefNum = null,
			int? PRsvdInvRefLine = null,
			int? PRsvdInvRefRelease = null,
			decimal? PRsvdInvRsvdNum = null);
	}
}

