//PROJECT NAME: CustomerExt
//CLASS NAME: SLTmpInvoiceBuilders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
	[IDOExtensionClass("SLTmpInvoiceBuilders")]
	public class SLTmpInvoiceBuilders : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvoiceBuilderProcessSp([Optional] Guid? PProcessID,
		                                   [Optional] string PCustNum,
		                                   [Optional, DefaultParameterValue("I")] string InvCred,
		[Optional] DateTime? PInvoiceDate,
		[Optional, DefaultParameterValue("R")] string InvType,
		[Optional, DefaultParameterValue("L")] string FormType,
		[Optional, DefaultParameterValue("CI")] string PrintItemCustomerItem,
		[Optional, DefaultParameterValue((byte)0)] byte? TransToDomCurr,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintSerialNumbers,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintPlanItemMaterial,
		[Optional, DefaultParameterValue("N")] string PrintConfigurationDetail,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintEuro,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintCustomerNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintOrderNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintOrderLineNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintOrderBlanketLineNotes,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintProgressiveBillingNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintInternalNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintExternalNotes,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintItemOverview,
		[Optional, DefaultParameterValue((byte)0)] byte? DisplayHeader,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintLineReleaseDescription,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintStandardOrderText,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintBillToNotes,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintDiscountAmt,
		[Optional] decimal? UserId,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintLotNumbers,
		[Optional] string CurrentCultureName,
		[Optional, DefaultParameterValue((byte)0)] byte? UseProfile,
		[Optional, DefaultParameterValue((byte)0)] byte? NonDraftCust,
		[Optional] string pSite,
		ref string PBuilderInvoiceNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInvoiceBuilderProcessExt = new InvoiceBuilderProcessFactory().Create(appDb);
				
				var result = iInvoiceBuilderProcessExt.InvoiceBuilderProcessSp(PProcessID,
				                                                               PCustNum,
				                                                               InvCred,
				                                                               PInvoiceDate,
				                                                               InvType,
				                                                               FormType,
				                                                               PrintItemCustomerItem,
				                                                               TransToDomCurr,
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
				                                                               PrintDiscountAmt,
				                                                               UserId,
				                                                               PrintLotNumbers,
				                                                               CurrentCultureName,
				                                                               UseProfile,
				                                                               NonDraftCust,
				                                                               pSite,
				                                                               PBuilderInvoiceNum,
				                                                               Infobar);
				
				int Severity = result.ReturnCode.Value;
				PBuilderInvoiceNum = result.PBuilderInvoiceNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvoiceBuilderReprintSp([Optional] string pSessionIDChar,
		                                   [Optional, DefaultParameterValue("")] string BGSessionID,
		[Optional, DefaultParameterValue("R")] string InvType,
		[Optional] string CustNum,
		[Optional] DateTime? InvoiceDate,
		[Optional] string ToSite,
		[Optional] string StartInvNum,
		[Optional] string EndInvNum,
		[Optional] DateTime? StartInvDate,
		[Optional] DateTime? EndInvDate,
		[Optional] string StartBuilderInvNum,
		[Optional] string EndBuilderInvNum,
		[Optional, DefaultParameterValue("N")] string PrintConfigurationDetail,
		[Optional, DefaultParameterValue("CI")] string PrintItemCustomerItem,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintOrderBlanketLineNotes,
		[Optional, DefaultParameterValue((byte)0)] byte? DisplayHeader,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintPlanItemMaterial,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintEuro,
		[Optional, DefaultParameterValue((byte)0)] byte? TransToDomCurr,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintLineReleaseDescription,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintDiscountAmt,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintSerialNumbers,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintLotNumbers,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintLineReleaseNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintStandardOrderText,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintOrderNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintCustomerNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintBillToNotes,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintProgressiveBillingNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintInternalNotes,
		[Optional, DefaultParameterValue((byte)1)] byte? PrintExternalNotes,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintItemOverview,
		[Optional, DefaultParameterValue("I")] string InvCred,
		[Optional, DefaultParameterValue("L")] string FormType,
		[Optional, DefaultParameterValue((byte)0)] byte? UseProfile,
		[Optional, DefaultParameterValue((byte)0)] byte? NonDraftCust,
		[Optional] string CurrentCultureName,
		[Optional] string pSite,
		[Optional] decimal? UserId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInvoiceBuilderReprintExt = new InvoiceBuilderReprintFactory().Create(appDb);
				
				var result = iInvoiceBuilderReprintExt.InvoiceBuilderReprintSp(pSessionIDChar,
				                                                               BGSessionID,
				                                                               InvType,
				                                                               CustNum,
				                                                               InvoiceDate,
				                                                               ToSite,
				                                                               StartInvNum,
				                                                               EndInvNum,
				                                                               StartInvDate,
				                                                               EndInvDate,
				                                                               StartBuilderInvNum,
				                                                               EndBuilderInvNum,
				                                                               PrintConfigurationDetail,
				                                                               PrintItemCustomerItem,
				                                                               PrintOrderBlanketLineNotes,
				                                                               DisplayHeader,
				                                                               PrintPlanItemMaterial,
				                                                               PrintEuro,
				                                                               TransToDomCurr,
				                                                               PrintLineReleaseDescription,
				                                                               PrintDiscountAmt,
				                                                               PrintSerialNumbers,
				                                                               PrintLotNumbers,
				                                                               PrintLineReleaseNotes,
				                                                               PrintStandardOrderText,
				                                                               PrintOrderNotes,
				                                                               PrintCustomerNotes,
				                                                               PrintBillToNotes,
				                                                               PrintProgressiveBillingNotes,
				                                                               PrintInternalNotes,
				                                                               PrintExternalNotes,
				                                                               PrintItemOverview,
				                                                               InvCred,
				                                                               FormType,
				                                                               UseProfile,
				                                                               NonDraftCust,
				                                                               CurrentCultureName,
				                                                               pSite,
				                                                               UserId,
				                                                               Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvoiceBuilderDeleteSp(Guid? PProcessID,
		[Optional] string PCustNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInvoiceBuilderDeleteExt = new InvoiceBuilderDeleteFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInvoiceBuilderDeleteExt.InvoiceBuilderDeleteSp(PProcessID,
				PCustNum);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InvoiceBuilderSaveDistSp(Guid? PRowPointer,
		[Optional] Guid? PProcessId,
		[Optional] int? PSelected,
		[Optional] string PCustNum,
		[Optional, DefaultParameterValue(0)] int? PClearSel)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInvoiceBuilderSaveDistExt = new InvoiceBuilderSaveDistFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInvoiceBuilderSaveDistExt.InvoiceBuilderSaveDistSp(PRowPointer,
				PProcessId,
				PSelected,
				PCustNum,
				PClearSel);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_CreatePendingInvoiceSp(Guid? PProcessID,
		[Optional] string PCustNum,
		string FormType,
		int? NonDraftCust,
		[Optional, DefaultParameterValue("I")] string PType,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_CreatePendingInvoiceExt = new CLM_CreatePendingInvoiceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_CreatePendingInvoiceExt.CLM_CreatePendingInvoiceSp(PProcessID,
				PCustNum,
				FormType,
				NonDraftCust,
				PType,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
