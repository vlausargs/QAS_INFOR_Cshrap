//PROJECT NAME: ReportExt
//CLASS NAME: SLQCIPCostOfQualityReport.cs

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
	[IDOExtensionClass("SLQCIPCostOfQualityReport")]
	public class SLQCIPCostOfQualityReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_IPCostOfQualitySSRSSp([Optional] string begitem,
		[Optional] string enditem,
		[Optional] DateTime? begddate,
		[Optional] DateTime? endddate,
		[Optional] string begmrr,
		[Optional] string endmrr,
		[Optional] string begcar,
		[Optional] string endcar,
		[Optional, DefaultParameterValue(0)] int? displayheader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_IPCostOfQualitySSRSExt = new Rpt_RSQC_IPCostOfQualitySSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_IPCostOfQualitySSRSExt.Rpt_RSQC_IPCostOfQualitySSRSSp(begitem,
				enditem,
				begddate,
				endddate,
				begmrr,
				endmrr,
				begcar,
				endcar,
				displayheader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
