//PROJECT NAME: ReportExt
//CLASS NAME: SLQCCMRFormReport.cs

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
    [IDOExtensionClass("SLQCCMRFormReport")]
    public class SLQCCMRFormReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_CMRRFormSSRSSp([Optional] string begcmr,
		[Optional] string endcmr,
		[Optional] string beginsp,
		[Optional] string endinsp,
		[Optional] DateTime? begcreatedate,
		[Optional] DateTime? endcreatedate,
		[Optional] DateTime? begclosedate,
		[Optional] DateTime? endclosedate,
		[Optional] int? printnotes,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_CMRRFormSSRSExt = new Rpt_RSQC_CMRRFormSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_CMRRFormSSRSExt.Rpt_RSQC_CMRRFormSSRSSp(begcmr,
				endcmr,
				beginsp,
				endinsp,
				begcreatedate,
				endcreatedate,
				begclosedate,
				endclosedate,
				printnotes,
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
