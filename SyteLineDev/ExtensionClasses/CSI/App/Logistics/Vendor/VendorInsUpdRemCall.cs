//PROJECT NAME: Logistics
//CLASS NAME: VendorInsUpdRemCall.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendorInsUpdRemCall : IVendorInsUpdRemCall
	{
		readonly IApplicationDB appDB;
		
		
		public VendorInsUpdRemCall(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Vendnum,
		string Infobar) VendorInsUpdRemCallSP(string Site,
		string Vendnum,
		string Contact = null,
		string Phone = null,
		string VendType = null,
		string TermsCode = null,
		string ShipCode = null,
		string FOB = null,
		int? PrintPrice = null,
		string Stat = null,
		DateTime? LastPurch = null,
		DateTime? LastPaid = null,
		decimal? Purchytd = null,
		decimal? PurchLstyr = null,
		decimal? Discytd = null,
		decimal? DiscLstyr = null,
		decimal? Payytd = null,
		string VendRemit = null,
		string Whse = null,
		string Charfld1 = null,
		string Charfld2 = null,
		string Charfld3 = null,
		decimal? Decifld1 = null,
		decimal? Decifld2 = null,
		decimal? Decifld3 = null,
		int? Logifld = null,
		DateTime? Datefld = null,
		string CurrCode = null,
		string BankCode = null,
		string PayType = null,
		decimal? PayLstyr = null,
		string BranchID = null,
		string TransNat = null,
		string DelTerm = null,
		string ProcessInd = null,
		string LangCode = null,
		string PurAcct = null,
		string PurAcctUnit1 = null,
		string PurAcctUnit2 = null,
		string PurAcctUnit3 = null,
		string PurAcctUnit4 = null,
		int? LcrReqd = null,
		string Category = null,
		string Account = null,
		string AccountName = null,
		string EFTBankNum = null,
		string PriceBy = "O",
		int? IncludeTaxInCost = null,
		string Transnat2 = null,
		int? ActiveForDataIntegration = 0,
		decimal? VchOverPOCostTolernace = null,
		decimal? VchUnderPoCostTolerance = null,
		decimal? PayFiscalytd = null,
		decimal? PayLstFiscalyr = null,
		string Name = null,
		string City = null,
		string State = null,
		string Zip = null,
		string County = null,
		string Country = null,
		string FaxNum = null,
		string TelexNum = null,
		string Addr1 = null,
		string Addr2 = null,
		string Addr3 = null,
		string Addr4 = null,
		int? PayHold = null,
		string PayHoldUser = null,
		DateTime? PayHoldDate = null,
		string PayHoldReason = null,
		string InternetEmailURL = null,
		string InternalEmailAddr = null,
		string ExternalEmailAddr = null,
		int? SupplyWebVendor = 0,
		int? RequestAcknowledgement = 0,
		string DepositAccountType = null,
		int? AutoVoucher = 0,
		string AutoVoucherMethod = null,
		string FlagInsertUpdate = "I",
		string Buyer = null,
		int? AllowToFirmPlns = 0,
		string FirmPlnTarget = "R",
		string FirmedPoitemStat = "P",
		string ReplenPoNum = null,
		string TransitReference = null,
		decimal? Misc1099Ytd = null,
		decimal? Misc1099LstYr = null,
		string SourceSite = null,
		string SourceSiteCustNum = null,
		int? AutoReceiveDemaindingSitePO = 0,
		int? AutoShipDemandingSiteCO = 0,
		string Infobar = null,
		string VendBank = null,
		string FiscalReportingSystem = null,
		string FiscalReportingSystemType = null,
		string BusinessIdentificationNum = null,
		string Profession = null,
		string EFTFormat = null,
		string BankAuthorityPartyId = null,
		int? ShowInDropDownList = 0,
		int? UseLongName = 0,
		string LongName = null,
		string VenBankTransitNum = null,
		int? OverrideBankTransitNum = 0)
		{
			SiteType _Site = Site;
			VendNumType _Vendnum = Vendnum;
			ContactType _Contact = Contact;
			PhoneType _Phone = Phone;
			VendTypeType _VendType = VendType;
			TermsCodeType _TermsCode = TermsCode;
			ShipCodeType _ShipCode = ShipCode;
			FOBType _FOB = FOB;
			ListYesNoType _PrintPrice = PrintPrice;
			VendorStatusType _Stat = Stat;
			DateType _LastPurch = LastPurch;
			DateType _LastPaid = LastPaid;
			AmountType _Purchytd = Purchytd;
			AmountType _PurchLstyr = PurchLstyr;
			AmountType _Discytd = Discytd;
			AmountType _DiscLstyr = DiscLstyr;
			AmountType _Payytd = Payytd;
			VendNumType _VendRemit = VendRemit;
			WhseType _Whse = Whse;
			UserCharFldType _Charfld1 = Charfld1;
			UserCharFldType _Charfld2 = Charfld2;
			UserCharFldType _Charfld3 = Charfld3;
			UserDeciFldType _Decifld1 = Decifld1;
			UserDeciFldType _Decifld2 = Decifld2;
			UserDeciFldType _Decifld3 = Decifld3;
			UserLogiFldType _Logifld = Logifld;
			UserDateFldType _Datefld = Datefld;
			CurrCodeType _CurrCode = CurrCode;
			BankCodeType _BankCode = BankCode;
			VendorPayTypeType _PayType = PayType;
			AmountType _PayLstyr = PayLstyr;
			BranchIdType _BranchID = BranchID;
			TransNatType _TransNat = TransNat;
			DeltermType _DelTerm = DelTerm;
			ProcessIndType _ProcessInd = ProcessInd;
			LangCodeType _LangCode = LangCode;
			AcctType _PurAcct = PurAcct;
			UnitCode1Type _PurAcctUnit1 = PurAcctUnit1;
			UnitCode2Type _PurAcctUnit2 = PurAcctUnit2;
			UnitCode3Type _PurAcctUnit3 = PurAcctUnit3;
			UnitCode4Type _PurAcctUnit4 = PurAcctUnit4;
			ListYesNoType _LcrReqd = LcrReqd;
			CategoryType _Category = Category;
			BankAccountType _Account = Account;
			AccountNameType _AccountName = AccountName;
			EFTBankNumType _EFTBankNum = EFTBankNum;
			ListOrderDueType _PriceBy = PriceBy;
			ListYesNoType _IncludeTaxInCost = IncludeTaxInCost;
			TransNat2Type _Transnat2 = Transnat2;
			ListYesNoType _ActiveForDataIntegration = ActiveForDataIntegration;
			TolerancePercentType _VchOverPOCostTolernace = VchOverPOCostTolernace;
			TolerancePercentType _VchUnderPoCostTolerance = VchUnderPoCostTolerance;
			AmountType _PayFiscalytd = PayFiscalytd;
			AmountType _PayLstFiscalyr = PayLstFiscalyr;
			NameType _Name = Name;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountyType _County = County;
			CountryType _Country = Country;
			PhoneType _FaxNum = FaxNum;
			PhoneType _TelexNum = TelexNum;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			ListYesNoType _PayHold = PayHold;
			UserCodeType _PayHoldUser = PayHoldUser;
			DateType _PayHoldDate = PayHoldDate;
			ReasonCodeType _PayHoldReason = PayHoldReason;
			URLType _InternetEmailURL = InternetEmailURL;
			EmailType _InternalEmailAddr = InternalEmailAddr;
			EmailType _ExternalEmailAddr = ExternalEmailAddr;
			ListYesNoType _SupplyWebVendor = SupplyWebVendor;
			ListYesNoType _RequestAcknowledgement = RequestAcknowledgement;
			EFTDepositAcctTypeType _DepositAccountType = DepositAccountType;
			ListYesNoType _AutoVoucher = AutoVoucher;
			AutoVoucherMethodType _AutoVoucherMethod = AutoVoucherMethod;
			SfModeType _FlagInsertUpdate = FlagInsertUpdate;
			UsernameType _Buyer = Buyer;
			ListYesNoType _AllowToFirmPlns = AllowToFirmPlns;
			FirmPlnTargetType _FirmPlnTarget = FirmPlnTarget;
			PoitemStatType _FirmedPoitemStat = FirmedPoitemStat;
			PoNumType _ReplenPoNum = ReplenPoNum;
			AchTransitReferenceType _TransitReference = TransitReference;
			AmountType _Misc1099Ytd = Misc1099Ytd;
			AmountType _Misc1099LstYr = Misc1099LstYr;
			SiteType _SourceSite = SourceSite;
			CustNumType _SourceSiteCustNum = SourceSiteCustNum;
			ListYesNoType _AutoReceiveDemaindingSitePO = AutoReceiveDemaindingSitePO;
			ListYesNoType _AutoShipDemandingSiteCO = AutoShipDemandingSiteCO;
			InfobarType _Infobar = Infobar;
			BankCodeType _VendBank = VendBank;
			FiscalReportingSystemType _FiscalReportingSystem = FiscalReportingSystem;
			FiscalReportingSystemTypeType _FiscalReportingSystemType = FiscalReportingSystemType;
			BusinessIdentificationNumType _BusinessIdentificationNum = BusinessIdentificationNum;
			ProfessionType _Profession = Profession;
			EFTFormatType _EFTFormat = EFTFormat;
			BankAuthorityPartyIDType _BankAuthorityPartyId = BankAuthorityPartyId;
			ListYesNoType _ShowInDropDownList = ShowInDropDownList;
			ListYesNoType _UseLongName = UseLongName;
			LongNameType _LongName = LongName;
			BankTransitNumType _VenBankTransitNum = VenBankTransitNum;
			ListYesNoType _OverrideBankTransitNum = OverrideBankTransitNum;


			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VendorInsUpdRemCallSP";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Vendnum", _Vendnum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendType", _VendType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermsCode", _TermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipCode", _ShipCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FOB", _FOB, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintPrice", _PrintPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastPurch", _LastPurch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastPaid", _LastPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Purchytd", _Purchytd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurchLstyr", _PurchLstyr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Discytd", _Discytd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscLstyr", _DiscLstyr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Payytd", _Payytd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendRemit", _VendRemit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld1", _Charfld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld2", _Charfld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld3", _Charfld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld1", _Decifld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld2", _Decifld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld3", _Decifld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Logifld", _Logifld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Datefld", _Datefld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayLstyr", _PayLstyr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BranchID", _BranchID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNat", _TransNat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DelTerm", _DelTerm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessInd", _ProcessInd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LangCode", _LangCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurAcct", _PurAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurAcctUnit1", _PurAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurAcctUnit2", _PurAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurAcctUnit3", _PurAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurAcctUnit4", _PurAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcrReqd", _LcrReqd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Category", _Category, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Account", _Account, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountName", _AccountName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFTBankNum", _EFTBankNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceBy", _PriceBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTaxInCost", _IncludeTaxInCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Transnat2", _Transnat2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveForDataIntegration", _ActiveForDataIntegration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VchOverPOCostTolernace", _VchOverPOCostTolernace, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VchUnderPoCostTolerance", _VchUnderPoCostTolerance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayFiscalytd", _PayFiscalytd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayLstFiscalyr", _PayLstFiscalyr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TelexNum", _TelexNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHold", _PayHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHoldUser", _PayHoldUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHoldDate", _PayHoldDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayHoldReason", _PayHoldReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternetEmailURL", _InternetEmailURL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InternalEmailAddr", _InternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExternalEmailAddr", _ExternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplyWebVendor", _SupplyWebVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequestAcknowledgement", _RequestAcknowledgement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepositAccountType", _DepositAccountType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoVoucher", _AutoVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoVoucherMethod", _AutoVoucherMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FlagInsertUpdate", _FlagInsertUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowToFirmPlns", _AllowToFirmPlns, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirmPlnTarget", _FirmPlnTarget, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirmedPoitemStat", _FirmedPoitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReplenPoNum", _ReplenPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransitReference", _TransitReference, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Misc1099Ytd", _Misc1099Ytd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Misc1099LstYr", _Misc1099LstYr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSiteCustNum", _SourceSiteCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoReceiveDemaindingSitePO", _AutoReceiveDemaindingSitePO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoShipDemandingSiteCO", _AutoShipDemandingSiteCO, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendBank", _VendBank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalReportingSystem", _FiscalReportingSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalReportingSystemType", _FiscalReportingSystemType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BusinessIdentificationNum", _BusinessIdentificationNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Profession", _Profession, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EFTFormat", _EFTFormat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankAuthorityPartyId", _BankAuthorityPartyId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInDropDownList", _ShowInDropDownList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseLongName", _UseLongName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LongName", _LongName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VenBankTransitNum", _VenBankTransitNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OverrideBankTransitNum", _OverrideBankTransitNum, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Vendnum = _Vendnum;
				Infobar = _Infobar;
				
				return (Severity, Vendnum, Infobar);
			}
		}
	}
}
