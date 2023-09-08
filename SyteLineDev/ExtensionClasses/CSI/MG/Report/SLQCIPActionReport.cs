//PROJECT NAME: ReportExt
//CLASS NAME: SLQCIPActionReport.cs

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
    [IDOExtensionClass("SLQCIPActionReport")]
    public class SLQCIPActionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RPT_RSQC_IPActionSSRSSp([Optional] string begjob,
		[Optional] string endjob,
		[Optional] int? begsuffix,
		[Optional] int? endsuffix,
		[Optional] string begpsnum,
		[Optional] string endpsnum,
		[Optional] string JustJobs,
		[Optional] int? ShowDetail,
		[Optional] int? DisplayHeader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRPT_RSQC_IPActionSSRSExt = new RPT_RSQC_IPActionSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRPT_RSQC_IPActionSSRSExt.RPT_RSQC_IPActionSSRSSp(begjob,
				endjob,
				begsuffix,
				endsuffix,
				begpsnum,
				endpsnum,
				JustJobs,
				ShowDetail,
				DisplayHeader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
