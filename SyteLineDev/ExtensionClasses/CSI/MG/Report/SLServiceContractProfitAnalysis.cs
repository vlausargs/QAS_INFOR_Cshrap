//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceContractProfitAnalysis.cs

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
	[IDOExtensionClass("SLServiceContractProfitAnalysis")]
	public class SLServiceContractProfitAnalysis : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_ContractProfitAnalysisSp([Optional] string BegContract,
		[Optional] string EndContract,
		[Optional] string BegCustNum,
		[Optional] string EndCustNum,
		[Optional] DateTime? BegInvoiceDate,
		[Optional] DateTime? EndInvoiceDate,
		[Optional, DefaultParameterValue(1)] int? ShowSro,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_ContractProfitAnalysisExt = new SSSFSRpt_ContractProfitAnalysisFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_ContractProfitAnalysisExt.SSSFSRpt_ContractProfitAnalysisSp(BegContract,
				EndContract,
				BegCustNum,
				EndCustNum,
				BegInvoiceDate,
				EndInvoiceDate,
				ShowSro,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
