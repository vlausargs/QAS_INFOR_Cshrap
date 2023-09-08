//PROJECT NAME: ReportExt
//CLASS NAME: SLVendorASNReconciliationReport.cs

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
    [IDOExtensionClass("SLVendorASNReconciliationReport")]
    public class SLVendorASNReconciliationReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_VendorASNReconciliationSp([Optional] string StartingGrn,
			[Optional] string EndingGrn,
			[Optional] string StartingVendor,
			[Optional] string EndingVendor,
			[Optional] DateTime? StartingHdrDate,
			[Optional] DateTime? EndingHdrDate,
			[Optional, DefaultParameterValue(0)] int? ExceptionsOnly,
			[Optional, DefaultParameterValue(0)] int? PrintGrnHdrNotes,
			[Optional, DefaultParameterValue(0)] int? PrintGrnLineNotes,
			[Optional, DefaultParameterValue(0)] int? ShowInternalNotes,
			[Optional, DefaultParameterValue(0)] int? ShowExternalNotes,
			[Optional] int? StartingHdrDateOffset,
			[Optional] int? EndingHdrDateOffset,
			[Optional, DefaultParameterValue(1)] int? DisplayHeader,
			[Optional] int? TaskId,
			[Optional] string pSite,
			[Optional, DefaultParameterValue(0)] int? PrintItemOverview)
		{
			var iRpt_VendorASNReconciliationExt = new Rpt_VendorASNReconciliationFactory().Create(this, true);

			var result = iRpt_VendorASNReconciliationExt.Rpt_VendorASNReconciliationSp(StartingGrn,
				EndingGrn,
				StartingVendor,
				EndingVendor,
				StartingHdrDate,
				EndingHdrDate,
				ExceptionsOnly,
				PrintGrnHdrNotes,
				PrintGrnLineNotes,
				ShowInternalNotes,
				ShowExternalNotes,
				StartingHdrDateOffset,
				EndingHdrDateOffset,
				DisplayHeader,
				TaskId,
				pSite,
				PrintItemOverview);


			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
	}
}
