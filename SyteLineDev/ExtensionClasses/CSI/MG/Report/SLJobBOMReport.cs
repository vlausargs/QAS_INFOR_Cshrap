//PROJECT NAME: ReportExt
//CLASS NAME: SLJobBOMReport.cs

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
    [IDOExtensionClass("SLJobBOMReport")]
    public class SLJobBOMReport : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobBOMSp([Optional] string JobStarting,
			[Optional] string JobEnding,
			[Optional] int? SuffixStarting,
			[Optional] int? SuffixEnding,
			[Optional] string PageJob3,
			[Optional] int? RefFields,
			[Optional] string SortBy,
			[Optional] string DisplayLevel,
			[Optional] int? PrintCost,
			[Optional] int? DisplayHeader,
			[Optional] string pSite)
		{
			var iRpt_JobBOMExt = new Rpt_JobBOMFactory().Create(this, true);

			var result = iRpt_JobBOMExt.Rpt_JobBOMSp(JobStarting,
				JobEnding,
				SuffixStarting,
				SuffixEnding,
				PageJob3,
				RefFields,
				SortBy,
				DisplayLevel,
				PrintCost,
				DisplayHeader,
				pSite);

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
