//PROJECT NAME: ReportExt
//CLASS NAME: SLQCSupVRMAFormReport.cs

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
    [IDOExtensionClass("SLQCSupVRMAFormReport")]
    public class SLQCSupVRMAFormReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_SupVRMAFormSSRSSp([Optional] string begitem,
		[Optional] string enditem,
		[Optional] string begvend,
		[Optional] string endvend,
		[Optional] int? begvrma,
		[Optional] int? endvrma,
		[Optional] string sortby,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_SupVRMAFormSSRSExt = new Rpt_RSQC_SupVRMAFormSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_SupVRMAFormSSRSExt.Rpt_RSQC_SupVRMAFormSSRSSp(begitem,
				enditem,
				begvend,
				endvend,
				begvrma,
				endvrma,
				sortby,
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
