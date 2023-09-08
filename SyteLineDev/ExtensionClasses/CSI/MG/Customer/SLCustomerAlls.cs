//PROJECT NAME: CustomerExt
//CLASS NAME: SLCustomerAlls.cs

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
	[IDOExtensionClass("SLCustomerAlls")]
	public class SLCustomerAlls : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IsCustomerActiveAllSp(string CustNum,
		                                 string SiteRef,
		                                 ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iIsCustomerActiveAllExt = new IsCustomerActiveAllFactory().Create(appDb);
				
				int Severity = iIsCustomerActiveAllExt.IsCustomerActiveAllSp(CustNum,
				                                                             SiteRef,
				                                                             ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckCorpCustSp(string CorpCust,
		                           string CustNum,
		                           string NewCurrCode,
		                           ref string CorpCustName,
		                           ref string Address,
		                           ref string Infobar,
		                           [Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCheckCorpCustExt = new CheckCorpCustFactory().Create(appDb);
				
				var result = iCheckCorpCustExt.CheckCorpCustSp(CorpCust,
				                                               CustNum,
				                                               NewCurrCode,
				                                               CorpCustName,
				                                               Address,
				                                               Infobar,
				                                               PSite);
				
				int Severity = result.ReturnCode.Value;
				CorpCustName = result.CorpCustName;
				Address = result.Address;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetExportTypeSp(string CustNum,
		                           ref string ExportType,
		                           ref string LangCode,
		                           ref string Slsman,
		                           [Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetExportTypeExt = new GetExportTypeFactory().Create(appDb);
				
				var result = iGetExportTypeExt.GetExportTypeSp(CustNum,
				                                               ExportType,
				                                               LangCode,
				                                               Slsman,
				                                               PSite);
				
				int Severity = result.ReturnCode.Value;
				ExportType = result.ExportType;
				LangCode = result.LangCode;
				Slsman = result.Slsman;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSiteParmsForCustomerAllsSP(string Site,
		                                         ref string CurrCode,
		                                         ref byte? EcReporting,
		                                         ref string Country)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetSiteParmsForCustomerAllsExt = new GetSiteParmsForCustomerAllsFactory().Create(appDb);
				
				var result = iGetSiteParmsForCustomerAllsExt.GetSiteParmsForCustomerAllsSP(Site,
				                                                                           CurrCode,
				                                                                           EcReporting,
				                                                                           Country);
				
				int Severity = result.ReturnCode.Value;
				CurrCode = result.CurrCode;
				EcReporting = result.EcReporting;
				Country = result.Country;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CustShipToInsUpdRemCallSP(string Site,
		                                     ref string CustNum,
		                                     ref int? CustSeq,
		                                     [Optional] string Addr_1,
		                                     [Optional] string Addr_2,
		                                     [Optional] string Addr_3,
		                                     [Optional] string Addr_4,
		                                     [Optional] string BillToEmail,
		                                     [Optional] string Charfld1,
		                                     [Optional] string Charfld2,
		                                     [Optional] string Charfld3,
		                                     [Optional] string City,
		                                     [Optional] string Contact_2,
		                                     [Optional] string Country,
		                                     [Optional] string County,
		                                     [Optional] string CurrCode,
		                                     [Optional] DateTime? Datefld,
		                                     [Optional] decimal? Decifld1,
		                                     [Optional] decimal? Decifld2,
		                                     [Optional] decimal? Decifld3,
		                                     [Optional] string ExportType,
		                                     [Optional] string FaxNum,
		                                     [Optional] string LangCode,
		                                     [Optional] byte? Logifld,
		                                     [Optional] string Name,
		                                     [Optional] string Phone_2,
		                                     [Optional] string ShipCode,
		                                     [Optional, DefaultParameterValue((byte)0)] byte? ShipEarly,
		[Optional, DefaultParameterValue((byte)0)] byte? ShipPartial,
		[Optional] string ShipSite,
		[Optional] string ShipToEmail,
		[Optional, DefaultParameterValue((byte)0)] byte? ShowInShipToDropDownList,
		[Optional] string Slsman,
		[Optional] string State,
		[Optional] string TelexNum,
		[Optional] string Whse,
		[Optional] string Zip,
		[Optional] decimal? ShippedOverOrderedQtyTolerance,
		[Optional] decimal? ShippedUnderOrderedQtyTolerance,
		[Optional] short? DaysShippedAfterDueDateTolerance,
		[Optional] short? DaysShippedBeforeDueDateTolerance,
		[Optional, DefaultParameterValue((byte)0)] byte? IncludeOrdersInTaxRpt,
		[Optional, DefaultParameterValue("I")] string FlagInsertUpdate,
		[Optional] Guid? CustaddrRowPointer,
		[Optional] string Stat)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCustShipToInsUpdRemCallExt = new CustShipToInsUpdRemCallFactory().Create(appDb);
				
				var result = iCustShipToInsUpdRemCallExt.CustShipToInsUpdRemCallSp(Site,
				                                                                   CustNum,
				                                                                   CustSeq,
				                                                                   Addr_1,
				                                                                   Addr_2,
				                                                                   Addr_3,
				                                                                   Addr_4,
				                                                                   BillToEmail,
				                                                                   Charfld1,
				                                                                   Charfld2,
				                                                                   Charfld3,
				                                                                   City,
				                                                                   Contact_2,
				                                                                   Country,
				                                                                   County,
				                                                                   CurrCode,
				                                                                   Datefld,
				                                                                   Decifld1,
				                                                                   Decifld2,
				                                                                   Decifld3,
				                                                                   ExportType,
				                                                                   FaxNum,
				                                                                   LangCode,
				                                                                   Logifld,
				                                                                   Name,
				                                                                   Phone_2,
				                                                                   ShipCode,
				                                                                   ShipEarly,
				                                                                   ShipPartial,
				                                                                   ShipSite,
				                                                                   ShipToEmail,
				                                                                   ShowInShipToDropDownList,
				                                                                   Slsman,
				                                                                   State,
				                                                                   TelexNum,
				                                                                   Whse,
				                                                                   Zip,
				                                                                   ShippedOverOrderedQtyTolerance,
				                                                                   ShippedUnderOrderedQtyTolerance,
				                                                                   DaysShippedAfterDueDateTolerance,
				                                                                   DaysShippedBeforeDueDateTolerance,
				                                                                   IncludeOrdersInTaxRpt,
				                                                                   FlagInsertUpdate,
				                                                                   CustaddrRowPointer,
				                                                                   Stat);
				
				int Severity = result.ReturnCode.Value;
				CustNum = result.CustNum;
				CustSeq = result.CustSeq;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CustomerInsUpdRemCallSP(string Site,
		ref string CustNum,
		[Optional, DefaultParameterValue((byte)0)] byte? ApsPullUp,
		[Optional] decimal? AvgBalOs,
		[Optional] short? AvgDaysOs,
		[Optional] string BankCode,
		[Optional] string BranchId,
		[Optional] DateTime? CalcDate,
		[Optional] string Charfld1,
		[Optional] string Charfld2,
		[Optional] string Charfld3,
		[Optional] decimal? CompanyRevenue,
		[Optional, DefaultParameterValue((byte)0)] byte? Consolidate,
		[Optional] string Contact_1,
		[Optional] string Contact_3,
		[Optional] string CustBank,
		ref int? CustSeq,
		[Optional] string CustType,
		[Optional] DateTime? Datefld,
		[Optional] string Delterm,
		[Optional] decimal? DiscLstYr,
		[Optional] decimal? DiscYtd,
		[Optional] string DoInvoice,
		[Optional] byte? DraftPrintFlag,
		[Optional, DefaultParameterValue((byte)0)] byte? Einvoice,
		[Optional] string EndUserType,
		[Optional, DefaultParameterValue((byte)0)] byte? FinChg,
		[Optional] byte? IncludeTaxInPrice,
		[Optional] string InvCategory,
		[Optional] string InvFreq,
		[Optional] string LangCode,
		[Optional] int? LargDaysOs,
		[Optional] decimal? LargeBalOs,
		[Optional] decimal? LastBalOs,
		[Optional] short? LastDaysOs,
		[Optional] DateTime? LastFinChg,
		[Optional] DateTime? LastInv,
		[Optional] DateTime? LastPaid,
		[Optional, DefaultParameterValue((byte)0)] byte? LcrReqd,
		[Optional] byte? Logifld,
		[Optional] int? NumberOfEmployees,
		[Optional] short? NumPeriods,
		[Optional, DefaultParameterValue((byte)0)] byte? OnePackInv,
		[Optional] byte? PayDay,
		[Optional] DateTime? PayDayEndTime_1,
		[Optional] DateTime? PayDayEndTime_2,
		[Optional] DateTime? PayDayStartTime_1,
		[Optional] DateTime? PayDayStartTime_2,
		[Optional] string PayType,
		[Optional] string Phone_1,
		[Optional] string Phone_3,
		[Optional, DefaultParameterValue((byte)0)] byte? PrintPackInv,
		[Optional] string ProcessInd,
		[Optional] byte? RevisionDay,
		[Optional] DateTime? RevisionDayEndTime_1,
		[Optional] DateTime? RevisionDayEndTime_2,
		[Optional] DateTime? RevisionDayStartTime_1,
		[Optional] DateTime? RevisionDayStartTime_2,
		[Optional] decimal? SalesLstYr,
		[Optional] decimal? SalesPtd,
		[Optional] decimal? SalesYtd,
		[Optional] string ShipSite,
		[Optional, DefaultParameterValue((byte)0)] byte? ShowInDropDownList,
		[Optional] string SICCode,
		[Optional] string StateCycle,
		[Optional, DefaultParameterValue((byte)0)] byte? Summarize,
		[Optional] string TermsCode,
		[Optional] string TerritoryCode,
		[Optional] string TransNat,
		[Optional] string TransNat2,
		[Optional] byte? UseExchRate,
		[Optional, DefaultParameterValue((byte)0)] byte? UseRevisionPayDays,
		[Optional, DefaultParameterValue("N")] string ExportType,
		[Optional] decimal? Decifld1,
		[Optional] decimal? Decifld2,
		[Optional] decimal? Decifld3,
		[Optional] string Pricecode,
		[Optional, DefaultParameterValue((byte)0)] byte? ActiveForDataIntegration,
		[Optional] string SalesTeamID,
		[Optional] decimal? AmtOverInvAmt,
		[Optional] string BalMethod,
		[Optional, DefaultParameterValue((byte)0)] byte? CorpAddress,
		[Optional, DefaultParameterValue((byte)0)] byte? CorpCred,
		[Optional] string CorpCust,
		[Optional, DefaultParameterValue((byte)0)] byte? CreditHold,
		[Optional] DateTime? CreditHoldDate,
		[Optional] string CreditHoldReason,
		[Optional] string CreditHoldUser,
		[Optional] decimal? CreditLimit,
		[Optional] decimal? OrderCreditLimit,
		[Optional] string CurrCode,
		[Optional] short? DaysOverInvDueDate,
		[Optional] string ExternalEmailAddr,
		[Optional] string FaxNum,
		[Optional] string InternalEmailAddr,
		[Optional] string InternetUrl,
		[Optional] string TelexNum,
		[Optional] string Addr_1,
		[Optional] string Addr_2,
		[Optional] string Addr_3,
		[Optional] string Addr_4,
		[Optional] string City,
		[Optional] string Country,
		[Optional] string County,
		[Optional] string Name,
		[Optional] string State,
		[Optional] string Zip,
		[Optional] int? DefaultShipTo,
		[Optional] short? DaysShippedBeforeDueDate,
		[Optional] short? DaysShippedAfterDueDate,
		[Optional] decimal? ShippedOverOrderedQty,
		[Optional] decimal? ShippedUnderOrderedQty,
		[Optional, DefaultParameterValue("I")] string FlagInsertUpdate,
		string ResellerSlsman,
		[Optional, DefaultParameterValue((byte)0)] byte? ShipmentApprovalRequired,
		[Optional] decimal? ConstructiveSalePricePct,
		[Optional] string SepaMandateRef,
		[Optional] DateTime? SepaMandateCreationDate,
		[Optional] DateTime? SepaMandateExpirationDate,
		[Optional] DateTime? SepaMndateLastUsedDate,
		[Optional] byte? SepaCoreDirectDebit,
		[Optional] byte? SepaOneOffMandate,
		[Optional] string BankAcctNo,
		[Optional] string AccountName,
		[Optional] string InternationalBankAccount,
		[Optional] string BankAuthorityPartyId,
		[Optional] string DunningGroup,
		[Optional] int? DunningStageId,
		[Optional] DateTime? LastDunningDate,
		[Optional] ref string Infobar,
		[Optional, DefaultParameterValue((byte)0)] byte? OneShipmentInv,
		[Optional] string ShipMethodGroup,
		[Optional] string Stat,
        [Optional, DefaultParameterValue((byte)0)] byte? UseLongName,
        [Optional] string LongName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCustomerInsUpdRemCallExt = new CustomerInsUpdRemCallFactory().Create(appDb);
				
				var result = iCustomerInsUpdRemCallExt.CustomerInsUpdRemCallSp(Site,
				CustNum,
				ApsPullUp,
				AvgBalOs,
				AvgDaysOs,
				BankCode,
				BranchId,
				CalcDate,
				Charfld1,
				Charfld2,
				Charfld3,
				CompanyRevenue,
				Consolidate,
				Contact_1,
				Contact_3,
				CustBank,
				CustSeq,
				CustType,
				Datefld,
				Delterm,
				DiscLstYr,
				DiscYtd,
				DoInvoice,
				DraftPrintFlag,
				Einvoice,
				EndUserType,
				FinChg,
				IncludeTaxInPrice,
				InvCategory,
				InvFreq,
				LangCode,
				LargDaysOs,
				LargeBalOs,
				LastBalOs,
				LastDaysOs,
				LastFinChg,
				LastInv,
				LastPaid,
				LcrReqd,
				Logifld,
				NumberOfEmployees,
				NumPeriods,
				OnePackInv,
				PayDay,
				PayDayEndTime_1,
				PayDayEndTime_2,
				PayDayStartTime_1,
				PayDayStartTime_2,
				PayType,
				Phone_1,
				Phone_3,
				PrintPackInv,
				ProcessInd,
				RevisionDay,
				RevisionDayEndTime_1,
				RevisionDayEndTime_2,
				RevisionDayStartTime_1,
				RevisionDayStartTime_2,
				SalesLstYr,
				SalesPtd,
				SalesYtd,
				ShipSite,
				ShowInDropDownList,
				SICCode,
				StateCycle,
				Summarize,
				TermsCode,
				TerritoryCode,
				TransNat,
				TransNat2,
				UseExchRate,
				UseRevisionPayDays,
				ExportType,
				Decifld1,
				Decifld2,
				Decifld3,
				Pricecode,
				ActiveForDataIntegration,
				SalesTeamID,
				AmtOverInvAmt,
				BalMethod,
				CorpAddress,
				CorpCred,
				CorpCust,
				CreditHold,
				CreditHoldDate,
				CreditHoldReason,
				CreditHoldUser,
				CreditLimit,
				OrderCreditLimit,
				CurrCode,
				DaysOverInvDueDate,
				ExternalEmailAddr,
				FaxNum,
				InternalEmailAddr,
				InternetUrl,
				TelexNum,
				Addr_1,
				Addr_2,
				Addr_3,
				Addr_4,
				City,
				Country,
				County,
				Name,
				State,
				Zip,
				DefaultShipTo,
				DaysShippedBeforeDueDate,
				DaysShippedAfterDueDate,
				ShippedOverOrderedQty,
				ShippedUnderOrderedQty,
				FlagInsertUpdate,
				ResellerSlsman,
				ShipmentApprovalRequired,
				ConstructiveSalePricePct,
				SepaMandateRef,
				SepaMandateCreationDate,
				SepaMandateExpirationDate,
				SepaMndateLastUsedDate,
				SepaCoreDirectDebit,
				SepaOneOffMandate,
				BankAcctNo,
				AccountName,
				InternationalBankAccount,
				BankAuthorityPartyId,
				DunningGroup,
				DunningStageId,
				LastDunningDate,
				Infobar,
				OneShipmentInv,
				ShipMethodGroup,
				Stat,
                UseLongName,
                LongName);
				
				int Severity = result.ReturnCode.Value;
				CustNum = result.CustNum;
				CustSeq = result.CustSeq;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IsCustomerDeactivationValidAllSp(string CustNum,
		[Optional, DefaultParameterValue(1)] int? Active,
		string SiteRef,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iIsCustomerDeactivationValidAllExt = new IsCustomerDeactivationValidAllFactory().Create(appDb);
				
				var result = iIsCustomerDeactivationValidAllExt.IsCustomerDeactivationValidAllSp(CustNum,
				Active,
				SiteRef,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckBankAddrSp([Optional] string bankcode,
		[Optional] string PayType,
		[Optional] string CustBank,
		int? PrintDraft,
		[Optional] ref string Infobar,
		[Optional] string PSite)
		{
			var iCheckBankAddrExt = new CheckBankAddrFactory().Create(this, true);
			
			var result = iCheckBankAddrExt.CheckBankAddrSp(bankcode,
			PayType,
			CustBank,
			PrintDraft,
			Infobar,
			PSite);
			
			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DunningCustAgingBasisSp([Optional] string CustNum,
		[Optional] string SiteRef)
		{
			var iCLM_DunningCustAgingBasisExt = new CLM_DunningCustAgingBasisFactory().Create(this, true);
			
			var result = iCLM_DunningCustAgingBasisExt.CLM_DunningCustAgingBasisSp(CustNum,
			SiteRef);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePackSliponInvoiceSp(string CustNum,
		int? PrintPackInv,
		ref string Infobar,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidatePackSliponInvoiceExt = new ValidatePackSliponInvoiceFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iValidatePackSliponInvoiceExt.ValidatePackSliponInvoiceSp(CustNum,
				PrintPackInv,
				Infobar,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
