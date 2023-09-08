//PROJECT NAME: ReportExt
//CLASS NAME: SLSalesCommissionbySalespersonReport.cs

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
    [IDOExtensionClass("SLSalesCommissionbySalespersonReport")]
    public class SLSalesCommissionbySalespersonReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SalesCommissionbySalespersonSp([Optional] string StartSalesman,
		[Optional] string EndSalesman,
		[Optional] string StartClass,
		[Optional] string EndClass,
		[Optional] DateTime? StartDueDate,
		[Optional] DateTime? EndDueDate,
		[Optional] string CommStatus,
		[Optional] int? PrintPaidRec,
		[Optional] int? PageForSalesman,
		[Optional] int? PrintPaymentDetail,
		[Optional] int? StartDateOffset,
		[Optional] int? EndDateOffset,
		[Optional] int? PDisplayHeader,
		[Optional] string BGSessionId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SalesCommissionbySalespersonExt = new Rpt_SalesCommissionbySalespersonFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SalesCommissionbySalespersonExt.Rpt_SalesCommissionbySalespersonSp(StartSalesman,
				EndSalesman,
				StartClass,
				EndClass,
				StartDueDate,
				EndDueDate,
				CommStatus,
				PrintPaidRec,
				PageForSalesman,
				PrintPaymentDetail,
				StartDateOffset,
				EndDateOffset,
				PDisplayHeader,
				BGSessionId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
