//PROJECT NAME: ReportExt
//CLASS NAME: SLQCSupVendorPerformanceReport.cs

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
    [IDOExtensionClass("SLQCSupVendorPerformanceReport")]
    public class SLQCSupVendorPerformanceReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_SupVendorPerformanceSSRSSp([Optional] string begvend,
		[Optional] string endvend,
		[Optional] DateTime? begtdate,
		[Optional] DateTime? endtdate,
		[Optional] string begitem,
		[Optional] string enditem,
		[Optional] int? showdetail,
		[Optional] int? displayheader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_SupVendorPerformanceSSRSExt = new Rpt_RSQC_SupVendorPerformanceSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_SupVendorPerformanceSSRSExt.Rpt_RSQC_SupVendorPerformanceSSRSSp(begvend,
				endvend,
				begtdate,
				endtdate,
				begitem,
				enditem,
				showdetail,
				displayheader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
