//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceContractInvoicingReport.cs

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
	[IDOExtensionClass("SLServiceContractInvoicingReport")]
	public class SLServiceContractInvoicingReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_ContractInvoicingSp([Optional, DefaultParameterValue("PROCESS")] string Mode,
		[Optional] string StartInvNum,
		[Optional] string EndInvNum,
		[Optional] DateTime? StartInvDate,
		[Optional] DateTime? EndInvDate,
		[Optional] string StartCustNum,
		[Optional] string EndCustNum,
		[Optional, DefaultParameterValue("N")] string MooreForm,
		[Optional, DefaultParameterValue(0)] int? TransToDomCurr,
		[Optional, DefaultParameterValue(0)] int? PrintEuroTotal,
		[Optional, DefaultParameterValue(0)] int? PrintCustomerNotes,
		[Optional, DefaultParameterValue(0)] int? PrintContractNotes,
		[Optional, DefaultParameterValue(0)] int? PrintContLineNotes,
		[Optional, DefaultParameterValue(0)] int? PrintInternalNotes,
		[Optional, DefaultParameterValue(0)] int? PrintExternalNotes,
		[Optional, DefaultParameterValue(0)] int? PrintFixedContLines,
		[Optional, DefaultParameterValue(0)] int? Summarize,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_ContractInvoicingExt = new SSSFSRpt_ContractInvoicingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_ContractInvoicingExt.SSSFSRpt_ContractInvoicingSp(Mode,
				StartInvNum,
				EndInvNum,
				StartInvDate,
				EndInvDate,
				StartCustNum,
				EndCustNum,
				MooreForm,
				TransToDomCurr,
				PrintEuroTotal,
				PrintCustomerNotes,
				PrintContractNotes,
				PrintContLineNotes,
				PrintInternalNotes,
				PrintExternalNotes,
				PrintFixedContLines,
				Summarize,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
