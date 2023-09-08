//PROJECT NAME: ReportExt
//CLASS NAME: SLVendortobeShippedReport.cs

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
	[IDOExtensionClass("SLVendortobeShippedReport")]
	public class SLVendortobeShippedReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRMXRpt_VendorToBeShippedSp([Optional] string StartVendNum,
		[Optional] string EndVendNum,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] string StartRefNum,
		[Optional] string EndRefNum,
		[Optional, DefaultParameterValue(1)] int? InclPO,
		[Optional, DefaultParameterValue(1)] int? InclRMA,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSRMXRpt_VendorToBeShippedExt = new SSSRMXRpt_VendorToBeShippedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSRMXRpt_VendorToBeShippedExt.SSSRMXRpt_VendorToBeShippedSp(StartVendNum,
				EndVendNum,
				StartItem,
				EndItem,
				StartRefNum,
				EndRefNum,
				InclPO,
				InclRMA,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
