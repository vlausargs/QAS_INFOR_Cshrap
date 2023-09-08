//PROJECT NAME: Logistics
//CLASS NAME: IRmaTP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaTP
	{
		(int? ReturnCode,
			string Infobar) RmaTPSp(
			string ParamRmaNum,
			int? ParamRmaLine,
			string ParamLoc,
			string ParamLot,
			decimal? ParamQty,
			int? ParamReturn,
			int? ParamRetToStock,
			DateTime? ParamTransDate,
			string ParamReasonCode,
			string ParamWorkkey,
			Guid? SessionID,
			string Infobar,
			string ParamImportDocId,
			decimal? ParamMatlCost = null,
			decimal? ParamLbrCost = null,
			decimal? ParamFovhdCost = null,
			decimal? ParamVovhdCost = null,
			decimal? ParamOutCost = null,
			string ContainerNum = null,
			string ParamDocumentNum = null);
	}
}

