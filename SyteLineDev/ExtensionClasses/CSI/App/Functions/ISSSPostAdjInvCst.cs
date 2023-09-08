//PROJECT NAME: Data
//CLASS NAME: ISSSPostAdjInvCst.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISSSPostAdjInvCst
	{
		(int? ReturnCode,
			string Infobar) SSSPostAdjInvCstSp(
			decimal? iInvQty,
			DateTime? iPostDate,
			decimal? iSum,
			string iCustNum,
			string iItem,
			string iWhse,
			string iLoc,
			string iLot,
			decimal? iMatltranTransNum,
			decimal? iMatltranMatlCost,
			decimal? iMatltranLbrCost,
			decimal? iMatltranFovhdCost,
			decimal? iMatltranVovhdCost,
			decimal? iMatltranOutCost,
			decimal? iMatltranCost,
			string iJournalId,
			int? iPreUpdateQtys,
			string iReference,
			string Infobar);
	}
}

