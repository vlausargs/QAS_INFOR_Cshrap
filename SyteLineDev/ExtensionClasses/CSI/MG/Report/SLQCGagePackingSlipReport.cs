//PROJECT NAME: ReportExt
//CLASS NAME: SLQCGagePackingSlipReport.cs

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
    [IDOExtensionClass("SLQCGagePackingSlipReport")]
    public class SLQCGagePackingSlipReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RPT_RSQC_GagePackingSlipSSRSSp([Optional] string BegGage,
		[Optional] string EndGage,
		[Optional] string BegStat,
		[Optional] string EndStat,
		[Optional] DateTime? BegCalDate,
		[Optional] DateTime? EndCalDate,
		[Optional] int? PrintInternal,
		[Optional] int? PrintExternal,
		[Optional] int? PrintCalNotes,
		[Optional] int? DisplayHeader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRPT_RSQC_GagePackingSlipSSRSExt = new RPT_RSQC_GagePackingSlipSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRPT_RSQC_GagePackingSlipSSRSExt.RPT_RSQC_GagePackingSlipSSRSSp(BegGage,
				EndGage,
				BegStat,
				EndStat,
				BegCalDate,
				EndCalDate,
				PrintInternal,
				PrintExternal,
				PrintCalNotes,
				DisplayHeader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
