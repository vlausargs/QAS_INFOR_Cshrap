//PROJECT NAME: ReportExt
//CLASS NAME: SLQCIPResultsWorksheetReport.cs

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
    [IDOExtensionClass("SLQCIPResultsWorksheetReport")]
    public class SLQCIPResultsWorksheetReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_IPResultsWorksheetSSRSSp([Optional] string begitem,
		[Optional] string enditem,
		[Optional] int? begopernum,
		[Optional] int? endopernum,
		[Optional] int? printworksheet,
		[Optional] int? numentries,
		[Optional] int? pagepertest,
		[Optional] int? displayheader,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_IPResultsWorksheetSSRSExt = new Rpt_RSQC_IPResultsWorksheetSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_IPResultsWorksheetSSRSExt.Rpt_RSQC_IPResultsWorksheetSSRSSp(begitem,
				enditem,
				begopernum,
				endopernum,
				printworksheet,
				numentries,
				pagepertest,
				displayheader,
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
