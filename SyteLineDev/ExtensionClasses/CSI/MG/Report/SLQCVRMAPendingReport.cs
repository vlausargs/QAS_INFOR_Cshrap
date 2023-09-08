//PROJECT NAME: ReportExt
//CLASS NAME: SLQCVRMAPendingReport.cs

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
    [IDOExtensionClass("SLQCVRMAPendingReport")]
    public class SLQCVRMAPendingReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_VRMAPendingSSRSSp([Optional] string BegItem,
		[Optional] string EndItem,
		[Optional] string BegVendor,
		[Optional] string EndVendor,
		[Optional] int? BegVrma,
		[Optional] int? EndVrma,
		[Optional] DateTime? BegDate,
		[Optional] DateTime? EndDate,
		[Optional] int? _internal,
		[Optional] int? external,
		[Optional] string orderby,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_VRMAPendingSSRSExt = new Rpt_RSQC_VRMAPendingSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_VRMAPendingSSRSExt.Rpt_RSQC_VRMAPendingSSRSSp(BegItem,
				EndItem,
				BegVendor,
				EndVendor,
				BegVrma,
				EndVrma,
				BegDate,
				EndDate,
				_internal,
				external,
				orderby,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
