//PROJECT NAME: ReportExt
//CLASS NAME: SLQCSupReadyForReceiptReport.cs

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
    [IDOExtensionClass("SLQCSupReadyForReceiptReport")]
    public class SLQCSupReadyForReceiptReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_SupReadyForReceiptsSSRSSp([Optional] int? showdetail,
		[Optional] int? displayheader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_SupReadyForReceiptsSSRSExt = new Rpt_RSQC_SupReadyForReceiptsSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_SupReadyForReceiptsSSRSExt.Rpt_RSQC_SupReadyForReceiptsSSRSSp(showdetail,
				displayheader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
