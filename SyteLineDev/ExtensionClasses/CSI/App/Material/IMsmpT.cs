//PROJECT NAME: Material
//CLASS NAME: IMsmpT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMsmpT
	{
		(int? ReturnCode,
			string Infobar) MsmpTSp(
			string PType,
			DateTime? PDate,
			decimal? PQty,
			string PItem,
			string PFromCurrCode,
			string PFromSite,
			string PToSite,
			string PToWhse,
			string PToLoc,
			string PToLot,
			string PTrnNum,
			int? PTrnLine,
			decimal? PTransNum,
			decimal? PRsvdNum,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			decimal? PMatlCost,
			decimal? PLbrCost,
			decimal? PVovhdCost,
			decimal? PFovhdCost,
			decimal? POutCost,
			decimal? PTotCost,
			decimal? PProfitMarkup,
			string Infobar,
			Guid? TmpSerId = null,
			int? UseExistingSerials = null,
			string SerialPrefix = null,
			string RemoteSiteLot = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string PImportDocId = null,
			string ReasonCode = null,
			string DocumentNum = null);
	}
}

