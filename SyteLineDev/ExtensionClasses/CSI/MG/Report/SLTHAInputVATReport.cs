//PROJECT NAME: ReportExt
//CLASS NAME: SLTHAInputVATReport.cs

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
	[IDOExtensionClass("SLTHAInputVATReport")]
	public class SLTHAInputVATReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable THARpt_InputVATSp(string BegTaxCode,
		string EndTaxCode,
		DateTime? BegDistDate,
		DateTime? EndDistDate,
		DateTime? BegInvDate,
		DateTime? EndInvDate,
		string BegVendNum,
		string EndVendNum,
		string CompName,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string TaxID,
		[Optional] string Description,
		[Optional] int? DisplayHeader,
		[Optional] int? DisplaySummaryInvoice,
		string Infobar,
		[Optional] string pSite,
        [Optional] int? UnpostedVAT,
        [Optional] int? PostedVAT,
        [Optional] string BranchId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHARpt_InputVATExt = new THARpt_InputVATFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHARpt_InputVATExt.THARpt_InputVATSp(BegTaxCode,
				EndTaxCode,
				BegDistDate,
				EndDistDate,
				BegInvDate,
				EndInvDate,
				BegVendNum,
				EndVendNum,
				CompName,
				Addr1,
				Addr2,
				Addr3,
				Addr4,
				TaxID,
				Description,
				DisplayHeader,
				DisplaySummaryInvoice,
				Infobar,
				pSite,
                UnpostedVAT,
                PostedVAT,
                BranchId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
