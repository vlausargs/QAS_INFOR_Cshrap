//PROJECT NAME: ReportExt
//CLASS NAME: SLReprintVendorPackingSlipReport.cs

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
	[IDOExtensionClass("SLReprintVendorPackingSlipReport")]
	public class SLReprintVendorPackingSlipReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRMXRpt_ReprintVendorPackingListSp(int? BegPackNum,
		int? EndPackNum,
		DateTime? BegPackDate,
		DateTime? EndPackDate,
		string BegWhse,
		string EndWhse,
		string BegVendor,
		string EndVendor,
		int? DisplayHeaderVar,
		int? PrintDispVar,
		int? PrintLineReleaseTextVar,
		int? PrintInternalNotesVar,
		int? PrintExternalNotesVar,
		[Optional, DefaultParameterValue(0)] int? PrintItemOverviewVar,
		string Infobar,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSRMXRpt_ReprintVendorPackingListExt = new SSSRMXRpt_ReprintVendorPackingListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSRMXRpt_ReprintVendorPackingListExt.SSSRMXRpt_ReprintVendorPackingListSp(BegPackNum,
				EndPackNum,
				BegPackDate,
				EndPackDate,
				BegWhse,
				EndWhse,
				BegVendor,
				EndVendor,
				DisplayHeaderVar,
				PrintDispVar,
				PrintLineReleaseTextVar,
				PrintInternalNotesVar,
				PrintExternalNotesVar,
				PrintItemOverviewVar,
				Infobar,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
