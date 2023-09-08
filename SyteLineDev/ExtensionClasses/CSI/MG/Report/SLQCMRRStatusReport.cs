//PROJECT NAME: ReportExt
//CLASS NAME: SLQCMRRStatusReport.cs

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
    [IDOExtensionClass("SLQCMRRStatusReport")]
    public class SLQCMRRStatusReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_MRRStatusSSRSSp([Optional] string beginsp,
		[Optional] string endinsp,
		[Optional] DateTime? begcdate,
		[Optional] DateTime? endcdate,
		[Optional] DateTime? begsdate,
		[Optional] DateTime? endsdate,
		[Optional] DateTime? begcldate,
		[Optional] DateTime? endcldate,
		[Optional] string begmrr,
		[Optional] string endmrr,
		[Optional] string begitem,
		[Optional] string enditem,
		[Optional] string reftype,
		[Optional, DefaultParameterValue(1)] int? openonly,
		[Optional] int? displayheader,
		[Optional] int? PrintNotes,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_MRRStatusSSRSExt = new Rpt_RSQC_MRRStatusSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_MRRStatusSSRSExt.Rpt_RSQC_MRRStatusSSRSSp(beginsp,
				endinsp,
				begcdate,
				endcdate,
				begsdate,
				endsdate,
				begcldate,
				endcldate,
				begmrr,
				endmrr,
				begitem,
				enditem,
				reftype,
				openonly,
				displayheader,
				PrintNotes,
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
