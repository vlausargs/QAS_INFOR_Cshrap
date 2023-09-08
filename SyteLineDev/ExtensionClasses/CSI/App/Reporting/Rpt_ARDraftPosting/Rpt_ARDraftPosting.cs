//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARDraftPosting.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.Finance;
using CSI.Codes;

namespace CSI.Reporting
{
	public class Rpt_ARDraftPosting : IRpt_ARDraftPosting
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		ICollectionInsertRequestFactory collectionInsertRequestFactory;
		ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IInitSessionContextWithUser iInitSessionContextWithUser;
		ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICloseSessionContext iCloseSessionContext;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IDropDynamicTable iDropDynamicTable;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        IExistsChecker existsChecker;
		IConvertToUtil convertToUtil;
		IVariableUtil variableUtil;
		IStringUtil stringUtil;
        readonly IIsInteger iIsInteger;
        readonly IGetLabel iGetLabel;
        readonly IEuroInfo iEuroInfo;
        readonly IEuroPart iEuroPart;
        readonly IEuroCnvt iEuroCnvt;
        readonly ICurrPer iCurrPer;
		IMathUtil mathUtil;
		ISQLValueComparerUtil sQLUtil;
        readonly IAcctDB iAcctDB;
        readonly IAcctD iAcctD;
        readonly ILowString lowString;
        readonly IHighString highString;
        readonly IRpt_ARDraftPostingIsNumberInvoice rpt_ARDraftPostingIsNumberInvoice;
        public Rpt_ARDraftPosting(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IInitSessionContextWithUser iInitSessionContextWithUser,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			IDropDynamicTable iDropDynamicTable,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			IIsInteger iIsInteger,
			IGetLabel iGetLabel,
			IEuroInfo iEuroInfo,
			IEuroPart iEuroPart,
			IEuroCnvt iEuroCnvt,
			ICurrPer iCurrPer,
			IMathUtil mathUtil,
			ISQLValueComparerUtil sQLUtil,
			IAcctDB iAcctDB,
			IAcctD iAcctD,
            ILowString lowString,
            IHighString highString,
            IRpt_ARDraftPostingIsNumberInvoice rpt_ARDraftPostingIsNumberInvoice)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.iInitSessionContextWithUser = iInitSessionContextWithUser;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.iDropDynamicTable = iDropDynamicTable;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.iIsInteger = iIsInteger;
			this.iGetLabel = iGetLabel;
			this.iEuroInfo = iEuroInfo;
			this.iEuroPart = iEuroPart;
			this.iEuroCnvt = iEuroCnvt;
			this.iCurrPer = iCurrPer;
			this.mathUtil = mathUtil;
			this.sQLUtil = sQLUtil;
			this.iAcctDB = iAcctDB;
			this.iAcctD = iAcctD;
            this.highString = highString;
            this.lowString = lowString;
            this.rpt_ARDraftPostingIsNumberInvoice = rpt_ARDraftPostingIsNumberInvoice;
        }

		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ARDraftPostingSp(
			int? PDisplayDetail = null,
			string PStartingCustomer = null,
			string PEndingCustomer = null,
			string pStartingBankCode = null,
			string pEndingBankCode = null,
			DateTime? pStartingDueDate = null,
			DateTime? pEndingDueDate = null,
			int? pStartingDraftNumber = null,
			int? pEndingDraftNumber = null,
			int? PDisplayHeader = null,
			string PSessionIDChar = null,
			string pSite = null,
			string BGUser = null)
		{
			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			Guid? RptSessionID = null;
			Guid? PSessionID = null;
			ICollectionLoadRequest TArpmtCrsLoadRequestForCursor = null;
			ICollectionLoadResponse TArpmtCrsLoadResponseForCursor = null;
			int TArpmtCrs_CursorFetch_Status = -1;
			int TArpmtCrs_CursorCounter = -1;
			ICollectionLoadRequest TArpmtdCrsLoadRequestForCursor = null;
			ICollectionLoadResponse TArpmtdCrsLoadResponseForCursor = null;
			int TArpmtdCrs_CursorFetch_Status = -1;
			int TArpmtdCrs_CursorCounter = -1;
			DecimalPlacesType _TEPlaces = DBNull.Value;
			int? TEPlaces = null;
			AcctType _TArparmsDraftReceivableAcct = DBNull.Value;
			string TArparmsDraftReceivableAcct = null;
			string TArpmtCustNum = null;
			decimal? TArpmtExchRate = null;
			decimal? TArpmtForCheckAmt = null;
			decimal? TArpmtDomCheckAmt = null;
			int? TArpmtCheckNum = null;
			string TArpmtType = null;
			string TArpmtBankCode = null;
			DateTime? TArpmtRecptDate = null;
			DateTime? TArpmtDueDate = null;
			string TArpmtRef = null;
			string TArpmtDescription = null;
			CurrCodeType _TCustaddrCurrCode = DBNull.Value;
			string TCustaddrCurrCode = null;
			NameType _TCustAddrName = DBNull.Value;
			string TCustAddrName = null;
			CurrCodeType _TBankHdrCurrCode = DBNull.Value;
			string TBankHdrCurrCode = null;
			UnitCode1Type _TBankHdrAcctUnit1 = DBNull.Value;
			string TBankHdrAcctUnit1 = null;
			UnitCode2Type _TBankHdrAcctUnit2 = DBNull.Value;
			string TBankHdrAcctUnit2 = null;
			UnitCode3Type _TBankHdrAcctUnit3 = DBNull.Value;
			string TBankHdrAcctUnit3 = null;
			UnitCode4Type _TBankHdrAcctUnit4 = DBNull.Value;
			string TBankHdrAcctUnit4 = null;
			CurrCodeType _TCurrParmsCurrCode = DBNull.Value;
			string TCurrParmsCurrCode = null;
			RowPointer _TArtranRowpointer = DBNull.Value;
			Guid? TArtranRowpointer = null;
			ArtranTypeType _TArtranType = DBNull.Value;
			string TArtranType = null;
			AcctType _TArtranAcct = DBNull.Value;
			string TArtranAcct = null;
			UnitCode1Type _TArtranAcctUnit1 = DBNull.Value;
			string TArtranAcctUnit1 = null;
			UnitCode2Type _TArtranAcctUnit2 = DBNull.Value;
			string TArtranAcctUnit2 = null;
			UnitCode3Type _TArtranAcctUnit3 = DBNull.Value;
			string TArtranAcctUnit3 = null;
			UnitCode4Type _TArtranAcctUnit4 = DBNull.Value;
			string TArtranAcctUnit4 = null;
			decimal? TRate = null;
			decimal? TcAmtFAmount = null;
			decimal? TDomTcAmtAmount = null;
			int? TPaymentDomestic = null;
			string TUnitCd1 = null;
			string TUnitCd2 = null;
			string TUnitCd3 = null;
			string TUnitCd4 = null;
			AcctType _TChartAcct = DBNull.Value;
			string TChartAcct = null;
			RowPointer _TCustomerRowpointer = DBNull.Value;
			Guid? TCustomerRowpointer = null;
			RowPointer _TEndtypeRowpointer = DBNull.Value;
			Guid? TEndtypeRowpointer = null;
			AcctType _TEndtypeDraftReceivableAcct = DBNull.Value;
			string TEndtypeDraftReceivableAcct = null;
			string TAcct = null;
			EndUserTypeType _TCustomerEndUserType = DBNull.Value;
			string TCustomerEndUserType = null;
			decimal? TEuroAmt = null;
			int? TStdLo = null;
			decimal? TStdDe = null;
			string TDist = null;
			string TError = null;
			int? TEuroUser = null;
			int? TEuroExists = null;
			int? TBaseEuro = null;
			string TEuroCurr = null;
			AcctType _TBankHdrAcct = DBNull.Value;
			string TBankHdrAcct = null;
			int? TTranID = null;
			int? THasDetail = null;
			decimal? TcAmtApplied = null;
			decimal? TcAmtFApplied = null;
			decimal? TNetEffectAr = null;
			string TArpmtdInvNum = null;
			string TType = null;
			decimal? TArpmtdDomAmtApplied = null;
			string TInv = null;
			decimal? TArpmtdForAmtApplied = null;
			decimal? TArpmtdForDiscAmt = null;
			decimal? TcAmtFAmtApplied = null;
			decimal? TArpmtdDomDiscAmt = null;
			decimal? TDomTcAmtAmtApplied = null;
			decimal? TcTotTReappl = null;
			decimal? TcAmtFAmtDisc = null;
			decimal? TArpmtdForAllowAmt = null;
			decimal? TDomTcAmtAmtDisc = null;
			decimal? TArpmtdDomAllowAmt = null;
			string TArpmtdSite = null;
			decimal? TcAmtFAmtAllow = null;
			decimal? TDomTcAmtAmtAllow = null;
			string TArpmtdDepositAcct = null;
			decimal? TcTotTNonAr = null;
			string TDiscLabel = null;
			string TArpmtdDepositAcctUnit1 = null;
			string TArpmtdDepositAcctUnit2 = null;
			string TArpmtdDepositAcctUnit3 = null;
			string TArpmtdDepositAcctUnit4 = null;
			string TArpmtdDiscAcct = null;
			string TArpmtdDiscAcctUnit1 = null;
			string TArpmtdDiscAcctUnit2 = null;
			string TArpmtdDiscAcctUnit3 = null;
			string TArpmtdDiscAcctUnit4 = null;
			decimal? TcTotTCheckAmt = null;
			decimal? TcTotTTotAllow = null;
			string TAllowLabel = null;
			string TArpmtdAllowAcct = null;
			decimal? TcTotTWireAmt = null;
			string TArpmtdAllowAcctUnit1 = null;
			string TArpmtdAllowAcctUnit2 = null;
			string TArpmtdAllowAcctUnit3 = null;
			string TArpmtdAllowAcctUnit4 = null;
			decimal? TcTotTDraftAmt = null;
			decimal? TcTotTAdjAmt = null;
			decimal? TcTotTTotApplied = null;
			decimal? TcTotTTotDisc = null;
			decimal? TcTotTNet = null;
			decimal? TcTotWarn = null;
			string ARPayPostCustNum = null;
			string ARPayPostBankCode = null;
			string ARPayPostType = null;
			int? ARPayPostCheckNum = null;
			int? Severity = null;
			string Infobar = null;
			string CreditAmt1Label = null;
			string CreditAmt2Label = null;
			string AllowAmtLabel = null;
			string DomDiscAmtLabel = null;
			int? CurrentPeriod = null;
			decimal? PaymentAmtApplied = null;
			decimal? TArpmtPaymentCheckAmount = null;
			string PaymentCheckCode = null;
			ICollectionLoadRequest ARPayPostCrsLoadRequestForCursor = null;
			ICollectionLoadResponse ARPayPostCrsLoadResponseForCursor = null;
			int ARPayPostCrs_CursorFetch_Status = -1;
			int ARPayPostCrs_CursorCounter = -1;
			string TDist1 = null;

			if (existsChecker.Exists(
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ARDraftPostingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						[SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN ");

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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_ARDraftPostingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_ARDraftPostingSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(
					tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("")))
				{
					//BEGIN
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
					this.appDB.Load(tv_ALTGEN1LoadRequest);
					ALTGEN_SpName = _ALTGEN_SpName;
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_Rpt_ARDraftPostingSp(_ALTGEN_SpName,
						PDisplayDetail,
						PStartingCustomer,
						PEndingCustomer,
						pStartingBankCode,
						pEndingBankCode,
						pStartingDueDate,
						pEndingDueDate,
						pStartingDraftNumber,
						pEndingDraftNumber,
						PDisplayHeader,
						PSessionIDChar,
						pSite,
						BGUser);
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
							{"col0","1"},
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
					//END
				}
				//END
			}

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_ARDraftPostingSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_ARDraftPostingSp("dbo.EXTGEN_Rpt_ARDraftPostingSp",
					PDisplayDetail,
					PStartingCustomer,
					PEndingCustomer,
					pStartingBankCode,
					pEndingBankCode,
					pStartingDueDate,
					pEndingDueDate,
					pStartingDraftNumber,
					pEndingDraftNumber,
					PDisplayHeader,
					PSessionIDChar,
					pSite,
					BGUser);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("ARDraftPostingReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			}
			PSessionID = string.IsNullOrEmpty(PSessionIDChar) ? default(Guid?) : new Guid(PSessionIDChar);

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextWithUserSp
			var InitSessionContextWithUser = this.iInitSessionContextWithUser.InitSessionContextWithUserSp(ContextName: "Rpt_ARDraftPostingSp"
				, SessionID: RptSessionID
				, Site: pSite
				, UserName: BGUser);
			RptSessionID = InitSessionContextWithUser.SessionID;

			#endregion ExecuteMethodCall

			if (PDisplayHeader == null)
			{
				PDisplayHeader = 1;
			}
			if (PDisplayDetail == null)
			{
				PDisplayDetail = 1;
			}
			PStartingCustomer = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CustNumType", PStartingCustomer), this.lowString.LowStringFn("CustNumType"));
			PEndingCustomer = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("CustNumType", PEndingCustomer), this.highString.HighStringFn("CustNumType"));
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @Header TABLE (
					TranID                 INT            ,
					CustNum                CustNumType    ,
					PaymentType            ArpmtTypeType  ,
					BankCode               BankCodeType   ,
					Payment                ArCheckNumType ,
					BankCurrCode           CurrCodeType   ,
					AmtFAmount             AmountType     ,
					RecptDate              DateType       ,
					DueDate                DateType       ,
					Reference              ReferenceType  ,
					CashAcct               AcctType       ,
					UnitCd1                UnitCode1Type  ,
					UnitCd2                UnitCode2Type  ,
					UnitCd3                UnitCode3Type  ,
					UnitCd4                UnitCode4Type  ,
					CustaddrName           NameType       ,
					CurrParmsCurrCode      CurrCodeType   ,
					DomTcAmtAmount         AmountType     ,
					ExchRate               ExchRateType   ,
					ArpmtDescription       DescriptionType,
					AcctDescription        DescriptionType,
					EuroCurr               CurrCodeType   ,
					EuroAmt                AmountType     ,
					CurrentPeriod          TINYINT        ,
					TotalCheckAmount       AmtTotType     ,
					TotalWireAmount        AmtTotType     ,
					TotalDraftAmount       AmtTotType     ,
					TotalAdjustAmount      AmtTotType     ,
					TotalReApplicationAmt  AmtTotType     ,
					TotalApplied           AmtTotType     ,
					TotalNonARAmount       AmtTotType     ,
					TotalDiscount          AmtTotType     ,
					TotalAllowance         AmtTotType     ,
					NetEffect              AmtTotType     ,
					TotalWarningAppliedAmt AmtTotType     ,
					PaymentCheckAmount     AmountType     ,
					PaymentCheckCode       CurrCodeType   );
				SELECT * into #tv_Header from @Header ");

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @Detail TABLE (
					DetailTranID           INT          ,
					InvoiceType            NVARCHAR (30),
					InvoiceNum             InvNumType   ,
					AppliedLabel           NVARCHAR (30),
					AmtFAmtApplied         AmountType   ,
					DomAmtApplied          AmountType   ,
					ArpmtdDepositAcct      AcctType     ,
					ArpmtdDepositAcctUnit1 UnitCode1Type,
					ArpmtdDepositAcctUnit2 UnitCode2Type,
					ArpmtdDepositAcctUnit3 UnitCode3Type,
					ArpmtdDepositAcctUnit4 UnitCode4Type,
					ArpmtdDepositAcctDesc  NVARCHAR (40),
					CreditLabel1           NVARCHAR (30),
					AmtFAmtCredit          AmountType   ,
					DomAmtFAmtCredit       AmountType   ,
					ArpmtdDiscAcct         AcctType     ,
					ArpmtdDiscAcctUnit1    UnitCode1Type,
					ArpmtdDiscAcctUnit2    UnitCode2Type,
					ArpmtdDiscAcctUnit3    UnitCode3Type,
					ArpmtdDiscAcctUnit4    UnitCode4Type,
					ArpmtdDiscAcctDesc     NVARCHAR (40),
					CreditLabel2           NVARCHAR (30),
					AmtFAmtAllow           AmountType   ,
					DomAmtFAmtAllow        AmountType   ,
					ArpmtdAllowAcct        AcctType     ,
					ArpmtdAllowAcctUnit1   UnitCode1Type,
					ArpmtdAllowAcctUnit2   UnitCode2Type,
					ArpmtdAllowAcctUnit3   UnitCode3Type,
					ArpmtdAllowAcctUnit4   UnitCode4Type,
					ArpmtdAllowAcctDesc    NVARCHAR (40),
					CurrParmsCurrCode      CurrCodeType ,
					CustAddrCurrCode       CurrCodeType ,
					PaymentCheckAmount     AmountType   ,
					PaymentCheckCode       CurrCodeType );
				SELECT * into #tv_Detail from @Detail ");

			PDisplayDetail = 1;
			Severity = 0;
			TcTotTCheckAmt = 0;
			TcTotTWireAmt = 0;
			TcTotTDraftAmt = 0;
			TcTotTAdjAmt = 0;
			TcTotTReappl = 0;
			TcTotTTotApplied = 0;
			TcTotTNonAr = 0;
			TcTotTTotDisc = 0;
			TcTotTTotAllow = 0;
			TcTotTNet = 0;
			TcTotWarn = 0;
			TcAmtApplied = 0;
			TcAmtFApplied = 0;
			PaymentAmtApplied = 0;
			TArpmtPaymentCheckAmount = 0;
			CreditAmt1Label = this.iGetLabel.GetLabelFn("@!CreditAmt1");
			CreditAmt2Label = this.iGetLabel.GetLabelFn("@!CreditAmt2");
			AllowAmtLabel = this.iGetLabel.GetLabelFn("@arpmtd.dom_allow_amt");
			DomDiscAmtLabel = this.iGetLabel.GetLabelFn("@arpmtd.dom_disc_amt");

			#region CRUD LoadToVariable
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TCurrParmsCurrCode,"currparms.curr_code"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName: "currparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(currparmsLoadRequest);
			TCurrParmsCurrCode = _TCurrParmsCurrCode;
			#endregion  LoadToVariable

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: EuroInfoSp
			var EuroInfo = this.iEuroInfo.EuroInfoSp(DispMsg: 0
				, PEuroUser: TEuroUser
				, PEuroExists: TEuroExists
				, PBaseEuro: TBaseEuro
				, PEuroCurr: TEuroCurr
				, InfoBar: TError);
			TEuroUser = EuroInfo.PEuroUser;
			TEuroExists = EuroInfo.PEuroExists;
			TBaseEuro = EuroInfo.PBaseEuro;
			TEuroCurr = EuroInfo.PEuroCurr;
			TError = EuroInfo.InfoBar;

			#endregion ExecuteMethodCall

			TEPlaces = 2;
			if (sQLUtil.SQLEqual(TEuroExists, 1) == true)
			{
				//BEGIN
				#region CRUD LoadToVariable
				var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_TEPlaces,"currency.places"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "currency",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = {0}", TEuroCurr),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				this.appDB.Load(currencyLoadRequest);
				TEPlaces = _TEPlaces;
				#endregion  LoadToVariable
				//END
			}

			#region CRUD LoadToVariable
			var arparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_TArparmsDraftReceivableAcct,"arparms.draft_receivable_acct"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
				tableName: "arparms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(arparmsLoadRequest);
			TArparmsDraftReceivableAcct = _TArparmsDraftReceivableAcct;
			#endregion  LoadToVariable

			TTranID = 0;
			#region Cursor Statement

			#region CRUD LoadToRecord
			ARPayPostCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"tmp_arpaypost.cust_num","tmp_arpaypost.cust_num"},
					{"tmp_arpaypost.bank_code","tmp_arpaypost.bank_code"},
					{"tmp_arpaypost.type","tmp_arpaypost.type"},
					{"tmp_arpaypost.check_num","tmp_arpaypost.check_num"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "tmp_arpaypost",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("tmp_arpaypost.SessionId = {0} AND tmp_arpaypost.printed = 0", PSessionID),
				orderByClause: collectionLoadRequestFactory.Clause(" tmp_arpaypost.check_num ASC"));
			#endregion  LoadToRecord

			#endregion Cursor Statement
			ARPayPostCrsLoadResponseForCursor = this.appDB.Load(ARPayPostCrsLoadRequestForCursor);
			ARPayPostCrs_CursorFetch_Status = ARPayPostCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			ARPayPostCrs_CursorCounter = -1;

			while (sQLUtil.SQLBool(sQLUtil.SQLEqual(Severity, 0)))
			{
				//BEGIN
				ARPayPostCrs_CursorCounter++;
				if (ARPayPostCrsLoadResponseForCursor.Items.Count > ARPayPostCrs_CursorCounter)
				{
					ARPayPostCustNum = ARPayPostCrsLoadResponseForCursor.Items[ARPayPostCrs_CursorCounter].GetValue<string>(0);
					ARPayPostBankCode = ARPayPostCrsLoadResponseForCursor.Items[ARPayPostCrs_CursorCounter].GetValue<string>(1);
					ARPayPostType = ARPayPostCrsLoadResponseForCursor.Items[ARPayPostCrs_CursorCounter].GetValue<string>(2);
					ARPayPostCheckNum = ARPayPostCrsLoadResponseForCursor.Items[ARPayPostCrs_CursorCounter].GetValue<int?>(3);
				}
				ARPayPostCrs_CursorFetch_Status = (ARPayPostCrs_CursorCounter == ARPayPostCrsLoadResponseForCursor.Items.Count ? -1 : 0);

				if (sQLUtil.SQLEqual(ARPayPostCrs_CursorFetch_Status, -1) == true)
				{
					break;
				}

				#region CRUD LoadToRecord
				TArpmtCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"cust_num","tmp_arpmt.cust_num"},
						{"col0","CAST (NULL AS DECIMAL)"},
						{"for_check_amt","tmp_arpmt.for_check_amt"},
						{"dom_check_amt","tmp_arpmt.dom_check_amt"},
						{"check_num","tmp_arpmt.check_num"},
						{"type","tmp_arpmt.type"},
						{"bank_code","tmp_arpmt.bank_code"},
						{"recpt_date","tmp_arpmt.recpt_date"},
						{"due_date","tmp_arpmt.due_date"},
						{"ref","tmp_arpmt.ref"},
						{"description","tmp_arpmt.description"},
						{"payment_check_amt","tmp_arpmt.payment_check_amt"},
						{"payment_curr_code","tmp_arpmt.payment_curr_code"},
						{"u0","tmp_arpmt.payment_exch_rate"},
						{"u1","tmp_arpmt.exch_rate"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "tmp_arpmt",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("tmp_arpmt.ProcessId = {2} AND tmp_arpmt.cust_num = {1} AND tmp_arpmt.check_num = {0}", ARPayPostCheckNum, ARPayPostCustNum, PSessionID),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				#endregion  LoadToRecord

				TArpmtCrsLoadResponseForCursor = this.appDB.Load(TArpmtCrsLoadRequestForCursor);
				foreach (var tmp_arpmtItem in TArpmtCrsLoadResponseForCursor.Items)
				{
					tmp_arpmtItem.SetValue<string>("cust_num", tmp_arpmtItem.GetValue<string>("cust_num"));
					tmp_arpmtItem.SetValue<decimal?>("col0", stringUtil.IsNull(tmp_arpmtItem.GetValue<decimal?>("u0"), tmp_arpmtItem.GetValue<decimal?>("u1")));
					tmp_arpmtItem.SetValue<decimal?>("for_check_amt", tmp_arpmtItem.GetValue<decimal?>("for_check_amt"));
					tmp_arpmtItem.SetValue<decimal?>("dom_check_amt", tmp_arpmtItem.GetValue<decimal?>("dom_check_amt"));
					tmp_arpmtItem.SetValue<int?>("check_num", tmp_arpmtItem.GetValue<int?>("check_num"));
					tmp_arpmtItem.SetValue<string>("type", tmp_arpmtItem.GetValue<string>("type"));
					tmp_arpmtItem.SetValue<string>("bank_code", tmp_arpmtItem.GetValue<string>("bank_code"));
					tmp_arpmtItem.SetValue<DateTime?>("recpt_date", tmp_arpmtItem.GetValue<DateTime?>("recpt_date"));
					tmp_arpmtItem.SetValue<DateTime?>("due_date", tmp_arpmtItem.GetValue<DateTime?>("due_date"));
					tmp_arpmtItem.SetValue<string>("ref", tmp_arpmtItem.GetValue<string>("ref"));
					tmp_arpmtItem.SetValue<string>("description", tmp_arpmtItem.GetValue<string>("description"));
					tmp_arpmtItem.SetValue<decimal?>("payment_check_amt", tmp_arpmtItem.GetValue<decimal?>("payment_check_amt"));
					tmp_arpmtItem.SetValue<string>("payment_curr_code", tmp_arpmtItem.GetValue<string>("payment_curr_code"));
				};

				TArpmtCrs_CursorFetch_Status = TArpmtCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				TArpmtCrs_CursorCounter = -1;

				while (sQLUtil.SQLBool((sQLUtil.SQLEqual(1, 1))))
				{
					//BEGIN
					TArpmtCrs_CursorCounter++;
					if (TArpmtCrsLoadResponseForCursor.Items.Count > TArpmtCrs_CursorCounter)
					{
						TArpmtCustNum = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<string>(0);
						TArpmtExchRate = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<decimal?>(1);
						TArpmtForCheckAmt = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<decimal?>(2);
						TArpmtDomCheckAmt = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<decimal?>(3);
						TArpmtCheckNum = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<int?>(4);
						TArpmtType = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<string>(5);
						TArpmtBankCode = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<string>(6);
						TArpmtRecptDate = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<DateTime?>(7);
						TArpmtDueDate = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<DateTime?>(8);
						TArpmtRef = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<string>(9);
						TArpmtDescription = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<string>(10);
						TArpmtPaymentCheckAmount = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<decimal?>(11);
						PaymentCheckCode = TArpmtCrsLoadResponseForCursor.Items[TArpmtCrs_CursorCounter].GetValue<string>(12);
					}
					TArpmtCrs_CursorFetch_Status = (TArpmtCrs_CursorCounter == TArpmtCrsLoadResponseForCursor.Items.Count ? -1 : 0);

					if (sQLUtil.SQLNotEqual(TArpmtCrs_CursorFetch_Status, 0) == true)
					{
						break;
					}
					CurrentPeriod = (int?)(this.iCurrPer.CurrPerSP(TArpmtRecptDate));
					TTranID = (int?)(TTranID + 1);

					#region CRUD LoadToVariable
					var custaddrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_TCustaddrCurrCode,"custaddr.curr_code"},
							{_TCustAddrName,"custaddr.name"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "custaddr",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("custaddr.cust_num = {0} AND custaddr.cust_seq = 0", TArpmtCustNum),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					this.appDB.Load(custaddrLoadRequest);
					TCustaddrCurrCode = _TCustaddrCurrCode;
					TCustAddrName = _TCustAddrName;
					#endregion  LoadToVariable

					#region CRUD LoadToVariable
					var bank_hdrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_TBankHdrCurrCode,"bank_hdr.curr_code"},
							{_TBankHdrAcctUnit1,"bank_hdr.acct_unit1"},
							{_TBankHdrAcctUnit2,"bank_hdr.acct_unit2"},
							{_TBankHdrAcctUnit3,"bank_hdr.acct_unit3"},
							{_TBankHdrAcctUnit4,"bank_hdr.acct_unit4"},
							{_TBankHdrAcct,"bank_hdr.acct"},
						},
						loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "bank_hdr",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("bank_hdr.bank_code = {0}", TArpmtBankCode),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					this.appDB.Load(bank_hdrLoadRequest);
					TBankHdrCurrCode = _TBankHdrCurrCode;
					TBankHdrAcctUnit1 = _TBankHdrAcctUnit1;
					TBankHdrAcctUnit2 = _TBankHdrAcctUnit2;
					TBankHdrAcctUnit3 = _TBankHdrAcctUnit3;
					TBankHdrAcctUnit4 = _TBankHdrAcctUnit4;
					TBankHdrAcct = _TBankHdrAcct;
					#endregion  LoadToVariable

					TRate = (decimal?)(((sQLUtil.SQLEqual(TArpmtExchRate, 0) == true ? null : TArpmtExchRate)));
					TcAmtFAmount = TArpmtForCheckAmt;
					TDomTcAmtAmount = TArpmtDomCheckAmt;
					TPaymentDomestic = convertToUtil.ToInt32(((sQLUtil.SQLEqual(PaymentCheckCode, TCurrParmsCurrCode) == true ? 1 : 0)));
					TArtranRowpointer = null;
					TArtranType = null;
					TArtranAcct = null;
					TArtranAcctUnit1 = null;
					TArtranAcctUnit2 = null;
					TArtranAcctUnit3 = null;
					TArtranAcctUnit4 = null;
					if (sQLUtil.SQLEqual(TPaymentDomestic, 1) == true)
					{
						TPaymentDomestic = convertToUtil.ToInt32(((sQLUtil.SQLEqual(TBankHdrCurrCode, TCurrParmsCurrCode) == true ? 1 : 0)));
					}

					#region CRUD LoadToVariable
					var artranLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_TArtranRowpointer,"artran.rowpointer"},
							{_TArtranType,"artran.type"},
							{_TArtranAcct,"artran.acct"},
							{_TArtranAcctUnit1,"artran.acct_unit1"},
							{_TArtranAcctUnit2,"artran.acct_unit2"},
							{_TArtranAcctUnit3,"artran.acct_unit3"},
							{_TArtranAcctUnit4,"artran.acct_unit4"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "artran",
						fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("artran.cust_num = {1} AND artran.inv_num = '0' AND artran.inv_seq = {0}", TArpmtCheckNum, TArpmtCustNum),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					this.appDB.Load(artranLoadRequest);
					TArtranRowpointer = _TArtranRowpointer;
					TArtranType = _TArtranType;
					TArtranAcct = _TArtranAcct;
					TArtranAcctUnit1 = _TArtranAcctUnit1;
					TArtranAcctUnit2 = _TArtranAcctUnit2;
					TArtranAcctUnit3 = _TArtranAcctUnit3;
					TArtranAcctUnit4 = _TArtranAcctUnit4;
					#endregion  LoadToVariable

					TChartAcct = "";
					if (TArtranRowpointer != null && sQLUtil.SQLNotEqual(stringUtil.CharIndex(TArtranType, "CP"), 0) == true)
					{
						//BEGIN
						TcTotTReappl = (decimal?)(TcTotTReappl + TDomTcAmtAmount);

						#region CRUD LoadToVariable
						var chartLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_TChartAcct,"chart.acct"},
							},
							loadForChange: false,
                            lockingType: LockingType.None,
                            tableName: "chart",
							fromClause: collectionLoadRequestFactory.Clause(""),
							whereClause: collectionLoadRequestFactory.Clause("chart.acct = {0}", TArtranAcct),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						this.appDB.Load(chartLoadRequest);
						TChartAcct = _TChartAcct;
						#endregion  LoadToVariable

						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: AcctDSp
						var AcctD = this.iAcctD.AcctDSp(pAccount: TArtranAcct
							, rDescription: TDist);
						TDist = AcctD.rDescription;

						#endregion ExecuteMethodCall

						TUnitCd1 = TArtranAcctUnit1;
						TUnitCd2 = TArtranAcctUnit2;
						TUnitCd3 = TArtranAcctUnit3;
						TUnitCd4 = TArtranAcctUnit4;
						//END
					}
					else
					{
						//BEGIN
						if (sQLUtil.SQLEqual(TArpmtType, "W") == true)
						{
							TcTotTWireAmt = (decimal?)(TcTotTWireAmt + TDomTcAmtAmount);
						}
						else
						{
							if (sQLUtil.SQLEqual(TArpmtType, "D") == true)
							{
								TcTotTDraftAmt = (decimal?)(TcTotTDraftAmt + TDomTcAmtAmount);
							}
							else
							{
								if (sQLUtil.SQLEqual(TArpmtType, "C") == true)
								{
									TcTotTCheckAmt = (decimal?)(TcTotTCheckAmt + TDomTcAmtAmount);
								}
								else
								{
									TcTotTAdjAmt = (decimal?)(TcTotTAdjAmt + TDomTcAmtAmount);
								}
							}
						}

						#region CRUD LoadToVariable
						var chart1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_TChartAcct,"chart.acct"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "chart",
							fromClause: collectionLoadRequestFactory.Clause(""),
							whereClause: collectionLoadRequestFactory.Clause("chart.acct = {0}", TBankHdrAcct),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						this.appDB.Load(chart1LoadRequest);
						TChartAcct = _TChartAcct;
						#endregion  LoadToVariable

						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: AcctDSp
						var AcctD1 = this.iAcctD.AcctDSp(pAccount: TBankHdrAcct
							, rDescription: TDist);
						TDist = AcctD1.rDescription;

						#endregion ExecuteMethodCall

						TUnitCd1 = TBankHdrAcctUnit1;
						TUnitCd2 = TBankHdrAcctUnit2;
						TUnitCd3 = TBankHdrAcctUnit3;
						TUnitCd4 = TBankHdrAcctUnit4;
						//END
					}
					if (sQLUtil.SQLEqual(TChartAcct, "") == true)
					{
						//BEGIN
						TUnitCd1 = "";
						TUnitCd2 = "";
						TUnitCd3 = "";
						TUnitCd4 = "";
						TDist = "";
						//END
					}
					TAcct = TChartAcct;
					if (sQLUtil.SQLEqual(TArpmtType, "D") == true)
					{
						//BEGIN

						#region CRUD LoadToVariable
						var customerLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_TCustomerRowpointer,"customer.rowpointer"},
								{_TCustomerEndUserType,"customer.end_user_type"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            maximumRows: 1,
							tableName: "customer",
							fromClause: collectionLoadRequestFactory.Clause(""),
							whereClause: collectionLoadRequestFactory.Clause("customer.cust_num = {0}", TArpmtCustNum),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						this.appDB.Load(customerLoadRequest);
						TCustomerRowpointer = _TCustomerRowpointer;
						TCustomerEndUserType = _TCustomerEndUserType;
						#endregion  LoadToVariable

						if (TCustomerRowpointer != null && sQLUtil.SQLNotEqual(TCustomerEndUserType, "") == true && TCustomerEndUserType != null)
						{
							//BEGIN
							#region CRUD LoadToVariable
							var endtypeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
								{
									{_TEndtypeRowpointer,"endtype.rowpointer"},
									{_TEndtypeDraftReceivableAcct,"endtype.draft_receivable_acct"},
								},
								loadForChange: false, 
                                lockingType: LockingType.None,
                                maximumRows: 1,
								tableName: "endtype",
								fromClause: collectionLoadRequestFactory.Clause(""),
								whereClause: collectionLoadRequestFactory.Clause("endtype.end_user_type = {0}", TCustomerEndUserType),
								orderByClause: collectionLoadRequestFactory.Clause(""));
							this.appDB.Load(endtypeLoadRequest);
							TEndtypeRowpointer = _TEndtypeRowpointer;
							TEndtypeDraftReceivableAcct = _TEndtypeDraftReceivableAcct;
							#endregion  LoadToVariable

							if (TEndtypeRowpointer != null && TEndtypeDraftReceivableAcct != null && sQLUtil.SQLNotEqual(TEndtypeDraftReceivableAcct, "") == true)
							{
								//BEGIN
								TAcct = TEndtypeDraftReceivableAcct;

								#region CRUD ExecuteMethodCall

								//Please Generate the bounce for this stored procedure: AcctDSp
								var AcctD2 = this.iAcctD.AcctDSp(pAccount: TEndtypeDraftReceivableAcct
									, rDescription: TDist);
								TDist = AcctD2.rDescription;

								#endregion ExecuteMethodCall
								//END
							}
							else
							{
								if (TArparmsDraftReceivableAcct != null && sQLUtil.SQLNotEqual(TArparmsDraftReceivableAcct, "") == true)
								{
									//BEGIN
									TAcct = TArparmsDraftReceivableAcct;

									#region CRUD ExecuteMethodCall

									//Please Generate the bounce for this stored procedure: AcctDSp
									var AcctD3 = this.iAcctD.AcctDSp(pAccount: TArparmsDraftReceivableAcct
										, rDescription: TDist);
									TDist = AcctD3.rDescription;

									#endregion ExecuteMethodCall
									//END
								}
							}
							//END
						}
						else
						{
							if (TArparmsDraftReceivableAcct != null && sQLUtil.SQLNotEqual(TArparmsDraftReceivableAcct, "") == true)
							{
								//BEGIN
								TAcct = TArparmsDraftReceivableAcct;

								#region CRUD ExecuteMethodCall

								//Please Generate the bounce for this stored procedure: AcctDSp
								var AcctD4 = this.iAcctD.AcctDSp(pAccount: TArparmsDraftReceivableAcct
									, rDescription: TDist);
								TDist = AcctD4.rDescription;

								#endregion ExecuteMethodCall
								//END
							}
						}
						//END
					}
					TEuroAmt = 0;
					if (sQLUtil.SQLEqual(TEuroExists, 1) == true)
					{
						//BEGIN
						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: EuroPartSp
						var EuroPart = this.iEuroPart.EuroPartSp(PCurrCode: TBankHdrCurrCode
							, PPartOfEuro: TStdLo);

						#endregion ExecuteMethodCall

						if (sQLUtil.SQLEqual(TStdLo, 1) == true)
						{
							//BEGIN
							TStdDe = convertToUtil.ToDecimal(this.iEuroCnvt.EuroCnvtFn(TcAmtFAmount, TBankHdrCurrCode, 0, 1));
							TEuroAmt = (decimal?)(mathUtil.Round<decimal?>(TStdDe, TEPlaces));
							//END
						}
						else
						{
							//BEGIN
							#region CRUD ExecuteMethodCall

							//Please Generate the bounce for this stored procedure: EuroPartSp
							var EuroPart1 = this.iEuroPart.EuroPartSp(PCurrCode: TCurrParmsCurrCode
								, PPartOfEuro: TStdLo);

							#endregion ExecuteMethodCall

							if (sQLUtil.SQLEqual(TStdLo, 1) == true)
							{
								//BEGIN
								TStdDe = convertToUtil.ToDecimal(this.iEuroCnvt.EuroCnvtFn(TDomTcAmtAmount, TCurrParmsCurrCode, 0, 1));
								TEuroAmt = (decimal?)(mathUtil.Round<decimal?>(TStdDe, TEPlaces));
								//END
							}
							//END
						}
						//END
					}

					#region CRUD LoadResponseWithoutTable
					var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
						{
							{ "TranID", variableUtil.GetValue<int?>(TTranID,true)},
							{ "CustNum", variableUtil.GetValue<string>(TArpmtCustNum,true)},
							{ "PaymentType", variableUtil.GetValue<string>(TArpmtType,true)},
							{ "BankCode", variableUtil.GetValue<string>(TArpmtBankCode,true)},
							{ "Payment", variableUtil.GetValue<int?>(TArpmtCheckNum,true)},
							{ "BankCurrCode", variableUtil.GetValue<string>(TBankHdrCurrCode,true)},
							{ "AmtFAmount", variableUtil.GetValue<decimal?>(TcAmtFAmount,true)},
							{ "RecptDate", variableUtil.GetValue<DateTime?>(TArpmtRecptDate,true)},
							{ "DueDate", variableUtil.GetValue<DateTime?>((sQLUtil.SQLEqual(TArpmtType, "D") == true ? TArpmtDueDate : convertToUtil.ToDateTime<string>(null)),true)},
							{ "Reference", variableUtil.GetValue<string>(TArpmtRef,true)},
							{ "CashAcct", variableUtil.GetValue<string>(TAcct,true)},
							{ "UnitCd1", variableUtil.GetValue<string>(TUnitCd1,true)},
							{ "UnitCd2", variableUtil.GetValue<string>(TUnitCd2,true)},
							{ "UnitCd3", variableUtil.GetValue<string>(TUnitCd3,true)},
							{ "UnitCd4", variableUtil.GetValue<string>(TUnitCd4,true)},
							{ "CustaddrName", variableUtil.GetValue<string>(TCustAddrName,true)},
							{ "CurrParmsCurrCode", variableUtil.GetValue<string>(TCurrParmsCurrCode,true)},
							{ "DomTcAmtAmount", variableUtil.GetValue<decimal?>((sQLUtil.SQLNotEqual(PaymentCheckCode, TCurrParmsCurrCode) == true ? TDomTcAmtAmount : null),true)},
							{ "ExchRate", variableUtil.GetValue<decimal?>((sQLUtil.SQLEqual(TPaymentDomestic, 0) == true ? TArpmtExchRate : null),true)},
							{ "ArpmtDescription", variableUtil.GetValue<string>(TArpmtDescription,true)},
							{ "AcctDescription", variableUtil.GetValue<string>(TDist,true)},
							{ "EuroCurr", variableUtil.GetValue<string>((sQLUtil.SQLNotEqual(TEuroAmt, 0) == true ? TEuroCurr : convertToUtil.ToString<string>(null)),true)},
							{ "EuroAmt", variableUtil.GetValue<decimal?>((sQLUtil.SQLNotEqual(TEuroAmt, 0) == true ? TEuroAmt : null),true)},
							{ "CurrentPeriod", variableUtil.GetValue<int?>(CurrentPeriod,true)},
							{ "PaymentCheckAmount", variableUtil.GetValue<decimal?>(TArpmtPaymentCheckAmount,true)},
							{ "PaymentCheckCode", variableUtil.GetValue<string>(PaymentCheckCode,true)},
						});

					var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
					Data = nonTableLoadResponse;
					#endregion CRUD LoadResponseWithoutTable

					#region CRUD InsertByRecords
					var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Header",
						items: nonTableLoadResponse.Items);

					this.appDB.Insert(nonTableInsertRequest);
					#endregion InsertByRecords

					THasDetail = 0;
					TcAmtApplied = 0;
					TcAmtFApplied = 0;
					TNetEffectAr = 0;
					PaymentAmtApplied = 0;

					#region CRUD LoadToRecord
					TArpmtdCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"tmp_arpmtd.inv_num","tmp_arpmtd.inv_num"},
							{"tmp_arpmtd.dom_amt_applied","tmp_arpmtd.dom_amt_applied"},
							{"tmp_arpmtd.for_amt_applied","tmp_arpmtd.for_amt_applied"},
							{"tmp_arpmtd.for_disc_amt","tmp_arpmtd.for_disc_amt"},
							{"tmp_arpmtd.dom_disc_amt","tmp_arpmtd.dom_disc_amt"},
							{"tmp_arpmtd.for_allow_amt","tmp_arpmtd.for_allow_amt"},
							{"tmp_arpmtd.dom_allow_amt","tmp_arpmtd.dom_allow_amt"},
							{"tmp_arpmtd.site","tmp_arpmtd.site"},
							{"tmp_arpmtd.deposit_acct","tmp_arpmtd.deposit_acct"},
							{"tmp_arpmtd.deposit_acct_unit1","tmp_arpmtd.deposit_acct_unit1"},
							{"tmp_arpmtd.deposit_acct_unit2","tmp_arpmtd.deposit_acct_unit2"},
							{"tmp_arpmtd.deposit_acct_unit3","tmp_arpmtd.deposit_acct_unit3"},
							{"tmp_arpmtd.deposit_acct_unit4","tmp_arpmtd.deposit_acct_unit4"},
							{"tmp_arpmtd.disc_acct","tmp_arpmtd.disc_acct"},
							{"tmp_arpmtd.disc_acct_unit1","tmp_arpmtd.disc_acct_unit1"},
							{"tmp_arpmtd.disc_acct_unit2","tmp_arpmtd.disc_acct_unit2"},
							{"tmp_arpmtd.disc_acct_unit3","tmp_arpmtd.disc_acct_unit3"},
							{"tmp_arpmtd.disc_acct_unit4","tmp_arpmtd.disc_acct_unit4"},
							{"tmp_arpmtd.allow_acct","tmp_arpmtd.allow_acct"},
							{"tmp_arpmtd.allow_acct_unit1","tmp_arpmtd.allow_acct_unit1"},
							{"tmp_arpmtd.allow_acct_unit2","tmp_arpmtd.allow_acct_unit2"},
							{"tmp_arpmtd.allow_acct_unit3","tmp_arpmtd.allow_acct_unit3"},
							{"tmp_arpmtd.allow_acct_unit4","tmp_arpmtd.allow_acct_unit4"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "tmp_arpmtd",
						fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("tmp_arpmtd.ProcessId = {3} AND tmp_arpmtd.cust_num = {2} AND tmp_arpmtd.check_num = {0} AND tmp_arpmtd.bank_code = {1} AND tmp_arpmtd.type = {4}", TArpmtCheckNum, TArpmtBankCode, TArpmtCustNum, PSessionID, TArpmtType),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					#endregion  LoadToRecord

					TArpmtdCrsLoadResponseForCursor = this.appDB.Load(TArpmtdCrsLoadRequestForCursor);
					TArpmtdCrs_CursorFetch_Status = TArpmtdCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
					TArpmtdCrs_CursorCounter = -1;

					while (sQLUtil.SQLBool((sQLUtil.SQLEqual(1, 1))))
                    {
                        //BEGIN
                        TArpmtdCrs_CursorCounter++;
                        if (TArpmtdCrsLoadResponseForCursor.Items.Count > TArpmtdCrs_CursorCounter)
                        {
                            TArpmtdInvNum = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(0);
                            TArpmtdDomAmtApplied = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<decimal?>(1);
                            TArpmtdForAmtApplied = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<decimal?>(2);
                            TArpmtdForDiscAmt = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<decimal?>(3);
                            TArpmtdDomDiscAmt = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<decimal?>(4);
                            TArpmtdForAllowAmt = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<decimal?>(5);
                            TArpmtdDomAllowAmt = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<decimal?>(6);
                            TArpmtdSite = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(7);
                            TArpmtdDepositAcct = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(8);
                            TArpmtdDepositAcctUnit1 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(9);
                            TArpmtdDepositAcctUnit2 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(10);
                            TArpmtdDepositAcctUnit3 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(11);
                            TArpmtdDepositAcctUnit4 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(12);
                            TArpmtdDiscAcct = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(13);
                            TArpmtdDiscAcctUnit1 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(14);
                            TArpmtdDiscAcctUnit2 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(15);
                            TArpmtdDiscAcctUnit3 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(16);
                            TArpmtdDiscAcctUnit4 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(17);
                            TArpmtdAllowAcct = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(18);
                            TArpmtdAllowAcctUnit1 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(19);
                            TArpmtdAllowAcctUnit2 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(20);
                            TArpmtdAllowAcctUnit3 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(21);
                            TArpmtdAllowAcctUnit4 = TArpmtdCrsLoadResponseForCursor.Items[TArpmtdCrs_CursorCounter].GetValue<string>(22);
                        }
                        TArpmtdCrs_CursorFetch_Status = (TArpmtdCrs_CursorCounter == TArpmtdCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                        if (sQLUtil.SQLNotEqual(TArpmtdCrs_CursorFetch_Status, 0) == true)
                        {
                            break;
                        }
                        THasDetail = 1;
                        if (sQLUtil.SQLEqual(TArpmtdInvNum, "-2") == true)
                        {
                            TType = "N";
                        }
                        else
                        {
                            if (sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(TArpmtdInvNum), 1) == true && sQLUtil.SQLLessThan(convertToUtil.ToInt64(TArpmtdInvNum), 0) == true)
                            {
                                TType = "F";
                            }
                            else
                            {
                                if (sQLUtil.SQLEqual(TArpmtdInvNum, "0") == true)
                                {
                                    TType = "O";
                                }
                                else
                                {
                                    TType = "I";
                                }
                            }
                        }
                        if (this.rpt_ARDraftPostingIsNumberInvoice.IsNumberInvoice(TArpmtdInvNum))
                        {
                            TInv = TArpmtdInvNum;
                        }
                        else
                        {
                            TInv = "0";
                        }
                        TcAmtFAmtApplied = TArpmtdForAmtApplied;
                        TcAmtApplied = (decimal?)(TcAmtApplied + TArpmtdDomAmtApplied);
                        PaymentAmtApplied = (decimal?)(PaymentAmtApplied + TArpmtdDomAmtApplied);
                        TcAmtFApplied = (decimal?)(TcAmtFApplied + TArpmtdForAmtApplied);
                        TcAmtFAmtApplied = TArpmtdForAmtApplied;
                        TDomTcAmtAmtApplied = TArpmtdDomAmtApplied;
                        if ((sQLUtil.SQLEqual(TcTotTReappl, 0) == true || (sQLUtil.SQLNotEqual(TcTotTReappl, 0) == true && sQLUtil.SQLNotEqual(TArpmtdInvNum, "0") == true)) && sQLUtil.SQLNotEqual(TType, "N") == true)
                        {
                            //BEGIN
                            TNetEffectAr = (decimal?)(TNetEffectAr + TArpmtdDomAmtApplied + TArpmtdDomDiscAmt + TArpmtdDomAllowAmt);
                            TcTotTNet = (decimal?)(TcTotTNet + TArpmtdDomAmtApplied + TArpmtdDomDiscAmt + TArpmtdDomAllowAmt);
                            //END
                        }
                        if (sQLUtil.SQLNotEqual(TArpmtType, "D") == true)
                        {
                            TcTotTTotApplied = (decimal?)(TcTotTTotApplied + TDomTcAmtAmtApplied);
                        }
                        TcAmtFAmtDisc = TArpmtdForDiscAmt;
                        TDomTcAmtAmtDisc = TArpmtdDomDiscAmt;
                        TcAmtFAmtAllow = TArpmtdForAllowAmt;
                        TDomTcAmtAmtAllow = TArpmtdDomAllowAmt;
                        if (sQLUtil.SQLEqual(PDisplayDetail, 1) == true || sQLUtil.SQLEqual(PDisplayDetail, 0) == true)
                        {
                            //BEGIN
                            if (sQLUtil.SQLNotEqual(TArpmtdInvNum, "-2") == true)
                            {
                                //BEGIN
                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: AcctDBSp
                                var AcctDB = this.iAcctDB.AcctDBSp(pAccount: TArpmtdDepositAcct
                                    , rDescription: TDist
                                    , pSiteRef: TArpmtdSite);
                                TDist = AcctDB.rDescription;

                                #endregion ExecuteMethodCall

                                #region CRUD LoadResponseWithoutTable
                                var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "DetailTranID", variableUtil.GetValue<int?>(TTranID,true)},
                                        { "InvoiceType", variableUtil.GetValue<string>(TType,true)},
                                        { "InvoiceNum", variableUtil.GetValue<string>(TInv,true)},
                                        { "AmtFAmtApplied", variableUtil.GetValue<decimal?>(TcAmtFAmtApplied,true)},
                                        { "DomAmtApplied", variableUtil.GetValue<decimal?>((sQLUtil.SQLNotEqual(TCustaddrCurrCode, TCurrParmsCurrCode) == true ? TDomTcAmtAmtApplied : null),true)},
                                        { "ArpmtdDepositAcct", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TArpmtdInvNum, "0") == true ? TArpmtdDepositAcct : convertToUtil.ToString<string>(null)),true)},
                                        { "ArpmtdDepositAcctUnit1", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TArpmtdInvNum, "0") == true ? TArpmtdDepositAcctUnit1 : convertToUtil.ToString<string>(null)),true)},
                                        { "ArpmtdDepositAcctUnit2", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TArpmtdInvNum, "0") == true ? TArpmtdDepositAcctUnit2 : convertToUtil.ToString<string>(null)),true)},
                                        { "ArpmtdDepositAcctUnit3", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TArpmtdInvNum, "0") == true ? TArpmtdDepositAcctUnit3 : convertToUtil.ToString<string>(null)),true)},
                                        { "ArpmtdDepositAcctUnit4", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TArpmtdInvNum, "0") == true ? TArpmtdDepositAcctUnit4 : convertToUtil.ToString<string>(null)),true)},
                                        { "ArpmtdDepositAcctDesc", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TArpmtdInvNum, "0") == true ? TDist : convertToUtil.ToString<string>(null)),true)},
                                        { "CreditLabel1", variableUtil.GetValue<string>(null,true)},
                                        { "AmtFAmtCredit", variableUtil.GetValue<decimal?>(null,true)},
                                        { "DomAmtFAmtCredit", variableUtil.GetValue<decimal?>(null,true)},
                                        { "ArpmtdDiscAcct", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctUnit1", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctUnit2", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctUnit3", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctUnit4", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctDesc", variableUtil.GetValue<string>(null,true)},
                                        { "CreditLabel2", variableUtil.GetValue<string>(null,true)},
                                        { "AmtFAmtAllow", variableUtil.GetValue<decimal?>(null,true)},
                                        { "DomAmtFAmtAllow", variableUtil.GetValue<decimal?>(null,true)},
                                        { "ArpmtdAllowAcct", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdAllowAcctUnit1", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdAllowAcctUnit2", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdAllowAcctUnit3", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdAllowAcctUnit4", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdAllowAcctDesc", variableUtil.GetValue<string>(null,true)},
                                        { "CurrParmsCurrCode", variableUtil.GetValue<string>((sQLUtil.SQLNotEqual(TCustaddrCurrCode, TCurrParmsCurrCode) == true ? TCurrParmsCurrCode : convertToUtil.ToString<string>(null)),true)},
                                        { "CustAddrCurrCode", variableUtil.GetValue<string>(TCustaddrCurrCode,true)},
                                        { "PaymentCheckAmount", variableUtil.GetValue<decimal?>(TArpmtPaymentCheckAmount,true)},
                                        { "PaymentCheckCode", variableUtil.GetValue<string>(PaymentCheckCode,true)},
                                    });

                                var nonTable1LoadResponse = this.appDB.Load(nonTable1LoadRequest);
                                Data = nonTable1LoadResponse;
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords
                                var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Detail",
                                    items: nonTable1LoadResponse.Items);

                                this.appDB.Insert(nonTable1InsertRequest);
                                #endregion InsertByRecords

                                if (sQLUtil.SQLNotEqual(TArpmtType, "D") == true)
                                {
                                    TcTotTTotDisc = (decimal?)(TcTotTTotDisc + TDomTcAmtAmtDisc);
                                }
                                TInv = "0";
                                TType = "";
                                //END
                            }
                            else
                            {
                                //BEGIN
                                TcAmtApplied = (decimal?)(TcAmtApplied + TArpmtdDomDiscAmt);
                                TcAmtFApplied = (decimal?)(TcAmtFApplied + TArpmtdForDiscAmt);
                                //END
                            }
                            if (sQLUtil.SQLNotEqual(TArpmtdDomDiscAmt, 0.0M) == true)
                            {
                                //BEGIN
                                if (sQLUtil.SQLEqual(TArpmtdInvNum, "-2") == true && sQLUtil.SQLNotEqual(TArpmtType, "D") == true)
                                {
                                    TcTotTNonAr = (decimal?)(TcTotTNonAr + TDomTcAmtAmtDisc);
                                }
                                if (sQLUtil.SQLEqual(PDisplayDetail, 1) == true || sQLUtil.SQLEqual(PDisplayDetail, 0) == true)
                                {
                                    //BEGIN
                                    if (sQLUtil.SQLEqual(TArpmtdInvNum, "-2") == true)
                                    {
                                        //BEGIN
                                        TDiscLabel = CreditAmt1Label;

                                        #region CRUD ExecuteMethodCall

                                        //Please Generate the bounce for this stored procedure: AcctDBSp
                                        var AcctDB1 = this.iAcctDB.AcctDBSp(pAccount: TArpmtdDiscAcct
                                            , rDescription: TDist
                                            , pSiteRef: TArpmtdSite);
                                        TDist = AcctDB1.rDescription;

                                        #endregion ExecuteMethodCall
                                        //END
                                    }
                                    else
                                    {
                                        //BEGIN
                                        TDiscLabel = DomDiscAmtLabel;

                                        #region CRUD ExecuteMethodCall

                                        //Please Generate the bounce for this stored procedure: AcctDBSp
                                        var AcctDB2 = this.iAcctDB.AcctDBSp(pAccount: TArpmtdDiscAcct
                                            , rDescription: TDist
                                            , pSiteRef: TArpmtdSite);
                                        TDist = AcctDB2.rDescription;

                                        #endregion ExecuteMethodCall
                                        //END
                                    }

                                    #region CRUD LoadResponseWithoutTable
                                    var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                        {
                                            { "DetailTranID", variableUtil.GetValue<int?>(TTranID,true)},
                                            { "InvoiceType", variableUtil.GetValue<string>(TType,true)},
                                            { "InvoiceNum", variableUtil.GetValue<string>(TInv,true)},
                                            { "AmtFAmtApplied", variableUtil.GetValue<decimal?>(null,true)},
                                            { "DomAmtApplied", variableUtil.GetValue<decimal?>(null,true)},
                                            { "ArpmtdDepositAcct", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdDepositAcctUnit1", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdDepositAcctUnit2", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdDepositAcctUnit3", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdDepositAcctUnit4", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdDepositAcctDesc", variableUtil.GetValue<string>(null,true)},
                                            { "CreditLabel1", variableUtil.GetValue<string>(TDiscLabel,true)},
                                            { "AmtFAmtCredit", variableUtil.GetValue<decimal?>(TcAmtFAmtDisc,true)},
                                            { "DomAmtFAmtCredit", variableUtil.GetValue<decimal?>((sQLUtil.SQLNotEqual(TCustaddrCurrCode, TCurrParmsCurrCode) == true ? TDomTcAmtAmtDisc : null),true)},
                                            { "ArpmtdDiscAcct", variableUtil.GetValue<string>(TArpmtdDiscAcct,true)},
                                            { "ArpmtdDiscAcctUnit1", variableUtil.GetValue<string>(TArpmtdDiscAcctUnit1,true)},
                                            { "ArpmtdDiscAcctUnit2", variableUtil.GetValue<string>(TArpmtdDiscAcctUnit2,true)},
                                            { "ArpmtdDiscAcctUnit3", variableUtil.GetValue<string>(TArpmtdDiscAcctUnit3,true)},
                                            { "ArpmtdDiscAcctUnit4", variableUtil.GetValue<string>(TArpmtdDiscAcctUnit4,true)},
                                            { "ArpmtdDiscAcctDesc", variableUtil.GetValue<string>(TDist,true)},
                                            { "CreditLabel2", variableUtil.GetValue<string>(null,true)},
                                            { "AmtFAmtAllow", variableUtil.GetValue<decimal?>(null,true)},
                                            { "DomAmtFAmtAllow", variableUtil.GetValue<decimal?>(null,true)},
                                            { "ArpmtdAllowAcct", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdAllowAcctUnit1", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdAllowAcctUnit2", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdAllowAcctUnit3", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdAllowAcctUnit4", variableUtil.GetValue<string>(null,true)},
                                            { "ArpmtdAllowAcctDesc", variableUtil.GetValue<string>(null,true)},
                                            { "CurrParmsCurrCode", variableUtil.GetValue<string>((sQLUtil.SQLNotEqual(TCustaddrCurrCode, TCurrParmsCurrCode) == true ? TCurrParmsCurrCode : convertToUtil.ToString<string>(null)),true)},
                                            { "CustAddrCurrCode", variableUtil.GetValue<string>(TCustaddrCurrCode,true)},
                                            { "PaymentCheckAmount", variableUtil.GetValue<decimal?>(TArpmtPaymentCheckAmount,true)},
                                            { "PaymentCheckCode", variableUtil.GetValue<string>(PaymentCheckCode,true)},
                                        });

                                    var nonTable2LoadResponse = this.appDB.Load(nonTable2LoadRequest);
                                    Data = nonTable2LoadResponse;
                                    #endregion CRUD LoadResponseWithoutTable

                                    #region CRUD InsertByRecords
                                    var nonTable2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Detail",
                                        items: nonTable2LoadResponse.Items);

                                    this.appDB.Insert(nonTable2InsertRequest);
                                    #endregion InsertByRecords
                                    //END
                                }
                                //END
                            }
                            if (sQLUtil.SQLNotEqual(TArpmtdDomAllowAmt, 0.0M) == true)
                            {
                                //BEGIN
                                if (sQLUtil.SQLEqual(TArpmtdInvNum, "-2") == true)
                                {
                                    //BEGIN
                                    TArpmtdInvNum = "-2";
                                    if (sQLUtil.SQLNotEqual(TArpmtType, "D") == true)
                                    {
                                        TcTotTNonAr = (decimal?)(TcTotTNonAr + TDomTcAmtAmtAllow);
                                    }
                                    TcAmtApplied = (decimal?)(TcAmtApplied + TDomTcAmtAmtAllow);
                                    TcAmtFApplied = (decimal?)(TcAmtFApplied + TcAmtFAmtAllow);
                                    //END
                                }
                                else
                                {
                                    //BEGIN
                                    if (sQLUtil.SQLNotEqual(TArpmtType, "D") == true)
                                    {
                                        TcTotTTotAllow = (decimal?)(TcTotTTotAllow + TDomTcAmtAmtAllow);
                                    }
                                    //END
                                }
                                if (sQLUtil.SQLEqual(TArpmtdInvNum, "-2") == true)
                                {
                                    TAllowLabel = CreditAmt2Label;
                                }
                                else
                                {
                                    TAllowLabel = AllowAmtLabel;
                                }

                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: AcctDBSp
                                var AcctDB3 = this.iAcctDB.AcctDBSp(pAccount: TArpmtdAllowAcct
                                    , rDescription: TDist1
                                    , pSiteRef: TArpmtdSite);
                                TDist1 = AcctDB3.rDescription;

                                #endregion ExecuteMethodCall

                                #region CRUD LoadResponseWithoutTable
                                var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "DetailTranID", variableUtil.GetValue<int?>(TTranID,true)},
                                        { "InvoiceType", variableUtil.GetValue<string>(TType,true)},
                                        { "InvoiceNum", variableUtil.GetValue<string>(TInv,true)},
                                        { "AppliedLabel", variableUtil.GetValue<string>(null,true)},
                                        { "AmtFAmtApplied", variableUtil.GetValue<decimal?>(null,true)},
                                        { "DomAmtApplied", variableUtil.GetValue<decimal?>(null,true)},
                                        { "ArpmtdDepositAcct", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDepositAcctUnit1", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDepositAcctUnit2", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDepositAcctUnit3", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDepositAcctUnit4", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDepositAcctDesc", variableUtil.GetValue<string>(null,true)},
                                        { "CreditLabel1", variableUtil.GetValue<string>(null,true)},
                                        { "AmtFAmtCredit", variableUtil.GetValue<decimal?>(null,true)},
                                        { "DomAmtFAmtCredit", variableUtil.GetValue<decimal?>(null,true)},
                                        { "ArpmtdDiscAcct", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctUnit1", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctUnit2", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctUnit3", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctUnit4", variableUtil.GetValue<string>(null,true)},
                                        { "ArpmtdDiscAcctDesc", variableUtil.GetValue<string>(null,true)},
                                        { "CreditLabel2", variableUtil.GetValue<string>(TAllowLabel,true)},
                                        { "AmtFAmtAllow", variableUtil.GetValue<decimal?>(TcAmtFAmtAllow,true)},
                                        { "DomAmtFAmtAllow", variableUtil.GetValue<decimal?>((sQLUtil.SQLNotEqual(TCustaddrCurrCode, TCurrParmsCurrCode) == true ? TDomTcAmtAmtApplied : null),true)},
                                        { "ArpmtdAllowAcct", variableUtil.GetValue<string>(TArpmtdAllowAcct,true)},
                                        { "ArpmtdAllowAcctUnit1", variableUtil.GetValue<string>(TArpmtdAllowAcctUnit1,true)},
                                        { "ArpmtdAllowAcctUnit2", variableUtil.GetValue<string>(TArpmtdAllowAcctUnit2,true)},
                                        { "ArpmtdAllowAcctUnit3", variableUtil.GetValue<string>(TArpmtdAllowAcctUnit3,true)},
                                        { "ArpmtdAllowAcctUnit4", variableUtil.GetValue<string>(TArpmtdAllowAcctUnit4,true)},
                                        { "ArpmtdAllowAcctDesc", variableUtil.GetValue<string>(TDist1,true)},
                                        { "CurrParmsCurrCode", variableUtil.GetValue<string>((sQLUtil.SQLNotEqual(TCustaddrCurrCode, TCurrParmsCurrCode) == true ? TCurrParmsCurrCode : convertToUtil.ToString<string>(null)),true)},
                                        { "CustAddrCurrCode", variableUtil.GetValue<string>(TCustaddrCurrCode,true)},
                                        { "PaymentCheckAmount", variableUtil.GetValue<decimal?>(TArpmtPaymentCheckAmount,true)},
                                        { "PaymentCheckCode", variableUtil.GetValue<string>(PaymentCheckCode,true)},
                                    });

                                var nonTable3LoadResponse = this.appDB.Load(nonTable3LoadRequest);
                                Data = nonTable3LoadResponse;
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords
                                var nonTable3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Detail",
                                    items: nonTable3LoadResponse.Items);

                                this.appDB.Insert(nonTable3InsertRequest);
                                #endregion InsertByRecords
                                //END
                            }
                            //END
                        }
                        //END
                    }
                    if (sQLUtil.SQLEqual(THasDetail, 1) == true)
					{
						//BEGIN
						TcAmtFAmtApplied = TcAmtFApplied;
						TDomTcAmtAmtApplied = TcAmtApplied;
						if (sQLUtil.SQLEqual(PDisplayDetail, 1) == true || sQLUtil.SQLEqual(PDisplayDetail, 0) == true)
						{
							//BEGIN
							if (sQLUtil.SQLNotEqual(TcAmtApplied, TArpmtDomCheckAmt) == true)
							{
								//BEGIN
								TcTotWarn = (decimal?)(TcTotWarn + TDomTcAmtAmtApplied);
								//END
							}
							//END
						}
						//END
					}
					//END
				}
				TArpmtCrsLoadResponseForCursor = null;
				//Deallocate Cursor @TArpmtCrs
				//END

			}
			//Deallocate Cursor ARPayPostCrs
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Header ADD tempTableId INT IDENTITY");

			#region CRUD LoadToRecord
			var tv_HeaderLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"TotalCheckAmount","#tv_Header.TotalCheckAmount"},
					{"TotalWireAmount","#tv_Header.TotalWireAmount"},
					{"TotalDraftAmount","#tv_Header.TotalDraftAmount"},
					{"TotalAdjustAmount","#tv_Header.TotalAdjustAmount"},
					{"TotalReApplicationAmt","#tv_Header.TotalReApplicationAmt"},
					{"TotalApplied","#tv_Header.TotalApplied"},
					{"TotalNonARAmount","#tv_Header.TotalNonARAmount"},
					{"TotalDiscount","#tv_Header.TotalDiscount"},
					{"TotalAllowance","#tv_Header.TotalAllowance"},
					{"NetEffect","#tv_Header.NetEffect"},
					{"TotalWarningAppliedAmt","#tv_Header.TotalWarningAppliedAmt"},
				}, 
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                tableName: "#tv_Header",
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_HeaderLoadResponse = this.appDB.Load(tv_HeaderLoadRequest);
			#endregion  LoadToRecord

			#region CRUD UpdateByRecord
			foreach (var tv_HeaderItem in tv_HeaderLoadResponse.Items)
			{
				tv_HeaderItem.SetValue<decimal?>("TotalCheckAmount", TcTotTCheckAmt);
				tv_HeaderItem.SetValue<decimal?>("TotalWireAmount", TcTotTWireAmt);
				tv_HeaderItem.SetValue<decimal?>("TotalDraftAmount", TcTotTDraftAmt);
				tv_HeaderItem.SetValue<decimal?>("TotalAdjustAmount", TcTotTAdjAmt);
				tv_HeaderItem.SetValue<decimal?>("TotalReApplicationAmt", TcTotTReappl);
				tv_HeaderItem.SetValue<decimal?>("TotalApplied", TcTotTTotApplied);
				tv_HeaderItem.SetValue<decimal?>("TotalNonARAmount", TcTotTNonAr);
				tv_HeaderItem.SetValue<decimal?>("TotalDiscount", TcTotTTotDisc);
				tv_HeaderItem.SetValue<decimal?>("TotalAllowance", TcTotTTotAllow);
				tv_HeaderItem.SetValue<decimal?>("NetEffect", TcTotTNet);
				tv_HeaderItem.SetValue<decimal?>("TotalWarningAppliedAmt", TcTotWarn);
			};

			var tv_HeaderRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_Header",
				items: tv_HeaderLoadResponse.Items);

			this.appDB.Update(tv_HeaderRequestUpdate);
			#endregion UpdateByRecord

			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_Header DROP COLUMN tempTableId");

			#region CRUD LoadToRecord
			var tv_Header1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"TranID","TranID"},
					{"CustNum","CustNum"},
					{"PaymentType","PaymentType"},
					{"BankCode","BankCode"},
					{"Payment","Payment"},
					{"BankCurrCode","BankCurrCode"},
					{"AmtFAmount","AmtFAmount"},
					{"RecptDate","RecptDate"},
					{"DueDate","DueDate"},
					{"Reference","Reference"},
					{"CashAcct","CashAcct"},
					{"UnitCd1","UnitCd1"},
					{"UnitCd2","UnitCd2"},
					{"UnitCd3","UnitCd3"},
					{"UnitCd4","UnitCd4"},
					{"CustaddrName","CustaddrName"},
					{"h.CurrParmsCurrCode","h.CurrParmsCurrCode"},
					{"DomTcAmtAmount","DomTcAmtAmount"},
					{"ExchRate","ExchRate"},
					{"ArpmtDescription","ArpmtDescription"},
					{"AcctDescription","AcctDescription"},
					{"EuroCurr","EuroCurr"},
					{"EuroAmt","EuroAmt"},
					{"CurrentPeriod","CurrentPeriod"},
					{"TotalCheckAmount","TotalCheckAmount"},
					{"TotalWireAmount","TotalWireAmount"},
					{"TotalDraftAmount","TotalDraftAmount"},
					{"TotalAdjustAmount","TotalAdjustAmount"},
					{"TotalReApplicationAmt","TotalReApplicationAmt"},
					{"TotalApplied","TotalApplied"},
					{"TotalNonARAmount","TotalNonARAmount"},
					{"TotalDiscount","TotalDiscount"},
					{"TotalAllowance","TotalAllowance"},
					{"NetEffect","NetEffect"},
					{"TotalWarningAppliedAmt","TotalWarningAppliedAmt"},
					{"DetailTranID","DetailTranID"},
					{"InvoiceType","InvoiceType"},
					{"InvoiceNum","InvoiceNum"},
					{"AppliedLabel","AppliedLabel"},
					{"AmtFAmtApplied","AmtFAmtApplied"},
					{"DomAmtApplied","DomAmtApplied"},
					{"ArpmtdDepositAcct","ArpmtdDepositAcct"},
					{"ArpmtdDepositAcctUnit1","ArpmtdDepositAcctUnit1"},
					{"ArpmtdDepositAcctUnit2","ArpmtdDepositAcctUnit2"},
					{"ArpmtdDepositAcctUnit3","ArpmtdDepositAcctUnit3"},
					{"ArpmtdDepositAcctUnit4","ArpmtdDepositAcctUnit4"},
					{"ArpmtdDepositAcctDesc","ArpmtdDepositAcctDesc"},
					{"CreditLabel1","CreditLabel1"},
					{"AmtFAmtCredit","AmtFAmtCredit"},
					{"DomAmtFAmtCredit","DomAmtFAmtCredit"},
					{"ArpmtdDiscAcct","ArpmtdDiscAcct"},
					{"ArpmtdDiscAcctUnit1","ArpmtdDiscAcctUnit1"},
					{"ArpmtdDiscAcctUnit2","ArpmtdDiscAcctUnit2"},
					{"ArpmtdDiscAcctUnit3","ArpmtdDiscAcctUnit3"},
					{"ArpmtdDiscAcctUnit4","ArpmtdDiscAcctUnit4"},
					{"ArpmtdDiscAcctDesc","ArpmtdDiscAcctDesc"},
					{"CreditLabel2","CreditLabel2"},
					{"AmtFAmtAllow","AmtFAmtAllow"},
					{"DomAmtFAmtAllow","DomAmtFAmtAllow"},
					{"ArpmtdAllowAcct","ArpmtdAllowAcct"},
					{"ArpmtdAllowAcctUnit1","ArpmtdAllowAcctUnit1"},
					{"ArpmtdAllowAcctUnit2","ArpmtdAllowAcctUnit2"},
					{"ArpmtdAllowAcctUnit3","ArpmtdAllowAcctUnit3"},
					{"ArpmtdAllowAcctUnit4","ArpmtdAllowAcctUnit4"},
					{"ArpmtdAllowAcctDesc","ArpmtdAllowAcctDesc"},
					{"DetCurrParmsCurrCode","d.CurrParmsCurrCode"},
					{"h.PaymentCheckAmount","h.PaymentCheckAmount"},
					{"h.PaymentCheckCode","h.PaymentCheckCode"},
					{"CustaddrCurrCode","CustaddrCurrCode"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_Header",
				fromClause: collectionLoadRequestFactory.Clause(" AS h LEFT OUTER JOIN #tv_Detail AS d ON h.TranID = d.DetailTranID"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" h.CustNum ASC"));
			var tv_Header1LoadResponse = this.appDB.Load(tv_Header1LoadRequest);
			#endregion  LoadToRecord

			Data = tv_Header1LoadResponse;

			if (existsChecker.Exists(
				tableName: "tmp_arpaypost",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("tmp_arpaypost.SessionID = {0} AND tmp_arpaypost.posted = 0", PSessionID)))
			{
				#region CRUD LoadToRecord
				var tmp_arpaypost2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"printed","tmp_arpaypost.printed"},
					}, 
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    tableName: "tmp_arpaypost",
                    fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("tmp_arpaypost.SessionId = {0}", PSessionID),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tmp_arpaypost2LoadResponse = this.appDB.Load(tmp_arpaypost2LoadRequest);
				#endregion  LoadToRecord

				#region CRUD UpdateByRecord
				foreach (var tmp_arpaypost2Item in tmp_arpaypost2LoadResponse.Items)
				{
					tmp_arpaypost2Item.SetValue<int?>("printed", 1);
				};

				var tmp_arpaypost2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "tmp_arpaypost",
					items: tmp_arpaypost2LoadResponse.Items);

				this.appDB.Update(tmp_arpaypost2RequestUpdate);
				#endregion UpdateByRecord
			}
			else
			{
				/*Needs to load at least one column from the table: tmp_arpaypost for delete, Loads the record based on its where and from clause, then deletes it by record.*/
				#region CRUD LoadToRecord
				var tmp_arpaypost3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"col0","1"},
					},
                    loadForChange: true, 
                    lockingType: LockingType.None,
                    tableName: "tmp_arpaypost",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("tmp_arpaypost.SessionId = {0}", PSessionID),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tmp_arpaypost3LoadResponse = this.appDB.Load(tmp_arpaypost3LoadRequest);
				#endregion  LoadToRecord

				#region CRUD DeleteByRecord
				var tmp_arpaypost3DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "tmp_arpaypost",
					items: tmp_arpaypost3LoadResponse.Items);
				this.appDB.Delete(tmp_arpaypost3DeleteRequest);
				#endregion DeleteByRecord
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: DropDynamicTableSp
			var DropDynamicTable = this.iDropDynamicTable.DropDynamicTableSp(pTable: "tmp_arpmt"
				, Infobar: Infobar
				, pParm1: PSessionIDChar);
			Infobar = DropDynamicTable.Infobar;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: DropDynamicTableSp
			var DropDynamicTable1 = this.iDropDynamicTable.DropDynamicTableSp(pTable: "tmp_arpmtd"
				, Infobar: Infobar
				, pParm1: PSessionIDChar);
			Infobar = DropDynamicTable1.Infobar;

			#endregion ExecuteMethodCall

			this.transactionFactory.CommitTransaction("");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}

        private bool IsNumberInvNum(string TArpmtdInvNum)
        {
            return sQLUtil.SQLBool(sQLUtil.SQLOr(sQLUtil.SQLNot((sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(TArpmtdInvNum), 1))), (sQLUtil.SQLAnd(sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(TArpmtdInvNum), 1), sQLUtil.SQLGreaterThan(convertToUtil.ToInt64(TArpmtdInvNum), 0)))));
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_ARDraftPostingSp(string AltExtGenSp,
			int? PDisplayDetail = null,
			string PStartingCustomer = null,
			string PEndingCustomer = null,
			string pStartingBankCode = null,
			string pEndingBankCode = null,
			DateTime? pStartingDueDate = null,
			DateTime? pEndingDueDate = null,
			int? pStartingDraftNumber = null,
			int? pEndingDraftNumber = null,
			int? PDisplayHeader = null,
			string PSessionIDChar = null,
			string pSite = null,
			string BGUser = null)
		{
			ListYesNoType _PDisplayDetail = PDisplayDetail;
			CustNumType _PStartingCustomer = PStartingCustomer;
			CustNumType _PEndingCustomer = PEndingCustomer;
			BankCodeType _pStartingBankCode = pStartingBankCode;
			BankCodeType _pEndingBankCode = pEndingBankCode;
			DateTimeType _pStartingDueDate = pStartingDueDate;
			DateTimeType _pEndingDueDate = pEndingDueDate;
			DraftNumType _pStartingDraftNumber = pStartingDraftNumber;
			DraftNumType _pEndingDraftNumber = pEndingDraftNumber;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			StringType _PSessionIDChar = PSessionIDChar;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "PDisplayDetail", _PDisplayDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCustomer", _PStartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCustomer", _PEndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingBankCode", _pStartingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingBankCode", _pEndingBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingDueDate", _pStartingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingDueDate", _pEndingDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartingDraftNumber", _pStartingDraftNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndingDraftNumber", _pEndingDraftNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionIDChar", _PSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);

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
