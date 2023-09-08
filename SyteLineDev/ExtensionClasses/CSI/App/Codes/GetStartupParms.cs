//PROJECT NAME: Codes
//CLASS NAME: GetStartupParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetStartupParms
	{
		(int? ReturnCode, string CurWhse, string CurUserCode, decimal? UserID, string Acct, string UnitCode1, string UnitCode2, string UnitCode3, string UnitCode4, byte? Tax1_Enabled, string Tax1_DefTaxCode, string Tax1_TaxCodeLabel, string Tax1_TaxIdLabel, byte? Tax1_PromptOnLine, string Tax1_TaxMode, byte? TaxPromptForSystem1, byte? TaxTwoExchRates, byte? TaxNmbrOfSystems, string Tax1_TaxAmtLabel, string Tax1_TaxItemLabel, byte? Tax1_ActiveForPurch, string Tax1_TaxIdPromptLoc, string Tax1_DefItemTaxCode, string Tax1_DefMiscTaxCode, string Tax1_DefFrtTaxCode, string Tax1_TaxCodeDescLabel, string Tax1_TaxItemDescLabel, string Tax1_FrtCodeLabel, string Tax1_FrtCodeDescLabel, string Tax1_MiscCodeLabel, string Tax1_MiscCodeDescLabel, string Tax1_TaxAmtAccumLabel, byte? Tax2_Enabled, string Tax2_DefTaxCode, string Tax2_TaxCodeLabel, string Tax2_TaxIdLabel, byte? Tax2_PromptOnLine, string Tax2_TaxMode, byte? TaxPromptForSystem2, string Tax2_TaxAmtLabel, string Tax2_TaxItemLabel, byte? Tax2_ActiveForPurch, string Tax2_TaxIdPromptLoc, string Tax2_DefItemTaxCode, string Tax2_DefMiscTaxCode, string Tax2_DefFrtTaxCode, string Tax2_TaxCodeDescLabel, string Tax2_TaxItemDescLabel, string Tax2_FrtCodeLabel, string Tax2_FrtCodeDescLabel, string Tax2_MiscCodeLabel, string Tax2_MiscCodeDescLabel, string Tax2_TaxAmtAccumLabel, string ArAcct, string ArUnitCode1, string ArUnitCode2, string ArUnitCode3, string ArUnitCode4, byte? Capitalize, byte? MultiWhse, byte? DoLength, byte? SerialLength, byte? LotLength, string CurrCode, string Addr1, string Addr2, string Addr3, string Addr4, string City, string State, string Zip, string Country, string Phone, string Company, string DefWhse, string Site, byte? EcReporting, string QtyUnitFormat, string QtyPerFormat, string QtyCumuFormat, string QtyTotlFormat, byte? LotGenExp, short? RetentionDays, byte? UniqueLot, string SiteGroup, string Infobar, string AmtFormat, string AmtTotFormat, string CstPrcFormat, string LotDataType, string SerNumDataType, byte? InvNumLength, string AcctDataType, string IntranetName, string MasterSite, byte? HideParentGridColumns, byte? BackflushLot, byte? BackflushSerial, byte? UniqueSerial, string EcnEst, string EcnJob, string EcnStd, byte? NegFlag, byte? SecureCtrlAcct, byte? DefaultStartingToEnding, string MsgBusLogicalId, string LanguageID, byte? UseAlternateAddressReportFormat, string DocAutoAppId, string DocAutoNameSpace, string DocAutoRuleSet, byte? ImplementCelergo, byte? AutoDisplayButtonBlock, string EcnItem, string EcnItemManufacturer, string CurPlant) GetStartupParmsSp(string UserName,
		string CurWhse,
		string CurUserCode,
		decimal? UserID,
		string AcctType,
		string Acct,
		string UnitCode1,
		string UnitCode2,
		string UnitCode3,
		string UnitCode4,
		byte? Tax1_Enabled,
		string Tax1_DefTaxCode,
		string Tax1_TaxCodeLabel,
		string Tax1_TaxIdLabel,
		byte? Tax1_PromptOnLine,
		string Tax1_TaxMode,
		byte? TaxPromptForSystem1,
		byte? TaxTwoExchRates,
		byte? TaxNmbrOfSystems,
		string Tax1_TaxAmtLabel,
		string Tax1_TaxItemLabel,
		byte? Tax1_ActiveForPurch,
		string Tax1_TaxIdPromptLoc,
		string Tax1_DefItemTaxCode,
		string Tax1_DefMiscTaxCode,
		string Tax1_DefFrtTaxCode,
		string Tax1_TaxCodeDescLabel,
		string Tax1_TaxItemDescLabel,
		string Tax1_FrtCodeLabel,
		string Tax1_FrtCodeDescLabel,
		string Tax1_MiscCodeLabel,
		string Tax1_MiscCodeDescLabel,
		string Tax1_TaxAmtAccumLabel,
		byte? Tax2_Enabled,
		string Tax2_DefTaxCode,
		string Tax2_TaxCodeLabel,
		string Tax2_TaxIdLabel,
		byte? Tax2_PromptOnLine,
		string Tax2_TaxMode,
		byte? TaxPromptForSystem2,
		string Tax2_TaxAmtLabel,
		string Tax2_TaxItemLabel,
		byte? Tax2_ActiveForPurch,
		string Tax2_TaxIdPromptLoc,
		string Tax2_DefItemTaxCode,
		string Tax2_DefMiscTaxCode,
		string Tax2_DefFrtTaxCode,
		string Tax2_TaxCodeDescLabel,
		string Tax2_TaxItemDescLabel,
		string Tax2_FrtCodeLabel,
		string Tax2_FrtCodeDescLabel,
		string Tax2_MiscCodeLabel,
		string Tax2_MiscCodeDescLabel,
		string Tax2_TaxAmtAccumLabel,
		string ArAcctType,
		string ArAcct,
		string ArUnitCode1,
		string ArUnitCode2,
		string ArUnitCode3,
		string ArUnitCode4,
		byte? Capitalize,
		byte? MultiWhse,
		byte? DoLength,
		byte? SerialLength,
		byte? LotLength,
		string CurrCode,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string State,
		string Zip,
		string Country,
		string Phone,
		string Company,
		string DefWhse,
		string Site,
		byte? EcReporting,
		string QtyUnitFormat,
		string QtyPerFormat,
		string QtyCumuFormat,
		string QtyTotlFormat,
		byte? LotGenExp,
		short? RetentionDays,
		byte? UniqueLot,
		string SiteGroup,
		string Infobar,
		string AmtFormat = null,
		string AmtTotFormat = null,
		string CstPrcFormat = null,
		string LotDataType = null,
		string SerNumDataType = null,
		byte? InvNumLength = null,
		string AcctDataType = null,
		string IntranetName = null,
		string MasterSite = null,
		byte? HideParentGridColumns = null,
		byte? BackflushLot = null,
		byte? BackflushSerial = null,
		byte? UniqueSerial = null,
		string EcnEst = null,
		string EcnJob = null,
		string EcnStd = null,
		byte? NegFlag = null,
		byte? SecureCtrlAcct = null,
		byte? DefaultStartingToEnding = null,
		string MsgBusLogicalId = null,
		string LanguageID = null,
		byte? UseAlternateAddressReportFormat = null,
		string DocAutoAppId = null,
		string DocAutoNameSpace = null,
		string DocAutoRuleSet = null,
		byte? ImplementCelergo = null,
		byte? AutoDisplayButtonBlock = null,
		string EcnItem = null,
		string EcnItemManufacturer = null,
        string CurPlant = null);
	}
	
	public class GetStartupParms : IGetStartupParms
	{
		readonly IApplicationDB appDB;
		
		public GetStartupParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CurWhse, string CurUserCode, decimal? UserID, string Acct, string UnitCode1, string UnitCode2, string UnitCode3, string UnitCode4, byte? Tax1_Enabled, string Tax1_DefTaxCode, string Tax1_TaxCodeLabel, string Tax1_TaxIdLabel, byte? Tax1_PromptOnLine, string Tax1_TaxMode, byte? TaxPromptForSystem1, byte? TaxTwoExchRates, byte? TaxNmbrOfSystems, string Tax1_TaxAmtLabel, string Tax1_TaxItemLabel, byte? Tax1_ActiveForPurch, string Tax1_TaxIdPromptLoc, string Tax1_DefItemTaxCode, string Tax1_DefMiscTaxCode, string Tax1_DefFrtTaxCode, string Tax1_TaxCodeDescLabel, string Tax1_TaxItemDescLabel, string Tax1_FrtCodeLabel, string Tax1_FrtCodeDescLabel, string Tax1_MiscCodeLabel, string Tax1_MiscCodeDescLabel, string Tax1_TaxAmtAccumLabel, byte? Tax2_Enabled, string Tax2_DefTaxCode, string Tax2_TaxCodeLabel, string Tax2_TaxIdLabel, byte? Tax2_PromptOnLine, string Tax2_TaxMode, byte? TaxPromptForSystem2, string Tax2_TaxAmtLabel, string Tax2_TaxItemLabel, byte? Tax2_ActiveForPurch, string Tax2_TaxIdPromptLoc, string Tax2_DefItemTaxCode, string Tax2_DefMiscTaxCode, string Tax2_DefFrtTaxCode, string Tax2_TaxCodeDescLabel, string Tax2_TaxItemDescLabel, string Tax2_FrtCodeLabel, string Tax2_FrtCodeDescLabel, string Tax2_MiscCodeLabel, string Tax2_MiscCodeDescLabel, string Tax2_TaxAmtAccumLabel, string ArAcct, string ArUnitCode1, string ArUnitCode2, string ArUnitCode3, string ArUnitCode4, byte? Capitalize, byte? MultiWhse, byte? DoLength, byte? SerialLength, byte? LotLength, string CurrCode, string Addr1, string Addr2, string Addr3, string Addr4, string City, string State, string Zip, string Country, string Phone, string Company, string DefWhse, string Site, byte? EcReporting, string QtyUnitFormat, string QtyPerFormat, string QtyCumuFormat, string QtyTotlFormat, byte? LotGenExp, short? RetentionDays, byte? UniqueLot, string SiteGroup, string Infobar, string AmtFormat, string AmtTotFormat, string CstPrcFormat, string LotDataType, string SerNumDataType, byte? InvNumLength, string AcctDataType, string IntranetName, string MasterSite, byte? HideParentGridColumns, byte? BackflushLot, byte? BackflushSerial, byte? UniqueSerial, string EcnEst, string EcnJob, string EcnStd, byte? NegFlag, byte? SecureCtrlAcct, byte? DefaultStartingToEnding, string MsgBusLogicalId, string LanguageID, byte? UseAlternateAddressReportFormat, string DocAutoAppId, string DocAutoNameSpace, string DocAutoRuleSet, byte? ImplementCelergo, byte? AutoDisplayButtonBlock, string EcnItem, string EcnItemManufacturer, string CurPlant) GetStartupParmsSp(string UserName,
		string CurWhse,
		string CurUserCode,
		decimal? UserID,
		string AcctType,
		string Acct,
		string UnitCode1,
		string UnitCode2,
		string UnitCode3,
		string UnitCode4,
		byte? Tax1_Enabled,
		string Tax1_DefTaxCode,
		string Tax1_TaxCodeLabel,
		string Tax1_TaxIdLabel,
		byte? Tax1_PromptOnLine,
		string Tax1_TaxMode,
		byte? TaxPromptForSystem1,
		byte? TaxTwoExchRates,
		byte? TaxNmbrOfSystems,
		string Tax1_TaxAmtLabel,
		string Tax1_TaxItemLabel,
		byte? Tax1_ActiveForPurch,
		string Tax1_TaxIdPromptLoc,
		string Tax1_DefItemTaxCode,
		string Tax1_DefMiscTaxCode,
		string Tax1_DefFrtTaxCode,
		string Tax1_TaxCodeDescLabel,
		string Tax1_TaxItemDescLabel,
		string Tax1_FrtCodeLabel,
		string Tax1_FrtCodeDescLabel,
		string Tax1_MiscCodeLabel,
		string Tax1_MiscCodeDescLabel,
		string Tax1_TaxAmtAccumLabel,
		byte? Tax2_Enabled,
		string Tax2_DefTaxCode,
		string Tax2_TaxCodeLabel,
		string Tax2_TaxIdLabel,
		byte? Tax2_PromptOnLine,
		string Tax2_TaxMode,
		byte? TaxPromptForSystem2,
		string Tax2_TaxAmtLabel,
		string Tax2_TaxItemLabel,
		byte? Tax2_ActiveForPurch,
		string Tax2_TaxIdPromptLoc,
		string Tax2_DefItemTaxCode,
		string Tax2_DefMiscTaxCode,
		string Tax2_DefFrtTaxCode,
		string Tax2_TaxCodeDescLabel,
		string Tax2_TaxItemDescLabel,
		string Tax2_FrtCodeLabel,
		string Tax2_FrtCodeDescLabel,
		string Tax2_MiscCodeLabel,
		string Tax2_MiscCodeDescLabel,
		string Tax2_TaxAmtAccumLabel,
		string ArAcctType,
		string ArAcct,
		string ArUnitCode1,
		string ArUnitCode2,
		string ArUnitCode3,
		string ArUnitCode4,
		byte? Capitalize,
		byte? MultiWhse,
		byte? DoLength,
		byte? SerialLength,
		byte? LotLength,
		string CurrCode,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string City,
		string State,
		string Zip,
		string Country,
		string Phone,
		string Company,
		string DefWhse,
		string Site,
		byte? EcReporting,
		string QtyUnitFormat,
		string QtyPerFormat,
		string QtyCumuFormat,
		string QtyTotlFormat,
		byte? LotGenExp,
		short? RetentionDays,
		byte? UniqueLot,
		string SiteGroup,
		string Infobar,
		string AmtFormat = null,
		string AmtTotFormat = null,
		string CstPrcFormat = null,
		string LotDataType = null,
		string SerNumDataType = null,
		byte? InvNumLength = null,
		string AcctDataType = null,
		string IntranetName = null,
		string MasterSite = null,
		byte? HideParentGridColumns = null,
		byte? BackflushLot = null,
		byte? BackflushSerial = null,
		byte? UniqueSerial = null,
		string EcnEst = null,
		string EcnJob = null,
		string EcnStd = null,
		byte? NegFlag = null,
		byte? SecureCtrlAcct = null,
		byte? DefaultStartingToEnding = null,
		string MsgBusLogicalId = null,
		string LanguageID = null,
		byte? UseAlternateAddressReportFormat = null,
		string DocAutoAppId = null,
		string DocAutoNameSpace = null,
		string DocAutoRuleSet = null,
		byte? ImplementCelergo = null,
		byte? AutoDisplayButtonBlock = null,
		string EcnItem = null,
		string EcnItemManufacturer = null,
        string CurPlant = null)
		{
			UsernameType _UserName = UserName;
			WhseType _CurWhse = CurWhse;
			UserCodeType _CurUserCode = CurUserCode;
			TokenType _UserID = UserID;
			LongStringType _AcctType = AcctType;
			AcctType _Acct = Acct;
			UnitCode1Type _UnitCode1 = UnitCode1;
			UnitCode2Type _UnitCode2 = UnitCode2;
			UnitCode3Type _UnitCode3 = UnitCode3;
			UnitCode4Type _UnitCode4 = UnitCode4;
			ListYesNoType _Tax1_Enabled = Tax1_Enabled;
			TaxCodeType _Tax1_DefTaxCode = Tax1_DefTaxCode;
			TaxCodeLabelType _Tax1_TaxCodeLabel = Tax1_TaxCodeLabel;
			TaxCodeLabelType _Tax1_TaxIdLabel = Tax1_TaxIdLabel;
			ListYesNoType _Tax1_PromptOnLine = Tax1_PromptOnLine;
			TaxModeType _Tax1_TaxMode = Tax1_TaxMode;
			ListYesNoType _TaxPromptForSystem1 = TaxPromptForSystem1;
			ListYesNoType _TaxTwoExchRates = TaxTwoExchRates;
			TaxSystemsType _TaxNmbrOfSystems = TaxNmbrOfSystems;
			TaxCodeLabelType _Tax1_TaxAmtLabel = Tax1_TaxAmtLabel;
			TaxCodeLabelType _Tax1_TaxItemLabel = Tax1_TaxItemLabel;
			ListYesNoType _Tax1_ActiveForPurch = Tax1_ActiveForPurch;
			TaxIdPromptType _Tax1_TaxIdPromptLoc = Tax1_TaxIdPromptLoc;
			TaxCodeType _Tax1_DefItemTaxCode = Tax1_DefItemTaxCode;
			TaxCodeType _Tax1_DefMiscTaxCode = Tax1_DefMiscTaxCode;
			TaxCodeType _Tax1_DefFrtTaxCode = Tax1_DefFrtTaxCode;
			LabelType _Tax1_TaxCodeDescLabel = Tax1_TaxCodeDescLabel;
			LabelType _Tax1_TaxItemDescLabel = Tax1_TaxItemDescLabel;
			TaxCodeLabelType _Tax1_FrtCodeLabel = Tax1_FrtCodeLabel;
			LabelType _Tax1_FrtCodeDescLabel = Tax1_FrtCodeDescLabel;
			TaxCodeLabelType _Tax1_MiscCodeLabel = Tax1_MiscCodeLabel;
			LabelType _Tax1_MiscCodeDescLabel = Tax1_MiscCodeDescLabel;
			LabelType _Tax1_TaxAmtAccumLabel = Tax1_TaxAmtAccumLabel;
			ListYesNoType _Tax2_Enabled = Tax2_Enabled;
			TaxCodeType _Tax2_DefTaxCode = Tax2_DefTaxCode;
			TaxCodeLabelType _Tax2_TaxCodeLabel = Tax2_TaxCodeLabel;
			TaxCodeLabelType _Tax2_TaxIdLabel = Tax2_TaxIdLabel;
			ListYesNoType _Tax2_PromptOnLine = Tax2_PromptOnLine;
			TaxModeType _Tax2_TaxMode = Tax2_TaxMode;
			ListYesNoType _TaxPromptForSystem2 = TaxPromptForSystem2;
			TaxCodeLabelType _Tax2_TaxAmtLabel = Tax2_TaxAmtLabel;
			TaxCodeLabelType _Tax2_TaxItemLabel = Tax2_TaxItemLabel;
			ListYesNoType _Tax2_ActiveForPurch = Tax2_ActiveForPurch;
			TaxIdPromptType _Tax2_TaxIdPromptLoc = Tax2_TaxIdPromptLoc;
			TaxCodeType _Tax2_DefItemTaxCode = Tax2_DefItemTaxCode;
			TaxCodeType _Tax2_DefMiscTaxCode = Tax2_DefMiscTaxCode;
			TaxCodeType _Tax2_DefFrtTaxCode = Tax2_DefFrtTaxCode;
			LabelType _Tax2_TaxCodeDescLabel = Tax2_TaxCodeDescLabel;
			LabelType _Tax2_TaxItemDescLabel = Tax2_TaxItemDescLabel;
			TaxCodeLabelType _Tax2_FrtCodeLabel = Tax2_FrtCodeLabel;
			LabelType _Tax2_FrtCodeDescLabel = Tax2_FrtCodeDescLabel;
			TaxCodeLabelType _Tax2_MiscCodeLabel = Tax2_MiscCodeLabel;
			LabelType _Tax2_MiscCodeDescLabel = Tax2_MiscCodeDescLabel;
			LabelType _Tax2_TaxAmtAccumLabel = Tax2_TaxAmtAccumLabel;
			LongStringType _ArAcctType = ArAcctType;
			AcctType _ArAcct = ArAcct;
			UnitCode1Type _ArUnitCode1 = ArUnitCode1;
			UnitCode2Type _ArUnitCode2 = ArUnitCode2;
			UnitCode3Type _ArUnitCode3 = ArUnitCode3;
			UnitCode4Type _ArUnitCode4 = ArUnitCode4;
			ListYesNoType _Capitalize = Capitalize;
			ListYesNoType _MultiWhse = MultiWhse;
			DoLengthType _DoLength = DoLength;
			SerialLengthType _SerialLength = SerialLength;
			LotLengthType _LotLength = LotLength;
			CurrCodeType _CurrCode = CurrCode;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CityType _City = City;
			StateType _State = State;
			PostalCodeType _Zip = Zip;
			CountryType _Country = Country;
			PhoneType _Phone = Phone;
			NameType _Company = Company;
			WhseType _DefWhse = DefWhse;
			SiteType _Site = Site;
			ListYesNoType _EcReporting = EcReporting;
			InputMaskType _QtyUnitFormat = QtyUnitFormat;
			InputMaskType _QtyPerFormat = QtyPerFormat;
			InputMaskType _QtyCumuFormat = QtyCumuFormat;
			InputMaskType _QtyTotlFormat = QtyTotlFormat;
			ListYesNoType _LotGenExp = LotGenExp;
			RetentionDaysType _RetentionDays = RetentionDays;
			ListYesNoType _UniqueLot = UniqueLot;
			SiteGroupType _SiteGroup = SiteGroup;
			InfobarType _Infobar = Infobar;
			InputMaskType _AmtFormat = AmtFormat;
			InputMaskType _AmtTotFormat = AmtTotFormat;
			InputMaskType _CstPrcFormat = CstPrcFormat;
			LongStringType _LotDataType = LotDataType;
			LongStringType _SerNumDataType = SerNumDataType;
			InvNumLength _InvNumLength = InvNumLength;
			LongStringType _AcctDataType = AcctDataType;
			IntranetNameType _IntranetName = IntranetName;
			SiteType _MasterSite = MasterSite;
			ListYesNoType _HideParentGridColumns = HideParentGridColumns;
			ListYesNoType _BackflushLot = BackflushLot;
			ListYesNoType _BackflushSerial = BackflushSerial;
			ListYesNoType _UniqueSerial = UniqueSerial;
			EcnModeType _EcnEst = EcnEst;
			EcnModeType _EcnJob = EcnJob;
			EcnModeType _EcnStd = EcnStd;
			ListYesNoType _NegFlag = NegFlag;
			ListYesNoType _SecureCtrlAcct = SecureCtrlAcct;
			ListYesNoType _DefaultStartingToEnding = DefaultStartingToEnding;
			MessageBusIdType _MsgBusLogicalId = MsgBusLogicalId;
			LanguageIDType _LanguageID = LanguageID;
			ListYesNoType _UseAlternateAddressReportFormat = UseAlternateAddressReportFormat;
			ConfiguratorServerIdType _DocAutoAppId = DocAutoAppId;
			ConfigNameSpaceType _DocAutoNameSpace = DocAutoNameSpace;
			ConfigRuleSetType _DocAutoRuleSet = DocAutoRuleSet;
			ListYesNoType _ImplementCelergo = ImplementCelergo;
			ListYesNoType _AutoDisplayButtonBlock = AutoDisplayButtonBlock;
			EcnModeType _EcnItem = EcnItem;
			EcnModeType _EcnItemManufacturer = EcnItemManufacturer;
            PlantType _CurPlant = CurPlant;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetStartupParmsSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurUserCode", _CurUserCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctType", _AcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode1", _UnitCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode2", _UnitCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode3", _UnitCode3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCode4", _UnitCode4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_Enabled", _Tax1_Enabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_DefTaxCode", _Tax1_DefTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_TaxCodeLabel", _Tax1_TaxCodeLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_TaxIdLabel", _Tax1_TaxIdLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_PromptOnLine", _Tax1_PromptOnLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_TaxMode", _Tax1_TaxMode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxPromptForSystem1", _TaxPromptForSystem1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxTwoExchRates", _TaxTwoExchRates, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxNmbrOfSystems", _TaxNmbrOfSystems, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_TaxAmtLabel", _Tax1_TaxAmtLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_TaxItemLabel", _Tax1_TaxItemLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_ActiveForPurch", _Tax1_ActiveForPurch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_TaxIdPromptLoc", _Tax1_TaxIdPromptLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_DefItemTaxCode", _Tax1_DefItemTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_DefMiscTaxCode", _Tax1_DefMiscTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_DefFrtTaxCode", _Tax1_DefFrtTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_TaxCodeDescLabel", _Tax1_TaxCodeDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_TaxItemDescLabel", _Tax1_TaxItemDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_FrtCodeLabel", _Tax1_FrtCodeLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_FrtCodeDescLabel", _Tax1_FrtCodeDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_MiscCodeLabel", _Tax1_MiscCodeLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_MiscCodeDescLabel", _Tax1_MiscCodeDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax1_TaxAmtAccumLabel", _Tax1_TaxAmtAccumLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_Enabled", _Tax2_Enabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_DefTaxCode", _Tax2_DefTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_TaxCodeLabel", _Tax2_TaxCodeLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_TaxIdLabel", _Tax2_TaxIdLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_PromptOnLine", _Tax2_PromptOnLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_TaxMode", _Tax2_TaxMode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxPromptForSystem2", _TaxPromptForSystem2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_TaxAmtLabel", _Tax2_TaxAmtLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_TaxItemLabel", _Tax2_TaxItemLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_ActiveForPurch", _Tax2_ActiveForPurch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_TaxIdPromptLoc", _Tax2_TaxIdPromptLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_DefItemTaxCode", _Tax2_DefItemTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_DefMiscTaxCode", _Tax2_DefMiscTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_DefFrtTaxCode", _Tax2_DefFrtTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_TaxCodeDescLabel", _Tax2_TaxCodeDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_TaxItemDescLabel", _Tax2_TaxItemDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_FrtCodeLabel", _Tax2_FrtCodeLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_FrtCodeDescLabel", _Tax2_FrtCodeDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_MiscCodeLabel", _Tax2_MiscCodeLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_MiscCodeDescLabel", _Tax2_MiscCodeDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax2_TaxAmtAccumLabel", _Tax2_TaxAmtAccumLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArAcctType", _ArAcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArAcct", _ArAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArUnitCode1", _ArUnitCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArUnitCode2", _ArUnitCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArUnitCode3", _ArUnitCode3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ArUnitCode4", _ArUnitCode4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Capitalize", _Capitalize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MultiWhse", _MultiWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DoLength", _DoLength, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialLength", _SerialLength, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotLength", _LotLength, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Phone", _Phone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Company", _Company, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefWhse", _DefWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcReporting", _EcReporting, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyUnitFormat", _QtyUnitFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyPerFormat", _QtyPerFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyCumuFormat", _QtyCumuFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyTotlFormat", _QtyTotlFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotGenExp", _LotGenExp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RetentionDays", _RetentionDays, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UniqueLot", _UniqueLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AmtFormat", _AmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AmtTotFormat", _AmtTotFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CstPrcFormat", _CstPrcFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotDataType", _LotDataType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerNumDataType", _SerNumDataType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvNumLength", _InvNumLength, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctDataType", _AcctDataType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IntranetName", _IntranetName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MasterSite", _MasterSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "HideParentGridColumns", _HideParentGridColumns, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BackflushLot", _BackflushLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BackflushSerial", _BackflushSerial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UniqueSerial", _UniqueSerial, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcnEst", _EcnEst, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcnJob", _EcnJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcnStd", _EcnStd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NegFlag", _NegFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SecureCtrlAcct", _SecureCtrlAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefaultStartingToEnding", _DefaultStartingToEnding, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MsgBusLogicalId", _MsgBusLogicalId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LanguageID", _LanguageID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseAlternateAddressReportFormat", _UseAlternateAddressReportFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocAutoAppId", _DocAutoAppId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocAutoNameSpace", _DocAutoNameSpace, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DocAutoRuleSet", _DocAutoRuleSet, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImplementCelergo", _ImplementCelergo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AutoDisplayButtonBlock", _AutoDisplayButtonBlock, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcnItem", _EcnItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EcnItemManufacturer", _EcnItemManufacturer, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurPlant", _CurPlant, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurWhse = _CurWhse;
				CurUserCode = _CurUserCode;
				UserID = _UserID;
				Acct = _Acct;
				UnitCode1 = _UnitCode1;
				UnitCode2 = _UnitCode2;
				UnitCode3 = _UnitCode3;
				UnitCode4 = _UnitCode4;
				Tax1_Enabled = _Tax1_Enabled;
				Tax1_DefTaxCode = _Tax1_DefTaxCode;
				Tax1_TaxCodeLabel = _Tax1_TaxCodeLabel;
				Tax1_TaxIdLabel = _Tax1_TaxIdLabel;
				Tax1_PromptOnLine = _Tax1_PromptOnLine;
				Tax1_TaxMode = _Tax1_TaxMode;
				TaxPromptForSystem1 = _TaxPromptForSystem1;
				TaxTwoExchRates = _TaxTwoExchRates;
				TaxNmbrOfSystems = _TaxNmbrOfSystems;
				Tax1_TaxAmtLabel = _Tax1_TaxAmtLabel;
				Tax1_TaxItemLabel = _Tax1_TaxItemLabel;
				Tax1_ActiveForPurch = _Tax1_ActiveForPurch;
				Tax1_TaxIdPromptLoc = _Tax1_TaxIdPromptLoc;
				Tax1_DefItemTaxCode = _Tax1_DefItemTaxCode;
				Tax1_DefMiscTaxCode = _Tax1_DefMiscTaxCode;
				Tax1_DefFrtTaxCode = _Tax1_DefFrtTaxCode;
				Tax1_TaxCodeDescLabel = _Tax1_TaxCodeDescLabel;
				Tax1_TaxItemDescLabel = _Tax1_TaxItemDescLabel;
				Tax1_FrtCodeLabel = _Tax1_FrtCodeLabel;
				Tax1_FrtCodeDescLabel = _Tax1_FrtCodeDescLabel;
				Tax1_MiscCodeLabel = _Tax1_MiscCodeLabel;
				Tax1_MiscCodeDescLabel = _Tax1_MiscCodeDescLabel;
				Tax1_TaxAmtAccumLabel = _Tax1_TaxAmtAccumLabel;
				Tax2_Enabled = _Tax2_Enabled;
				Tax2_DefTaxCode = _Tax2_DefTaxCode;
				Tax2_TaxCodeLabel = _Tax2_TaxCodeLabel;
				Tax2_TaxIdLabel = _Tax2_TaxIdLabel;
				Tax2_PromptOnLine = _Tax2_PromptOnLine;
				Tax2_TaxMode = _Tax2_TaxMode;
				TaxPromptForSystem2 = _TaxPromptForSystem2;
				Tax2_TaxAmtLabel = _Tax2_TaxAmtLabel;
				Tax2_TaxItemLabel = _Tax2_TaxItemLabel;
				Tax2_ActiveForPurch = _Tax2_ActiveForPurch;
				Tax2_TaxIdPromptLoc = _Tax2_TaxIdPromptLoc;
				Tax2_DefItemTaxCode = _Tax2_DefItemTaxCode;
				Tax2_DefMiscTaxCode = _Tax2_DefMiscTaxCode;
				Tax2_DefFrtTaxCode = _Tax2_DefFrtTaxCode;
				Tax2_TaxCodeDescLabel = _Tax2_TaxCodeDescLabel;
				Tax2_TaxItemDescLabel = _Tax2_TaxItemDescLabel;
				Tax2_FrtCodeLabel = _Tax2_FrtCodeLabel;
				Tax2_FrtCodeDescLabel = _Tax2_FrtCodeDescLabel;
				Tax2_MiscCodeLabel = _Tax2_MiscCodeLabel;
				Tax2_MiscCodeDescLabel = _Tax2_MiscCodeDescLabel;
				Tax2_TaxAmtAccumLabel = _Tax2_TaxAmtAccumLabel;
				ArAcct = _ArAcct;
				ArUnitCode1 = _ArUnitCode1;
				ArUnitCode2 = _ArUnitCode2;
				ArUnitCode3 = _ArUnitCode3;
				ArUnitCode4 = _ArUnitCode4;
				Capitalize = _Capitalize;
				MultiWhse = _MultiWhse;
				DoLength = _DoLength;
				SerialLength = _SerialLength;
				LotLength = _LotLength;
				CurrCode = _CurrCode;
				Addr1 = _Addr1;
				Addr2 = _Addr2;
				Addr3 = _Addr3;
				Addr4 = _Addr4;
				City = _City;
				State = _State;
				Zip = _Zip;
				Country = _Country;
				Phone = _Phone;
				Company = _Company;
				DefWhse = _DefWhse;
				Site = _Site;
				EcReporting = _EcReporting;
				QtyUnitFormat = _QtyUnitFormat;
				QtyPerFormat = _QtyPerFormat;
				QtyCumuFormat = _QtyCumuFormat;
				QtyTotlFormat = _QtyTotlFormat;
				LotGenExp = _LotGenExp;
				RetentionDays = _RetentionDays;
				UniqueLot = _UniqueLot;
				SiteGroup = _SiteGroup;
				Infobar = _Infobar;
				AmtFormat = _AmtFormat;
				AmtTotFormat = _AmtTotFormat;
				CstPrcFormat = _CstPrcFormat;
				LotDataType = _LotDataType;
				SerNumDataType = _SerNumDataType;
				InvNumLength = _InvNumLength;
				AcctDataType = _AcctDataType;
				IntranetName = _IntranetName;
				MasterSite = _MasterSite;
				HideParentGridColumns = _HideParentGridColumns;
				BackflushLot = _BackflushLot;
				BackflushSerial = _BackflushSerial;
				UniqueSerial = _UniqueSerial;
				EcnEst = _EcnEst;
				EcnJob = _EcnJob;
				EcnStd = _EcnStd;
				NegFlag = _NegFlag;
				SecureCtrlAcct = _SecureCtrlAcct;
				DefaultStartingToEnding = _DefaultStartingToEnding;
				MsgBusLogicalId = _MsgBusLogicalId;
				LanguageID = _LanguageID;
				UseAlternateAddressReportFormat = _UseAlternateAddressReportFormat;
				DocAutoAppId = _DocAutoAppId;
				DocAutoNameSpace = _DocAutoNameSpace;
				DocAutoRuleSet = _DocAutoRuleSet;
				ImplementCelergo = _ImplementCelergo;
				AutoDisplayButtonBlock = _AutoDisplayButtonBlock;
				EcnItem = _EcnItem;
				EcnItemManufacturer = _EcnItemManufacturer;
                CurPlant = _CurPlant;
				
				return (Severity, CurWhse, CurUserCode, UserID, Acct, UnitCode1, UnitCode2, UnitCode3, UnitCode4, Tax1_Enabled, Tax1_DefTaxCode, Tax1_TaxCodeLabel, Tax1_TaxIdLabel, Tax1_PromptOnLine, Tax1_TaxMode, TaxPromptForSystem1, TaxTwoExchRates, TaxNmbrOfSystems, Tax1_TaxAmtLabel, Tax1_TaxItemLabel, Tax1_ActiveForPurch, Tax1_TaxIdPromptLoc, Tax1_DefItemTaxCode, Tax1_DefMiscTaxCode, Tax1_DefFrtTaxCode, Tax1_TaxCodeDescLabel, Tax1_TaxItemDescLabel, Tax1_FrtCodeLabel, Tax1_FrtCodeDescLabel, Tax1_MiscCodeLabel, Tax1_MiscCodeDescLabel, Tax1_TaxAmtAccumLabel, Tax2_Enabled, Tax2_DefTaxCode, Tax2_TaxCodeLabel, Tax2_TaxIdLabel, Tax2_PromptOnLine, Tax2_TaxMode, TaxPromptForSystem2, Tax2_TaxAmtLabel, Tax2_TaxItemLabel, Tax2_ActiveForPurch, Tax2_TaxIdPromptLoc, Tax2_DefItemTaxCode, Tax2_DefMiscTaxCode, Tax2_DefFrtTaxCode, Tax2_TaxCodeDescLabel, Tax2_TaxItemDescLabel, Tax2_FrtCodeLabel, Tax2_FrtCodeDescLabel, Tax2_MiscCodeLabel, Tax2_MiscCodeDescLabel, Tax2_TaxAmtAccumLabel, ArAcct, ArUnitCode1, ArUnitCode2, ArUnitCode3, ArUnitCode4, Capitalize, MultiWhse, DoLength, SerialLength, LotLength, CurrCode, Addr1, Addr2, Addr3, Addr4, City, State, Zip, Country, Phone, Company, DefWhse, Site, EcReporting, QtyUnitFormat, QtyPerFormat, QtyCumuFormat, QtyTotlFormat, LotGenExp, RetentionDays, UniqueLot, SiteGroup, Infobar, AmtFormat, AmtTotFormat, CstPrcFormat, LotDataType, SerNumDataType, InvNumLength, AcctDataType, IntranetName, MasterSite, HideParentGridColumns, BackflushLot, BackflushSerial, UniqueSerial, EcnEst, EcnJob, EcnStd, NegFlag, SecureCtrlAcct, DefaultStartingToEnding, MsgBusLogicalId, LanguageID, UseAlternateAddressReportFormat, DocAutoAppId, DocAutoNameSpace, DocAutoRuleSet, ImplementCelergo, AutoDisplayButtonBlock, EcnItem, EcnItemManufacturer, CurPlant);
			}
		}
	}
}
