//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderInvoicingReport.cs

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
	[IDOExtensionClass("SLServiceOrderInvoicingReport")]
	public class SLServiceOrderInvoicingReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROInvoicingSp([Optional, DefaultParameterValue("ToBeInvoiced")] string Mode,
		[Optional] string PBegSroNum,
		[Optional] string PEndSroNum,
		[Optional] int? PBegSroLine,
		[Optional] int? PEndSroLine,
		[Optional] int? PBegSroOper,
		[Optional] int? PEndSroOper,
		[Optional] string PBegBillMgr,
		[Optional] string PEndBillMgr,
		[Optional] string PBegCustNum,
		[Optional] string PEndCustNum,
		[Optional] string PBegRegion,
		[Optional] string PEndRegion,
		[Optional] DateTime? PBegTransDate,
		[Optional] DateTime? PEndTransDate,
		[Optional] DateTime? PBegCloseDate,
		[Optional] DateTime? PEndCloseDate,
		[Optional, DefaultParameterValue(1)] int? PInclCalculated,
		[Optional, DefaultParameterValue(1)] int? PInclProject,
		[Optional, DefaultParameterValue("I")] string PInvCred,
		[Optional] DateTime? PInvDate,
		[Optional, DefaultParameterValue(0)] int? PTransDom,
		[Optional, DefaultParameterValue("S")] string SortBy,
		[Optional] string StartInvNum,
		[Optional] string EndInvNum,
		[Optional] DateTime? StartInvDate,
		[Optional] DateTime? EndInvDate,
		[Optional, DefaultParameterValue("N")] string MooreForm,
		[Optional, DefaultParameterValue(0)] int? PrintCustomerNotes,
		[Optional, DefaultParameterValue(0)] int? PrintSRONotes,
		[Optional, DefaultParameterValue(0)] int? PrintSROLineNotes,
		[Optional, DefaultParameterValue(0)] int? PrintSROOperNotes,
		[Optional, DefaultParameterValue(0)] int? PrintTransNotes,
		[Optional, DefaultParameterValue(0)] int? PrintInternalNotes,
		[Optional, DefaultParameterValue(0)] int? PrintExternalNotes,
		[Optional, DefaultParameterValue(0)] int? PrintSerials,
		[Optional, DefaultParameterValue(0)] int? PrintMatl,
		[Optional, DefaultParameterValue(0)] int? PrintLabor,
		[Optional, DefaultParameterValue(0)] int? PrintMisc,
		[Optional, DefaultParameterValue(0)] int? SummarizeTrans,
		[Optional, DefaultParameterValue("U")] string BillCustCons,
		[Optional, DefaultParameterValue(0)] int? PrintEuroTotal,
		[Optional, DefaultParameterValue(1)] int? InclBillHold,
		[Optional, DefaultParameterValue("I")] string OperationStatus,
		[Optional] int? DisplayHeader,
		[Optional, DefaultParameterValue("N")] string OrderBy,
		[Optional] ref string Infobar,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROInvoicingExt = new SSSFSRpt_SROInvoicingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROInvoicingExt.SSSFSRpt_SROInvoicingSp(Mode,
				PBegSroNum,
				PEndSroNum,
				PBegSroLine,
				PEndSroLine,
				PBegSroOper,
				PEndSroOper,
				PBegBillMgr,
				PEndBillMgr,
				PBegCustNum,
				PEndCustNum,
				PBegRegion,
				PEndRegion,
				PBegTransDate,
				PEndTransDate,
				PBegCloseDate,
				PEndCloseDate,
				PInclCalculated,
				PInclProject,
				PInvCred,
				PInvDate,
				PTransDom,
				SortBy,
				StartInvNum,
				EndInvNum,
				StartInvDate,
				EndInvDate,
				MooreForm,
				PrintCustomerNotes,
				PrintSRONotes,
				PrintSROLineNotes,
				PrintSROOperNotes,
				PrintTransNotes,
				PrintInternalNotes,
				PrintExternalNotes,
				PrintSerials,
				PrintMatl,
				PrintLabor,
				PrintMisc,
				SummarizeTrans,
				BillCustCons,
				PrintEuroTotal,
				InclBillHold,
				OperationStatus,
				DisplayHeader,
				OrderBy,
				Infobar,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}
	}
}
