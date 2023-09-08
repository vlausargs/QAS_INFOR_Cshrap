//PROJECT NAME: ReportExt
//CLASS NAME: SLMaterialAnalysisbyWorkCenterReport.cs

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
    [IDOExtensionClass("SLMaterialAnalysisbyWorkCenterReport")]
    public class SLMaterialAnalysisbyWorkCenterReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MaterialAnalysisbyWorkCenterSp([Optional] string StartingWc,
		[Optional] string EndingWc,
		[Optional] string StartingIterm,
		[Optional] string EndingIterm,
		[Optional] DateTime? StartingTransDate,
		[Optional] DateTime? EndingTransDate,
		[Optional] int? StartingTransDateOffset,
		[Optional] int? EndingTransDateOffset,
		[Optional] int? ShowDetail,
		[Optional] int? ShowHeader,
		[Optional] string pSite,
		[Optional] string DocumentNumStarting,
		[Optional] string DocumentNumEnding)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MaterialAnalysisbyWorkCenterExt = new Rpt_MaterialAnalysisbyWorkCenterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MaterialAnalysisbyWorkCenterExt.Rpt_MaterialAnalysisbyWorkCenterSp(StartingWc,
				EndingWc,
				StartingIterm,
				EndingIterm,
				StartingTransDate,
				EndingTransDate,
				StartingTransDateOffset,
				EndingTransDateOffset,
				ShowDetail,
				ShowHeader,
				pSite,
				DocumentNumStarting,
				DocumentNumEnding);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
