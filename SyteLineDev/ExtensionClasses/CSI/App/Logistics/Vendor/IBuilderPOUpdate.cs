//PROJECT NAME: Logistics
//CLASS NAME: IBuilderPOUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IBuilderPOUpdate
	{
		(int? ReturnCode,
			string Infobar) BuilderPOUpdateSp(
			string pPoType,
			string pPoStat,
			int? pPostFlag,
			string pReviewPrint,
			string pOrigSite,
			string pStartvendor,
			string pEndVendor,
			int? pTransDomCurr,
			string pStartBuilderPoNum,
			string pEndBuilderPoNum,
			int? pStartPoLine,
			int? pEndPoLine,
			int? pStartPoRelease,
			int? pEndPoRelease,
			DateTime? pStartDueDate,
			DateTime? pEndDueDate,
			string pPoitemStat,
			DateTime? pStartOrderDate,
			DateTime? pEndOrderDate,
			int? pIncludeRegularPO,
			int? pIncludeBlanketPO,
			int? pIncludeBlnsWOReleases,
			int? pIncludePlannedPO,
			int? pIncludeOrderedPO,
			int? pIncludeCompletePO,
			int? pIncludePlannedLineRel,
			int? pIncludeOrderedLineRel,
			int? pIncludeFilledLineRel,
			int? pIncludeCompleteLineRel,
			int? pPrPoNotes,
			int? pPrPoBlnNotes,
			int? pPrPoItemNotes,
			int? pShowInternal,
			int? pShowExternal,
			string pPrintSite,
			Guid? pProcessId,
			string Infobar);
	}
}

