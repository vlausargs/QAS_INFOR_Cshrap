//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickList
	{
		(int? ReturnCode, string Infobar) GenerateOrderPickListSp(Guid? PSessionId,
		string PCoNum,
		DateTime? PStartDueDate,
		DateTime? PEndDueDate,
		string PWhse,
		string PCustNum,
		int? PCustSeq,
		string PParmsSite,
		DateTime? PPostDate,
		int? PPostMatlIssues,
		int? PBarLoc,
		int? PShowExternal,
		int? PShowInternal,
		int? PDisplayHeader,
		int? PPrintBc,
		int? PPrint80,
		string PDetSummBoth,
		string PPrItemCi,
		int? PPrSerialNumbers,
		int? PPrPlanItemMatl,
		int? PPrStdOrderText,
		int? PDisplayDescription,
		int? PListByLoc,
		string PPickwarn,
		int? PSuppressErrorWhenCustomerLcrNotReqd,
		int? PSkipOrderLineCycCnt,
		int? PProcessBatchId = null,
		string PText = null,
		string Infobar = null);
	}
}

