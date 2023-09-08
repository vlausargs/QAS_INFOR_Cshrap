//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ChangeOrder.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Finance;
using CSI.Admin;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.Codes;
using CSI.Logistics.Vendor;
using CSI.DataCollection;

namespace CSI.Reporting
{
	public class Rpt_ChangeOrder : IRpt_ChangeOrder
	{
		
		readonly ICSIRemoteMethodForReplicationTargets cSIRemoteMethodForReplicationTargets;
		readonly IDisplayVendorAddressWithPhoneLang iDisplayVendorAddressWithPhoneLang;
		readonly IDisplayOurAddressWithPhoneLang iDisplayOurAddressWithPhoneLang;
		readonly IGetDropShipToAddrWithPhoneLang iGetDropShipToAddrWithPhoneLang;
		readonly IDisplayAddressForReportFooter iDisplayAddressForReportFooter;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly IGetParmsSingleLineAddress iGetParmsSingleLineAddress;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IReleaseTmpTaxTables iReleaseTmpTaxTables;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly ITaxPriceSeparation iTaxPriceSeparation;
		readonly IAddProcessErrorLog iAddProcessErrorLog;
		readonly ITransactionFactory transactionFactory;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly IReportNotesExist iReportNotesExist;
		readonly IIsFeatureActive iIsFeatureActive;
		readonly IUseTmpTaxTables iUseTmpTaxTables;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IHighCharacter highCharacter;
		readonly ILowCharacter lowCharacter;
		readonly IHighAnyInt iHighAnyInt;
		readonly IUomConvQty iUomConvQty;
		readonly IStringUtil stringUtil;
		readonly ILowAnyInt iLowAnyInt;
		readonly IEuroInfo iEuroInfo;
		readonly ICurrCnvt iCurrCnvt;
		readonly IEuroPart iEuroPart;
		readonly IMathUtil mathUtil;
		readonly ITaxBase iTaxBase;
		readonly ITaxCalc iTaxCalc;
		readonly IGetumcf iGetumcf;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRpt_ChangeOrderCRUD iRpt_ChangeOrderCRUD;
		readonly IBankTransitNumLoader iBankTransitNumLoader;

		public Rpt_ChangeOrder(ICSIRemoteMethodForReplicationTargets cSIRemoteMethodForReplicationTargets,
			IDisplayVendorAddressWithPhoneLang iDisplayVendorAddressWithPhoneLang,
			IDisplayOurAddressWithPhoneLang iDisplayOurAddressWithPhoneLang,
			IGetDropShipToAddrWithPhoneLang iGetDropShipToAddrWithPhoneLang,
			IDisplayAddressForReportFooter iDisplayAddressForReportFooter,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			IGetParmsSingleLineAddress iGetParmsSingleLineAddress,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IReleaseTmpTaxTables iReleaseTmpTaxTables,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			ITaxPriceSeparation iTaxPriceSeparation,
			IAddProcessErrorLog iAddProcessErrorLog,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			IReportNotesExist iReportNotesExist,
			IIsFeatureActive iIsFeatureActive,
			IUseTmpTaxTables iUseTmpTaxTables,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IHighCharacter highCharacter,
			ILowCharacter lowCharacter,
			IHighAnyInt iHighAnyInt,
			IUomConvQty iUomConvQty,
			IStringUtil stringUtil,
			ILowAnyInt iLowAnyInt,
			IEuroInfo iEuroInfo,
			ICurrCnvt iCurrCnvt,
			IEuroPart iEuroPart,
			IMathUtil mathUtil,
			ITaxBase iTaxBase,
			ITaxCalc iTaxCalc,
			IGetumcf iGetumcf,
			ISQLValueComparerUtil sQLUtil,
			IRpt_ChangeOrderCRUD iRpt_ChangeOrderCRUD,
			IBankTransitNumLoader iBankTransitNumLoader)
		{
			this.cSIRemoteMethodForReplicationTargets = cSIRemoteMethodForReplicationTargets;
			this.iDisplayVendorAddressWithPhoneLang = iDisplayVendorAddressWithPhoneLang;
			this.iDisplayOurAddressWithPhoneLang = iDisplayOurAddressWithPhoneLang;
			this.iGetDropShipToAddrWithPhoneLang = iGetDropShipToAddrWithPhoneLang;
			this.iDisplayAddressForReportFooter = iDisplayAddressForReportFooter;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.iGetParmsSingleLineAddress = iGetParmsSingleLineAddress;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iReleaseTmpTaxTables = iReleaseTmpTaxTables;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.iTaxPriceSeparation = iTaxPriceSeparation;
			this.iAddProcessErrorLog = iAddProcessErrorLog;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.iReportNotesExist = iReportNotesExist;
			this.iIsFeatureActive = iIsFeatureActive;
			this.iUseTmpTaxTables = iUseTmpTaxTables;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.highCharacter = highCharacter;
			this.lowCharacter = lowCharacter;
			this.iHighAnyInt = iHighAnyInt;
			this.iUomConvQty = iUomConvQty;
			this.stringUtil = stringUtil;
			this.iLowAnyInt = iLowAnyInt;
			this.iEuroInfo = iEuroInfo;
			this.iCurrCnvt = iCurrCnvt;
			this.iEuroPart = iEuroPart;
			this.mathUtil = mathUtil;
			this.iTaxBase = iTaxBase;
			this.iTaxCalc = iTaxCalc;
			this.iGetumcf = iGetumcf;
			this.sQLUtil = sQLUtil;
			this.iRpt_ChangeOrderCRUD = iRpt_ChangeOrderCRUD;
			this.iBankTransitNumLoader = iBankTransitNumLoader;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_ChangeOrderSp (
			string pPoType = null,
			string pPoStat = null,
			string pPoitemStat = null,
			int? pRoundPlaces = null,
			string pPrintItemIV = null,
			int? pPrPoTxt = null,
			int? pPrPoBlnTxt = null,
			int? pPrPoLineTxt = null,
			string pPRPoChg = null,
			string pChgStat = null,
			int? pTransDomCurr = null,
			int? pPrintEuro = null,
			string pStartPoNum = null,
			string pEndPoNum = null,
			int? pStartPoLine = null,
			int? pEndPoLine = null,
			int? pStartPoRElease = null,
			int? pEndPoRelease = null,
			string pStartvendor = null,
			string pEndVendor = null,
			int? pShowExternal1 = null,
			int? pShowInternal1 = null,
			int? pPrintPOTable = null,
			int? pPrintpoitem = null,
			int? pPrintpo_bln = null,
			int? pPrintpochange = null,
			int? TaskId = null,
			int? pPrintManufacturerItem = 0,
			string ReviewPrint = null,
			string pSite = null,
			int? pPrintItemOverview = null,
			int? PrintDrawingNumber = 0,
			int? PrintDeliveryIncoTerms = 0,
			int? PrintEUCode = 0,
			int? PrintOriginCode = 0,
			int? PrintCommodityCode = 0,
			int? PrintHeaderOnAllPages = 0,
			int? PrintAuthorizationSignatures = 0)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			string FeatureInfoBar = null;
			string ProductName = null;
			string FeatureID1 = null;
			int? FeatureRS8927Active = null;
			int? FeatureRS9231Active = null;
			Guid? RptSessionID = null;
			Guid? PochangeRowpointer = null;
			string PochangeStat = null;
			int? PochangeNoteexistsflag = null;
			int? PochangeChgNum = null;
			DateTime? PochangeChgDate = null;
			Guid? PoRowpointer = null;
			Guid? PrevPoRowpointer = null;
			int? PoNoteexistsflag = null;
			string PoVendNum = null;
			string PoStat = null;
			string PoPoNum = null;
			string PoType = null;
			string PrevPoType = null;
			int? PrevPoPrintPrice = null;
			string PoShipAddr = null;
			string PoDropShipNo = null;
			int? PoDropSeq = null;
			decimal? PoExchRate = null;
			int? PoPrintPrice = null;
			string PoBuyer = null;
			string PoVendLcrNum = null;
			string PoFob = null;
			int? PoIncludeTaxInCost = null;
			Guid? PoitmchgRowpointer = null;
			string XVendaddrVendNum = null;
			Guid? PoblnchgRowpointer = null;
			int? DPoitemPoLine = null;
			int? DPoitemPoRelease = null;
			decimal? DPoitemUnitMatCostConv = null;
			decimal? DPoitemQtyOrderedConv = null;
			string TermsDescription = null;
			Guid? XPochangeRowpointer = null;
			string VendaddrFaxNum = null;
			string VendaddrFaxNumTmp = null;
			string ParmsSite = null;
			Guid? XVendorRowpointer = null;
			string XVendorVendNum = null;
			Guid? PoitemRowpointer = null;
			int? PoitemNoteexistsflag = null;
			string PoitemStat = null;
			string PoitemItem = null;
			string PoitemPoNum = null;
			int? PoitemPoLine = null;
			string PoitemVendItem = null;
			int? PoitemPoRelease = null;
			decimal? PoitemUnitMatCostConv = null;
			decimal? PoitemQtyOrderedConv = null;
			string PoitemUM = null;
			decimal? PoitemQtyReceived = null;
			string PoitemDrawingNbr = null;
			string PoitemRevision = null;
			DateTime? PoitemDueDate = null;
			int? PoitemExpedited = null;
			string PoitemDropShipNo = null;
			int? PoitemDropSeq = null;
			string PoitemShipAddr = null;
			string PoitemDescription = null;
			Guid? PoLangRowpointer = null;
			string PoLangPoText__1 = null;
			string PoLangPoText__2 = null;
			string PoLangPoText__3 = null;
			string ShipcodeDescription = null;
			int? PoparmsVendorRequired = null;
			string PoparmsPoText1 = null;
			string PoparmsPoText2 = null;
			string PoparmsPoText3 = null;
			int? CurrencyPlaces = null;
			string CurrencySymbol = null;
			string CurrencyDescription = null;
			string CurrencyDescriptionTmp = null;
			string CurrparmsCurrCode = null;
			Guid? APoitemRowpointer = null;
			Guid? PoBlnRowpointer = null;
			string PoBlnVendItem = null;
			string PoBlnStat = null;
			string PoBlnDrawingNbr = null;
			string PoBlnRevision = null;
			DateTime? PoBlnEffDate = null;
			DateTime? PoBlnExpDate = null;
			int? PoBlnNoteexistsflag = null;
			Guid? XPoBlnRowpointer = null;
			string PoCurrCode = null;
			string VendorLangCode = null;
			string VendorVendRemit = null;
			int? ECurrencyPlaces = null;
			string ECurrencySymbol = null;
			int? VendorPrintVATonPO = null;
			int? PrintVATSummary = null;
			decimal? PAmount = null;
			string PoitemTaxCode1 = null;
			string PoitemTaxCode2 = null;
			string PoTaxCode1 = null;
			string PoTaxCode2 = null;
			int? ReleaseTmpTaxTables = null;
			int? TaxSystem1_ActiveForPurch = null;
			int? TaxSystem2_ActiveForPurch = null;
			string TaxCodeLabel = null;
			string TaxCode2Label = null;
			string TaxAmtLabel = null;
			string TaxAmt2Label = null;
			decimal? TaxAmount1 = null;
			decimal? TaxAmount2 = null;
			decimal? xAmount = null;
			int? PrintCompanyName = null;
			int? poitmchgNotAvail = null;
			string PoitemManufacturerId = null;
			string PoitemManufacturerItem = null;
			string PoBlnManufacturerId = null;
			string PoBlnManufacturerItem = null;
			string UserNamesUserDesc = null;
			string Infobar = null;
			int? TRptNum = null;
			decimal? ConvFactor = null;
			string Area = null;
			DateTime? RateDate = null;
			decimal? TRate = null;
			decimal? TStd_De = null;
			int? TStd_Lo = null;
			decimal? TFudge = null;
			int? TNumLines = null;
			decimal? TForSum = null;
			string TRevision = null;
			string TDrawingNbr = null;
			DateTime? TEffDate = null;
			DateTime? TExpDate = null;
			decimal? TEuroTotal = null;
			string TESymbol = null;
			int? TEuroUser = null;
			int? TEuroExists = null;
			int? TBaseEuro = null;
			string TEuroCurr = null;
			decimal? TTot = null;
			string TVendRemit = null;
			string TSymbol = null;
			string TAddr0 = null;
			string TAddr1 = null;
			string TAddr2 = null;
			string TAddr3 = null;
			string TAddr4 = null;
			string TPoText1 = null;
			string TPoText2 = null;
			string TPoText3 = null;
			string TShipcodeDesc = null;
			string TShipcodeDescTmp = null;
			string TTermsDesc = null;
			string TTermsDescTmp = null;
			string TVendItem = null;
			decimal? TQty = null;
			decimal? TcAmtPrice = null;
			decimal? TcCprUnitMatCostConv = null;
			int? TChangedPobln = null;
			decimal? TRoundFactor = null;
			int? TFirstPOItem = null;
			int? TPONoteExits = null;
			int? TPONoteExitsTmp = null;
			int? TPOBlnNoteExits = null;
			int? TPOLineNoteExits = null;
			int? TPOChgNoteExits = null;
			string TStartVendor = null;
			string TEndVendor = null;
			string poblndescription = null;
			decimal? VatAmt = null;
			decimal? VatAmt2 = null;
			decimal? TSalesTax1 = null;
			decimal? TSalesTax2 = null;
			decimal? TaxAmount = null;
			decimal? CostWithoutTax = null;
			string LowCharValue = null;
			string HighCharValue = null;
			string MessageLanguage = null;
			string ActionExpression = null;
			string TManufacturerId = null;
			string TManufacturerItem = null;
			int? UseAlternateAddressReportFormat = null;
			string ItemOverview = null;
			string PoVendOrder = null;
			string PoItemDeliveryIncoTerm = null;
			string DeltermDescription = null;
			string PoItemECCode = null;
			string PoItemOriginCode = null;
			string PoItemCommodityCode = null;
			string ParmsURL = null;
			string CurrCode = null;
			string OfficeAddrFooter = null;
			string OfficeEmailAddrFooter = null;
			string BankName = null;
			string BankTransitNum = null;
			string Account = null;
			ICollectionLoadResponse po_crsLoadResponseForCursor = null;
			int po_crs_CursorFetch_Status = -1;
			int po_crs_CursorCounter = -1;
			ICollectionLoadResponse d_poitem_crsLoadResponseForCursor = null;
			int d_poitem_crs_CursorFetch_Status = -1;
			int d_poitem_crs_CursorCounter = -1;
			ICollectionLoadResponse poitem_crsLoadResponseForCursor = null;
			int poitem_crs_CursorFetch_Status = -1;
			int poitem_crs_CursorCounter = -1;
			if (this.iRpt_ChangeOrderCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRpt_ChangeOrderCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iRpt_ChangeOrderCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iRpt_ChangeOrderCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRpt_ChangeOrderCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRpt_ChangeOrderCRUD.AltExtGen_Rpt_ChangeOrderSp (ALTGEN_SpName,
						pPoType,
						pPoStat,
						pPoitemStat,
						pRoundPlaces,
						pPrintItemIV,
						pPrPoTxt,
						pPrPoBlnTxt,
						pPrPoLineTxt,
						pPRPoChg,
						pChgStat,
						pTransDomCurr,
						pPrintEuro,
						pStartPoNum,
						pEndPoNum,
						pStartPoLine,
						pEndPoLine,
						pStartPoRElease,
						pEndPoRelease,
						pStartvendor,
						pEndVendor,
						pShowExternal1,
						pShowInternal1,
						pPrintPOTable,
						pPrintpoitem,
						pPrintpo_bln,
						pPrintpochange,
						TaskId,
						pPrintManufacturerItem,
						ReviewPrint,
						pSite,
						pPrintItemOverview,
						PrintDrawingNumber,
						PrintDeliveryIncoTerms,
						PrintEUCode,
						PrintOriginCode,
						PrintCommodityCode,
						PrintHeaderOnAllPages,
						PrintAuthorizationSignatures);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRpt_ChangeOrderCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRpt_ChangeOrderCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_ChangeOrderSp") != null)
			{
				var EXTGEN = this.iRpt_ChangeOrderCRUD.AltExtGen_Rpt_ChangeOrderSp("dbo.EXTGEN_Rpt_ChangeOrderSp",
					pPoType,
					pPoStat,
					pPoitemStat,
					pRoundPlaces,
					pPrintItemIV,
					pPrPoTxt,
					pPrPoBlnTxt,
					pPrPoLineTxt,
					pPRPoChg,
					pChgStat,
					pTransDomCurr,
					pPrintEuro,
					pStartPoNum,
					pEndPoNum,
					pStartPoLine,
					pEndPoLine,
					pStartPoRElease,
					pEndPoRelease,
					pStartvendor,
					pEndVendor,
					pShowExternal1,
					pShowInternal1,
					pPrintPOTable,
					pPrintpoitem,
					pPrintpo_bln,
					pPrintpochange,
					TaskId,
					pPrintManufacturerItem,
					ReviewPrint,
					pSite,
					pPrintItemOverview,
					PrintDrawingNumber,
					PrintDeliveryIncoTerms,
					PrintEUCode,
					PrintOriginCode,
					PrintCommodityCode,
					PrintHeaderOnAllPages,
					PrintAuthorizationSignatures);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			Severity = 0;
			ProductName = "CSI";
			FeatureID1 = "RS8927";
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: IsFeatureActiveSp
			var IsFeatureActive = this.iIsFeatureActive.IsFeatureActiveSp(
				ProductName: ProductName,
				FeatureID: FeatureID1,
				FeatureActive: FeatureRS8927Active,
				InfoBar: FeatureInfoBar);
			Severity = IsFeatureActive.ReturnCode;
			FeatureRS8927Active = IsFeatureActive.FeatureActive;
			FeatureInfoBar = IsFeatureActive.InfoBar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Data, Severity);
			}

			Severity = 0;
			ProductName = "CSI";
			FeatureID1 = "RS9231";

			IsFeatureActive = this.iIsFeatureActive.IsFeatureActiveSp(
				ProductName: ProductName,
				FeatureID: FeatureID1,
				FeatureActive: FeatureRS9231Active,
				InfoBar: FeatureInfoBar);
			Severity = IsFeatureActive.ReturnCode;
			FeatureRS9231Active = IsFeatureActive.FeatureActive;
			FeatureInfoBar = IsFeatureActive.InfoBar;

			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Data, Severity);
			}

			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(
				ContextName: "Rpt_ChangeOrderSp",
				SessionID: RptSessionID,
				Site: pSite);
			RptSessionID = InitSessionContext.SessionID;
			
			#endregion ExecuteMethodCall
			
			this.transactionFactory.BeginTransaction("");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("ChangeOrderReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
				
			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
				
			}
			pPoType = stringUtil.IsNull(
				pPoType,
				"RB");
			pPoStat = stringUtil.IsNull(
				pPoStat,
				"POC");
			pPoitemStat = stringUtil.IsNull(
				pPoitemStat,
				"POC");
			pRoundPlaces = (int?)(stringUtil.IsNull(
				pRoundPlaces,
				3));
			pPrintItemIV = stringUtil.IsNull(
				pPrintItemIV,
				"IV");
			pPRPoChg = stringUtil.IsNull(
				pPRPoChg,
				"C");
			pChgStat = stringUtil.IsNull(
				pChgStat,
				"F");
			pTransDomCurr = (int?)(stringUtil.IsNull(
				pTransDomCurr,
				0));
			pPrintEuro = (int?)(stringUtil.IsNull(
				pPrintEuro,
				0));
			pShowExternal1 = (int?)(stringUtil.IsNull(
				pShowExternal1,
				1));
			pShowInternal1 = (int?)(stringUtil.IsNull(
				pShowInternal1,
				1));
			pPrintPOTable = (int?)(stringUtil.IsNull(
				pPrintPOTable,
				1));
			pPrintpoitem = (int?)(stringUtil.IsNull(
				pPrintpoitem,
				1));
			pPrintpo_bln = (int?)(stringUtil.IsNull(
				pPrintpo_bln,
				1));
			pPrintpochange = (int?)(stringUtil.IsNull(
				pPrintpochange,
				1));
			ReviewPrint = stringUtil.IsNull(
				ReviewPrint,
				"R");
			pPrintManufacturerItem = (int?)(stringUtil.IsNull(
				pPrintManufacturerItem,
				0));
			pPrintItemOverview = (int?)(stringUtil.IsNull(
				pPrintItemOverview,
				0));
			ActionExpression = "Replace";
			TaxSystem1_ActiveForPurch = 0;
			(TaxCodeLabel, TaxAmtLabel, TaxSystem1_ActiveForPurch, rowCount) = this.iRpt_ChangeOrderCRUD.Tax_SystemLoad(TaxSystem1_ActiveForPurch, TaxCodeLabel, TaxAmtLabel);
			TaxSystem2_ActiveForPurch = 0;
			(TaxCode2Label, TaxAmt2Label, TaxSystem2_ActiveForPurch, rowCount) = this.iRpt_ChangeOrderCRUD.Tax_System1Load(TaxSystem2_ActiveForPurch, TaxCode2Label, TaxAmt2Label);
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: UseTmpTaxTablesSp
			var UseTmpTaxTables = this.iUseTmpTaxTables.UseTmpTaxTablesSp(
				PSessionId: RptSessionID,
				LocalInit: ReleaseTmpTaxTables,
				Infobar: Infobar);
			Severity = UseTmpTaxTables.ReturnCode;
			ReleaseTmpTaxTables = UseTmpTaxTables.LocalInit;
			Infobar = UseTmpTaxTables.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				goto END_OF_PROG;
				
			}
			LowCharValue = convertToUtil.ToString(lowCharacter.LowCharacterFn());
			HighCharValue = convertToUtil.ToString(highCharacter.HighCharacterFn());
			Severity = 0;
			TEuroUser = 0;
			TEuroExists = 0;
			TBaseEuro = 0;
			TTot = 0;
			TQty = 0;
			TcCprUnitMatCostConv = 0;
			TChangedPobln = 0;
			TRoundFactor = 0;
			Area = "P";
			poblndescription = null;
			PoIncludeTaxInCost = 0;
			poitmchgNotAvail = 0;
			PrintVATSummary = 0;
			VatAmt = 0;
			VatAmt2 = 0;
			pStartPoNum = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"PoNumType",
					pStartPoNum),
				LowCharValue);
			pEndPoNum = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"PoNumType",
					pEndPoNum),
				HighCharValue);
			pStartPoLine = convertToUtil.ToInt32(stringUtil.IsNull(
				pStartPoLine,
				this.iLowAnyInt.LowAnyIntFn("PoLineType")));
			pEndPoLine = convertToUtil.ToInt32(stringUtil.IsNull(
				pEndPoLine,
				this.iHighAnyInt.HighAnyIntFn("PoLineType")));
			pStartPoRElease = convertToUtil.ToInt32(stringUtil.IsNull(
				pStartPoRElease,
				this.iLowAnyInt.LowAnyIntFn("PoReleaseType")));
			pEndPoRelease = convertToUtil.ToInt32(stringUtil.IsNull(
				pEndPoRelease,
				this.iHighAnyInt.HighAnyIntFn("PoReleaseType")));
			TStartVendor = pStartvendor;
			TEndVendor = pEndVendor;
			pStartvendor = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"VendNumType",
					pStartvendor),
				LowCharValue);
			pEndVendor = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"VendNumType",
					pEndVendor),
				HighCharValue);
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @ReportSet TABLE (
				    seq                    INT                IDENTITY,
				    rpt_seq                INT               ,
				    po_num                 PoNumType         ,
				    chg_num                ChgNumType        ,
				    chg_date               DateType          ,
				    chg_label_1            NVARCHAR (20)     ,
				    chg_label_2            NVARCHAR (20)     ,
				    po_type                PoTypeType        ,
				    print_price            ListYesNoType     ,
				    po_date                DateType          ,
				    po_line                SMALLINT          ,
				    Po_release             SMALLINT          ,
				    vend_num               VendNumType       ,
				    addr_0                 LongAddress       ,
				    addr_1                 LongAddress       ,
				    addr_2                 LongAddress       ,
				    addr_3                 LongAddress       ,
				    addr_4                 LongAddress       ,
				    buyer                  UsernameType      ,
				    vend_lcr_num           VendLcrNumType    ,
				    fob                    FOBType           ,
				    shipcode_desc          DescriptionType   ,
				    terms_desc             DescriptionType   ,
				    dropship_num           DropShipNoType    ,
				    dropship_seq           DropSeqType       ,
				    fax_num                PhoneType         ,
				    item                   NVARCHAR (30)     ,
				    vend_item              NVARCHAR (30)     ,
				    unit_mat_cost          CostPrcType       ,
				    qty_ordered            QtyUnitNoNegType  ,
				    qty_due                DECIMAL (38, 10)  ,
				    revision               NVARCHAR (8)      ,
				    drawing_nbr            NVARCHAR (25)     ,
				    eff_date               DateType          ,
				    exp_date               DateType          ,
				    amt_ext_price          AmountType        ,
				    due_date               DateType          ,
				    expedited              TINYINT           ,
				    item_Desc              NVARCHAR (40)     ,
				    item_u_m               NVARCHAR (3)      ,
				    po_text_1              ReportTxtType     ,
				    po_text_2              ReportTxtType     ,
				    po_text_3              ReportTxtType     ,
				    std_symbol             CurrSymbolType    ,
				    po_amount              GenericDecimalType,
				    eur_symbol             CurrSymbolType    ,
				    euro_amount            AmountType        ,
				    curr_desc              DescriptionType   ,
				    LcrNumLabel            NVARCHAR (20)     ,
				    FaxLabel               NVARCHAR (20)     ,
				    DrawingLabel           NVARCHAR (20)     ,
				    RevisionLabel          NVARCHAR (20)     ,
				    EffectiveDatelabel     NVARCHAR (20)     ,
				    Expirationdatelabel    NVARCHAR (20)     ,
				    RelText                NVARCHAR (20)     ,
				    DropShipToLabel        NVARCHAR (20)     ,
				    CurrencyLabel          NVARCHAR (20)     ,
				    PONotes                ListYesNoType     ,
				    POBlnNotes             ListYesNoType     ,
				    POLineNotes            ListYesNoType     ,
				    POChgNotes             ListYesNoType     ,
				    porow                  RowPointerType    ,
				    poblnrow               RowPointerType    ,
				    poitemrow              RowPointerType    ,
				    pochgrow               RowPointerType    ,
				    poblndescription       NVARCHAR (40)     ,
				    VatAmt                 AmountType        ,
				    VatAmt2                AmountType        ,
				    tax_code1              NVARCHAR (12)     ,
				    tax_code2              NVARCHAR (12)     ,
				    print_vat_on_po        ListYesNoType     ,
				    tax_code_label         TaxCodeLabelType  ,
				    tax_code2_label        TaxCodeLabelType  ,
				    tax_amt_label          TaxCodeLabelType  ,
				    tax_amt2_label         TaxCodeLabelType  ,
				    Cost_without_tax       AmountType        ,
				    Include_tax_in_cost    ListYesNoType     ,
				    Tax_amt                AmountType        ,
				    PrintVATSummary        ListYesNoType     ,
				    manufacturer_id        NVARCHAR (7)      ,
				    manufacturer_item      NVARCHAR (30)     ,
				    item_overview          NVARCHAR (MAX)    ,
				    vend_order             VendOrderType     ,
				    delterm                DeltermType       ,
				    description            DescriptionType   ,
				    ec_code                EcCodeType        ,
				    origin                 EcCodeType        ,
				    comm_code              CommodityCodeType ,
				    url                    URLType           ,
				    curr_code              CurrCodeType      ,
				    AddressforReportFooter LongAddress       ,
				    email_addr             EmailType         ,
				    bank_name              NameType          ,
				    bank_transit_num       BankTransitNumType,
				    account                BankAccountType    PRIMARY KEY (seq),
					ven_bank_transit_num   BankTransitNumType,
					override_bank_transit_num ListYesNoType);
				SELECT * into #tv_ReportSet from @ReportSet
				ALTER TABLE #tv_ReportSet ADD PRIMARY KEY (seq)");
			(ParmsSite, PrintCompanyName, ParmsURL, rowCount) = this.iRpt_ChangeOrderCRUD.ParmsLoad(ParmsSite, PrintCompanyName, ParmsURL);
			PrintCompanyName = (int?)(stringUtil.IsNull(
				PrintCompanyName,
				0));
			if (sQLUtil.SQLEqual(Severity, 0) == true)
			{
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: EuroInfoSp
				var EuroInfo = this.iEuroInfo.EuroInfoSp(
					DispMsg: 0,
					PEuroUser: TEuroUser,
					PEuroExists: TEuroExists,
					PBaseEuro: TBaseEuro,
					PEuroCurr: TEuroCurr,
					InfoBar: Infobar,
					Site: ParmsSite);
				Severity = EuroInfo.ReturnCode;
				TEuroUser = EuroInfo.PEuroUser;
				TEuroExists = EuroInfo.PEuroExists;
				TBaseEuro = EuroInfo.PBaseEuro;
				TEuroCurr = EuroInfo.PEuroCurr;
				Infobar = EuroInfo.InfoBar;
				
				#endregion ExecuteMethodCall
				
			}
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				goto END_OF_PROG;
				
			}
			if (sQLUtil.SQLEqual(TEuroExists, 1) == true)
			{
				(ECurrencyPlaces, ECurrencySymbol, rowCount) = this.iRpt_ChangeOrderCRUD.Currencyase_CurrencyLoad(TEuroCurr, ECurrencyPlaces, ECurrencySymbol);
				
			}
			(CurrparmsCurrCode, rowCount) = this.iRpt_ChangeOrderCRUD.CurrparmsLoad(CurrparmsCurrCode);
			(PoparmsVendorRequired, PoparmsPoText1, PoparmsPoText2, PoparmsPoText3, rowCount) = this.iRpt_ChangeOrderCRUD.PoparmsLoad(PoparmsVendorRequired, PoparmsPoText1, PoparmsPoText2, PoparmsPoText3);
			(OfficeEmailAddrFooter, rowCount) = this.iRpt_ChangeOrderCRUD.ArparmsLoad(OfficeEmailAddrFooter);
			OfficeAddrFooter = convertToUtil.ToString(this.iDisplayAddressForReportFooter.DisplayAddressForReportFooterFn());
			#region Cursor Statement
			po_crsLoadResponseForCursor = this.iRpt_ChangeOrderCRUD.PoSelect(pPoType, pPoStat, pStartPoNum, pEndPoNum, pStartvendor, pEndVendor, TStartVendor, TEndVendor, pStartPoRElease, pEndPoRelease, pStartPoLine, pPoitemStat, pEndPoLine, pTransDomCurr, pShowExternal1, pShowInternal1, pPrintPOTable, CurrparmsCurrCode);
			po_crs_CursorFetch_Status = po_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			po_crs_CursorCounter = -1;
			
			#endregion Cursor Statement
			while (sQLUtil.SQLBool(sQLUtil.SQLEqual(1, 1)))
			{
				po_crs_CursorCounter++;
				if(po_crsLoadResponseForCursor.Items.Count > po_crs_CursorCounter)
				{
					PoRowpointer = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<Guid?>(0);
					PoNoteexistsflag = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<int?>(1);
					PoVendNum = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(2);
					PoStat = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(3);
					PoPoNum = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(4);
					PoType = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(5);
					PoShipAddr = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(6);
					PoDropShipNo = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(7);
					PoDropSeq = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<int?>(8);
					PoExchRate = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<decimal?>(9);
					PoPrintPrice = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<int?>(10);
					PoBuyer = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(11);
					PoVendLcrNum = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(12);
					PoFob = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(13);
					PoIncludeTaxInCost = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<int?>(14);
					APoitemRowpointer = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<Guid?>(15);
					PoCurrCode = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(16);
					VendorLangCode = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(17);
					VendorVendRemit = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(18);
					TermsDescription = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(19);
					ShipcodeDescription = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(20);
					CurrencyPlaces = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<int?>(21);
					CurrencySymbol = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(22);
					CurrencyDescriptionTmp = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(23);
					PoLangRowpointer = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<Guid?>(24);
					PoLangPoText__1 = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(25);
					PoLangPoText__2 = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(26);
					PoLangPoText__3 = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(27);
					VendaddrFaxNumTmp = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(28);
					TPONoteExitsTmp = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<int?>(29);
					TShipcodeDescTmp = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(30);
					TTermsDescTmp = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(31);
					UserNamesUserDesc = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(32);
					PoVendOrder = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(33);
					CurrCode = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(34);
					BankName = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(35);
					BankTransitNum = iBankTransitNumLoader.GetBankTransitNumber(FeatureRS9231Active, po_crsLoadResponseForCursor, po_crs_CursorCounter);
					Account = po_crsLoadResponseForCursor.Items[po_crs_CursorCounter].GetValue<string>(39);
				}
				po_crs_CursorFetch_Status = (po_crs_CursorCounter == po_crsLoadResponseForCursor.Items.Count ? -1 : 0);
				
				if (sQLUtil.SQLNotEqual(po_crs_CursorFetch_Status, 0) == true)
				{
					
					break;
					
				}
				MessageLanguage = null;
				(MessageLanguage, rowCount) = this.iRpt_ChangeOrderCRUD.LanguageidsLoad(VendorLangCode, MessageLanguage);
				MessageLanguage = stringUtil.IsNull(
					MessageLanguage,
					"1033");
				if (sQLUtil.SQLEqual(FeatureRS8927Active, 1) == true)
				{
					(UseAlternateAddressReportFormat, rowCount) = this.iRpt_ChangeOrderCRUD.CountryLoad(UseAlternateAddressReportFormat);
					UseAlternateAddressReportFormat = (int?)(stringUtil.IsNull(
						UseAlternateAddressReportFormat,
						0));
					
				}
				else
				{
					(UseAlternateAddressReportFormat, rowCount) = this.iRpt_ChangeOrderCRUD.Parms1Load(UseAlternateAddressReportFormat);
					
				}
				if (sQLUtil.SQLEqual(PrintCompanyName, 1) == true)
				{
					if (sQLUtil.SQLEqual(UseAlternateAddressReportFormat, 0) == true)
					{
						TAddr0 = this.iDisplayOurAddressWithPhoneLang.DisplayOurAddressWithPhoneLangSp(MessageLanguage);
						
					}
					else
					{
						TAddr0 = this.iGetParmsSingleLineAddress.GetParmsSingleLineAddressSp();
						
					}
					
				}
				else
				{
					TAddr0 = null;
					
				}
				
				var execResult = cSIRemoteMethodForReplicationTargets.CSIRemoteMethodForReplicationTargetsSp(
				IdoName: "SL.ESBSLPos"
				, MethodName: "TriggerPurchaseOrderSyncSp"
				, Infobar: Infobar
				, RefRowPointer: null
				, PoPoNum
				, ActionExpression);
				Severity = execResult.ReturnCode;
				TTot = 0;
				TEuroTotal = 0;
				PrevPoType = PoType;
				PrevPoPrintPrice = PoPrintPrice;
				TPONoteExits = TPONoteExitsTmp;
				PrevPoRowpointer = PoRowpointer;
				if (PoVendNum== null && sQLUtil.SQLEqual(PoStat, "P") == true && sQLUtil.SQLEqual(PoparmsVendorRequired, 1) == true)
				{
					
					continue;
					
				}
				if (APoitemRowpointer== null)
				{
					
					continue;
					
				}
				PochangeRowpointer = null;
				(PochangeRowpointer, PochangeStat, PochangeNoteexistsflag, PochangeChgNum, PochangeChgDate, rowCount) = this.iRpt_ChangeOrderCRUD.PochangeLoad(PoPoNum, PochangeRowpointer, PochangeStat, PochangeNoteexistsflag, PochangeChgNum, PochangeChgDate);
				if (sQLUtil.SQLBool((sQLUtil.SQLOr(sQLUtil.SQLOr(sQLUtil.SQLNot((PochangeRowpointer!= null)), sQLUtil.SQLEqual(PochangeStat, "O")), sQLUtil.SQLEqual(stringUtil.CharIndex(
								PochangeStat,
								pChgStat), 0)))))
				{
					
					continue;
					
				}
				TPOChgNoteExits = convertToUtil.ToInt32(this.iReportNotesExist.ReportNotesExistFn(
					"pochange",
					PochangeRowpointer,
					pShowInternal1,
					pShowExternal1,
					PochangeNoteexistsflag));
				TShipcodeDesc = TShipcodeDescTmp;
				TTermsDesc = TTermsDescTmp;
				VendaddrFaxNum = VendaddrFaxNumTmp;
				TAddr1 = this.iDisplayVendorAddressWithPhoneLang.DisplayVendorAddressWithPhoneLangSp(
					PoVendNum,
					MessageLanguage,
					null);
				if (sQLUtil.SQLEqual(Severity, 0) == true)
				{
					
					#region CRUD ExecuteMethodCall
					
					//Please Generate the bounce for this stored procedure: GetDropShipToAddrWithPhoneLangSp
					var GetDropShipToAddrWithPhoneLang = this.iGetDropShipToAddrWithPhoneLang.GetDropShipToAddrWithPhoneLangSp(
						ShipTo: PoShipAddr,
						DropShipNo: PoDropShipNo,
						DropSeqNo: PoDropSeq,
						SiteRef: ParmsSite,
						MessageLanguage: MessageLanguage,
						ShipToAddress: TAddr2);
					Severity = GetDropShipToAddrWithPhoneLang.ReturnCode;
					TAddr2 = GetDropShipToAddrWithPhoneLang.ShipToAddress;
					
					#endregion ExecuteMethodCall
					
				}
				TAddr4 = "";
				if (VendorVendRemit!= null)
				{
					TVendRemit = VendorVendRemit;
					XVendorRowpointer = null;
					(XVendorRowpointer, XVendorVendNum, rowCount) = this.iRpt_ChangeOrderCRUD.Vendorasx_VendorLoad(TVendRemit, XVendorRowpointer, XVendorVendNum);
					if ((XVendorRowpointer!= null))
					{
						(XVendaddrVendNum, rowCount) = this.iRpt_ChangeOrderCRUD.Vendaddrasx_VendaddrLoad(XVendorVendNum, XVendaddrVendNum);
						TAddr4 = this.iDisplayVendorAddressWithPhoneLang.DisplayVendorAddressWithPhoneLangSp(
							XVendaddrVendNum,
							MessageLanguage,
							null);
						
					}
					
				}
				TRoundFactor = (decimal?)(1 / mathUtil.Pow<decimal?>(10, CurrencyPlaces));
				TEuroTotal = 0;
				if (sQLUtil.SQLEqual(pTransDomCurr, 1) == true)
				{
					#region Cursor Statement
					d_poitem_crsLoadResponseForCursor = this.iRpt_ChangeOrderCRUD.PoitemSelect(pPoitemStat, pStartPoLine, pEndPoLine, pStartPoRElease, pEndPoRelease, PoPoNum, PoType, pShowExternal1, pShowInternal1, pPrintPOTable);
					d_poitem_crs_CursorFetch_Status = d_poitem_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
					d_poitem_crs_CursorCounter = -1;
					
					#endregion Cursor Statement
					while (sQLUtil.SQLEqual(1, 1) == true)
					{
						d_poitem_crs_CursorCounter++;
						if(d_poitem_crsLoadResponseForCursor.Items.Count > d_poitem_crs_CursorCounter)
						{
							DPoitemPoLine = d_poitem_crsLoadResponseForCursor.Items[d_poitem_crs_CursorCounter].GetValue<int?>(0);
							DPoitemPoRelease = d_poitem_crsLoadResponseForCursor.Items[d_poitem_crs_CursorCounter].GetValue<int?>(1);
							DPoitemUnitMatCostConv = d_poitem_crsLoadResponseForCursor.Items[d_poitem_crs_CursorCounter].GetValue<decimal?>(2);
							DPoitemQtyOrderedConv = d_poitem_crsLoadResponseForCursor.Items[d_poitem_crs_CursorCounter].GetValue<decimal?>(3);
						}
						d_poitem_crs_CursorFetch_Status = (d_poitem_crs_CursorCounter == d_poitem_crsLoadResponseForCursor.Items.Count ? -1 : 0);
						
						if (sQLUtil.SQLNotEqual(d_poitem_crs_CursorFetch_Status, 0) == true)
						{
							
							break;
							
						}
						if (sQLUtil.SQLEqual(pPRPoChg, "C") == true)
						{
							PoitmchgRowpointer = null;
							(PoitmchgRowpointer, rowCount) = this.iRpt_ChangeOrderCRUD.PoitmchgLoad(PochangeChgNum, PoPoNum, DPoitemPoLine, DPoitemPoRelease, PoitmchgRowpointer);
							if (PoitmchgRowpointer== null)
							{
								
								continue;
								
							}
							
						}
						TcAmtPrice = (decimal?)(mathUtil.Round<decimal?>(DPoitemUnitMatCostConv * DPoitemQtyOrderedConv, CurrencyPlaces));
						TRate = PoExchRate;
						if (sQLUtil.SQLEqual(Severity, 0) == true)
						{
							
							#region CRUD ExecuteMethodCall
							
							//Please Generate the bounce for this stored procedure: CurrCnvtSp
							var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
								CurrCode: PoCurrCode,
								FromDomestic: 0,
								UseBuyRate: 1,
								RoundResult: 1,
								Date: RateDate,
								RoundPlaces: CurrencyPlaces,
								UseCustomsAndExciseRates: 0,
								ForceRate: null,
								FindTTFixed: null,
								TRate: TRate,
								Infobar: Infobar,
								Amount1: TcAmtPrice,
								Result1: TStd_De,
								Site: ParmsSite,
								DomCurrCode: CurrparmsCurrCode);
							Severity = CurrCnvt.ReturnCode;
							TRate = CurrCnvt.TRate;
							Infobar = CurrCnvt.Infobar;
							TStd_De = CurrCnvt.Result1;
							
							#endregion ExecuteMethodCall
							
						}
						if (sQLUtil.SQLNotEqual(Severity, 0) == true)
						{
							goto END_OF_PROG;
							
						}
						TForSum = (decimal?)(TForSum + TcAmtPrice);
						TFudge = (decimal?)(TFudge - TStd_De);
						TNumLines = (int?)(TNumLines + 1);
						
					}
					//Deallocate Cursor d_poitem_crs
					if (sQLUtil.SQLEqual(Severity, 0) == true)
					{
						
						#region CRUD ExecuteMethodCall
						
						//Please Generate the bounce for this stored procedure: CurrCnvtSp
						var CurrCnvt1 = this.iCurrCnvt.CurrCnvtSp(
							CurrCode: PoCurrCode,
							FromDomestic: 0,
							UseBuyRate: 1,
							RoundResult: 1,
							Date: RateDate,
							RoundPlaces: CurrencyPlaces,
							UseCustomsAndExciseRates: 0,
							ForceRate: null,
							FindTTFixed: null,
							TRate: TRate,
							Infobar: Infobar,
							Amount1: TForSum,
							Result1: TStd_De,
							Site: ParmsSite,
							DomCurrCode: CurrparmsCurrCode);
						Severity = CurrCnvt1.ReturnCode;
						TRate = CurrCnvt1.TRate;
						Infobar = CurrCnvt1.Infobar;
						TStd_De = CurrCnvt1.Result1;
						
						#endregion ExecuteMethodCall
						
					}
					if (sQLUtil.SQLNotEqual(Severity, 0) == true)
					{
						goto END_OF_PROG;
						
					}
					TFudge = (decimal?)(TFudge + TStd_De);
					
				}
				TFirstPOItem = 1;
				#region Cursor Statement
				poitem_crsLoadResponseForCursor = this.iRpt_ChangeOrderCRUD.Poitem1Select(pPoitemStat, pStartPoLine, pEndPoLine, pStartPoRElease, pEndPoRelease, PoPoNum, PoType, pShowExternal1, pShowInternal1, pPrintPOTable, pPrintpoitem);
				poitem_crs_CursorFetch_Status = poitem_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				poitem_crs_CursorCounter = -1;
				
				#endregion Cursor Statement
				while (sQLUtil.SQLBool(sQLUtil.SQLEqual(1, 1)))
				{
					poitem_crs_CursorCounter++;
					if(poitem_crsLoadResponseForCursor.Items.Count > poitem_crs_CursorCounter)
					{
						PoitemRowpointer = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<Guid?>(0);
						PoitemNoteexistsflag = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<int?>(1);
						PoitemStat = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(2);
						PoitemItem = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(3);
						PoitemPoNum = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(4);
						PoitemPoLine = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<int?>(5);
						PoitemVendItem = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(6);
						PoitemPoRelease = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<int?>(7);
						PoitemUnitMatCostConv = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<decimal?>(8);
						PoitemQtyOrderedConv = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<decimal?>(9);
						PoitemUM = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(10);
						PoitemQtyReceived = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<decimal?>(11);
						PoitemDrawingNbr = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(12);
						PoitemRevision = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(13);
						PoitemDueDate = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<DateTime?>(14);
						PoitemTaxCode1 = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(15);
						PoitemTaxCode2 = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(16);
						PoTaxCode1 = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(17);
						PoTaxCode2 = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(18);
						VendorPrintVATonPO = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<int?>(19);
						PoitemExpedited = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<int?>(20);
						PoitemDropShipNo = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(21);
						PoitemDropSeq = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<int?>(22);
						PoitemShipAddr = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(23);
						PoitemDescription = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(24);
						PoitemManufacturerId = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(25);
						PoitemManufacturerItem = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(26);
						TPOLineNoteExits = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<int?>(27);
						ItemOverview = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(28);
						PoItemDeliveryIncoTerm = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(29);
						DeltermDescription = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(30);
						PoItemECCode = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(31);
						PoItemOriginCode = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(32);
						PoItemCommodityCode = poitem_crsLoadResponseForCursor.Items[poitem_crs_CursorCounter].GetValue<string>(33);
					}
					poitem_crs_CursorFetch_Status = (poitem_crs_CursorCounter == poitem_crsLoadResponseForCursor.Items.Count ? -1 : 0);
					
					if (sQLUtil.SQLNotEqual(poitem_crs_CursorFetch_Status, 0) == true)
					{
						
						break;
						
					}
					PAmount = (decimal?)(mathUtil.Round<decimal?>(stringUtil.IsNull<decimal?>(
							PoitemUnitMatCostConv,
							0) * stringUtil.IsNull<decimal?>(
							PoitemQtyOrderedConv,
							0), CurrencyPlaces));
					CostWithoutTax = 0;
					TaxAmount = 0;
					if (sQLUtil.SQLEqual(PoIncludeTaxInCost, 1) == true)
					{
						
						#region CRUD ExecuteMethodCall
						
						//Please Generate the bounce for this stored procedure: TaxPriceSeparationSp
						var TaxPriceSeparation = this.iTaxPriceSeparation.TaxPriceSeparationSp(
							InvType: "PO",
							Type: "I",
							TaxCode1: PoitemTaxCode1,
							TaxCode2: PoitemTaxCode2,
							HdrTaxCode1: PoTaxCode1,
							HdrTaxCode2: PoTaxCode2,
							Amount: PAmount,
							UndiscAmount: PAmount,
							CurrCode: PoCurrCode,
							ExchRate: PoExchRate,
							UseExchRate: 0,
							Places: CurrencyPlaces,
							InvDate: null,
							TermsCode: null,
							AmountWithoutTax: PAmount,
							UndiscAmountWithoutTax: PAmount,
							Tax1OnAmount: TaxAmount1,
							Tax2OnAmount: TaxAmount2,
							Tax1OnUndiscAmount: xAmount,
							Tax2OnUndiscAmount: xAmount,
							Infobar: Infobar);
						Severity = TaxPriceSeparation.ReturnCode;
						PAmount = TaxPriceSeparation.AmountWithoutTax;
						PAmount = TaxPriceSeparation.AmountWithoutTax;
						TaxAmount1 = TaxPriceSeparation.Tax1OnAmount;
						TaxAmount2 = TaxPriceSeparation.Tax2OnAmount;
						xAmount = TaxPriceSeparation.Tax1OnUndiscAmount;
						xAmount = TaxPriceSeparation.Tax1OnUndiscAmount;
						Infobar = TaxPriceSeparation.Infobar;
						
						#endregion ExecuteMethodCall
						
						if (sQLUtil.SQLNotEqual(Severity, 0) == true)
						{
							goto END_OF_PROG;
							
						}
						CostWithoutTax = PAmount;
						TaxAmount = (decimal?)(TaxAmount1 + TaxAmount2);
						
					}
					if (sQLUtil.SQLEqual(VendorPrintVATonPO, 1) == true && sQLUtil.SQLEqual(PoPrintPrice, 1) == true && (sQLUtil.SQLEqual(TaxSystem1_ActiveForPurch, 1) == true || sQLUtil.SQLEqual(TaxSystem2_ActiveForPurch, 1) == true))
					{
						PrintVATSummary = 1;
						
						#region CRUD ExecuteMethodCall
						
						//Please Generate the bounce for this stored procedure: TaxBaseSp
						var TaxBase = this.iTaxBase.TaxBaseSp(
							PInvType: "PO",
							PType: "I",
							PTaxCode1: PoitemTaxCode1,
							PTaxCode2: PoitemTaxCode2,
							PAmount: PAmount,
							PAmountToApply: convertToUtil.ToDecimal(0),
							PUndiscAmount: PAmount,
							PUWsPrice: null,
							PTaxablePrice: null,
							PQtyInvoiced: null,
							PCurrCode: null,
							PInvDate: null,
							PExchRate: null,
							Infobar: Infobar);
						Severity = TaxBase.ReturnCode;
						Infobar = TaxBase.Infobar;
						
						#endregion ExecuteMethodCall
						
						if (sQLUtil.SQLNotEqual(Severity, 0) == true)
						{
							goto END_OF_PROG;
							
						}
						
						#region CRUD ExecuteMethodCall
						
						//Please Generate the bounce for this stored procedure: TaxCalcSp
						var TaxCalc = this.iTaxCalc.TaxCalcSp(
							PInvType: "PO",
							PTaxCode1: PoTaxCode1,
							PTaxCode2: PoTaxCode2,
							PFreight: null,
							PFrtTaxCode1: null,
							PFrtTaxCode2: null,
							PMisc: convertToUtil.ToDecimal(0),
							PMiscTaxCode1: null,
							PMiscTaxCode2: null,
							PInvDate: null,
							PTermsCode: null,
							PUseExchRate: 0,
							PCurrCode: null,
							PPlaces: CurrencyPlaces,
							PExchRate: null,
							PSalesTax1: TSalesTax1,
							PSalesTax2: TSalesTax2,
							Infobar: Infobar);
						Severity = TaxCalc.ReturnCode;
						TSalesTax1 = TaxCalc.PSalesTax1;
						TSalesTax2 = TaxCalc.PSalesTax2;
						Infobar = TaxCalc.Infobar;
						
						#endregion ExecuteMethodCall
						
						if (sQLUtil.SQLNotEqual(Severity, 0) == true)
						{
							goto END_OF_PROG;
							
						}
						VatAmt = TSalesTax1;
						VatAmt2 = TSalesTax2;
						
					}
					else
					{
						VatAmt = null;
						VatAmt2 = null;
						PoitemTaxCode1 = null;
						PoitemTaxCode2 = null;
						
					}
					if (sQLUtil.SQLEqual(PoitemStat, "P") == true && sQLUtil.SQLEqual(ReviewPrint, "P") == true)
					{
						var poitem2LoadResponse = this.iRpt_ChangeOrderCRUD.Poitem2Select(PoitemRowpointer, pPoitemStat, pStartPoLine, pEndPoLine, pStartPoRElease, pEndPoRelease, pShowExternal1, pShowInternal1, pPrintPOTable, pPrintpoitem);
						this.iRpt_ChangeOrderCRUD.Poitem2Update(poitem2LoadResponse);
						
					}
					if (sQLUtil.SQLEqual(TFirstPOItem, 1) == true)
					{
						if (sQLUtil.SQLEqual(PoType, "B") == true)
						{
							PoBlnRowpointer = null;
							(PoBlnRowpointer,
								 PoBlnVendItem,
								 PoBlnStat,
								 PoBlnDrawingNbr,
								 PoBlnRevision,
								 PoBlnEffDate,
								 PoBlnExpDate,
								 PoBlnNoteexistsflag,
								 poblndescription,
								 PoBlnManufacturerId,
								 PoBlnManufacturerItem, rowCount) = this.iRpt_ChangeOrderCRUD.Po_BlnLoad(PoitemPoNum,
								 PoitemPoLine,
								 PoBlnRowpointer,
								 PoBlnVendItem,
								 PoBlnStat,
								 PoBlnDrawingNbr,
								 PoBlnRevision,
								 PoBlnEffDate,
								 PoBlnExpDate,
								 PoBlnNoteexistsflag,
								 PoBlnManufacturerId,
								 PoBlnManufacturerItem,
								 poblndescription);
							if ((PoBlnRowpointer!= null))
							{
								TVendItem = PoBlnVendItem;
								TManufacturerId = PoBlnManufacturerId;
								TManufacturerItem = PoBlnManufacturerItem;
								if (sQLUtil.SQLEqual(PoBlnStat, "P") == true && sQLUtil.SQLEqual(ReviewPrint, "P") == true)
								{
									XPoBlnRowpointer = null;
									(XPoBlnRowpointer, rowCount) = this.iRpt_ChangeOrderCRUD.Po_Blnasx_Po_BlnLoad(PoBlnRowpointer, XPoBlnRowpointer);
									if (XPoBlnRowpointer!= null)
									{
										var po_bln1LoadResponse = this.iRpt_ChangeOrderCRUD.Po_Bln1Select(XPoBlnRowpointer, pPoitemStat, pStartPoLine, pEndPoLine, pStartPoRElease, pEndPoRelease, pShowExternal1, pShowInternal1, pPrintPOTable, pPrintpoitem);
										this.iRpt_ChangeOrderCRUD.Po_Bln1Update(po_bln1LoadResponse);
										
									}
									
								}
								
							}
							else
							{
								TVendItem = "";
								
							}
							TManufacturerId = "";
							TManufacturerItem = "";
							PoblnchgRowpointer = null;
							(PoblnchgRowpointer, rowCount) = this.iRpt_ChangeOrderCRUD.PoblnchgLoad(PochangeChgNum, PoPoNum, PoitemPoLine, PoblnchgRowpointer);
							if ((PoblnchgRowpointer!= null))
							{
								TChangedPobln = 1;
								
							}
							
						}
						else
						{
							TVendItem = PoitemVendItem;
							
						}
						TManufacturerId = PoitemManufacturerId;
						TManufacturerItem = PoitemManufacturerItem;
						TRptNum = 1;
						
					}
					else
					{
						TRptNum = 2;
						
					}
					poitmchgNotAvail = 0;
					if (sQLUtil.SQLEqual(pPRPoChg, "C") == true)
					{
						if (sQLUtil.SQLNotEqual(PoType, "B") == true || sQLUtil.SQLEqual(TChangedPobln, 0) == true)
						{
							PoitmchgRowpointer = null;
							(PoitmchgRowpointer, rowCount) = this.iRpt_ChangeOrderCRUD.Poitmchg1Load(PochangeChgNum, PoPoNum, PoitemPoLine, PoitemPoRelease, PoitmchgRowpointer);
							if (PoitmchgRowpointer== null)
							{
								poitmchgNotAvail = 1;
								
							}
							
						}
						
					}
					if (sQLUtil.SQLBool(sQLUtil.SQLOr(sQLUtil.SQLOr((sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLEqual(pPRPoChg, "C"), (sQLUtil.SQLOr(sQLUtil.SQLNotEqual(PoType, "B"), sQLUtil.SQLEqual(TChangedPobln, 0)))), PoitmchgRowpointer!= null)), (sQLUtil.SQLAnd(sQLUtil.SQLEqual(pPRPoChg, "C"), sQLUtil.SQLNot((sQLUtil.SQLOr(sQLUtil.SQLNotEqual(PoType, "B"), sQLUtil.SQLEqual(TChangedPobln, 0))))))), (sQLUtil.SQLNotEqual(pPRPoChg, "C")))))
					{
						if (sQLUtil.SQLEqual(PoPrintPrice, 1) == true)
						{
							TSymbol = CurrencySymbol;
							CurrencyDescription = CurrencyDescriptionTmp;
							TcAmtPrice = (decimal?)(mathUtil.Round<decimal?>(PoitemUnitMatCostConv * PoitemQtyOrderedConv, CurrencyPlaces));
							if (sQLUtil.SQLEqual(TEuroExists, 1) == true)
							{
								if (sQLUtil.SQLEqual(Severity, 0) == true)
								{
									
									#region CRUD ExecuteMethodCall
									
									//Please Generate the bounce for this stored procedure: EuroPartSp
									var EuroPart = this.iEuroPart.EuroPartSp(
										PCurrCode: PoCurrCode,
										PPartOfEuro: TStd_Lo,
										Site: ParmsSite);
									Severity = EuroPart.ReturnCode;
									TStd_Lo = EuroPart.PPartOfEuro;
									
									#endregion ExecuteMethodCall
									
								}
								if (sQLUtil.SQLEqual(TStd_Lo, 1) == true)
								{
									TStd_De = 0;
									if (sQLUtil.SQLEqual(Severity, 0) == true)
									{
										
										#region CRUD ExecuteMethodCall
										
										//Please Generate the bounce for this stored procedure: CurrCnvtSp
										var CurrCnvt2 = this.iCurrCnvt.CurrCnvtSp(
											CurrCode: PoCurrCode,
											FromDomestic: 0,
											UseBuyRate: 1,
											RoundResult: 1,
											Date: RateDate,
											RoundPlaces: CurrencyPlaces,
											UseCustomsAndExciseRates: 0,
											ForceRate: null,
											FindTTFixed: null,
											TRate: TRate,
											Infobar: Infobar,
											Amount1: TcAmtPrice,
											Result1: TStd_De,
											Site: ParmsSite,
											DomCurrCode: CurrparmsCurrCode);
										Severity = CurrCnvt2.ReturnCode;
										TRate = CurrCnvt2.TRate;
										Infobar = CurrCnvt2.Infobar;
										TStd_De = CurrCnvt2.Result1;
										
										#endregion ExecuteMethodCall
										
									}
									if (sQLUtil.SQLNotEqual(Severity, 0) == true)
									{
										goto END_OF_PROG;
										
									}
									TEuroTotal = (decimal?)(mathUtil.Round<decimal?>(TEuroTotal - TStd_De, ECurrencyPlaces));
									
								}
								
							}
							if (sQLUtil.SQLEqual(pTransDomCurr, 1) == true)
							{
								TRate = PoExchRate;
								if (sQLUtil.SQLEqual(Severity, 0) == true)
								{
									
									#region CRUD ExecuteMethodCall
									
									//Please Generate the bounce for this stored procedure: CurrCnvtSp
									var CurrCnvt3 = this.iCurrCnvt.CurrCnvtSp(
										CurrCode: PoCurrCode,
										FromDomestic: 0,
										UseBuyRate: 1,
										RoundResult: 0,
										Date: RateDate,
										RoundPlaces: CurrencyPlaces,
										UseCustomsAndExciseRates: 0,
										ForceRate: null,
										FindTTFixed: null,
										TRate: TRate,
										Infobar: Infobar,
										Amount1: PoitemUnitMatCostConv,
										Result1: TcCprUnitMatCostConv,
										Amount2: TcAmtPrice,
										Result2: TcAmtPrice,
										Site: ParmsSite,
										DomCurrCode: CurrparmsCurrCode);
									Severity = CurrCnvt3.ReturnCode;
									TRate = CurrCnvt3.TRate;
									Infobar = CurrCnvt3.Infobar;
									TcCprUnitMatCostConv = CurrCnvt3.Result1;
									TcAmtPrice = CurrCnvt3.Result2;
									
									#endregion ExecuteMethodCall
									
								}
								if (sQLUtil.SQLNotEqual(Severity, 0) == true)
								{
									goto END_OF_PROG;
									
								}
								
							}
							else
							{
								TcCprUnitMatCostConv = PoitemUnitMatCostConv;
								
							}
							TTot = (decimal?)(TTot + TcAmtPrice);
							if (sQLUtil.SQLEqual(pTransDomCurr, 1) == true && sQLUtil.SQLNotEqual(TFudge, 0) == true)
							{
								TStd_De = (decimal?)(((sQLUtil.SQLEqual(TNumLines, 1) == true ? TFudge : TRoundFactor)) * (decimal?)(mathUtil.Round<decimal?>((TFudge / (decimal?)(TNumLines)) + (49.999999M * TRoundFactor * (decimal?)(((sQLUtil.SQLGreaterThan(TFudge, 0) == true ? 1 : -1)))), 0)));
								TcAmtPrice = (decimal?)(TcAmtPrice + TStd_De);
								TNumLines = (int?)(TNumLines - 1);
								TFudge = (decimal?)(TFudge - TStd_De);
								TcCprUnitMatCostConv = (decimal?)(TcAmtPrice / PoitemQtyOrderedConv);
								
							}
							
						}
						if (sQLUtil.SQLEqual(Severity, 0) == true)
						{
							
							#region CRUD ExecuteMethodCall
							
							//Please Generate the bounce for this stored procedure: GetumcfSp
							var Getumcf = this.iGetumcf.GetumcfSp(
								OtherUM: PoitemUM,
								Item: PoitemItem,
								VendNum: PoVendNum,
								Area: Area,
								ConvFactor: ConvFactor,
								Infobar: Infobar,
								Site: ParmsSite);
							Severity = Getumcf.ReturnCode;
							ConvFactor = Getumcf.ConvFactor;
							Infobar = Getumcf.Infobar;
							
							#endregion ExecuteMethodCall
							
						}
						if (sQLUtil.SQLNotEqual(Severity, 0) == true)
						{
							goto END_OF_PROG;
							
						}
						TQty = convertToUtil.ToDecimal(mathUtil.Round<decimal?>(PoitemQtyOrderedConv, pRoundPlaces) - mathUtil.Round<decimal?>(this.iUomConvQty.UomConvQtyFn(
								PoitemQtyReceived,
								ConvFactor,
								"From Base"), pRoundPlaces));
						PoBlnRowpointer = null;
						(PoBlnRowpointer,
							 PoBlnVendItem,
							 PoBlnStat,
							 PoBlnDrawingNbr,
							 PoBlnRevision,
							 PoBlnEffDate,
							 PoBlnExpDate,
							 PoBlnNoteexistsflag,
							 poblndescription,
							 PoBlnManufacturerId,
							 PoBlnManufacturerItem, rowCount) = this.iRpt_ChangeOrderCRUD.Po_Bln2Load(PoitemPoNum,
							 PoitemPoLine,
							 PoBlnRowpointer,
							 PoBlnVendItem,
							 PoBlnStat,
							 PoBlnDrawingNbr,
							 PoBlnRevision,
							 PoBlnEffDate,
							 PoBlnExpDate,
							 PoBlnNoteexistsflag,
							 PoBlnManufacturerId,
							 PoBlnManufacturerItem,
							 poblndescription);
						if (sQLUtil.SQLEqual(PoType, "B") == true)
						{
							if ((PoBlnRowpointer!= null))
							{
								TVendItem = PoBlnVendItem;
								
							}
							TManufacturerId = PoBlnManufacturerId;
							TManufacturerItem = PoBlnManufacturerItem;
							
						}
						else
						{
							TVendItem = PoitemVendItem;
							
						}
						TManufacturerId = PoitemManufacturerId;
						TManufacturerItem = PoitemManufacturerItem;
						if (PoBlnRowpointer== null)
						{
							TDrawingNbr = stringUtil.IsNull(
								PoitemDrawingNbr,
								"");
							
						}
						else
						{
							TDrawingNbr = stringUtil.IsNull(
								PoBlnDrawingNbr,
								"");
							
						}
						if (PoBlnRowpointer== null)
						{
							TRevision = stringUtil.IsNull(
								PoitemRevision,
								"");
							
						}
						else
						{
							TRevision = stringUtil.IsNull(
								PoBlnRevision,
								"");
							
						}
						if ((PoBlnRowpointer!= null))
						{
							if (PoBlnEffDate!= null)
							{
								TEffDate = convertToUtil.ToDateTime(PoBlnEffDate);
								
							}
							if (PoBlnExpDate!= null)
							{
								TExpDate = convertToUtil.ToDateTime(PoBlnExpDate);
								
							}
							if (sQLUtil.SQLEqual(pPrintpo_bln, 1) == true)
							{
								TPOBlnNoteExits = convertToUtil.ToInt32(this.iReportNotesExist.ReportNotesExistFn(
									"po_bln",
									PoBlnRowpointer,
									pShowInternal1,
									pShowExternal1,
									PoBlnNoteexistsflag));
								
							}
							else
							{
								TPOBlnNoteExits = 0;
								
							}
							
						}
						TAddr3 = null;
						if ((sQLUtil.SQLNotEqual(PoitemShipAddr, "N") == true) && (sQLUtil.SQLNotEqual(PoitemDropShipNo, PoDropShipNo) == true || sQLUtil.SQLNotEqual(PoitemDropSeq, PoDropSeq) == true || sQLUtil.SQLNotEqual(PoitemShipAddr, PoShipAddr) == true))
						{
							if (sQLUtil.SQLEqual(Severity, 0) == true)
							{
								
								#region CRUD ExecuteMethodCall
								
								//Please Generate the bounce for this stored procedure: GetDropShipToAddrWithPhoneLangSp
								var GetDropShipToAddrWithPhoneLang1 = this.iGetDropShipToAddrWithPhoneLang.GetDropShipToAddrWithPhoneLangSp(
									ShipTo: PoitemShipAddr,
									DropShipNo: PoitemDropShipNo,
									DropSeqNo: PoitemDropSeq,
									SiteRef: ParmsSite,
									MessageLanguage: MessageLanguage,
									ShipToAddress: TAddr3);
								Severity = GetDropShipToAddrWithPhoneLang1.ReturnCode;
								TAddr3 = GetDropShipToAddrWithPhoneLang1.ShipToAddress;
								
								#endregion ExecuteMethodCall
								
							}
							
						}
						if (sQLUtil.SQLEqual(pPrPoBlnTxt, 0) == true)
						{
							poblndescription = null;
							
						}
						
					}
					else
					{
						PoitemPoLine = null;
						PoitemPoRelease = null;
						PoitemItem = null;
						TVendItem = null;
						TcCprUnitMatCostConv = null;
						PoitemQtyOrderedConv = null;
						TQty = null;
						TRevision = null;
						TDrawingNbr = null;
						TEffDate = convertToUtil.ToDateTime<DateTime?>(null);
						TExpDate = convertToUtil.ToDateTime<DateTime?>(null);
						TcAmtPrice = null;
						PoitemDueDate = convertToUtil.ToDateTime<DateTime?>(null);
						PoitemExpedited = null;
						PoitemDescription = null;
						PoitemUM = null;
						TPOBlnNoteExits = null;
						TPOLineNoteExits = null;
						PoBlnRowpointer = null;
						PoitemRowpointer = null;
						poblndescription = null;
						VatAmt = null;
						VatAmt2 = null;
						PoitemTaxCode1 = null;
						PoitemTaxCode2 = null;
						CostWithoutTax = null;
						TaxAmount = null;
						TManufacturerId = null;
						TManufacturerItem = null;
						
					}
					if (sQLUtil.SQLEqual(TFirstPOItem, 1) == true || PoitmchgRowpointer!= null || sQLUtil.SQLEqual(pPRPoChg, "P") == true)
					{
						TFirstPOItem = 0;
						var nonTable1LoadResponse = this.iRpt_ChangeOrderCRUD.Nontable1Select(TRptNum, PoPoNum, PochangeChgNum, PochangeChgDate, PoType, PoPrintPrice, PoitemPoLine, PoitemPoRelease, PoVendNum, TAddr0, TAddr1, TAddr2, TAddr4, UserNamesUserDesc, PoBuyer, PoVendLcrNum, PoFob, TShipcodeDesc, TTermsDesc, PoDropShipNo, PoDropSeq, VendaddrFaxNum, TSymbol, TTot, CurrencyDescription, PoitemItem, TVendItem, TcCprUnitMatCostConv, PoitemQtyOrderedConv, TQty, TRevision, TDrawingNbr, TEffDate, TExpDate, TcAmtPrice, PoitemDueDate, PoitemExpedited, PoitemDescription, PoitemUM, TPOBlnNoteExits, TPOLineNoteExits, TPOChgNoteExits, PoBlnRowpointer, PoitemRowpointer, PochangeRowpointer, poblndescription, VatAmt, VatAmt2, PoitemTaxCode1, PoitemTaxCode2, VendorPrintVATonPO, TaxCodeLabel, TaxCode2Label, TaxAmtLabel, TaxAmt2Label, CostWithoutTax, PoIncludeTaxInCost, TaxAmount, PrintVATSummary, TManufacturerId, TManufacturerItem, ItemOverview, PoVendOrder, PoItemDeliveryIncoTerm, DeltermDescription, PoItemECCode, PoItemOriginCode, PoItemCommodityCode, ParmsURL, CurrCode, OfficeAddrFooter, OfficeEmailAddrFooter, BankName, BankTransitNum, Account);
						Data = nonTable1LoadResponse;
						this.iRpt_ChangeOrderCRUD.Nontable1Insert(nonTable1LoadResponse);
						
					}
					if (TAddr3!= null)
					{
						var nonTable2LoadResponse = this.iRpt_ChangeOrderCRUD.Nontable2Select(PoPoNum, PochangeChgNum, PoType, PoPrintPrice, TAddr3, TPoText1, TPoText2, TPoText3, TSymbol, TTot, TESymbol, TEuroTotal, CurrencyDescription, TPONoteExits, PoRowpointer, VendorPrintVATonPO, TaxCodeLabel, TaxCode2Label, TaxAmtLabel, TaxAmt2Label, PrintVATSummary, PoVendNum, TAddr0, TAddr1, TAddr2, TAddr4, UserNamesUserDesc, PoBuyer, PoVendLcrNum, PoFob, TShipcodeDesc, TTermsDesc, PoDropShipNo, PoDropSeq, VendaddrFaxNum, PochangeChgDate, PoVendOrder, PoItemDeliveryIncoTerm, DeltermDescription, PoItemECCode, PoItemOriginCode, PoItemCommodityCode, ParmsURL, CurrCode, OfficeAddrFooter, OfficeEmailAddrFooter, BankName, BankTransitNum, Account);
						Data = nonTable2LoadResponse;
						this.iRpt_ChangeOrderCRUD.Nontable2Insert(nonTable2LoadResponse);
						
					}
					TAddr3 = null;
					
				}
				//Deallocate Cursor poitem_crs
				if ((PoLangRowpointer!= null))
				{
					TPoText1 = PoLangPoText__1;
					TPoText2 = PoLangPoText__2;
					TPoText3 = PoLangPoText__3;
					
				}
				else
				{
					TPoText1 = PoparmsPoText1;
					TPoText2 = PoparmsPoText2;
					TPoText3 = PoparmsPoText3;
					
				}
				if (sQLUtil.SQLEqual(PoPrintPrice, 1) == true)
				{
					TSymbol = CurrencySymbol;
					CurrencyDescription = CurrencyDescriptionTmp;
					if (sQLUtil.SQLEqual(TEuroExists, 1) == true && sQLUtil.SQLEqual(pPrintEuro, 1) == true)
					{
						if (sQLUtil.SQLEqual(Severity, 0) == true)
						{
							
							#region CRUD ExecuteMethodCall
							
							//Please Generate the bounce for this stored procedure: EuroPartSp
							var EuroPart1 = this.iEuroPart.EuroPartSp(
								PCurrCode: PoCurrCode,
								PPartOfEuro: TStd_Lo,
								Site: ParmsSite);
							Severity = EuroPart1.ReturnCode;
							TStd_Lo = EuroPart1.PPartOfEuro;
							
							#endregion ExecuteMethodCall
							
						}
						if (sQLUtil.SQLEqual(TStd_Lo, 1) == true)
						{
							if (sQLUtil.SQLEqual(Severity, 0) == true)
							{
								
								#region CRUD ExecuteMethodCall
								
								//Please Generate the bounce for this stored procedure: CurrCnvtSp
								var CurrCnvt4 = this.iCurrCnvt.CurrCnvtSp(
									CurrCode: PoCurrCode,
									FromDomestic: 0,
									UseBuyRate: 1,
									RoundResult: 0,
									Date: RateDate,
									RoundPlaces: CurrencyPlaces,
									UseCustomsAndExciseRates: 0,
									ForceRate: null,
									FindTTFixed: null,
									TRate: TRate,
									Infobar: Infobar,
									Amount1: TcAmtPrice,
									Result1: TStd_De,
									Site: ParmsSite,
									DomCurrCode: CurrparmsCurrCode);
								Severity = CurrCnvt4.ReturnCode;
								TRate = CurrCnvt4.TRate;
								Infobar = CurrCnvt4.Infobar;
								TStd_De = CurrCnvt4.Result1;
								
								#endregion ExecuteMethodCall
								
							}
							if (sQLUtil.SQLNotEqual(Severity, 0) == true)
							{
								goto END_OF_PROG;
								
							}
							TEuroTotal = (decimal?)(mathUtil.Round<decimal?>(TEuroTotal - TStd_De, ECurrencyPlaces));
							TESymbol = ECurrencySymbol;
							
						}
						
					}
					
				}
				if (sQLUtil.SQLEqual(PochangeStat, "F") == true && sQLUtil.SQLEqual(ReviewPrint, "P") == true)
				{
					XPochangeRowpointer = null;
					(XPochangeRowpointer, rowCount) = this.iRpt_ChangeOrderCRUD.Pochangeasx_PochangeLoad(PochangeRowpointer, XPochangeRowpointer);
					if (XPochangeRowpointer!= null)
					{
						var pochange1LoadResponse = this.iRpt_ChangeOrderCRUD.Pochange1Select(XPochangeRowpointer);
						this.iRpt_ChangeOrderCRUD.Pochange1Update(pochange1LoadResponse);
						
					}
					
				}
				if (TAddr3== null && (sQLUtil.SQLNotEqual(TTot, 0) == true || sQLUtil.SQLNotEqual(TEuroTotal, 0) == true || sQLUtil.SQLNotEqual(TPONoteExits, 0) == true || sQLUtil.SQLEqual(poitmchgNotAvail, 1) == true))
				{
					poitmchgNotAvail = 0;
					var nonTable3LoadResponse = this.iRpt_ChangeOrderCRUD.Nontable3Select(PoitemPoNum, PochangeChgNum, PrevPoType, PrevPoPrintPrice, TAddr3, TPoText1, TPoText2, TPoText3, TSymbol, TTot, TESymbol, TEuroTotal, CurrencyDescription, TPONoteExits, PoRowpointer, VendorPrintVATonPO, TaxCodeLabel, TaxCode2Label, TaxAmtLabel, TaxAmt2Label, PrintVATSummary, PoVendNum, TAddr0, TAddr1, TAddr2, TAddr4, UserNamesUserDesc, PoBuyer, PoVendLcrNum, PoFob, TShipcodeDesc, TTermsDesc, PoDropShipNo, PoDropSeq, VendaddrFaxNum, PochangeChgDate, PoVendOrder, PoItemDeliveryIncoTerm, DeltermDescription, PoItemECCode, PoItemOriginCode, PoItemCommodityCode, ParmsURL, CurrCode, OfficeAddrFooter, OfficeEmailAddrFooter, BankName, BankTransitNum, Account);
					Data = nonTable3LoadResponse;
					this.iRpt_ChangeOrderCRUD.Nontable3Insert(nonTable3LoadResponse);
					
				}
				
			}
			//Deallocate Cursor po_crs
			if (sQLUtil.SQLEqual(PrintVATSummary, 1) == true)
			{
				var tv_ReportSetLoadResponse = this.iRpt_ChangeOrderCRUD.Tv_ReportsetSelect();
				this.iRpt_ChangeOrderCRUD.Tv_ReportsetUpdate(PrintVATSummary, tv_ReportSetLoadResponse);
				
			}
			END_OF_PROG: ;
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				if (TaskId!= null)
				{
					
					#region CRUD ExecuteMethodCall
					
					//Please Generate the bounce for this stored procedure: AddProcessErrorLogSp
					var AddProcessErrorLog = this.iAddProcessErrorLog.AddProcessErrorLogSp(
						ProcessID: TaskId,
						InfobarText: Infobar,
						MessageSeverity: Severity);
					
					#endregion ExecuteMethodCall
					
				}
				
			}
			var tv_ReportSet1LoadResponse = this.iRpt_ChangeOrderCRUD.Tv_Reportset1Select(Severity, UseAlternateAddressReportFormat);
			Data = tv_ReportSet1LoadResponse;
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: ReleaseTmpTaxTablesSp
			var ReleaseTmpTaxTables1 = this.iReleaseTmpTaxTables.ReleaseTmpTaxTablesSp(PSessionId: RptSessionID);
			
			#endregion ExecuteMethodCall
			
			this.transactionFactory.CommitTransaction("");
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);
			
			#endregion ExecuteMethodCall
			
			return (Data, Severity);
		}
		
	}
}
