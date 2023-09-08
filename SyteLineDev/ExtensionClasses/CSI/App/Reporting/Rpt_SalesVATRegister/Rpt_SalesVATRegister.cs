//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SalesVATRegister.cs

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
using CSI.Codes;
using CSI.Admin;
using CSI.Material;
using CSI.Logistics.Vendor;

namespace CSI.Reporting
{
	public class Rpt_SalesVATRegister : IRpt_SalesVATRegister
	{
		readonly IApplicationDB appDB;

		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly ITransactionFactory transactionFactory;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly IDisplayOurAddress iDisplayOurAddress;
		readonly IGetWinRegDecGroup iGetWinRegDecGroup;
		readonly IFixMaskForCrystal iFixMaskForCrystal;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IMultiLineAddress iMultiLineAddress;
		readonly IIsFeatureActive iIsFeatureActive;
		readonly IApplyDateOffset iApplyDateOffset;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ICurrCnvt iCurrCnvt;
		readonly IMathUtil mathUtil;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly ILowString lowString;
        readonly IHighString highString;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
		readonly IRpt_SalesVATRegisterGetInvHdrTaxDate Rpt_SalesVATRegisterGetInvHdrTaxDate;

		public Rpt_SalesVATRegister(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			IDisplayOurAddress iDisplayOurAddress,
			IGetWinRegDecGroup iGetWinRegDecGroup,
			IFixMaskForCrystal iFixMaskForCrystal,
			IIsAddonAvailable iIsAddonAvailable,
			IMultiLineAddress iMultiLineAddress,
			IIsFeatureActive iIsFeatureActive,
			IApplyDateOffset iApplyDateOffset,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			ICurrCnvt iCurrCnvt,
			IMathUtil mathUtil,
			ISQLValueComparerUtil sQLUtil,
            ILowString lowString,
            IHighString highString,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter,
			IRpt_SalesVATRegisterGetInvHdrTaxDate Rpt_SalesVATRegisterGetInvHdrTaxDate)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.iDisplayOurAddress = iDisplayOurAddress;
			this.iGetWinRegDecGroup = iGetWinRegDecGroup;
			this.iFixMaskForCrystal = iFixMaskForCrystal;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.iMultiLineAddress = iMultiLineAddress;
			this.iIsFeatureActive = iIsFeatureActive;
			this.iApplyDateOffset = iApplyDateOffset;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.iCurrCnvt = iCurrCnvt;
			this.mathUtil = mathUtil;
			this.sQLUtil = sQLUtil;
            this.lowString = lowString;
            this.highString = highString;
            this.lowCharacter = lowCharacter;
            this.highCharacter = highCharacter;
			this.Rpt_SalesVATRegisterGetInvHdrTaxDate = Rpt_SalesVATRegisterGetInvHdrTaxDate;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_SalesVATRegisterSp(
			string TaxCodeStarting = null,
			string TaxCodeEnding = null,
			DateTime? TaxPeriodDateStarting = null,
			DateTime? TaxPeriodDateEnding = null,
			string InvoiceStarting = null,
			string InvoiceEnding = null,
			int? TaxPeriodDateStartingOffset = null,
			int? TaxPeriodDateEndingOffset = null,
			string Description = null,
			int? DisplayHeader = null,
			string ECCodeStarting = null,
			string ECCodeEnding = null,
			string ReportType = null,
			int? DisplaySummaryInvoice = null,
			string SortBy = null,
			string pSite = null)
		{

			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			Guid? RptSessionID = null;
			string TaxIdLabel = null;
			TaxRegNumType _TaxRegNum = DBNull.Value;
			string TaxRegNum = null;
			DateTime? InvTaxInvDate = null;
			string InvTaxInvNum = null;
			int? InvTaxInvSeq = null;
			string InvTaxCustNum = null;
			int? InvTaxCustSeq = null;
			string InvTaxStaxAcct = null;
			string CustaddrName = null;
			string InvHdrCurrCode = null;
			string CustaddrAddr__1 = null;
			string CustaddrAddr__2 = null;
			string CustaddrAddr__3 = null;
			string CustaddrAddr__4 = null;
			string CustaddrCity = null;
			string CustaddrState = null;
			string CustaddrZip = null;
			string CustaddrCountry = null;
			string ChartDescription = null;
			decimal? InvTaxBasis = null;
			decimal? InvSalesTax = null;
			string TaxCode = null;
			int? TaxSystem = null;
			string TaxCodeDescription = null;
			DecimalPlacesType _TPlaces = DBNull.Value;
			int? TPlaces = null;
			InputMaskType _DomAmtFormat = DBNull.Value;
			string DomAmtFormat = null;
			string ECCode = null;
			TaxRegNumType _CustomerVATID = DBNull.Value;
			string CustomerVATID = null;
			ReferenceType _GLReference = DBNull.Value;
			string GLReference = null;
			InputMaskType _DomCurrencyTotFormat = DBNull.Value;
			string DomCurrencyTotFormat = null;
			DecimalPlacesType _DomCurrencyTotPlaces = DBNull.Value;
			int? DomCurrencyTotPlaces = null;
			int? HasThai = null;
			DateTime? InvHdrTaxDate = null;
			int? PolandCountryPack = null;
			decimal? TRate = null;
			string TError = null;
			string Addr = null;
			string LowChar = null;
			string HighChar = null;
			int? Severity = null;
			string ProductName = null;
			string FeatureID = null;
			int? FeatureRS8518_2Active = null;
			string Infobar = null;
			string FeatureRS8937 = null;
			int? FeatureRS8937Active = null;
			string FeatureInfoBar = null;
			ICollectionLoadRequest InvStaxCurLoadRequestForCursor = null;
			ICollectionLoadResponse InvStaxCurLoadResponseForCursor = null;
			int InvStaxCur_CursorFetch_Status = -1;
			int InvStaxCur_CursorCounter = -1;

			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_SalesVATRegisterSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
			)
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

				#region CRUD LoadToRecord
				var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SpName","CAST (NULL AS NVARCHAR)"},
						{"u0","[om].[ModuleName]"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_SalesVATRegisterSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_SalesVATRegisterSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""))
				)
				{
					#region CRUD LoadToVariable
					var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_ALTGEN_SpName,"[SpName]"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
						tableName: "#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause(""),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
					if (tv_ALTGEN1LoadResponse.Items.Count > 0)
					{
						ALTGEN_SpName = _ALTGEN_SpName;
					}
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_Rpt_SalesVATRegisterSp(ALTGEN_SpName,
						TaxCodeStarting,
						TaxCodeEnding,
						TaxPeriodDateStarting,
						TaxPeriodDateEnding,
						InvoiceStarting,
						InvoiceEnding,
						TaxPeriodDateStartingOffset,
						TaxPeriodDateEndingOffset,
						Description,
						DisplayHeader,
						ECCodeStarting,
						ECCodeEnding,
						ReportType,
						DisplaySummaryInvoice,
						SortBy,
						pSite);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					#region CRUD LoadToRecord
					var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"[SpName]","[SpName]"},
						},
                        loadForChange: true, 
                        lockingType: LockingType.None,
                        tableName: "#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
					#endregion  LoadToRecord

					#region CRUD DeleteByRecord
					var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
						items: tv_ALTGEN2LoadResponse.Items);
					this.appDB.Delete(tv_ALTGEN2DeleteRequest);
					#endregion DeleteByRecord

					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
				}
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_SalesVATRegisterSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_SalesVATRegisterSp("dbo.EXTGEN_Rpt_SalesVATRegisterSp",
					TaxCodeStarting,
					TaxCodeEnding,
					TaxPeriodDateStarting,
					TaxPeriodDateEnding,
					InvoiceStarting,
					InvoiceEnding,
					TaxPeriodDateStartingOffset,
					TaxPeriodDateEndingOffset,
					Description,
					DisplayHeader,
					ECCodeStarting,
					ECCodeEnding,
					ReportType,
					DisplaySummaryInvoice,
					SortBy,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("SalesVATRegister"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(
				ContextName: "Rpt_SalesVATRegisterSp",
				SessionID: RptSessionID,
				Site: pSite);
			RptSessionID = InitSessionContext.SessionID;

			#endregion ExecuteMethodCall

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @ReportSet TABLE (
				    Addr                 LongAddress      ,
				    TaxIdLabel           TaxCodeLabelType ,
				    TaxRegNum            TaxRegNumType    ,
				    TaxCode              TaxCodeType      ,
				    TaxCodeDescription   DescriptionType  ,
				    InvTaxInvDate        DateType         ,
				    InvTaxInvNum         InvNumType       ,
				    InvTaxInvSeq         InvSeqType       ,
				    InvTaxCustNum        CustNumType      ,
				    CustaddrName         LongNameType     ,
				    Addr1                AddressType      ,
				    Addr2                AddressType      ,
				    Addr3                AddressType      ,
				    Addr4                AddressType      ,
				    City                 CityType         ,
				    State                StateType        ,
				    Zip                  PostalCodeType   ,
				    Country              CountryType      ,
				    ChartDescription     DescriptionType  ,
				    InvTaxBasis          AmountType       ,
				    InvSalesTax          AmountType       ,
				    Amt_format           InputMaskType    ,
				    Places               DecimalPlacesType,
				    ECCode               ECCodeType       ,
				    CustomerVATID        TaxRegNumType    ,
				    GLReference          ReferenceType    ,
				    DomCurrencyTotFormat InputMaskType    ,
				    DomCurrencyTotPlaces DecimalPlacesType,
				    HasThai              INT              ,
				    TotalTax             AmountType       ,
				    InvHdrTaxDate        DateType         );
				SELECT * into #tv_ReportSet from @ReportSet");
			Severity = 0;
			ProductName = "CSI";
			FeatureID = "RS8518_2";

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: IsFeatureActiveSp
			var IsFeatureActive = this.iIsFeatureActive.IsFeatureActiveSp(
				ProductName: ProductName,
				FeatureID: FeatureID,
				FeatureActive: FeatureRS8518_2Active,
				InfoBar: Infobar);
			Severity = IsFeatureActive.ReturnCode;
			FeatureRS8518_2Active = IsFeatureActive.FeatureActive;
			Infobar = IsFeatureActive.InfoBar;

			#endregion ExecuteMethodCall

			PolandCountryPack = convertToUtil.ToInt32((sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("PolandCountryPack"), 1) == true && sQLUtil.SQLEqual(FeatureRS8518_2Active, 1) == true ? 1 : 0));
			LowChar = convertToUtil.ToString(this.lowCharacter.LowCharacterFn());
			HighChar = convertToUtil.ToString(this.highCharacter.HighCharacterFn());
			TaxCodeStarting = stringUtil.IsNull(
				TaxCodeStarting,
				LowChar);
			TaxCodeEnding = stringUtil.IsNull(
				TaxCodeEnding,
				HighChar);
			InvoiceStarting = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"InvNumType",
					InvoiceStarting),
				LowChar);
			InvoiceEnding = stringUtil.IsNull(
				this.iExpandKyByType.ExpandKyByTypeFn(
					"InvNumType",
					InvoiceEnding),
				HighChar);
			ECCodeStarting = stringUtil.IsNull(
				ECCodeStarting,
				this.lowString.LowStringFn("ECCodeType"));
			ECCodeEnding = stringUtil.IsNull(
				ECCodeEnding,
				this.highString.HighStringFn("ECCodeType"));
			DisplayHeader = (int?)(stringUtil.IsNull(
				DisplayHeader,
				1));
			if (SortBy == null)
			{
				SortBy = "I";

			}
			ProductName = "CSI";
			FeatureRS8937 = "RS8937";

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: IsFeatureActiveSp
			var IsFeatureActive1 = this.iIsFeatureActive.IsFeatureActiveSp(
				ProductName: ProductName,
				FeatureID: FeatureRS8937,
				FeatureActive: FeatureRS8937Active,
				InfoBar: FeatureInfoBar);
			Severity = IsFeatureActive1.ReturnCode;
			FeatureRS8937Active = IsFeatureActive1.FeatureActive;
			FeatureInfoBar = IsFeatureActive1.InfoBar;

			#endregion ExecuteMethodCall

			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Data, Severity);//END
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
				Date: TaxPeriodDateStarting,
				Offset: TaxPeriodDateStartingOffset,
				IsEndDate: 0);
			TaxPeriodDateStarting = ApplyDateOffset.Date;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
				Date: TaxPeriodDateEnding,
				Offset: TaxPeriodDateEndingOffset,
				IsEndDate: 1);
			TaxPeriodDateEnding = ApplyDateOffset1.Date;

			#endregion ExecuteMethodCall

			Addr = convertToUtil.ToString(this.iDisplayOurAddress.DisplayOurAddressFn());
			HasThai = convertToUtil.ToInt32(this.iIsAddonAvailable.IsAddonAvailableFn("ThailandCountryPack"));

			#region CRUD LoadToVariable
			var taxparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TaxRegNum,"taxparms.tax_reg_num1"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "taxparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var taxparmsLoadResponse = this.appDB.Load(taxparmsLoadRequest);
			if (taxparmsLoadResponse.Items.Count > 0)
			{
				TaxRegNum = _TaxRegNum;
			}
			#endregion  LoadToVariable

			#region CRUD LoadToVariable
			var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TPlaces,"places"},
					{_DomAmtFormat,"amt_format"},
					{_DomCurrencyTotFormat,"amt_tot_format"},
					{_DomCurrencyTotPlaces,"places"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName: "currency",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = (SELECT curr_code FROM currparms)"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
			if (currencyLoadResponse.Items.Count > 0)
			{
				TPlaces = _TPlaces;
				DomAmtFormat = _DomAmtFormat;
				DomCurrencyTotFormat = _DomCurrencyTotFormat;
				DomCurrencyTotPlaces = _DomCurrencyTotPlaces;
			}
			#endregion  LoadToVariable

			DomCurrencyTotFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
				DomCurrencyTotFormat,
				this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
			DomAmtFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
				DomAmtFormat,
				this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
			TRate = 1.0M;
			InvTaxBasis = 0.0M;
			InvSalesTax = 0.0M;
			if (sQLUtil.SQLNotEqual(stringUtil.Coalesce<int?>(FeatureRS8937Active, 0), 0) == true)
			{

				#region CRUD LoadToRecord
				InvStaxCurLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"inv_date","inv_stax.inv_date"},
						{"inv_num","inv_stax.inv_num"},
						{"inv_seq","inv_stax.inv_seq"},
						{"cust_num","inv_stax.cust_num"},
						{"cust_seq","inv_stax.cust_seq"},
						{"stax_acct","inv_stax.stax_acct"},
						{"tax_basis","inv_stax.tax_basis"},
						{"sales_tax","inv_stax.sales_tax"},
						{"col0","CAST (NULL AS NVARCHAR)"},
						{"tax_system","inv_stax.tax_system"},
						{"col1","CAST (NULL AS NVARCHAR)"},
						{"addr##1","custaddr.addr##1"},
						{"addr##2","custaddr.addr##2"},
						{"addr##3","custaddr.addr##3"},
						{"addr##4","custaddr.addr##4"},
						{"city","custaddr.city"},
						{"state_code","s.state_code"},
						{"zip","custaddr.zip"},
						{"country","custaddr.country"},
						{"col2","CAST (NULL AS NVARCHAR)"},
						{"description","taxcode.description"},
						{"curr_code","inv_hdr.curr_code"},
						{"exch_rate","inv_hdr.exch_rate"},
						{"ec_code","inv_hdr.ec_code"},
						{"tax_id_label","tax_system.tax_id_label"},
						{"tax_date","inv_hdr.tax_date"},
						{"u0","inv_stax.tax_code_e"},
						{"u1","inv_stax.tax_code"},
						{"u2","custaddr.use_long_name"},
						{"u3","custaddr.long_name"},
						{"u4","custaddr.name"},
						{"u5","(SELECT TOP 1 chart.description FROM   inv_hdr        INNER JOIN        inv_item        ON inv_item.inv_num = inv_hdr.inv_num           AND inv_item.inv_seq = inv_hdr.inv_seq        INNER JOIN        chart        ON chart.acct = inv_item.sales_acct WHERE  inv_hdr.inv_num = inv_stax.inv_num        AND inv_hdr.cust_num = inv_stax.cust_num)"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "inv_stax",
					fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN custaddr ON custaddr.cust_num = inv_stax.cust_num
						AND custaddr.cust_seq = inv_stax.cust_seq LEFT OUTER JOIN taxcode ON taxcode.tax_system = inv_stax.tax_system
						AND taxcode.tax_code = CASE WHEN inv_stax.sales_tax = 0 THEN inv_stax.tax_code_e ELSE inv_stax.tax_code END LEFT OUTER JOIN tax_system ON taxcode.tax_system = tax_system.tax_system LEFT OUTER JOIN inv_hdr ON inv_hdr.inv_num = inv_stax.inv_num
						AND inv_hdr.inv_seq = inv_stax.inv_seq LEFT OUTER JOIN state AS s ON s.state = custaddr.state"),
					whereClause: collectionLoadRequestFactory.Clause("(inv_stax.tax_code BETWEEN {3} AND {5}) AND (CASE WHEN ({7} <> 'Standard') THEN inv_stax.inv_date ELSE (CASE WHEN ({2} = 1) THEN CONVERT (DATE, COALESCE (inv_hdr.tax_date, inv_stax.inv_date)) ELSE CONVERT (DATE, inv_stax.inv_date) END) END) BETWEEN {0} AND {1} AND (inv_stax.inv_num BETWEEN {4} AND {6})", TaxPeriodDateStarting, TaxPeriodDateEnding, PolandCountryPack, TaxCodeStarting, InvoiceStarting, TaxCodeEnding, InvoiceEnding, ReportType),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				#endregion  LoadToRecord

				InvStaxCurLoadResponseForCursor = this.appDB.Load(InvStaxCurLoadRequestForCursor);
				foreach (var inv_staxItem in InvStaxCurLoadResponseForCursor.Items)
				{
					inv_staxItem.SetValue<DateTime?>("inv_date", inv_staxItem.GetValue<DateTime?>("inv_date"));
					inv_staxItem.SetValue<string>("inv_num", inv_staxItem.GetValue<string>("inv_num"));
					inv_staxItem.SetValue<int?>("inv_seq", inv_staxItem.GetValue<int?>("inv_seq"));
					inv_staxItem.SetValue<string>("cust_num", inv_staxItem.GetValue<string>("cust_num"));
					inv_staxItem.SetValue<int?>("cust_seq", inv_staxItem.GetValue<int?>("cust_seq"));
					inv_staxItem.SetValue<string>("stax_acct", inv_staxItem.GetValue<string>("stax_acct"));
					inv_staxItem.SetValue<decimal?>("tax_basis", inv_staxItem.GetValue<decimal?>("tax_basis"));
					inv_staxItem.SetValue<decimal?>("sales_tax", inv_staxItem.GetValue<decimal?>("sales_tax"));
					inv_staxItem.SetValue<string>("col0", (sQLUtil.SQLEqual(inv_staxItem.GetValue<decimal?>("sales_tax"), 0) == true ? stringUtil.Upper(inv_staxItem.GetValue<string>("u0")) : stringUtil.Upper(inv_staxItem.GetValue<string>("u1"))));
					inv_staxItem.SetValue<int?>("tax_system", inv_staxItem.GetValue<int?>("tax_system"));
					inv_staxItem.SetValue<string>("col1", (sQLUtil.SQLEqual(inv_staxItem.GetValue<int?>("u2"), 1) == true && sQLUtil.SQLNotEqual(stringUtil.IsNull(
						inv_staxItem.GetValue<string>("u3"),
						""), "") == true ? inv_staxItem.GetValue<string>("u3") : inv_staxItem.GetValue<string>("u4")));
					inv_staxItem.SetValue<string>("addr##1", inv_staxItem.GetValue<string>("addr##1"));
					inv_staxItem.SetValue<string>("addr##2", inv_staxItem.GetValue<string>("addr##2"));
					inv_staxItem.SetValue<string>("addr##3", inv_staxItem.GetValue<string>("addr##3"));
					inv_staxItem.SetValue<string>("addr##4", inv_staxItem.GetValue<string>("addr##4"));
					inv_staxItem.SetValue<string>("city", inv_staxItem.GetValue<string>("city"));
					inv_staxItem.SetValue<string>("state_code", inv_staxItem.GetValue<string>("state_code"));
					inv_staxItem.SetValue<string>("zip", inv_staxItem.GetValue<string>("zip"));
					inv_staxItem.SetValue<string>("country", inv_staxItem.GetValue<string>("country"));
					inv_staxItem.SetValue<string>("col2", inv_staxItem.GetValue<string>("u5"));
					inv_staxItem.SetValue<string>("description", inv_staxItem.GetValue<string>("description"));
					inv_staxItem.SetValue<string>("curr_code", inv_staxItem.GetValue<string>("curr_code"));
					inv_staxItem.SetValue<decimal?>("exch_rate", inv_staxItem.GetValue<decimal?>("exch_rate"));
					inv_staxItem.SetValue<string>("ec_code", inv_staxItem.GetValue<string>("ec_code"));
					inv_staxItem.SetValue<string>("tax_id_label", inv_staxItem.GetValue<string>("tax_id_label"));
					inv_staxItem.SetValue<DateTime?>("tax_date", inv_staxItem.GetValue<DateTime?>("tax_date"));
				};

				InvStaxCur_CursorFetch_Status = InvStaxCurLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				InvStaxCur_CursorCounter = -1;
			}
			else
			{
				#region CRUD LoadToRecord
				InvStaxCurLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"inv_date","inv_stax.inv_date"},
						{"inv_num","inv_stax.inv_num"},
						{"inv_seq","inv_stax.inv_seq"},
						{"cust_num","inv_stax.cust_num"},
						{"cust_seq","inv_stax.cust_seq"},
						{"stax_acct","inv_stax.stax_acct"},
						{"tax_basis","inv_stax.tax_basis"},
						{"sales_tax","inv_stax.sales_tax"},
						{"col0","CAST (NULL AS NVARCHAR)"},
						{"tax_system","inv_stax.tax_system"},
						{"name","custaddr.name"},
						{"addr##1","custaddr.addr##1"},
						{"addr##2","custaddr.addr##2"},
						{"addr##3","custaddr.addr##3"},
						{"addr##4","custaddr.addr##4"},
						{"city","custaddr.city"},
						{"state_code","s.state_code"},
						{"zip","custaddr.zip"},
						{"country","custaddr.country"},
						{"col1","CAST (NULL AS NVARCHAR)"},
						{"description","taxcode.description"},
						{"curr_code","inv_hdr.curr_code"},
						{"exch_rate","inv_hdr.exch_rate"},
						{"ec_code","inv_hdr.ec_code"},
						{"tax_id_label","tax_system.tax_id_label"},
						{"tax_date","inv_hdr.tax_date"},
						{"u0","inv_stax.tax_code_e"},
						{"u1","inv_stax.tax_code"},
						{"u2","(SELECT TOP 1 chart.description FROM   inv_hdr        INNER JOIN        inv_item        ON inv_item.inv_num = inv_hdr.inv_num           AND inv_item.inv_seq = inv_hdr.inv_seq        INNER JOIN        chart        ON chart.acct = inv_item.sales_acct WHERE  inv_hdr.inv_num = inv_stax.inv_num        AND inv_hdr.cust_num = inv_stax.cust_num)"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "inv_stax",
					fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN custaddr ON custaddr.cust_num = inv_stax.cust_num
						AND custaddr.cust_seq = inv_stax.cust_seq LEFT OUTER JOIN taxcode ON taxcode.tax_system = inv_stax.tax_system
						AND taxcode.tax_code = CASE WHEN inv_stax.sales_tax = 0 THEN inv_stax.tax_code_e ELSE inv_stax.tax_code END LEFT OUTER JOIN tax_system ON taxcode.tax_system = tax_system.tax_system LEFT OUTER JOIN inv_hdr ON inv_hdr.inv_num = inv_stax.inv_num
						AND inv_hdr.inv_seq = inv_stax.inv_seq LEFT OUTER JOIN state AS s ON s.state = custaddr.state"),
					whereClause: collectionLoadRequestFactory.Clause("(inv_stax.tax_code BETWEEN {3} AND {5}) AND (CASE WHEN ({7} <> 'Standard') THEN inv_stax.inv_date ELSE (CASE WHEN ({2} = 1) THEN CONVERT (DATE, COALESCE (inv_hdr.tax_date, inv_stax.inv_date)) ELSE CONVERT (DATE, inv_stax.inv_date) END) END) BETWEEN {0} AND {1} AND (inv_stax.inv_num BETWEEN {4} AND {6})", TaxPeriodDateStarting, TaxPeriodDateEnding, PolandCountryPack, TaxCodeStarting, InvoiceStarting, TaxCodeEnding, InvoiceEnding, ReportType),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				#endregion  LoadToRecord

				InvStaxCurLoadResponseForCursor = this.appDB.Load(InvStaxCurLoadRequestForCursor);
				foreach (var inv_stax1Item in InvStaxCurLoadResponseForCursor.Items)
				{
					inv_stax1Item.SetValue<DateTime?>("inv_date", inv_stax1Item.GetValue<DateTime?>("inv_date"));
					inv_stax1Item.SetValue<string>("inv_num", inv_stax1Item.GetValue<string>("inv_num"));
					inv_stax1Item.SetValue<int?>("inv_seq", inv_stax1Item.GetValue<int?>("inv_seq"));
					inv_stax1Item.SetValue<string>("cust_num", inv_stax1Item.GetValue<string>("cust_num"));
					inv_stax1Item.SetValue<int?>("cust_seq", inv_stax1Item.GetValue<int?>("cust_seq"));
					inv_stax1Item.SetValue<string>("stax_acct", inv_stax1Item.GetValue<string>("stax_acct"));
					inv_stax1Item.SetValue<decimal?>("tax_basis", inv_stax1Item.GetValue<decimal?>("tax_basis"));
					inv_stax1Item.SetValue<decimal?>("sales_tax", inv_stax1Item.GetValue<decimal?>("sales_tax"));
					inv_stax1Item.SetValue<string>("col0", (sQLUtil.SQLEqual(inv_stax1Item.GetValue<decimal?>("sales_tax"), 0) == true ? stringUtil.Upper(inv_stax1Item.GetValue<string>("u0")) : stringUtil.Upper(inv_stax1Item.GetValue<string>("u1"))));
					inv_stax1Item.SetValue<int?>("tax_system", inv_stax1Item.GetValue<int?>("tax_system"));
					inv_stax1Item.SetValue<string>("name", inv_stax1Item.GetValue<string>("name"));
					inv_stax1Item.SetValue<string>("addr##1", inv_stax1Item.GetValue<string>("addr##1"));
					inv_stax1Item.SetValue<string>("addr##2", inv_stax1Item.GetValue<string>("addr##2"));
					inv_stax1Item.SetValue<string>("addr##3", inv_stax1Item.GetValue<string>("addr##3"));
					inv_stax1Item.SetValue<string>("addr##4", inv_stax1Item.GetValue<string>("addr##4"));
					inv_stax1Item.SetValue<string>("city", inv_stax1Item.GetValue<string>("city"));
					inv_stax1Item.SetValue<string>("state_code", inv_stax1Item.GetValue<string>("state_code"));
					inv_stax1Item.SetValue<string>("zip", inv_stax1Item.GetValue<string>("zip"));
					inv_stax1Item.SetValue<string>("country", inv_stax1Item.GetValue<string>("country"));
					inv_stax1Item.SetValue<string>("col1", inv_stax1Item.GetValue<string>("u2"));
					inv_stax1Item.SetValue<string>("description", inv_stax1Item.GetValue<string>("description"));
					inv_stax1Item.SetValue<string>("curr_code", inv_stax1Item.GetValue<string>("curr_code"));
					inv_stax1Item.SetValue<decimal?>("exch_rate", inv_stax1Item.GetValue<decimal?>("exch_rate"));
					inv_stax1Item.SetValue<string>("ec_code", inv_stax1Item.GetValue<string>("ec_code"));
					inv_stax1Item.SetValue<string>("tax_id_label", inv_stax1Item.GetValue<string>("tax_id_label"));
					inv_stax1Item.SetValue<DateTime?>("tax_date", inv_stax1Item.GetValue<DateTime?>("tax_date"));
				};

				InvStaxCur_CursorFetch_Status = InvStaxCurLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				InvStaxCur_CursorCounter = -1;

			}
			while (sQLUtil.SQLEqual(1, 1) == true)
			{
				//BEGIN
				InvStaxCur_CursorCounter++;
				if (InvStaxCurLoadResponseForCursor.Items.Count > InvStaxCur_CursorCounter)
				{
					InvTaxInvDate = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<DateTime?>(0);
					InvTaxInvNum = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(1);
					InvTaxInvSeq = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<int?>(2);
					InvTaxCustNum = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(3);
					InvTaxCustSeq = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<int?>(4);
					InvTaxStaxAcct = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(5);
					InvTaxBasis = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<decimal?>(6);
					InvSalesTax = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<decimal?>(7);
					TaxCode = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(8);
					TaxSystem = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<int?>(9);
					CustaddrName = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(10);
					CustaddrAddr__1 = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(11);
					CustaddrAddr__2 = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(12);
					CustaddrAddr__3 = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(13);
					CustaddrAddr__4 = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(14);
					CustaddrCity = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(15);
					CustaddrState = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(16);
					CustaddrZip = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(17);
					CustaddrCountry = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(18);
					ChartDescription = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(19);
					TaxCodeDescription = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(20);
					InvHdrCurrCode = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(21);
					TRate = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<decimal?>(22);
					ECCode = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(23);
					TaxIdLabel = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<string>(24);
					InvHdrTaxDate = InvStaxCurLoadResponseForCursor.Items[InvStaxCur_CursorCounter].GetValue<DateTime?>(25);
				}
				InvStaxCur_CursorFetch_Status = (InvStaxCur_CursorCounter == InvStaxCurLoadResponseForCursor.Items.Count ? -1 : 0);

				if (sQLUtil.SQLNotEqual(InvStaxCur_CursorFetch_Status, 0) == true)
				{

					break;

				}
				InvTaxBasis = (decimal?)(mathUtil.Round<decimal?>(InvTaxBasis, TPlaces));
				GLReference = null;
				if (existsChecker.Exists(tableName: "artran",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("artran.cust_num = {0} AND artran.inv_num = {1}", InvTaxCustNum, InvTaxInvNum))
				)
				{
					//BEGIN

					#region CRUD LoadToVariable
					var artran1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_GLReference,"artran.ref"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
						tableName: "artran",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("artran.cust_num = {0} AND artran.inv_num = {1}", InvTaxCustNum, InvTaxInvNum),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var artran1LoadResponse = this.appDB.Load(artran1LoadRequest);
					if (artran1LoadResponse.Items.Count > 0)
					{
						GLReference = _GLReference;
					}
					#endregion  LoadToVariable
				}
				else
				{
					#region CRUD LoadToVariable
					var arinvLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_GLReference,"arinv.ref"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
						tableName: "arinv",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("arinv.cust_num = {0} AND arinv.inv_num = {1}", InvTaxCustNum, InvTaxInvNum),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var arinvLoadResponse = this.appDB.Load(arinvLoadRequest);
					if (arinvLoadResponse.Items.Count > 0)
					{
						GLReference = _GLReference;
					}
					#endregion  LoadToVariable
				}

				#region CRUD LoadToVariable
				var customerLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_CustomerVATID,"customer.tax_reg_num1"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "customer",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("customer.cust_num = {0} AND customer.cust_seq = {1}", InvTaxCustNum, InvTaxCustSeq),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var customerLoadResponse = this.appDB.Load(customerLoadRequest);
				if (customerLoadResponse.Items.Count > 0)
				{
					CustomerVATID = _CustomerVATID;
				}
				#endregion  LoadToVariable

				TRate = null;
				InvHdrTaxDate = Rpt_SalesVATRegisterGetInvHdrTaxDate.GetInvHdrTaxDate(ReportType, InvTaxInvDate, InvHdrTaxDate, PolandCountryPack);

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: CurrCnvtSp
				var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
					CurrCode: InvHdrCurrCode,
					FromDomestic: 0,
					UseBuyRate: 0,
					RoundResult: 0,
					Date: InvHdrTaxDate,
					TRate: TRate,
					Infobar: TError,
					Amount1: InvTaxBasis,
					Result1: InvTaxBasis,
					Amount2: InvSalesTax,
					Result2: InvSalesTax);
				Severity = CurrCnvt.ReturnCode;
				TRate = CurrCnvt.TRate;
				TError = CurrCnvt.Infobar;
				InvTaxBasis = CurrCnvt.Result1;
				InvSalesTax = CurrCnvt.Result2;

				#endregion ExecuteMethodCall

				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					break;
				}

				#region CRUD LoadResponseWithoutTable
				var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
						{ "Addr", Addr},
						{ "TaxIdLabel", TaxIdLabel},
						{ "TaxRegNum", TaxRegNum},
						{ "TaxCode", TaxCode},
						{ "TaxCodeDescription", TaxCodeDescription},
						{ "InvTaxInvDate", InvTaxInvDate},
						{ "InvTaxInvNum", InvTaxInvNum},
						{ "InvTaxInvSeq", InvTaxInvSeq},
						{ "InvTaxCustNum", InvTaxCustNum},
						{ "CustaddrName", CustaddrName},
						{ "Addr1", CustaddrAddr__1},
						{ "Addr2", CustaddrAddr__2},
						{ "Addr3", CustaddrAddr__3},
						{ "Addr4", CustaddrAddr__4},
						{ "City", CustaddrCity},
						{ "State", CustaddrState},
						{ "Zip", CustaddrZip},
						{ "Country", CustaddrCountry},
						{ "ChartDescription", stringUtil.IsNull(
							ChartDescription,
							Description)},
						{ "InvTaxBasis", InvTaxBasis},
						{ "InvSalesTax", InvSalesTax},
						{ "Amt_format", DomAmtFormat},
						{ "Places", TPlaces},
						{ "ECCode", ECCode},
						{ "CustomerVATID", CustomerVATID},
						{ "GLReference", GLReference},
						{ "DomCurrencyTotFormat", DomCurrencyTotFormat},
						{ "DomCurrencyTotPlaces", DomCurrencyTotPlaces},
						{ "HasThai", HasThai},
						{ "TotalTax", InvTaxBasis + InvSalesTax},
						{ "InvHdrTaxDate", InvHdrTaxDate},
				});

				var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
				Data = nonTableLoadResponse;
				#endregion CRUD LoadResponseWithoutTable

				#region CRUD InsertByRecords
				var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ReportSet",
					items: nonTableLoadResponse.Items);

				this.appDB.Insert(nonTableInsertRequest);
				#endregion InsertByRecords
			}
			InvStaxCurLoadResponseForCursor = null;
			//Deallocate Cursor @InvStaxCur

			#region CRUD LoadToRecord
			var tv_ReportSetLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Addr","#tv_ReportSet.Addr"},
					{"TaxIdLabel","#tv_ReportSet.TaxIdLabel"},
					{"TaxRegNum","#tv_ReportSet.TaxRegNum"},
					{"TaxCode","#tv_ReportSet.TaxCode"},
					{"TaxCodeDescription","#tv_ReportSet.TaxCodeDescription"},
					{"InvTaxInvDate","#tv_ReportSet.InvTaxInvDate"},
					{"InvTaxInvNum","#tv_ReportSet.InvTaxInvNum"},
					{"InvTaxInvSeq","#tv_ReportSet.InvTaxInvSeq"},
					{"InvTaxCustNum","#tv_ReportSet.InvTaxCustNum"},
					{"CustaddrName","#tv_ReportSet.CustaddrName"},
					{"Addr1","#tv_ReportSet.Addr1"},
					{"Addr2","#tv_ReportSet.Addr2"},
					{"Addr3","#tv_ReportSet.Addr3"},
					{"Addr4","#tv_ReportSet.Addr4"},
					{"City","#tv_ReportSet.City"},
					{"State","#tv_ReportSet.State"},
					{"Zip","#tv_ReportSet.Zip"},
					{"Country","#tv_ReportSet.Country"},
					{"ChartDescription","#tv_ReportSet.ChartDescription"},
					{"InvTaxBasis","#tv_ReportSet.InvTaxBasis"},
					{"InvSalesTax","#tv_ReportSet.InvSalesTax"},
					{"Amt_format","#tv_ReportSet.Amt_format"},
					{"Places","#tv_ReportSet.Places"},
					{"ECCode","#tv_ReportSet.ECCode"},
					{"CustomerVATID","#tv_ReportSet.CustomerVATID"},
					{"GLReference","#tv_ReportSet.GLReference"},
					{"DomCurrencyTotFormat","#tv_ReportSet.DomCurrencyTotFormat"},
					{"DomCurrencyTotPlaces","#tv_ReportSet.DomCurrencyTotPlaces"},
					{"HasThai","#tv_ReportSet.HasThai"},
					{"TotalTax","#tv_ReportSet.TotalTax"},
					{"InvHdrTaxDate","#tv_ReportSet.InvHdrTaxDate"},
					{"Longaddr","CAST (NULL AS NVARCHAR)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_ReportSet",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("({2} = '347' AND ECCode IS NULL) OR ({2} = '349' AND ECCode IS NOT NULL AND ECCode BETWEEN {0} AND {1}) OR ({2} = 'Standard')", ECCodeStarting, ECCodeEnding, ReportType),
				orderByClause: collectionLoadRequestFactory.Clause(" CASE WHEN {0} = 'Standard' THEN '' ELSE CustaddrName END, TaxCode, CASE WHEN {1} = 'G' THEN GLReference ELSE '' END, InvTaxInvDate, InvTaxInvNum, InvTaxInvSeq", ReportType, SortBy));
			var tv_ReportSetLoadResponse = this.appDB.Load(tv_ReportSetLoadRequest);
			#endregion  LoadToRecord

			foreach (var tv_ReportSetItem in tv_ReportSetLoadResponse.Items)
			{
				tv_ReportSetItem.SetValue<string>("Addr", tv_ReportSetItem.GetValue<string>("Addr"));
				tv_ReportSetItem.SetValue<string>("TaxIdLabel", tv_ReportSetItem.GetValue<string>("TaxIdLabel"));
				tv_ReportSetItem.SetValue<string>("TaxRegNum", tv_ReportSetItem.GetValue<string>("TaxRegNum"));
				tv_ReportSetItem.SetValue<string>("TaxCode", tv_ReportSetItem.GetValue<string>("TaxCode"));
				tv_ReportSetItem.SetValue<string>("TaxCodeDescription", tv_ReportSetItem.GetValue<string>("TaxCodeDescription"));
				tv_ReportSetItem.SetValue<DateTime?>("InvTaxInvDate", tv_ReportSetItem.GetValue<DateTime?>("InvTaxInvDate"));
				tv_ReportSetItem.SetValue<string>("InvTaxInvNum", tv_ReportSetItem.GetValue<string>("InvTaxInvNum"));
				tv_ReportSetItem.SetValue<int?>("InvTaxInvSeq", tv_ReportSetItem.GetValue<int?>("InvTaxInvSeq"));
				tv_ReportSetItem.SetValue<string>("InvTaxCustNum", tv_ReportSetItem.GetValue<string>("InvTaxCustNum"));
				tv_ReportSetItem.SetValue<string>("CustaddrName", tv_ReportSetItem.GetValue<string>("CustaddrName"));
				tv_ReportSetItem.SetValue<string>("Addr1", tv_ReportSetItem.GetValue<string>("Addr1"));
				tv_ReportSetItem.SetValue<string>("Addr2", tv_ReportSetItem.GetValue<string>("Addr2"));
				tv_ReportSetItem.SetValue<string>("Addr3", tv_ReportSetItem.GetValue<string>("Addr3"));
				tv_ReportSetItem.SetValue<string>("Addr4", tv_ReportSetItem.GetValue<string>("Addr4"));
				tv_ReportSetItem.SetValue<string>("City", tv_ReportSetItem.GetValue<string>("City"));
				tv_ReportSetItem.SetValue<string>("State", tv_ReportSetItem.GetValue<string>("State"));
				tv_ReportSetItem.SetValue<string>("Zip", tv_ReportSetItem.GetValue<string>("Zip"));
				tv_ReportSetItem.SetValue<string>("Country", tv_ReportSetItem.GetValue<string>("Country"));
				tv_ReportSetItem.SetValue<string>("ChartDescription", tv_ReportSetItem.GetValue<string>("ChartDescription"));
				tv_ReportSetItem.SetValue<decimal?>("InvTaxBasis", tv_ReportSetItem.GetValue<decimal?>("InvTaxBasis"));
				tv_ReportSetItem.SetValue<decimal?>("InvSalesTax", tv_ReportSetItem.GetValue<decimal?>("InvSalesTax"));
				tv_ReportSetItem.SetValue<string>("Amt_format", tv_ReportSetItem.GetValue<string>("Amt_format"));
				tv_ReportSetItem.SetValue<int?>("Places", tv_ReportSetItem.GetValue<int?>("Places"));
				tv_ReportSetItem.SetValue<string>("ECCode", tv_ReportSetItem.GetValue<string>("ECCode"));
				tv_ReportSetItem.SetValue<string>("CustomerVATID", tv_ReportSetItem.GetValue<string>("CustomerVATID"));
				tv_ReportSetItem.SetValue<string>("GLReference", tv_ReportSetItem.GetValue<string>("GLReference"));
				tv_ReportSetItem.SetValue<string>("DomCurrencyTotFormat", tv_ReportSetItem.GetValue<string>("DomCurrencyTotFormat"));
				tv_ReportSetItem.SetValue<int?>("DomCurrencyTotPlaces", tv_ReportSetItem.GetValue<int?>("DomCurrencyTotPlaces"));
				tv_ReportSetItem.SetValue<int?>("HasThai", tv_ReportSetItem.GetValue<int?>("HasThai"));
				tv_ReportSetItem.SetValue<decimal?>("TotalTax", tv_ReportSetItem.GetValue<decimal?>("TotalTax"));
				tv_ReportSetItem.SetValue<DateTime?>("InvHdrTaxDate", tv_ReportSetItem.GetValue<DateTime?>("InvHdrTaxDate"));
				tv_ReportSetItem.SetValue<string>("Longaddr", this.iMultiLineAddress.MultiLineAddressSp(
					null,
					tv_ReportSetItem.GetValue<string>("Addr1"),
					tv_ReportSetItem.GetValue<string>("Addr2"),
					tv_ReportSetItem.GetValue<string>("Addr3"),
					tv_ReportSetItem.GetValue<string>("Addr4"),
					tv_ReportSetItem.GetValue<string>("City"),
					tv_ReportSetItem.GetValue<string>("State"),
					tv_ReportSetItem.GetValue<string>("Zip"),
					tv_ReportSetItem.GetValue<string>("Country"),
					null));
			};

			Data = tv_ReportSetLoadResponse;

			this.transactionFactory.CommitTransaction("");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_SalesVATRegisterSp(
			string AltExtGenSp,
			string TaxCodeStarting = null,
			string TaxCodeEnding = null,
			DateTime? TaxPeriodDateStarting = null,
			DateTime? TaxPeriodDateEnding = null,
			string InvoiceStarting = null,
			string InvoiceEnding = null,
			int? TaxPeriodDateStartingOffset = null,
			int? TaxPeriodDateEndingOffset = null,
			string Description = null,
			int? DisplayHeader = null,
			string ECCodeStarting = null,
			string ECCodeEnding = null,
			string ReportType = null,
			int? DisplaySummaryInvoice = null,
			string SortBy = null,
			string pSite = null)
		{
			TaxCodeType _TaxCodeStarting = TaxCodeStarting;
			TaxCodeType _TaxCodeEnding = TaxCodeEnding;
			DateType _TaxPeriodDateStarting = TaxPeriodDateStarting;
			DateType _TaxPeriodDateEnding = TaxPeriodDateEnding;
			InvNumType _InvoiceStarting = InvoiceStarting;
			InvNumType _InvoiceEnding = InvoiceEnding;
			DateOffsetType _TaxPeriodDateStartingOffset = TaxPeriodDateStartingOffset;
			DateOffsetType _TaxPeriodDateEndingOffset = TaxPeriodDateEndingOffset;
			DescriptionType _Description = Description;
			ListYesNoType _DisplayHeader = DisplayHeader;
			EcCodeType _ECCodeStarting = ECCodeStarting;
			EcCodeType _ECCodeEnding = ECCodeEnding;
			StringType _ReportType = ReportType;
			ListYesNoType _DisplaySummaryInvoice = DisplaySummaryInvoice;
			SortDirectionPlusType _SortBy = SortBy;
			SiteType _pSite = pSite;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "TaxCodeStarting", _TaxCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxCodeEnding", _TaxCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPeriodDateStarting", _TaxPeriodDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPeriodDateEnding", _TaxPeriodDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceStarting", _InvoiceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceEnding", _InvoiceEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPeriodDateStartingOffset", _TaxPeriodDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxPeriodDateEndingOffset", _TaxPeriodDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECCodeStarting", _ECCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECCodeEnding", _ECCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportType", _ReportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplaySummaryInvoice", _DisplaySummaryInvoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);

				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

				dtReturn = appDB.ExecuteQuery(cmd);

				var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
				var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

				return (resultSet, returnCode);
			}
		}

	}
}
