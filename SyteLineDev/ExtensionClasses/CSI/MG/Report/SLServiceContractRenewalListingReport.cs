//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceContractRenewalListingReport.cs

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
	[IDOExtensionClass("SLServiceContractRenewalListingReport")]
	public class SLServiceContractRenewalListingReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRPT_ContractRenewalListingSp(string StartingContract,
		string EndingContract,
		string StartingCustomer,
		string EndingCustomer,
		string StartingItem,
		string EndingItem,
		int? t_Period,
		int? t_Year,
		[Optional] string pSite,
		[Optional] string BillingFrequencies,
		[Optional, DefaultParameterValue(0)] int? DaysLookAhead)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRPT_ContractRenewalListingExt = new SSSFSRPT_ContractRenewalListingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRPT_ContractRenewalListingExt.SSSFSRPT_ContractRenewalListingSp(StartingContract,
				EndingContract,
				StartingCustomer,
				EndingCustomer,
				StartingItem,
				EndingItem,
				t_Period,
				t_Year,
				pSite,
				BillingFrequencies,
				DaysLookAhead);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
