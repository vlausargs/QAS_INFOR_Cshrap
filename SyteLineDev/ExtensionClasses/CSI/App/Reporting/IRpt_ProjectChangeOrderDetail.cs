//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjectChangeOrderDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjectChangeOrderDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectChangeOrderDetailSp(string pChgStat = null,
		string pPrChgTxtDet = null,
		string pStartProjNum = null,
		string pEndProjNum = null,
		int? pStartChgNum = null,
		int? pEndChgNum = null,
		int? pStartTaskNum = null,
		int? pEndTaskNum = null,
		int? pStartSeq = null,
		int? pEndSeq = null,
		DateTime? pStartChgDate = null,
		DateTime? pEndChgDate = null,
		int? pStartChgDateOffset = null,
		int? pEndChgDateOffset = null,
		int? Showinternal = 1,
		int? ShowExternal = 1,
		int? DisplayHeader = null,
		string PMessageLanguage = null,
		string pSite = null);
	}
}

