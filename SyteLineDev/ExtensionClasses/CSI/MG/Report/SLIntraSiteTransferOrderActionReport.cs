//PROJECT NAME: ReportExt
//CLASS NAME: SLIntraSiteTransferOrderActionReport.cs

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
	[IDOExtensionClass("SLIntraSiteTransferOrderActionReport")]
	public class SLIntraSiteTransferOrderActionReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_IntraSiteTransferOrderActionSp([Optional] string PlannerCodeStarting,
		[Optional] string PlannerCodeEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string WhseStarting,
		[Optional] string WhseEnding,
		[Optional] DateTime? StartDateBeg,
		[Optional] DateTime? StartDateEnd,
		[Optional] int? StartDateBegOffset,
		[Optional] int? StartDateEndOffset,
		[Optional] string Source,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_IntraSiteTransferOrderActionExt = new Rpt_IntraSiteTransferOrderActionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_IntraSiteTransferOrderActionExt.Rpt_IntraSiteTransferOrderActionSp(PlannerCodeStarting,
				PlannerCodeEnding,
				ItemStarting,
				ItemEnding,
				WhseStarting,
				WhseEnding,
				StartDateBeg,
				StartDateEnd,
				StartDateBegOffset,
				StartDateEndOffset,
				Source,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
