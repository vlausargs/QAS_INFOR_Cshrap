//PROJECT NAME: ReportExt
//CLASS NAME: SLQCTRRStatusReport.cs

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
    [IDOExtensionClass("SLQCTRRStatusReport")]
    public class SLQCTRRStatusReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_TRRStatusSSRSSp([Optional] string beginsp,
		[Optional] string endinsp,
		[Optional] DateTime? begcdate,
		[Optional] DateTime? endcdate,
		[Optional] DateTime? begcldate,
		[Optional] DateTime? endcldate,
		[Optional] string begtrr,
		[Optional] string endtrr,
		[Optional, DefaultParameterValue(1)] int? openonly,
		[Optional] int? displayheader,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_TRRStatusSSRSExt = new Rpt_RSQC_TRRStatusSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_TRRStatusSSRSExt.Rpt_RSQC_TRRStatusSSRSSp(beginsp,
				endinsp,
				begcdate,
				endcdate,
				begcldate,
				endcldate,
				begtrr,
				endtrr,
				openonly,
				displayheader,
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
