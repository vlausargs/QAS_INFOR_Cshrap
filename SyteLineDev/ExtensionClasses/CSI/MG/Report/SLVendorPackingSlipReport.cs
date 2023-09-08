//PROJECT NAME: ReportExt
//CLASS NAME: SLVendorPackingSlipReport.cs

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
	[IDOExtensionClass("SLVendorPackingSlipReport")]
	public class SLVendorPackingSlipReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRMXRpt_VendorPackingSlipSp(string CalledType,
		int? BegPackNum,
		int? EndPackNum,
		int? PrintDisp,
		int? PrintLineReleaseText,
		int? PrintExternalNotes,
		int? PrintInternalNotes,
		int? DisplayHeader,
		[Optional, DefaultParameterValue(0)] int? PrintItemOverview,
		string Whse,
		int? RefTypeM,
		int? RefTypeP,
		string BegVendNum,
		string EndBendNum,
		string BegRefNum,
		string EndRefNum,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSRMXRpt_VendorPackingSlipExt = new SSSRMXRpt_VendorPackingSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSRMXRpt_VendorPackingSlipExt.SSSRMXRpt_VendorPackingSlipSp(CalledType,
				BegPackNum,
				EndPackNum,
				PrintDisp,
				PrintLineReleaseText,
				PrintExternalNotes,
				PrintInternalNotes,
				DisplayHeader,
				PrintItemOverview,
				Whse,
				RefTypeM,
				RefTypeP,
				BegVendNum,
				EndBendNum,
				BegRefNum,
				EndRefNum,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
