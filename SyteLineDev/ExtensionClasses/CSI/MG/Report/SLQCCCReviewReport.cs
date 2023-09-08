//PROJECT NAME: ReportExt
//CLASS NAME: SLQCCCReviewReport.cs

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
    [IDOExtensionClass("SLQCCCReviewReport")]
    public class SLQCCCReviewReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_CCReviewSSRSSp([Optional] string CompanyName,
		[Optional] string ProductLine,
		[Optional] string begReasonCode,
		[Optional] string endReasonCode,
		[Optional] string begccr,
		[Optional] string endccr,
		[Optional] int? Openccr,
		[Optional] int? closeccr,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_CCReviewSSRSExt = new Rpt_RSQC_CCReviewSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_CCReviewSSRSExt.Rpt_RSQC_CCReviewSSRSSp(CompanyName,
				ProductLine,
				begReasonCode,
				endReasonCode,
				begccr,
				endccr,
				Openccr,
				closeccr,
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
