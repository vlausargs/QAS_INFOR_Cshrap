//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderInspectionReport.cs

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
	[IDOExtensionClass("SLServiceOrderInspectionReport")]
	public class SLServiceOrderInspectionReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROInspectionSp([Optional] string StartSroNum,
		[Optional] string EndSroNum,
		[Optional] int? StartSroLine,
		[Optional] int? EndSroLine,
		[Optional] string StartInspectType,
		[Optional] string EndInspectType,
		[Optional] string StartLineSerNum,
		[Optional] string EndLineSerNum,
		[Optional] string StartLineItem,
		[Optional] string EndLineItem,
		[Optional] string StartSerNum,
		[Optional] string EndSerNum,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] string StartPartner,
		[Optional] string EndPartner,
		[Optional] DateTime? StartInspDate,
		[Optional] DateTime? EndInspDate,
		[Optional, DefaultParameterValue(0)] int? PrintSRONotes,
		[Optional, DefaultParameterValue(0)] int? PrintSROLineNotes,
		[Optional, DefaultParameterValue(0)] int? PrintInspNotes,
		[Optional, DefaultParameterValue(0)] int? PrintInternalNotes,
		[Optional, DefaultParameterValue(0)] int? PrintExternalNotes,
		[Optional, DefaultParameterValue(0)] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROInspectionExt = new SSSFSRpt_SROInspectionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROInspectionExt.SSSFSRpt_SROInspectionSp(StartSroNum,
				EndSroNum,
				StartSroLine,
				EndSroLine,
				StartInspectType,
				EndInspectType,
				StartLineSerNum,
				EndLineSerNum,
				StartLineItem,
				EndLineItem,
				StartSerNum,
				EndSerNum,
				StartItem,
				EndItem,
				StartPartner,
				EndPartner,
				StartInspDate,
				EndInspDate,
				PrintSRONotes,
				PrintSROLineNotes,
				PrintInspNotes,
				PrintInternalNotes,
				PrintExternalNotes,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
