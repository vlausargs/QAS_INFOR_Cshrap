//PROJECT NAME: ReportExt
//CLASS NAME: SLJobHeaderReport.cs

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
    [IDOExtensionClass("SLJobHeaderReport")]
    public class SLJobHeaderReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobHeaderSp([Optional] string StartJob,
			[Optional] string EndJob,
			[Optional] int? StartSuffix,
			[Optional] int? EndSuffix,
			[Optional] string JobStat,
			[Optional] string StartItem,
			[Optional] string EndItem,
			[Optional] string StartProdMix,
			[Optional] string EndProdMix,
			[Optional] DateTime? StartJobDate,
			[Optional] DateTime? EndJobDate,
			[Optional] int? JobHdrDate,
			[Optional] int? PrintBCFmt,
			[Optional] int? StartJobDateOffset,
			[Optional] int? EndJobDateOffset,
			[Optional] int? JobShowInternal,
			[Optional] int? JobShowExternal,
			[Optional] int? DisplayHeader,
			[Optional] string BGSessionId,
			[Optional] string pSite)
		{
			var iRpt_JobHeaderExt = new Rpt_JobHeaderFactory().Create(this, true);

			var result = iRpt_JobHeaderExt.Rpt_JobHeaderSp(StartJob,
				EndJob,
				StartSuffix,
				EndSuffix,
				JobStat,
				StartItem,
				EndItem,
				StartProdMix,
				EndProdMix,
				StartJobDate,
				EndJobDate,
				JobHdrDate,
				PrintBCFmt,
				StartJobDateOffset,
				EndJobDateOffset,
				JobShowInternal,
				JobShowExternal,
				DisplayHeader,
				BGSessionId,
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
