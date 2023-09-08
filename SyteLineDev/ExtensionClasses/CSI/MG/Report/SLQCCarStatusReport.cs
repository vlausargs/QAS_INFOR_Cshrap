//PROJECT NAME: ReportExt
//CLASS NAME: SLQCCarStatusReport.cs

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
    [IDOExtensionClass("SLQCCarStatusReport")]
    public class SLQCCarStatusReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_CARStatusSSRSSp([Optional] string beginsp,
		[Optional] string endinsp,
		[Optional] DateTime? begcdate,
		[Optional] DateTime? endcdate,
		[Optional] DateTime? begddate,
		[Optional] DateTime? endddate,
		[Optional] DateTime? begcldate,
		[Optional] DateTime? endcldate,
		[Optional] string begitem,
		[Optional] string enditem,
		[Optional] string reftype,
		[Optional] int? openonly,
		[Optional] int? shownotes,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		[Optional] int? displayheader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_CARStatusSSRSExt = new Rpt_RSQC_CARStatusSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_CARStatusSSRSExt.Rpt_RSQC_CARStatusSSRSSp(beginsp,
				endinsp,
				begcdate,
				endcdate,
				begddate,
				endddate,
				begcldate,
				endcldate,
				begitem,
				enditem,
				reftype,
				openonly,
				shownotes,
				PrintInternal,
				PrintExternal,
				displayheader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
