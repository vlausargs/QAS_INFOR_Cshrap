//PROJECT NAME: ReportExt
//CLASS NAME: SLQCTestResultReport.cs

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
    [IDOExtensionClass("SLQCTestResultReport")]
    public class SLQCTestResultReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_TestResultsSSRSSp([Optional] string begitem,
		[Optional] string enditem,
		[Optional] DateTime? begtdate,
		[Optional] DateTime? endtdate,
		[Optional] string beginsp,
		[Optional] string endinsp,
		[Optional] string begrefnum,
		[Optional] string endrefnum,
		[Optional] int? begrcvr,
		[Optional] int? endrcvr,
		[Optional] string testtype,
		[Optional] string reftype,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		[Optional] int? displayheader,
		[Optional] int? firstarticle,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_TestResultsSSRSExt = new Rpt_RSQC_TestResultsSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_TestResultsSSRSExt.Rpt_RSQC_TestResultsSSRSSp(begitem,
				enditem,
				begtdate,
				endtdate,
				beginsp,
				endinsp,
				begrefnum,
				endrefnum,
				begrcvr,
				endrcvr,
				testtype,
				reftype,
				PrintInternal,
				PrintExternal,
				displayheader,
				firstarticle,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
