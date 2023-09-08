//PROJECT NAME: Material
//CLASS NAME: IMsmp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMsmp
	{
		(int? ReturnCode, decimal? PUnitCost,
		decimal? PMatlCost,
		decimal? PLbrCost,
		decimal? PFovhdCost,
		decimal? PVovhdCost,
		decimal? POutCost,
		decimal? PTotCost,
		string Infobar) MsmpSp(string PType,
		DateTime? PDate,
		decimal? PQty,
		string PItem,
		string PFromSite,
		string PFromWhse,
		string PFromLoc,
		string PFromLot,
		string PToSite,
		string PToWhse,
		string PToLoc,
		string PToLot,
		int? PZeroCost,
		string PTrnNum,
		int? PTrnLine,
		decimal? PTransNum,
		decimal? PRsvdNum,
		string PStat,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		string RemoteSiteLot = null,
		string PReasonCode = null,
		decimal? PUnitCost = null,
		decimal? PMatlCost = null,
		decimal? PLbrCost = null,
		decimal? PFovhdCost = null,
		decimal? PVovhdCost = null,
		decimal? POutCost = null,
		decimal? PTotCost = null,
		string Infobar = null,
		string PImportDocId = null,
		int? MoveZeroCostItem = 0,
		string EmpNum = null,
		int? CheckExternalWhseFlag = 0,
		string DocumentNum = null);
	}
}

