//PROJECT NAME: ReportExt
//CLASS NAME: SLQCCustRMAAnalysisReport.cs

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
    [IDOExtensionClass("SLQCCustRMAAnalysisReport")]
    public class SLQCCustRMAAnalysisReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_CustRMAAnalysisSSRSSp([Optional] string begitem,
		[Optional] string enditem,
		[Optional] string begcust,
		[Optional] string endcust,
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
				
				var iRpt_RSQC_CustRMAAnalysisSSRSExt = new Rpt_RSQC_CustRMAAnalysisSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_CustRMAAnalysisSSRSExt.Rpt_RSQC_CustRMAAnalysisSSRSSp(begitem,
				enditem,
				begcust,
				endcust,
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
