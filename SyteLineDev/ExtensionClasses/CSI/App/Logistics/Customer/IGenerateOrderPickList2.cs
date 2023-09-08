//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickList2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickList2
	{
		(int? ReturnCode,
			string Infobar) GenerateOrderPickList2Sp(
			int? PFromCo14R,
			int? PProcessBatchId,
			Guid? PSessionId,
			int? PBarLoc,
			string PCoNum,
			string PCustNum,
			int? PCustSeq,
			string PWhse,
			DateTime? PStartDueDate,
			DateTime? PEndDueDate,
			string PParmsSite,
			string PDetSummBoth,
			int? PDisplayDescription,
			int? PListByLoc,
			string PPickwarn,
			int? PPostMatlIssues,
			DateTime? PPostDate,
			int? PPrintBc,
			string PPrItemCi,
			int? PPrPlanItemMatl,
			int? PPrSerialNumbers,
			int? PPrStdOrderText,
			int? PSuppressErrorWhenCustomerLcrNotReqd,
			int? PSkipOrderLineCycCnt,
			string PText,
			string PCoparmsCoText1,
			string PCoparmsCoText2,
			string PCoparmsCoText3,
			int? PCoparmsPickwarnCo,
			string PInvparmsFbomBlank,
			string PInvparmsFeatTempl,
			string Infobar);
	}
}

