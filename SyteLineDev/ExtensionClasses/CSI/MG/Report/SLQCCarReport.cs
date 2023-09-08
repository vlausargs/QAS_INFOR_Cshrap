//PROJECT NAME: ReportExt
//CLASS NAME: SLQCCarReport.cs

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
    [IDOExtensionClass("SLQCCarReport")]
    public class SLQCCarReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_CARFormSSRSSp([Optional] string begcar,
		[Optional] string endcar,
		[Optional] string begitem,
		[Optional] string enditem,
		[Optional] string begentity,
		[Optional] string endentity,
		[Optional] string beginsp,
		[Optional] string endinsp,
		[Optional] DateTime? begcdate,
		[Optional] DateTime? endcdate,
		[Optional] DateTime? begddate,
		[Optional] DateTime? endddate,
		[Optional] string status,
		[Optional] string reftype,
		[Optional] int? printcost,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_CARFormSSRSExt = new Rpt_RSQC_CARFormSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_CARFormSSRSExt.Rpt_RSQC_CARFormSSRSSp(begcar,
				endcar,
				begitem,
				enditem,
				begentity,
				endentity,
				beginsp,
				endinsp,
				begcdate,
				endcdate,
				begddate,
				endddate,
				status,
				reftype,
				printcost,
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
