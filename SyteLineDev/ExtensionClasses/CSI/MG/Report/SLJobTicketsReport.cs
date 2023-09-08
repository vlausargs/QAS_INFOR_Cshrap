//PROJECT NAME: ReportExt
//CLASS NAME: SLJobTicketsReport.cs

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
    [IDOExtensionClass("SLJobTicketsReport")]
    public class SLJobTicketsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobTicketsSp([Optional] string StartJob,
		[Optional] string EndJob,
		[Optional] int? StartSuffix,
		[Optional] int? EndSuffix,
		[Optional] string JobStat,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] string StartProdMix,
		[Optional] string EndProdMix,
		[Optional] DateTime? StartJobDate,
		[Optional] DateTime? EndJobDate,
		[Optional] int? JobTickets132,
		[Optional] int? NumTickets,
		[Optional] int? StartJobDateOffset,
		[Optional] int? EndJobDateOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobTicketsExt = new Rpt_JobTicketsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobTicketsExt.Rpt_JobTicketsSp(StartJob,
				EndJob,
				StartSuffix,
				EndSuffix,
				JobStat,
				StartItem,
				EndItem,
				StartProdMix,
				EndProdMix,
				StartJobDate,
				EndJobDate,
				JobTickets132,
				NumTickets,
				StartJobDateOffset,
				EndJobDateOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
