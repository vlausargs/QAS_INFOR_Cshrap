//PROJECT NAME: ReportExt
//CLASS NAME: SLInvoiceMilestoneProgressReport.cs

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
    [IDOExtensionClass("SLInvoiceMilestoneProgressReport")]
    public class SLInvoiceMilestoneProgressReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InvoiceMilestoneProgressSp([Optional] string BegProjNum,
		                                                [Optional] string EndProjNum,
		                                                [Optional] string BegInvMsNum,
		                                                [Optional] string EndInvMsNum,
		                                                [Optional, DefaultParameterValue((byte)1)] byte? PDisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InvoiceMilestoneProgressExt = new Rpt_InvoiceMilestoneProgressFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InvoiceMilestoneProgressExt.Rpt_InvoiceMilestoneProgressSp(BegProjNum,
				                                                                             EndProjNum,
				                                                                             BegInvMsNum,
				                                                                             EndInvMsNum,
				                                                                             PDisplayHeader,
				                                                                             TaskId,
				                                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
