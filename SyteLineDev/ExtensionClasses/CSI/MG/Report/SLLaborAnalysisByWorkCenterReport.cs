//PROJECT NAME: ReportExt
//CLASS NAME: SLLaborAnalysisByWorkCenterReport.cs

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
    [IDOExtensionClass("SLLaborAnalysisByWorkCenterReport")]
    public class SLLaborAnalysisByWorkCenterReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_LaborAnalysisbyWorkCenterSp([Optional] string StartWc,
		[Optional] string EWc,
		[Optional] string StartProductCode,
		[Optional] string EProductCode,
		[Optional] string StartItem,
		[Optional] string EItem,
		[Optional] DateTime? STransDate,
		[Optional] DateTime? ETransDate,
		[Optional] int? STransDateOffSET,
		[Optional] int? ETransDateOffSET,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_LaborAnalysisbyWorkCenterExt = new Rpt_LaborAnalysisbyWorkCenterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_LaborAnalysisbyWorkCenterExt.Rpt_LaborAnalysisbyWorkCenterSp(StartWc,
				EWc,
				StartProductCode,
				EProductCode,
				StartItem,
				EItem,
				STransDate,
				ETransDate,
				STransDateOffSET,
				ETransDateOffSET,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
