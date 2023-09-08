//PROJECT NAME: ReportExt
//CLASS NAME: SLQCIPYieldReport.cs

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
	[IDOExtensionClass("SLQCIPYieldReport")]
	public class SLQCIPYieldReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_IPYieldSSRSSp([Optional] string begjob,
		[Optional] string endjob,
		[Optional] int? begsuffix,
		[Optional] int? endsuffix,
		[Optional] string BegItem,
		[Optional] string enditem,
		[Optional] DateTime? begjdate,
		[Optional] DateTime? endjdate,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_IPYieldSSRSExt = new Rpt_RSQC_IPYieldSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_IPYieldSSRSExt.Rpt_RSQC_IPYieldSSRSSp(begjob,
				endjob,
				begsuffix,
				endsuffix,
				BegItem,
				enditem,
				begjdate,
				endjdate,
				DisplayHeader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
