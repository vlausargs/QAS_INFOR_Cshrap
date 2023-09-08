//PROJECT NAME: Reporting
//CLASS NAME: IRpt_GenerateOrderPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_GenerateOrderPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_GenerateOrderPickListSp(string PSessionIdChar = null,
		string PStartCoNum = null,
		string PEndCoNum = null,
		DateTime? PStartDueDate = null,
		DateTime? PEndDueDate = null,
		string PStartWhse = null,
		string PEndWhse = null,
		string PStartCustNum = null,
		string PEndCustNum = null,
		int? PStartCustSeq = null,
		int? PEndCustSeq = null,
		string PParmsSite = null,
		DateTime? PPostDate = null,
		int? PPostMatlIssues = null,
		int? PBarLoc = null,
		int? PShowExternal = null,
		int? PShowInternal = null,
		int? PDisplayHeader = null,
		int? PPrintBc = null,
		int? PPrint80 = null,
		string PDetSummBoth = null,
		string PPrItemCi = null,
		int? PPrSerialNumbers = null,
		int? PPrPlanItemMatl = null,
		int? PPrStdOrderText = null,
		int? PDisplayDescription = null,
		int? PListByLoc = null,
		string PPickwarn = null,
		int? PSuppressErrorWhenCustomerLcrNotReqd = null,
		int? PSkipOrderLineCycCnt = null,
		int? PProcessBatchId = null,
		int? TaskId = null,
		int? pPrintManufacturerItem = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? PostDateOffset = null,
		string pSite = null,
		decimal? UserID = null);
	}
}

