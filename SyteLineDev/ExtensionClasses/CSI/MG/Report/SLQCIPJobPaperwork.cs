//PROJECT NAME: ReportExt
//CLASS NAME: SLQCIPJobPaperwork.cs

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
    [IDOExtensionClass("SLQCIPJobPaperwork")]
    public class SLQCIPJobPaperwork : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_IPJobPaperworkSSRSSp([Optional] string begjob,
		[Optional] string endjob,
		[Optional] int? begsuffix,
		[Optional] int? endsuffix,
		[Optional] string begpsnum,
		[Optional] string endpsnum,
		[Optional] int? DisplayHeader,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_IPJobPaperworkSSRSExt = new Rpt_RSQC_IPJobPaperworkSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_IPJobPaperworkSSRSExt.Rpt_RSQC_IPJobPaperworkSSRSSp(begjob,
				endjob,
				begsuffix,
				endsuffix,
				begpsnum,
				endpsnum,
				DisplayHeader,
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
