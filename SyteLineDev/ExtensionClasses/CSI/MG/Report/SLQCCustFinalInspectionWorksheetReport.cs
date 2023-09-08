//PROJECT NAME: ReportExt
//CLASS NAME: SLQCCustFinalInspectionWorksheetReport.cs

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
    [IDOExtensionClass("SLQCCustFinalInspectionWorksheetReport")]
    public class SLQCCustFinalInspectionWorksheetReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_CustFinalInspectionWorksheetSSRSSp([Optional] string BegCust,
		[Optional] string EndCust,
		[Optional] string BegItem,
		[Optional] string EndItem,
		[Optional] int? NumEntries,
		[Optional] int? PrintWorksheet,
		[Optional] int? DisplayHeader,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_CustFinalInspectionWorksheetSSRSExt = new Rpt_RSQC_CustFinalInspectionWorksheetSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_CustFinalInspectionWorksheetSSRSExt.Rpt_RSQC_CustFinalInspectionWorksheetSSRSSp(BegCust,
				EndCust,
				BegItem,
				EndItem,
				NumEntries,
				PrintWorksheet,
				DisplayHeader,
				PrintInternal,
				PrintExternal,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
