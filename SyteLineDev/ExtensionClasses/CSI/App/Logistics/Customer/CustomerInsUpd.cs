//PROJECT NAME: Data
//CLASS NAME: CustomerInsUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustomerInsUpd : ICustomerInsUpd
	{
		readonly IApplicationDB appDB;
		
		public CustomerInsUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CustomerInsUpdSp(
			string CustNum,
			int? ApsPullUp = 0,
			decimal? AvgBalOs = null,
			int? AvgDaysOs = null,
			string BankCode = null,
			string BranchId = null,
			DateTime? CalcDate = null,
			string Charfld1 = null,
			string Charfld2 = null,
			string Charfld3 = null,
			decimal? CompanyRevenue = null,
			int? Consolidate = 0,
			string Contact_1 = null,
			string Contact_3 = null,
			string CustBank = null,
			int? CustSeq = null,
			string CustType = null,
			DateTime? Datefld = null,
			string Delterm = null,
			decimal? DiscLstYr = null,
			decimal? DiscYtd = null,
			string DoInvoice = null,
			int? DraftPrintFlag = null,
			int? Einvoice = 0,
			string EndUserType = null,
			int? FinChg = 0,
			int? IncludeTaxInPrice = null,
			string InvCategory = null,
			string InvFreq = null,
			string LangCode = null,
			int? LargDaysOs = null,
			decimal? LargeBalOs = null,
			decimal? LastBalOs = null,
			int? LastDaysOs = null,
			DateTime? LastFinChg = null,
			DateTime? LastInv = null,
			DateTime? LastPaid = null,
			int? LcrReqd = 0,
			int? Logifld = null,
			int? NumberOfEmployees = null,
			int? NumPeriods = null,
			int? OnePackInv = 0,
			int? PayDay = null,
			DateTime? PayDayEndTime_1 = null,
			DateTime? PayDayEndTime_2 = null,
			DateTime? PayDayStartTime_1 = null,
			DateTime? PayDayStartTime_2 = null,
			string PayType = null,
			string Phone_1 = null,
			string Phone_3 = null,
			int? PrintPackInv = 0,
			string ProcessInd = null,
			int? RevisionDay = null,
			DateTime? RevisionDayEndTime_1 = null,
			DateTime? RevisionDayEndTime_2 = null,
			DateTime? RevisionDayStartTime_1 = null,
			DateTime? RevisionDayStartTime_2 = null,
			decimal? SalesLstYr = null,
			decimal? SalesPtd = null,
			decimal? SalesYtd = null,
			string ShipSite = null,
			int? ShowInDropDownList = 0,
			string SICCode = null,
			string StateCycle = null,
			int? Summarize = 0,
			string TermsCode = null,
			string TerritoryCode = null,
			string TransNat = null,
			string TransNat2 = null,
			int? UseExchRate = null,
			int? UseRevisionPayDays = 0,
			string ExportType = null,
			decimal? Decifld1 = null,
			decimal? Decifld2 = null,
			decimal? Decifld3 = null,
			string Pricecode = null,
			int? ActiveForDataIntegration = null,
			string SalesTeamID = null,
			decimal? AmtOverInvAmt = null,
			string BalMethod = null,
			int? CorpAddress = 0,
			int? CorpCred = 0,
			string CorpCust = null,
			int? CreditHold = 0,
			DateTime? CreditHoldDate = null,
			string CreditHoldReason = null,
			string CreditHoldUser = null,
			decimal? CreditLimit = null,
			decimal? OrderCreditLimit = null,
			string CurrCode = null,
			int? DaysOverInvDueDate = null,
			string ExternalEmailAddr = null,
			string FaxNum = null,
			string InternalEmailAddr = null,
			string InternetUrl = null,
			string TelexNum = null,
			string Addr_1 = null,
			string Addr_2 = null,
			string Addr_3 = null,
			string Addr_4 = null,
			string City = null,
			string Country = null,
			string County = null,
			string Name = null,
			string State = null,
			string Zip = null,
			int? DefaultShipTo = null,
			int? DaysShippedBeforeDueDate = null,
			int? DaysShippedAfterDueDate = null,
			decimal? ShippedOverOrderedQty = null,
			decimal? ShippedUnderOrderedQty = null,
			string FlagInsertUpdate = "I",
			string ResellerSlsman = null,
			int? ShipmentApprovalRequired = null,
			decimal? ConstructiveSalePricePct = null,
			string SepaMandateRef = null,
			DateTime? SepaMandateCreationDate = null,
			DateTime? SepaMandateExpirationDate = null,
			DateTime? SepaMndateLastUsedDate = null,
			int? SepaCoreDirectDebit = null,
			int? SepaOneOffMandate = null,
			string BankAcctNo = null,
			string AccountName = null,
			string InternationalBankAccount = null,
			string BankAuthorityPartyId = null,
			string DunningGroup = null,
			int? DunningStageId = null,
			DateTime? LastDunningDate = null,
			Guid? RowPointer = null,
			int? OneShipmentInv = 0,
			string ShipMethodGroup = null,
			string Stat = null,
			int? UseLongName = 0,
			string LongName = null)
		{
			CustNumType _CustNum = CustNum;
			ListYesNoType _ApsPullUp = ApsPullUp;
			AmountType _AvgBalOs = AvgBalOs;
			DaysOSType _AvgDaysOs = AvgDaysOs;
			BankCodeType _BankCode = BankCode;
			BranchIdType _BranchId = BranchId;
			DateType _CalcDate = CalcDate;
			UserCharFldType _Charfld1 = Charfld1;
			UserCharFldType _Charfld2 = Charfld2;
			UserCharFldType _Charfld3 = Charfld3;
			AmountType _CompanyRevenue = CompanyRevenue;
			ListYesNoType _Consolidate = Consolidate;
			ContactType _Contact_1 = Contact_1;
			ContactType _Contact_3 = Contact_3;
			BankCodeType _CustBank = CustBank;
			CustSeqType _CustSeq = CustSeq;
			CustTypeType _CustType = CustType;
			UserDateFldType _Datefld = Datefld;
			DeltermType _Delterm = Delterm;
			AmountType _DiscLstYr = DiscLstYr;
			AmountType _DiscYtd = DiscYtd;
			DoInvoiceType _DoInvoice = DoInvoice;
			ListYesNoType _DraftPrintFlag = DraftPrintFlag;
			ListYesNoType _Einvoice = Einvoice;
			EndUserTypeType _EndUserType = EndUserType;
			ListYesNoType _FinChg = FinChg;
			ListYesNoType _IncludeTaxInPrice = IncludeTaxInPrice;
			InvCategoryType _InvCategory = InvCategory;
			InvFreqType _InvFreq = InvFreq;
			LangCodeType _LangCode = LangCode;
			TotalDaysOSType _LargDaysOs = LargDaysOs;
			AmountType _LargeBalOs = LargeBalOs;
			AmountType _LastBalOs = LastBalOs;
			DaysOSType _LastDaysOs = LastDaysOs;
			DateType _LastFinChg = LastFinChg;
			DateType _LastInv = LastInv;
			DateType _LastPaid = LastPaid;
			ListYesNoType _LcrReqd = LcrReqd;
			UserLogiFldType _Logifld = Logifld;
			NumberOfEmployeesType _NumberOfEmployees = NumberOfEmployees;
			PeriodsAveragedType _NumPeriods = NumPeriods;
			ListYesNoType _OnePackInv = OnePackInv;
			WeekDayType _PayDay = PayDay;
			TimeType _PayDayEndTime_1 = PayDayEndTime_1;
			TimeType _PayDayEndTime_2 = PayDayEndTime_2;
			TimeType _PayDayStartTime_1 = PayDayStartTime_1;
			TimeType _PayDayStartTime_2 = PayDayStartTime_2;
			CustPayTypeType _PayType = PayType;
			PhoneType _Phone_1 = Phone_1;
			PhoneType _Phone_3 = Phone_3;
			ListYesNoType _PrintPackInv = PrintPackInv;
			ProcessIndType _ProcessInd = ProcessInd;
			WeekDayType _RevisionDay = RevisionDay;
			TimeType _RevisionDayEndTime_1 = RevisionDayEndTime_1;
			TimeType _RevisionDayEndTime_2 = RevisionDayEndTime_2;
			TimeType _RevisionDayStartTime_1 = RevisionDayStartTime_1;
			TimeType _RevisionDayStartTime_2 = RevisionDayStartTime_2;
			AmountType _SalesLstYr = SalesLstYr;
			AmountType _SalesPtd = SalesPtd;
			AmountType _SalesYtd = SalesYtd;
			SiteType _ShipSite = ShipSite;
			ListYesNoType _ShowInDropDownList = ShowInDropDownList;
			SICCodeType _SICCode = SICCode;
			StatementCycleType _StateCycle = StateCycle;
			ListYesNoType _Summarize = Summarize;
			TermsCodeType _TermsCode = TermsCode;
			TerritoryCodeType _TerritoryCode = TerritoryCode;
			TransNatType _TransNat = TransNat;
			TransNat2Type _TransNat2 = TransNat2;
			ListYesNoType _UseExchRate = UseExchRate;
			ListYesNoType _UseRevisionPayDays = UseRevisionPayDays;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			UserDeciFldType _Decifld1 = Decifld1;
			UserDeciFldType _Decifld2 = Decifld2;
			UserDeciFldType _Decifld3 = Decifld3;
			PriceCodeType _Pricecode = Pricecode;
			ListYesNoType _ActiveForDataIntegration = ActiveForDataIntegration;
			SalesTeamIDType _SalesTeamID = SalesTeamID;
			AmountType _AmtOverInvAmt = AmtOverInvAmt;
			BalMethodType _BalMethod = BalMethod;
			ListYesNoType _CorpAddress = CorpAddress;
			ListYesNoType _CorpCred = CorpCred;
			CustNumType _CorpCust = CorpCust;
			ListYesNoType _CreditHold = CreditHold;
			DateType _CreditHoldDate = CreditHoldDate;
			ReasonCodeType _CreditHoldReason = CreditHoldReason;
			UserCodeType _CreditHoldUser = CreditHoldUser;
			AmountType _CreditLimit = CreditLimit;
			AmountType _OrderCreditLimit = OrderCreditLimit;
			CurrCodeType _CurrCode = CurrCode;
			DaysOverType _DaysOverInvDueDate = DaysOverInvDueDate;
			EmailType _ExternalEmailAddr = ExternalEmailAddr;
			PhoneType _FaxNum = FaxNum;
			EmailType _InternalEmailAddr = InternalEmailAddr;
			URLType _InternetUrl = InternetUrl;
			PhoneType _TelexNum = TelexNum;
			AddressType _Addr_1 = Addr_1;
			AddressType _Addr_2 = Addr_2;
			AddressType _Addr_3 = Addr_3;
			AddressType _Addr_4 = Addr_4;
			CityType _City = City;
			CountryType _Country = Country;
			CountyType _County = County;
			NameType _Name = Name;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CustSeqType _DefaultShipTo = DefaultShipTo;
			ToleranceDaysType _DaysShippedBeforeDueDate = DaysShippedBeforeDueDate;
			ToleranceDaysType _DaysShippedAfterDueDate = DaysShippedAfterDueDate;
			TolerancePercentType _ShippedOverOrderedQty = ShippedOverOrderedQty;
			TolerancePercentType _ShippedUnderOrderedQty = ShippedUnderOrderedQty;
			SfModeType _FlagInsertUpdate = FlagInsertUpdate;
			SlsmanType _ResellerSlsman = ResellerSlsman;
			ListYesNoType _ShipmentApprovalRequired = ShipmentApprovalRequired;
			SalePricePercentType _ConstructiveSalePricePct = ConstructiveSalePricePct;
			SepaMandateRefType _SepaMandateRef = SepaMandateRef;
			DateType _SepaMandateCreationDate = SepaMandateCreationDate;
			DateType _SepaMandateExpirationDate = SepaMandateExpirationDate;
			DateType _SepaMndateLastUsedDate = SepaMndateLastUsedDate;
			ListYesNoType _SepaCoreDirectDebit = SepaCoreDirectDebit;
			ListYesNoType _SepaOneOffMandate = SepaOneOffMandate;
			BankAccountType _BankAcctNo = BankAcctNo;
			AccountNameType _AccountName = AccountName;
			InternationalBankAccountType _InternationalBankAccount = InternationalBankAccount;
			BankAuthorityPartyIDType _BankAuthorityPartyId = BankAuthorityPartyId;
			DunningGroupType _DunningGroup = DunningGroup;
			DunningStageIdType _DunningStageId = DunningStageId;
			DateType _LastDunningDate = LastDunningDate;
			RowPointerType _RowPointer = RowPointer;
			ListYesNoType _OneShipmentInv = OneShipmentInv;
			ShipMethodGroupType _ShipMethodGroup = ShipMethodGroup;
			CustomerStatusType _Stat = Stat;
			ListYesNoType _UseLongName = UseLongName;
			LongNameType _LongName = LongName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerInsUpdSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsPullUp", _ApsPullUp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AvgBalOs", _AvgBalOs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AvgDaysOs", _AvgDaysOs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BranchId", _BranchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalcDate", _CalcDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld1", _Charfld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld2", _Charfld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld3", _Charfld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompanyRevenue", _CompanyRevenue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Consolidate", _Consolidate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact_1", _Contact_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Contact_3", _Contact_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustBank", _CustBank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustType", _CustType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Datefld", _Datefld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Delterm", _Delterm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscLstYr", _DiscLstYr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscYtd", _DiscYtd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoInvoice", _DoInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DraftPrintFlag", _DraftPrintFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Einvoice", _Einvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndUserType", _EndUserType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinChg", _FinChg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTaxInPrice", _IncludeTaxInPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCategory", _InvCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvFreq", _InvFreq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LargDaysOs", _LargDaysOs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LargeBalOs", _LargeBalOs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastBalOs", _LastBalOs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastDaysOs", _LastDaysOs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastFinChg", _LastFinChg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastInv", _LastInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastPaid", _LastPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcrReqd", _LcrReqd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Logifld", _Logifld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumberOfEmployees", _NumberOfEmployees, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumPeriods", _NumPeriods, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OnePackInv", _OnePackInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDay", _PayDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDayEndTime_1", _PayDayEndTime_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDayEndTime_2", _PayDayEndTime_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDayStartTime_1", _PayDayStartTime_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayDayStartTime_2", _PayDayStartTime_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone_1", _Phone_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone_3", _Phone_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPackInv", _PrintPackInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionDay", _RevisionDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionDayEndTime_1", _RevisionDayEndTime_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionDayEndTime_2", _RevisionDayEndTime_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionDayStartTime_1", _RevisionDayStartTime_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevisionDayStartTime_2", _RevisionDayStartTime_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesLstYr", _SalesLstYr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesPtd", _SalesPtd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesYtd", _SalesYtd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInDropDownList", _ShowInDropDownList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SICCode", _SICCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StateCycle", _StateCycle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Summarize", _Summarize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TerritoryCode", _TerritoryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat2", _TransNat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseExchRate", _UseExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseRevisionPayDays", _UseRevisionPayDays, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld1", _Decifld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld2", _Decifld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld3", _Decifld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveForDataIntegration", _ActiveForDataIntegration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesTeamID", _SalesTeamID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtOverInvAmt", _AmtOverInvAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BalMethod", _BalMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpAddress", _CorpAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCred", _CorpCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpCust", _CorpCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHoldDate", _CreditHoldDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHoldReason", _CreditHoldReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHoldUser", _CreditHoldUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditLimit", _CreditLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderCreditLimit", _OrderCreditLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysOverInvDueDate", _DaysOverInvDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExternalEmailAddr", _ExternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternalEmailAddr", _InternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternetUrl", _InternetUrl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TelexNum", _TelexNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_1", _Addr_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_2", _Addr_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_3", _Addr_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr_4", _Addr_4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DefaultShipTo", _DefaultShipTo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysShippedBeforeDueDate", _DaysShippedBeforeDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysShippedAfterDueDate", _DaysShippedAfterDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShippedOverOrderedQty", _ShippedOverOrderedQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShippedUnderOrderedQty", _ShippedUnderOrderedQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FlagInsertUpdate", _FlagInsertUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerSlsman", _ResellerSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipmentApprovalRequired", _ShipmentApprovalRequired, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConstructiveSalePricePct", _ConstructiveSalePricePct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SepaMandateRef", _SepaMandateRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SepaMandateCreationDate", _SepaMandateCreationDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SepaMandateExpirationDate", _SepaMandateExpirationDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SepaMndateLastUsedDate", _SepaMndateLastUsedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SepaCoreDirectDebit", _SepaCoreDirectDebit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SepaOneOffMandate", _SepaOneOffMandate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankAcctNo", _BankAcctNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountName", _AccountName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternationalBankAccount", _InternationalBankAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankAuthorityPartyId", _BankAuthorityPartyId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DunningGroup", _DunningGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DunningStageId", _DunningStageId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastDunningDate", _LastDunningDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OneShipmentInv", _OneShipmentInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipMethodGroup", _ShipMethodGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseLongName", _UseLongName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LongName", _LongName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
