//PROJECT NAME: ReportExt
//CLASS NAME: SLItemRevisionReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLItemRevisionReport")]
    public class SLItemRevisionReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ItemRevisionSp([Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string RevisionStarting,
		[Optional] string RevisionEnding,
		[Optional] string ProdCodeStarting,
		[Optional] string ProdCodeEnding,
		[Optional] string ExOptacAbcCode,
		[Optional] int? OperNumStarting,
		[Optional] int? OperNumEnding,
		[Optional] int? ECNNumStarting,
		[Optional] int? ECNNumEnding,
		[Optional] int? PJobRefs,
		[Optional] int? PItemManufacture,
		[Optional] int? PECNItem,
		[Optional] int? HighlightRevDiff,
		[Optional] int? PJobrouteNote,
		[Optional] int? PJobmatlNote,
		[Optional] int? PECNItemNote,
		[Optional] int? PageOper,
		[Optional] int? ExOptacChkEffDates,
		[Optional] DateTime? ExOptdfEffDate,
		[Optional, DefaultParameterValue(1)] int? ShowInternal,
		[Optional, DefaultParameterValue(1)] int? ShowExternal,
		[Optional] int? ExOptdfEffDateOffset,
		[Optional] string SummaryDetail,
		[Optional] string SiteGroup,
		[Optional] int? DisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			var iRpt_ItemRevisionExt = new Rpt_ItemRevisionFactory().Create(this, true);
			
			var result = iRpt_ItemRevisionExt.Rpt_ItemRevisionSp(ItemStarting,
			ItemEnding,
			RevisionStarting,
			RevisionEnding,
			ProdCodeStarting,
			ProdCodeEnding,
			ExOptacAbcCode,
			OperNumStarting,
			OperNumEnding,
			ECNNumStarting,
			ECNNumEnding,
			PJobRefs,
			PItemManufacture,
			PECNItem,
			HighlightRevDiff,
			PJobrouteNote,
			PJobmatlNote,
			PECNItemNote,
			PageOper,
			ExOptacChkEffDates,
			ExOptdfEffDate,
			ShowInternal,
			ShowExternal,
			ExOptdfEffDateOffset,
			SummaryDetail,
			SiteGroup,
			DisplayHeader,
			BGSessionId,
			pSite);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

    }
}
