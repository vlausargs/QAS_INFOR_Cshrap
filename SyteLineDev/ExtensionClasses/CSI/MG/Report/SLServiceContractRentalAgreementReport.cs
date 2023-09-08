//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceContractRentalAgreementReport.cs

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
	[IDOExtensionClass("SLServiceContractRentalAgreementReport")]
	public class SLServiceContractRentalAgreementReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_RentalContractAgreementSp([Optional] string ContractStarting,
		[Optional] string ContractEnding,
		[Optional] string CustNumStarting,
		[Optional] string CustNumEnding,
		[Optional, DefaultParameterValue(1)] int? DispContractNotes,
		[Optional, DefaultParameterValue(1)] int? DispLineNotes,
		[Optional, DefaultParameterValue(0)] int? ShowInternal,
		[Optional, DefaultParameterValue(1)] int? ShowExternal,
		[Optional, DefaultParameterValue(1)] int? DispLineDetail,
		[Optional, DefaultParameterValue(1)] int? DispLineSurcharge,
		[Optional, DefaultParameterValue(1)] int? DispContractWaiver,
		[Optional, DefaultParameterValue(0)] int? DispContractPricing,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_RentalContractAgreementExt = new SSSFSRpt_RentalContractAgreementFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_RentalContractAgreementExt.SSSFSRpt_RentalContractAgreementSp(ContractStarting,
				ContractEnding,
				CustNumStarting,
				CustNumEnding,
				DispContractNotes,
				DispLineNotes,
				ShowInternal,
				ShowExternal,
				DispLineDetail,
				DispLineSurcharge,
				DispContractWaiver,
				DispContractPricing,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
