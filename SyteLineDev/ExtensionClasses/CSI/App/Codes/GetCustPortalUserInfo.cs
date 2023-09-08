//PROJECT NAME: CSICodes
//CLASS NAME: GetCustPortalUserInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetCustPortalUserInfo
	{
		(int? ReturnCode, Guid? CoRowPointer, string GlobalCustNum, int? GlobalCustSeq, string GlobalCustName, byte? GlobalB2B, string GlobalCoType, string GlobalUserId, string GlobalUserDesc, string GlobalCurrCode, string GlobalResellerCustNum, string GlobalResellerSlsman, string GlobalPrimarySite, string GlobalCoNum, string GlobalPaymentMethod, string GlobalShippingMethod, string GlobalAPSMode, string GlobalSupportPhone, byte? GlobalHasCCI, byte? GlobalHasFSP, string GlobalUserEmailAddress, byte? GlobalCreateUserPrivilege, byte? GlobalIsAdmin, byte? GlobalEnableCategoryBrowsing, string GlobalResellerCurrCode, string GlobalGroupName, byte? GlobalSuperUserFlag, string GlobalB2BCOCustNum, byte? GlobalIsPreLogin, string GlobalPricingPreCalculationRule, string GlobalPricingDisplayRule, byte? GlobalDisplayPriceOnRequest, Guid? GlobalCustomerCatalogRowPointer, Guid? GlobalResellerCatalogRowPointer, Guid? GlobalPreLoginCatalogRowPointer, string ConfiguratorUserInterface, string Infobar) GetCustPortalUserInfoSp(Guid? CoRowPointer,
		string GlobalCustNum,
		int? GlobalCustSeq,
		string GlobalCustName,
		byte? GlobalB2B,
		string GlobalCoType,
		string GlobalUserId,
		string GlobalUserDesc,
		string GlobalCurrCode,
		string GlobalResellerCustNum,
		string GlobalResellerSlsman,
		string GlobalPrimarySite,
		string GlobalCoNum,
		string GlobalPaymentMethod,
		string GlobalShippingMethod,
		string GlobalAPSMode,
		string GlobalSupportPhone,
		byte? GlobalHasCCI,
		byte? GlobalHasFSP,
		string GlobalUserEmailAddress,
		byte? GlobalCreateUserPrivilege,
		byte? GlobalIsAdmin,
		byte? GlobalEnableCategoryBrowsing,
		string GlobalResellerCurrCode,
		string GlobalGroupName,
		byte? GlobalSuperUserFlag,
		string GlobalB2BCOCustNum,
		byte? GlobalIsPreLogin,
		string GlobalPricingPreCalculationRule,
		string GlobalPricingDisplayRule,
		byte? GlobalDisplayPriceOnRequest,
		Guid? GlobalCustomerCatalogRowPointer,
		Guid? GlobalResellerCatalogRowPointer,
		Guid? GlobalPreLoginCatalogRowPointer,
		byte? MergeCart,
		string ToOrderType,
		string PreLoginCoNum,
		string PostLoginCoNum,
		string ConfiguratorUserInterface = "N",
		string Infobar = null);
	}
	
	public class GetCustPortalUserInfo : IGetCustPortalUserInfo
	{
		readonly IApplicationDB appDB;
		
		public GetCustPortalUserInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? CoRowPointer, string GlobalCustNum, int? GlobalCustSeq, string GlobalCustName, byte? GlobalB2B, string GlobalCoType, string GlobalUserId, string GlobalUserDesc, string GlobalCurrCode, string GlobalResellerCustNum, string GlobalResellerSlsman, string GlobalPrimarySite, string GlobalCoNum, string GlobalPaymentMethod, string GlobalShippingMethod, string GlobalAPSMode, string GlobalSupportPhone, byte? GlobalHasCCI, byte? GlobalHasFSP, string GlobalUserEmailAddress, byte? GlobalCreateUserPrivilege, byte? GlobalIsAdmin, byte? GlobalEnableCategoryBrowsing, string GlobalResellerCurrCode, string GlobalGroupName, byte? GlobalSuperUserFlag, string GlobalB2BCOCustNum, byte? GlobalIsPreLogin, string GlobalPricingPreCalculationRule, string GlobalPricingDisplayRule, byte? GlobalDisplayPriceOnRequest, Guid? GlobalCustomerCatalogRowPointer, Guid? GlobalResellerCatalogRowPointer, Guid? GlobalPreLoginCatalogRowPointer, string ConfiguratorUserInterface, string Infobar) GetCustPortalUserInfoSp(Guid? CoRowPointer,
		string GlobalCustNum,
		int? GlobalCustSeq,
		string GlobalCustName,
		byte? GlobalB2B,
		string GlobalCoType,
		string GlobalUserId,
		string GlobalUserDesc,
		string GlobalCurrCode,
		string GlobalResellerCustNum,
		string GlobalResellerSlsman,
		string GlobalPrimarySite,
		string GlobalCoNum,
		string GlobalPaymentMethod,
		string GlobalShippingMethod,
		string GlobalAPSMode,
		string GlobalSupportPhone,
		byte? GlobalHasCCI,
		byte? GlobalHasFSP,
		string GlobalUserEmailAddress,
		byte? GlobalCreateUserPrivilege,
		byte? GlobalIsAdmin,
		byte? GlobalEnableCategoryBrowsing,
		string GlobalResellerCurrCode,
		string GlobalGroupName,
		byte? GlobalSuperUserFlag,
		string GlobalB2BCOCustNum,
		byte? GlobalIsPreLogin,
		string GlobalPricingPreCalculationRule,
		string GlobalPricingDisplayRule,
		byte? GlobalDisplayPriceOnRequest,
		Guid? GlobalCustomerCatalogRowPointer,
		Guid? GlobalResellerCatalogRowPointer,
		Guid? GlobalPreLoginCatalogRowPointer,
		byte? MergeCart,
		string ToOrderType,
		string PreLoginCoNum,
		string PostLoginCoNum,
		string ConfiguratorUserInterface = "N",
		string Infobar = null)
		{
			RowPointerType _CoRowPointer = CoRowPointer;
			CustNumType _GlobalCustNum = GlobalCustNum;
			CustSeqType _GlobalCustSeq = GlobalCustSeq;
			NameType _GlobalCustName = GlobalCustName;
			ListYesNoType _GlobalB2B = GlobalB2B;
			CoTypeType _GlobalCoType = GlobalCoType;
			UsernameType _GlobalUserId = GlobalUserId;
			LongDescType _GlobalUserDesc = GlobalUserDesc;
			CurrCodeType _GlobalCurrCode = GlobalCurrCode;
			CustNumType _GlobalResellerCustNum = GlobalResellerCustNum;
			SlsmanType _GlobalResellerSlsman = GlobalResellerSlsman;
			SiteType _GlobalPrimarySite = GlobalPrimarySite;
			CoNumType _GlobalCoNum = GlobalCoNum;
			PaymentMethodType _GlobalPaymentMethod = GlobalPaymentMethod;
			ShipMethodType _GlobalShippingMethod = GlobalShippingMethod;
			ApsModeType _GlobalAPSMode = GlobalAPSMode;
			PhoneType _GlobalSupportPhone = GlobalSupportPhone;
			ListYesNoType _GlobalHasCCI = GlobalHasCCI;
			ListYesNoType _GlobalHasFSP = GlobalHasFSP;
			EmailType _GlobalUserEmailAddress = GlobalUserEmailAddress;
			ListYesNoType _GlobalCreateUserPrivilege = GlobalCreateUserPrivilege;
			ListYesNoType _GlobalIsAdmin = GlobalIsAdmin;
			ListYesNoType _GlobalEnableCategoryBrowsing = GlobalEnableCategoryBrowsing;
			CurrCodeType _GlobalResellerCurrCode = GlobalResellerCurrCode;
			GroupnameType _GlobalGroupName = GlobalGroupName;
			FlagNyType _GlobalSuperUserFlag = GlobalSuperUserFlag;
			CustNumType _GlobalB2BCOCustNum = GlobalB2BCOCustNum;
			ListYesNoType _GlobalIsPreLogin = GlobalIsPreLogin;
			PricingPrecalculationRuleType _GlobalPricingPreCalculationRule = GlobalPricingPreCalculationRule;
			PricingDisplayRuleType _GlobalPricingDisplayRule = GlobalPricingDisplayRule;
			ListYesNoType _GlobalDisplayPriceOnRequest = GlobalDisplayPriceOnRequest;
			RowPointerType _GlobalCustomerCatalogRowPointer = GlobalCustomerCatalogRowPointer;
			RowPointerType _GlobalResellerCatalogRowPointer = GlobalResellerCatalogRowPointer;
			RowPointerType _GlobalPreLoginCatalogRowPointer = GlobalPreLoginCatalogRowPointer;
			ListYesNoType _MergeCart = MergeCart;
			CoTypeType _ToOrderType = ToOrderType;
			CoNumType _PreLoginCoNum = PreLoginCoNum;
			CoNumType _PostLoginCoNum = PostLoginCoNum;
			ConfiguratorUserInterfaceType _ConfiguratorUserInterface = ConfiguratorUserInterface;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCustPortalUserInfoSp";
				
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalCustNum", _GlobalCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalCustSeq", _GlobalCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalCustName", _GlobalCustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalB2B", _GlobalB2B, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalCoType", _GlobalCoType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalUserId", _GlobalUserId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalUserDesc", _GlobalUserDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalCurrCode", _GlobalCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalResellerCustNum", _GlobalResellerCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalResellerSlsman", _GlobalResellerSlsman, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalPrimarySite", _GlobalPrimarySite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalCoNum", _GlobalCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalPaymentMethod", _GlobalPaymentMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalShippingMethod", _GlobalShippingMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalAPSMode", _GlobalAPSMode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalSupportPhone", _GlobalSupportPhone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalHasCCI", _GlobalHasCCI, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalHasFSP", _GlobalHasFSP, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalUserEmailAddress", _GlobalUserEmailAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalCreateUserPrivilege", _GlobalCreateUserPrivilege, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalIsAdmin", _GlobalIsAdmin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalEnableCategoryBrowsing", _GlobalEnableCategoryBrowsing, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalResellerCurrCode", _GlobalResellerCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalGroupName", _GlobalGroupName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalSuperUserFlag", _GlobalSuperUserFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalB2BCOCustNum", _GlobalB2BCOCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalIsPreLogin", _GlobalIsPreLogin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalPricingPreCalculationRule", _GlobalPricingPreCalculationRule, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalPricingDisplayRule", _GlobalPricingDisplayRule, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalDisplayPriceOnRequest", _GlobalDisplayPriceOnRequest, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalCustomerCatalogRowPointer", _GlobalCustomerCatalogRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalResellerCatalogRowPointer", _GlobalResellerCatalogRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GlobalPreLoginCatalogRowPointer", _GlobalPreLoginCatalogRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MergeCart", _MergeCart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToOrderType", _ToOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreLoginCoNum", _PreLoginCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostLoginCoNum", _PostLoginCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfiguratorUserInterface", _ConfiguratorUserInterface, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoRowPointer = _CoRowPointer;
				GlobalCustNum = _GlobalCustNum;
				GlobalCustSeq = _GlobalCustSeq;
				GlobalCustName = _GlobalCustName;
				GlobalB2B = _GlobalB2B;
				GlobalCoType = _GlobalCoType;
				GlobalUserId = _GlobalUserId;
				GlobalUserDesc = _GlobalUserDesc;
				GlobalCurrCode = _GlobalCurrCode;
				GlobalResellerCustNum = _GlobalResellerCustNum;
				GlobalResellerSlsman = _GlobalResellerSlsman;
				GlobalPrimarySite = _GlobalPrimarySite;
				GlobalCoNum = _GlobalCoNum;
				GlobalPaymentMethod = _GlobalPaymentMethod;
				GlobalShippingMethod = _GlobalShippingMethod;
				GlobalAPSMode = _GlobalAPSMode;
				GlobalSupportPhone = _GlobalSupportPhone;
				GlobalHasCCI = _GlobalHasCCI;
				GlobalHasFSP = _GlobalHasFSP;
				GlobalUserEmailAddress = _GlobalUserEmailAddress;
				GlobalCreateUserPrivilege = _GlobalCreateUserPrivilege;
				GlobalIsAdmin = _GlobalIsAdmin;
				GlobalEnableCategoryBrowsing = _GlobalEnableCategoryBrowsing;
				GlobalResellerCurrCode = _GlobalResellerCurrCode;
				GlobalGroupName = _GlobalGroupName;
				GlobalSuperUserFlag = _GlobalSuperUserFlag;
				GlobalB2BCOCustNum = _GlobalB2BCOCustNum;
				GlobalIsPreLogin = _GlobalIsPreLogin;
				GlobalPricingPreCalculationRule = _GlobalPricingPreCalculationRule;
				GlobalPricingDisplayRule = _GlobalPricingDisplayRule;
				GlobalDisplayPriceOnRequest = _GlobalDisplayPriceOnRequest;
				GlobalCustomerCatalogRowPointer = _GlobalCustomerCatalogRowPointer;
				GlobalResellerCatalogRowPointer = _GlobalResellerCatalogRowPointer;
				GlobalPreLoginCatalogRowPointer = _GlobalPreLoginCatalogRowPointer;
				ConfiguratorUserInterface = _ConfiguratorUserInterface;
				Infobar = _Infobar;
				
				return (Severity, CoRowPointer, GlobalCustNum, GlobalCustSeq, GlobalCustName, GlobalB2B, GlobalCoType, GlobalUserId, GlobalUserDesc, GlobalCurrCode, GlobalResellerCustNum, GlobalResellerSlsman, GlobalPrimarySite, GlobalCoNum, GlobalPaymentMethod, GlobalShippingMethod, GlobalAPSMode, GlobalSupportPhone, GlobalHasCCI, GlobalHasFSP, GlobalUserEmailAddress, GlobalCreateUserPrivilege, GlobalIsAdmin, GlobalEnableCategoryBrowsing, GlobalResellerCurrCode, GlobalGroupName, GlobalSuperUserFlag, GlobalB2BCOCustNum, GlobalIsPreLogin, GlobalPricingPreCalculationRule, GlobalPricingDisplayRule, GlobalDisplayPriceOnRequest, GlobalCustomerCatalogRowPointer, GlobalResellerCatalogRowPointer, GlobalPreLoginCatalogRowPointer, ConfiguratorUserInterface, Infobar);
			}
		}
	}
}
