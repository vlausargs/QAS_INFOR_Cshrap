//PROJECT NAME: ReportExt
//CLASS NAME: SLQCCOCReport.cs

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
    [IDOExtensionClass("SLQCCOCReport")]
    public class SLQCCOCReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_COCSSRSSp([Optional] string BegCoc,
		[Optional] string EndCoc,
		[Optional] int? BegRcvr,
		[Optional] int? EndRcvr,
		[Optional] string BegCoNum,
		[Optional] string EndCoNum,
		[Optional] int? BegLine,
		[Optional] int? EndLine,
		[Optional] int? BegRel,
		[Optional] int? EndRel,
		[Optional] string BegCust,
		[Optional] string EndCust,
		[Optional] int? PrintCustNotes,
		[Optional] int? PrintOrderNotes,
		[Optional] int? PrintQCCustNotes,
		[Optional] int? PrintRcvrNotes,
		[Optional] int? PrintCocNotes,
		[Optional] int? ShowTests,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		[Optional] string ref_type,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_COCSSRSExt = new Rpt_RSQC_COCSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_COCSSRSExt.Rpt_RSQC_COCSSRSSp(BegCoc,
				EndCoc,
				BegRcvr,
				EndRcvr,
				BegCoNum,
				EndCoNum,
				BegLine,
				EndLine,
				BegRel,
				EndRel,
				BegCust,
				EndCust,
				PrintCustNotes,
				PrintOrderNotes,
				PrintQCCustNotes,
				PrintRcvrNotes,
				PrintCocNotes,
				ShowTests,
				PrintInternal,
				PrintExternal,
				ref_type,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
