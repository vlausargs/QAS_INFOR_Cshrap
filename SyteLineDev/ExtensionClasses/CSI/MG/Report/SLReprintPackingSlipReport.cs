//PROJECT NAME: ReportExt
//CLASS NAME: SLReprintPackingSlipReport.cs

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
    [IDOExtensionClass("SLReprintPackingSlipReport")]
    public class SLReprintPackingSlipReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ReprintPackingSlipSp([Optional] int? PStartSlipNum,
		[Optional] int? PEndSlipNum,
		[Optional] int? PrintLineReleaseDescription,
		[Optional] int? PPrPlanItemMatl,
		[Optional] int? PPrSerialNumber,
		[Optional] int? PrintOrderNotes,
		[Optional] int? PrintLineReleaseNotes,
		[Optional] int? PrintinternalNotes,
		[Optional] int? PrintExternalNotes,
		[Optional] int? DisplayHeader,
		[Optional] int? PrintItemOverview,
		[Optional] ref string InfoBar,
		[Optional] string BGSessionId,
		[Optional] int? TaskId,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ReprintPackingSlipExt = new Rpt_ReprintPackingSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ReprintPackingSlipExt.Rpt_ReprintPackingSlipSp(PStartSlipNum,
				PEndSlipNum,
				PrintLineReleaseDescription,
				PPrPlanItemMatl,
				PPrSerialNumber,
				PrintOrderNotes,
				PrintLineReleaseNotes,
				PrintinternalNotes,
				PrintExternalNotes,
				DisplayHeader,
				PrintItemOverview,
				InfoBar,
				BGSessionId,
				TaskId,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				InfoBar = result.InfoBar;
				return dt;
			}
		}
    }
}
