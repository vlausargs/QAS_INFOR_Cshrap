//PROJECT NAME: ReportExt
//CLASS NAME: SLQCCMRStatusReport.cs

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
    [IDOExtensionClass("SLQCCMRStatusReport")]
    public class SLQCCMRStatusReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_CMRStatusSSRSSp([Optional] string beginsp,
		[Optional] string endinsp,
		[Optional] DateTime? begcdate,
		[Optional] DateTime? endcdate,
		[Optional] DateTime? begcldate,
		[Optional] DateTime? endcldate,
		[Optional] string begcmr,
		[Optional] string endcmr,
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
				
				var iRpt_RSQC_CMRStatusSSRSExt = new Rpt_RSQC_CMRStatusSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_CMRStatusSSRSExt.Rpt_RSQC_CMRStatusSSRSSp(beginsp,
				endinsp,
				begcdate,
				endcdate,
				begcldate,
				endcldate,
				begcmr,
				endcmr,
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
