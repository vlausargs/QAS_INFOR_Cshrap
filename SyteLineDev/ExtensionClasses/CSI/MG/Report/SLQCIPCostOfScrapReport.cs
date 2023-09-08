//PROJECT NAME: ReportExt
//CLASS NAME: SLQCIPCostOfScrapReport.cs

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
	[IDOExtensionClass("SLQCIPCostOfScrapReport")]
	public class SLQCIPCostOfScrapReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_IPCostOfScrapSSRSSp([Optional] string BegItem,
		[Optional] string EndItem,
		[Optional] string begjob,
		[Optional] string endjob,
		[Optional] DateTime? begtdate,
		[Optional] DateTime? endtdate,
		[Optional] string begreason,
		[Optional] string endreason,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_IPCostOfScrapSSRSExt = new Rpt_RSQC_IPCostOfScrapSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_IPCostOfScrapSSRSExt.Rpt_RSQC_IPCostOfScrapSSRSSp(BegItem,
				EndItem,
				begjob,
				endjob,
				begtdate,
				endtdate,
				begreason,
				endreason,
				DisplayHeader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
