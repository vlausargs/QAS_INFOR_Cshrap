//PROJECT NAME: ReportExt
//CLASS NAME: SLProjectPurchaseOrderCommitmentsReport.cs

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
    [IDOExtensionClass("SLProjectPurchaseOrderCommitmentsReport")]
    public class SLProjectPurchaseOrderCommitmentsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProjectPurchaseOrderCommitmentsSp([Optional] string ProjNumStarting,
		[Optional] string ProjNumEnding,
		[Optional] int? TaskNumStarting,
		[Optional] int? TaskNumEnding,
		[Optional] string ProjectStatus,
		[Optional] string POLineResStatus,
		[Optional] string JobStarting,
		[Optional] string JobEnding,
		[Optional] int? JobStartSuffix,
		[Optional] int? JobEndSuffix,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProjectPurchaseOrderCommitmentsExt = new Rpt_ProjectPurchaseOrderCommitmentsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProjectPurchaseOrderCommitmentsExt.Rpt_ProjectPurchaseOrderCommitmentsSp(ProjNumStarting,
				ProjNumEnding,
				TaskNumStarting,
				TaskNumEnding,
				ProjectStatus,
				POLineResStatus,
				JobStarting,
				JobEnding,
				JobStartSuffix,
				JobEndSuffix,
				PrintCost,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
