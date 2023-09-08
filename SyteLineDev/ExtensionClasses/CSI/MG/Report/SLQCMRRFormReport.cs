//PROJECT NAME: ReportExt
//CLASS NAME: SLQCMRRFormReport.cs

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
    [IDOExtensionClass("SLQCMRRFormReport")]
    public class SLQCMRRFormReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_MRRFormSSRSSp([Optional] string begmrr,
		[Optional] string endmrr,
		[Optional] string begitem,
		[Optional] string enditem,
		[Optional] string beginsp,
		[Optional] string endinsp,
		[Optional] DateTime? begcdate,
		[Optional] DateTime? endcdate,
		[Optional] DateTime? begsdate,
		[Optional] DateTime? endsdate,
		[Optional] string reftype,
		[Optional] int? printcost,
		[Optional] int? showtrans,
		[Optional] int? shownotes,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_MRRFormSSRSExt = new Rpt_RSQC_MRRFormSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_MRRFormSSRSExt.Rpt_RSQC_MRRFormSSRSSp(begmrr,
				endmrr,
				begitem,
				enditem,
				beginsp,
				endinsp,
				begcdate,
				endcdate,
				begsdate,
				endsdate,
				reftype,
				printcost,
				showtrans,
				shownotes,
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
