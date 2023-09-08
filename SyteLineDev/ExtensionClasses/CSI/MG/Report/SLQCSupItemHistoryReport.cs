//PROJECT NAME: ReportExt
//CLASS NAME: SLQCSupItemHistoryReport.cs

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
    [IDOExtensionClass("SLQCSupItemHistoryReport")]
    public class SLQCSupItemHistoryReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_SupItemHistorySSRSSp([Optional] string begitem,
		[Optional] string enditem,
		[Optional] string begvend,
		[Optional] string endvend,
		[Optional] DateTime? begtdate,
		[Optional] DateTime? endtdate,
		[Optional] string sortby,
		[Optional] int? displayheader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_SupItemHistorySSRSExt = new Rpt_RSQC_SupItemHistorySSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_SupItemHistorySSRSExt.Rpt_RSQC_SupItemHistorySSRSSp(begitem,
				enditem,
				begvend,
				endvend,
				begtdate,
				endtdate,
				sortby,
				displayheader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
