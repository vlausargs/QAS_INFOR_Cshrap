//PROJECT NAME: Material
//CLASS NAME: IMvPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMvPost
	{
		(int? ReturnCode, decimal? PUnitCost,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		decimal? PTotCost,
		string Infobar) MvPostSp(string PType,
		DateTime? PDate,
		decimal? PQty,
		string PItem,
		string FromWhse,
		string FromLoc,
		string FromLot,
		string ToWhse,
		string ToLoc,
		string ToLot,
		int? PZeroCost,
		string PTrnNum,
		int? PTrnLine,
		decimal? PTransNum,
		decimal? PRsvdNum,
		string PStat,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		string RefStr = null,
		decimal? PUnitCost = null,
		decimal? PMatlCost = null,
		decimal? PLbrCost = null,
		decimal? PFovhdCost = null,
		decimal? PVovhdCost = null,
		decimal? POutCost = null,
		decimal? PTotCost = null,
		string Infobar = null,
		string DocumentNum = null,
		string FromImportDocId = null,
		string ToImportDocId = null,
		string ReasonCode = null,
		string EmpNum = null,
		DateTime? FromSiteRecordDate = null);
	}
}

