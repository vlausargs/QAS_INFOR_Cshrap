//PROJECT NAME: ReportExt
//CLASS NAME: SLOrderInvoicingCreditMemoReport.cs

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
	[IDOExtensionClass("SLOrderInvoicingCreditMemoReport")]
	public class SLOrderInvoicingCreditMemoReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_OrderInvoicingCreditMemoSp([Optional] string pSessionIDChar,
		[Optional, DefaultParameterValue("RBP")] string InvType,
		[Optional, DefaultParameterValue("REPRINT")] string Mode,
		[Optional] string StartInvNum,
		[Optional] string EndInvNum,
		[Optional] string StartOrderNum,
		[Optional] string EndOrderNum,
		[Optional] DateTime? StartInvDate,
		[Optional] DateTime? EndInvDate,
		[Optional] string StartCustNum,
		[Optional] string EndCustNum,
		[Optional, DefaultParameterValue("CI")] string PrintItemCustomerItem,
		[Optional, DefaultParameterValue(0)] int? TransToDomCurr,
		[Optional, DefaultParameterValue("I")] string InvCred,
		[Optional, DefaultParameterValue(1)] int? PrintSerialNumbers,
		[Optional, DefaultParameterValue(0)] int? PrintPlanItemMaterial,
		[Optional, DefaultParameterValue("N")] string PrintConfigurationDetail,
		[Optional, DefaultParameterValue(0)] int? PrintEuro,
		[Optional, DefaultParameterValue(1)] int? PrintCustomerNotes,
		[Optional, DefaultParameterValue(1)] int? PrintOrderNotes,
		[Optional, DefaultParameterValue(1)] int? PrintOrderLineNotes,
		[Optional, DefaultParameterValue(1)] int? PrintOrderBlanketLineNotes,
		[Optional, DefaultParameterValue(0)] int? PrintProgressiveBillingNotes,
		[Optional, DefaultParameterValue(1)] int? PrintInternalNotes,
		[Optional, DefaultParameterValue(1)] int? PrintExternalNotes,
		[Optional, DefaultParameterValue(0)] int? PrintItemOverview,
		[Optional, DefaultParameterValue(1)] int? DisplayHeader,
		[Optional, DefaultParameterValue(1)] int? PrintLineReleaseDescription,
		[Optional, DefaultParameterValue(1)] int? PrintStandardOrderText,
		[Optional, DefaultParameterValue(1)] int? PrintBillToNotes,
		[Optional] string LangCode,
		[Optional] string BGSessionId,
		[Optional, DefaultParameterValue(0)] int? PrintDiscountAmt,
		[Optional, DefaultParameterValue(1)] int? PrintLotNumbers,
		[Optional] string pSite,
		[Optional] string CalledFrom,
		[Optional] Guid? InvoicBuilderProcessID,
		[Optional] string StartBuilderInvNum,
		[Optional] string EndBuilderInvNum,
		[Optional, DefaultParameterValue(0)] int? pPrintDrawingNumber,
		[Optional, DefaultParameterValue(0)] int? pPrintDeliveryIncoTerms,
		[Optional, DefaultParameterValue(0)] int? pPrintTax,
		[Optional, DefaultParameterValue(0)] int? pPrintEUDetails,
		[Optional, DefaultParameterValue(0)] int? pPrintCurrCode,
		[Optional, DefaultParameterValue(0)] int? pPrintHeaderOnAllPages)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_OrderInvoicingCreditMemoExt = new Rpt_OrderInvoicingCreditMemoFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_OrderInvoicingCreditMemoExt.Rpt_OrderInvoicingCreditMemoSp(pSessionIDChar,
				InvType,
				Mode,
				StartInvNum,
				EndInvNum,
				StartOrderNum,
				EndOrderNum,
				StartInvDate,
				EndInvDate,
				StartCustNum,
				EndCustNum,
				PrintItemCustomerItem,
				TransToDomCurr,
				InvCred,
				PrintSerialNumbers,
				PrintPlanItemMaterial,
				PrintConfigurationDetail,
				PrintEuro,
				PrintCustomerNotes,
				PrintOrderNotes,
				PrintOrderLineNotes,
				PrintOrderBlanketLineNotes,
				PrintProgressiveBillingNotes,
				PrintInternalNotes,
				PrintExternalNotes,
				PrintItemOverview,
				DisplayHeader,
				PrintLineReleaseDescription,
				PrintStandardOrderText,
				PrintBillToNotes,
				LangCode,
				BGSessionId,
				PrintDiscountAmt,
				PrintLotNumbers,
				pSite,
				CalledFrom,
				InvoicBuilderProcessID,
				StartBuilderInvNum,
				EndBuilderInvNum,
				pPrintDrawingNumber,
				pPrintDeliveryIncoTerms,
				pPrintTax,
				pPrintEUDetails,
				pPrintCurrCode,
				pPrintHeaderOnAllPages);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
