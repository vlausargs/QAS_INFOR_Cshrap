//PROJECT NAME: ReportExt
//CLASS NAME: SLQCTransactionReport.cs

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
    [IDOExtensionClass("SLQCTransactionReport")]
    public class SLQCTransactionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_TransactionSSRSSp([Optional] DateTime? begtdate,
		[Optional] DateTime? endtdate,
		[Optional] string begdcode,
		[Optional] string enddcode,
		[Optional] string begitem,
		[Optional] string enditem,
		[Optional] string beginsp,
		[Optional] string endinsp,
		[Optional] string beguser,
		[Optional] string enduser,
		[Optional] string reftype,
		[Optional] string status,
		[Optional] int? openonly,
		[Optional] string begentity,
		[Optional] string endentity,
		[Optional] int? displayheader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_TransactionSSRSExt = new Rpt_RSQC_TransactionSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_TransactionSSRSExt.Rpt_RSQC_TransactionSSRSSp(begtdate,
				endtdate,
				begdcode,
				enddcode,
				begitem,
				enditem,
				beginsp,
				endinsp,
				beguser,
				enduser,
				reftype,
				status,
				openonly,
				begentity,
				endentity,
				displayheader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
