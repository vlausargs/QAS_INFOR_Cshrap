//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceContractTBIReport.cs

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
	[IDOExtensionClass("SLServiceContractTBIReport")]
	public class SLServiceContractTBIReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_ContractTBISp([Optional] string ExOptBegCon_num,
		[Optional] string ExOptEndCon_num,
		[Optional] int? ExOptBegCon_line,
		[Optional] int? ExOptEndCon_line,
		[Optional] string ExOptBegcust_num,
		[Optional] string ExOptENDcust_num,
		[Optional] string ExOptBegserv_type,
		[Optional] string ExOptENDserv_type,
		[Optional] DateTime? ExOptRenew_date,
		[Optional] int? Renew_dateOffSET,
		[Optional, DefaultParameterValue(1)] int? ExOptConIntNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptConExtNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptCustIntNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptCustExtNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptCustPage,
		[Optional, DefaultParameterValue("ASQBMO")] string ExOptBillFreq,
		[Optional, DefaultParameterValue(1)] int? ExOptContLineIntNotes,
		[Optional, DefaultParameterValue(1)] int? ExOptContLineExtNotes,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_ContractTBIExt = new SSSFSRpt_ContractTBIFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_ContractTBIExt.SSSFSRpt_ContractTBISp(ExOptBegCon_num,
				ExOptEndCon_num,
				ExOptBegCon_line,
				ExOptEndCon_line,
				ExOptBegcust_num,
				ExOptENDcust_num,
				ExOptBegserv_type,
				ExOptENDserv_type,
				ExOptRenew_date,
				Renew_dateOffSET,
				ExOptConIntNotes,
				ExOptConExtNotes,
				ExOptCustIntNotes,
				ExOptCustExtNotes,
				ExOptCustPage,
				ExOptBillFreq,
				ExOptContLineIntNotes,
				ExOptContLineExtNotes,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
