//PROJECT NAME: ReportExt
//CLASS NAME: SLQCGageReport.cs

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
    [IDOExtensionClass("SLQCGageReport")]
    public class SLQCGageReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RPT_RSQC_GageReportSSRSSp([Optional] string BegGage,
		[Optional] string EndGage,
		[Optional] string BegStat,
		[Optional] string EndStat,
		[Optional] string BegGageType,
		[Optional] string EndGageType,
		[Optional] int? DisplayHistory,
		[Optional] int? DisplayHeader,
		string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRPT_RSQC_GageReportSSRSExt = new RPT_RSQC_GageReportSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRPT_RSQC_GageReportSSRSExt.RPT_RSQC_GageReportSSRSSp(BegGage,
				EndGage,
				BegStat,
				EndStat,
				BegGageType,
				EndGageType,
				DisplayHistory,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
