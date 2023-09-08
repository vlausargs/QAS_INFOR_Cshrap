//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderWorkOrderReport.cs

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
	[IDOExtensionClass("SLServiceOrderWorkOrderReport")]
	public class SLServiceOrderWorkOrderReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROWorkOrderSp([Optional] string StartSRONum,
		[Optional] string EndSRONum,
		[Optional] int? StartSROLine,
		[Optional] int? EndSROLine,
		[Optional] int? StartSROOper,
		[Optional] int? EndSROOper,
		[Optional] string StartCustNum,
		[Optional] string EndCustNum,
		[Optional] string StartSerNum,
		[Optional] string EndSerNum,
		[Optional, DefaultParameterValue("P")] string Type,
		[Optional, DefaultParameterValue(1)] int? PrintDetail,
		[Optional, DefaultParameterValue(0)] int? PrintReasonCodes,
		[Optional, DefaultParameterValue(0)] int? PrintShipTo,
		[Optional, DefaultParameterValue(0)] int? PrintWarrantyInfo,
		[Optional, DefaultParameterValue(0)] int? PrintSRONotes,
		[Optional, DefaultParameterValue(0)] int? PrintLineNotes,
		[Optional, DefaultParameterValue(0)] int? PrintOperNotes,
		[Optional, DefaultParameterValue(0)] int? PrintCustomerNotes,
		[Optional, DefaultParameterValue(0)] int? PrintReasonNotes,
		[Optional, DefaultParameterValue(1)] int? PrintInternalNotes,
		[Optional, DefaultParameterValue(1)] int? PrintExternalNotes,
		[Optional] int? DisplayHeader,
		[Optional, DefaultParameterValue(1)] int? PrintOpen,
		[Optional, DefaultParameterValue(0)] int? PrintClosed,
		[Optional, DefaultParameterValue(0)] int? PrintEstimate,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROWorkOrderExt = new SSSFSRpt_SROWorkOrderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROWorkOrderExt.SSSFSRpt_SROWorkOrderSp(StartSRONum,
				EndSRONum,
				StartSROLine,
				EndSROLine,
				StartSROOper,
				EndSROOper,
				StartCustNum,
				EndCustNum,
				StartSerNum,
				EndSerNum,
				Type,
				PrintDetail,
				PrintReasonCodes,
				PrintShipTo,
				PrintWarrantyInfo,
				PrintSRONotes,
				PrintLineNotes,
				PrintOperNotes,
				PrintCustomerNotes,
				PrintReasonNotes,
				PrintInternalNotes,
				PrintExternalNotes,
				DisplayHeader,
				PrintOpen,
				PrintClosed,
				PrintEstimate,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
