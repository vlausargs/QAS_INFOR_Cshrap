//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BankReconciliation.cs

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
using CSI.Adapters;
using CSI.MG.MGCore;

namespace CSI.Reporting
{
	public class Rpt_BankReconciliation : IRpt_BankReconciliation
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		ICollectionInsertRequestFactory collectionInsertRequestFactory;
		ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IInitSessionContextWithUser iInitSessionContextWithUser;
		ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICopySessionVariables iCopySessionVariables;
        readonly ICloseSessionContext iCloseSessionContext;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IScalarFunction scalarFunction;
		IExistsChecker existsChecker;
		IConvertToUtil convertToUtil;
		IVariableUtil variableUtil;
		IStringUtil stringUtil;
        readonly IGetLabel iGetLabel;
        readonly IHighInt iHighInt;
        readonly IGetCode iGetCode;
		ISQLValueComparerUtil sQLUtil;
        readonly ILowInt iLowInt;
        readonly IMsgApp iMsgApp;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
        public Rpt_BankReconciliation(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
		ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
		ICollectionInsertRequestFactory collectionInsertRequestFactory,
		ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
		ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
		ICollectionLoadRequestFactory collectionLoadRequestFactory,
		IInitSessionContextWithUser iInitSessionContextWithUser,
		ICollectionLoadResponseUtil collectionLoadResponseUtil,
		ISQLExpressionExecutor sQLExpressionExecutor,
		ICopySessionVariables iCopySessionVariables,
		ICloseSessionContext iCloseSessionContext,
		ITransactionFactory transactionFactory,
		IGetIsolationLevel iGetIsolationLevel,
		IApplyDateOffset iApplyDateOffset,
		IScalarFunction scalarFunction,
		IExistsChecker existsChecker,
		IConvertToUtil convertToUtil,
		IVariableUtil variableUtil,
		IStringUtil stringUtil,
		IGetLabel iGetLabel,
		IHighInt iHighInt,
		IGetCode iGetCode,
		ISQLValueComparerUtil sQLUtil,
		ILowInt iLowInt,
		IMsgApp iMsgApp,
        ILowCharacter lowCharacter,
        IHighCharacter highCharacter)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.iInitSessionContextWithUser = iInitSessionContextWithUser;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCopySessionVariables = iCopySessionVariables;
			this.iCloseSessionContext = iCloseSessionContext;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.iApplyDateOffset = iApplyDateOffset;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.iGetLabel = iGetLabel;
			this.iHighInt = iHighInt;
			this.iGetCode = iGetCode;
			this.sQLUtil = sQLUtil;
			this.iLowInt = iLowInt;
			this.iMsgApp = iMsgApp;
            this.lowCharacter = lowCharacter;
            this.highCharacter = highCharacter;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_BankReconciliationSp(string StartBankCode = null,
			string EndBankCode = null,
			DateTime? StartTransDate = null,
			DateTime? EndTransDate = null,
			int? StartTransNum = null,
			int? EndTransNum = null,
			int? IncludeVoidChecks = null,
			int? IncludeReconciled = null,
			string SortBy = null,
			int? DisplayReasonCodes = null,
			int? DisplayRefFields = null,
			string BankRecTypes = null,
			int? StartDateOffset = null,
			int? EndDateOffset = null,
			int? DisplayHeader = null,
			string BGSessionId = null,
			string pSite = null,
			string BGUser = null)
		{
			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			Guid? RptSessionID = null;
			DateTime? TmpStartTransDate = null;
			string VendorLabel = null;
			string EmployeeLabel = null;
			string CustomerLabel = null;
			string OtherLabel = null;
			int? LookAheadBankHdrEof = null;
			int? LastOfBankCode = null;
			int? FirstOfBankCode = null;
			string LookAheadBankHdrBankCode = null;
			string LookAheadBankHdrAcct = null;
			string LookAheadBankHdrAcctUnit1 = null;
			string LookAheadBankHdrAcctUnit2 = null;
			string LookAheadBankHdrAcctUnit3 = null;
			string LookAheadBankHdrAcctUnit4 = null;
			string LookAheadGlbankType = null;
			DateTime? LookAheadGlbankCheckDate = null;
			int? LookAheadGlbankCheckNum = null;
			int? LookAheadGlbankVoided = null;
			string LookAheadGlbankRefType = null;
			string LookAheadGlbankRefNum = null;
			DateTime? LookAheadGlbankPostDate = null;
			int? LookAheadGlbankBankRecon = null;
			decimal? LookAheadGlbankBankAmt = null;
			decimal? LookAheadGlbankCheckAmt = null;
			string LookAheadGlbankReasonCode = null;
			string BankHdrBankCode = null;
			string BankHdrAcct = null;
			string BankHdrAcctUnit1 = null;
			string BankHdrAcctUnit2 = null;
			string BankHdrAcctUnit3 = null;
			string BankHdrAcctUnit4 = null;
			string GlbankType = null;
			DateTime? GlbankCheckDate = null;
			int? GlbankCheckNum = null;
			int? GlbankVoided = null;
			string GlbankRefType = null;
			string GlbankRefNum = null;
			DateTime? GlbankPostDate = null;
			int? GlbankBankRecon = null;
			decimal? GlbankBankAmt = null;
			decimal? GlbankCheckAmt = null;
			string GlbankReasonCode = null;
			RowPointerType _ChartRowpointer = DBNull.Value;
			Guid? ChartRowpointer = null;
			DescriptionType _ChartDescription = DBNull.Value;
			string ChartDescription = null;
			string ReasonDescription = null;
			decimal? __TcAmtBankBal = null;
			decimal? __TcAmtPostBal = null;
			AmountType _TcAmtBankBal = DBNull.Value;
			decimal? TcAmtBankBal = null;
			AmountType _TcAmtPostBal = DBNull.Value;
			decimal? TcAmtPostBal = null;
			string TAcctDesc = null;
			int? Stdin = null;
			string RCLabel = null;
			string RefNumLabel = null;
			string RefName = null;
			string TypeDesc = null;
			string Type = null;
			int? Counter = null;
			int? iTemp = null;
			ICollectionLoadRequest bank_hdr_crsLoadRequestForCursor = null;
			ICollectionLoadResponse bank_hdr_crsLoadResponseForCursor = null;
			int bank_hdr_crs_CursorFetch_Status = -1;
			int bank_hdr_crs_CursorCounter = -1;

			if (existsChecker.Exists(
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_BankReconciliationSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_BankReconciliationSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_BankReconciliationSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Rpt_BankReconciliationSp(_ALTGEN_SpName,
						StartBankCode,
						EndBankCode,
						StartTransDate,
						EndTransDate,
						StartTransNum,
						EndTransNum,
						IncludeVoidChecks,
						IncludeReconciled,
						SortBy,
						DisplayReasonCodes,
						DisplayRefFields,
						BankRecTypes,
						StartDateOffset,
						EndDateOffset,
						DisplayHeader,
						BGSessionId,
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
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_BankReconciliationSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_BankReconciliationSp("dbo.EXTGEN_Rpt_BankReconciliationSp",
					StartBankCode,
					EndBankCode,
					StartTransDate,
					EndTransDate,
					StartTransNum,
					EndTransNum,
					IncludeVoidChecks,
					IncludeReconciled,
					SortBy,
					DisplayReasonCodes,
					DisplayRefFields,
					BankRecTypes,
					StartDateOffset,
					EndDateOffset,
					DisplayHeader,
					BGSessionId,
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
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("BankReconciliationReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			}
			if (SortBy == null)
			{
				SortBy = "N";
			}
			if (BankRecTypes == null)
			{
				BankRecTypes = "CDMORWTNEFH";
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextWithUserSp
			var InitSessionContextWithUser = this.iInitSessionContextWithUser.InitSessionContextWithUserSp(ContextName: "Rpt_BankReconciliationSp"
				, SessionID: RptSessionID
				, Site: pSite
				, UserName: BGUser);
			RptSessionID = InitSessionContextWithUser.SessionID;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CopySessionVariablesSp
			var CopySessionVariables = this.iCopySessionVariables.CopySessionVariablesSp(SessionId: BGSessionId);

			#endregion ExecuteMethodCall

			TmpStartTransDate = convertToUtil.ToDateTime(StartTransDate);
			StartBankCode = stringUtil.IsNull(StartBankCode, this.lowCharacter.LowCharacterFn());
			EndBankCode = stringUtil.IsNull(EndBankCode, this.highCharacter.HighCharacterFn());
			StartTransNum = (int?)(stringUtil.IsNull(StartTransNum, this.iLowInt.LowIntFn()));
			EndTransNum = (int?)(stringUtil.IsNull(EndTransNum, this.iHighInt.HighIntFn()));
			IncludeVoidChecks = (int?)(stringUtil.IsNull(IncludeVoidChecks, 1));
			IncludeReconciled = (int?)(stringUtil.IsNull(IncludeReconciled, 1));
			SortBy = stringUtil.IsNull(SortBy, "DNTC");
			DisplayReasonCodes = (int?)(stringUtil.IsNull(DisplayReasonCodes, 0));
			DisplayRefFields = (int?)(stringUtil.IsNull(DisplayRefFields, 0));
			BankRecTypes = stringUtil.IsNull(BankRecTypes, "CDMORWTNEFH");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(Date: StartTransDate
				, Offset: StartDateOffset
				, IsEndDate: 0);
			StartTransDate = ApplyDateOffset.Date;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: EndTransDate
				, Offset: EndDateOffset
				, IsEndDate: 1);
			EndTransDate = ApplyDateOffset1.Date;

			#endregion ExecuteMethodCall

			if (sQLUtil.SQLEqual(DisplayRefFields, 1) == true)
			{
				//BEGIN
				VendorLabel = this.iGetLabel.GetLabelFn("@vendor.vend_num");
				EmployeeLabel = this.iGetLabel.GetLabelFn("@employee.emp_num");
				CustomerLabel = this.iGetLabel.GetLabelFn("@customer.cust_num");
				OtherLabel = this.iGetLabel.GetLabelFn("@glbank.ref_num");
				//END
			}
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @ReportSet TABLE (
					seq                INT                IDENTITY,
					bank_code          BankCodeType      ,
					account            AcctType          ,
					acct_unit1         UnitCode1Type     ,
					acct_unit2         UnitCode2Type     ,
					acct_unit3         UnitCode3Type     ,
					acct_unit4         UnitCode4Type     ,
					acct_desc          DescriptionType   ,
					amt_post_bal_first AmountType        ,
					amt_bank_bal_first AmountType        ,
					type               GlbankTypeType    ,
					check_date         DateType          ,
					check_num          GlCheckNumType    ,
					voided             ListYesNoType     ,
					ref_type           GlbankRefTypeType ,
					ref_num            CustEmpVendNumType,
					check_amt          AmountType        ,
					bank_recon         ListYesNoType     ,
					bank_amt           AmountType        ,
					post_date          DateType          ,
					amt_post_bal       AmountType        ,
					amt_bank_bal       AmountType        ,
					lbl_reason_code    LabelType         ,
					reason_code        ReasonCodeType    ,
					reason_desc        DescriptionType   ,
					lbl_ref_num        LabelType         ,
					ref_name           NameType          ,
					type_desc          InfobarType       ,
					rowpointer         RowPointerType    );
				SELECT * into #tv_ReportSet from @ReportSet 
				ALTER TABLE #tv_ReportSet ADD PRIMARY KEY (seq) ");
			TypeDesc = "";
			RCLabel = this.iGetLabel.GetLabelFn("@glbank.reason_code");
			Counter = 1;
			while (sQLUtil.SQLLessThanOrEqual(Counter, stringUtil.Len(BankRecTypes)) == true)
			{
				//BEGIN
				Type = stringUtil.Substring(BankRecTypes, Counter, 1);

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: GetCodeSp
				var GetCode = this.iGetCode.GetCodeSp(PClass: "glbank.type"
					, PCode: Type
					, PDesc: Type);
				Type = GetCode.PDesc;

				#endregion ExecuteMethodCall

				TypeDesc = stringUtil.Concat(TypeDesc, Type, ",");
				Counter = (int?)(Counter + 1);
				//END

			}
			iTemp = convertToUtil.ToInt32(stringUtil.Len(TypeDesc) - 1);
			if (sQLUtil.SQLGreaterThan(iTemp, 0) == true)
			{
				TypeDesc = stringUtil.Substring(TypeDesc, 1, iTemp);
			}
			if (sQLUtil.SQLEqual(SortBy, "D") == true)
			{
				//BEGIN
				#region CRUD LoadToRecord
				bank_hdr_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"bank_hdr.bank_code","bank_hdr.bank_code"},
						{"bank_hdr.acct","bank_hdr.acct"},
						{"bank_hdr.acct_unit1","bank_hdr.acct_unit1"},
						{"bank_hdr.acct_unit2","bank_hdr.acct_unit2"},
						{"bank_hdr.acct_unit3","bank_hdr.acct_unit3"},
						{"bank_hdr.acct_unit4","bank_hdr.acct_unit4"},
						{"glbank.type","glbank.type"},
						{"glbank.check_date","glbank.check_date"},
						{"glbank.check_num","glbank.check_num"},
						{"glbank.voided","glbank.voided"},
						{"glbank.ref_type","glbank.ref_type"},
						{"glbank.ref_num","glbank.ref_num"},
						{"glbank.check_amt","glbank.check_amt"},
						{"glbank.bank_recon","glbank.bank_recon"},
						{"glbank.bank_amt","glbank.bank_amt"},
						{"glbank.post_date","glbank.post_date"},
						{"glbank.reason_code","glbank.reason_code"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "bank_hdr",
					fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN glbank ON glbank.bank_code = bank_hdr.bank_code"),
					whereClause: collectionLoadRequestFactory.Clause("(bank_hdr.bank_code BETWEEN {1} AND {3}) AND (glbank.check_date <= {2}) AND ({0} = 1 OR glbank.voided = 0)", IncludeVoidChecks, StartBankCode, EndTransDate, EndBankCode),
					orderByClause: collectionLoadRequestFactory.Clause(" bank_hdr.bank_code, glbank.check_date, glbank.check_num"));
				#endregion  LoadToRecord

				bank_hdr_crsLoadResponseForCursor = this.appDB.Load(bank_hdr_crsLoadRequestForCursor);
				bank_hdr_crs_CursorFetch_Status = bank_hdr_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				bank_hdr_crs_CursorCounter = -1;

				//END
			}
			else
			{
				//BEGIN
				if (sQLUtil.SQLEqual(SortBy, "N") == true)
				{
					//BEGIN
					#region CRUD LoadToRecord
					bank_hdr_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"bank_hdr.bank_code","bank_hdr.bank_code"},
							{"bank_hdr.acct","bank_hdr.acct"},
							{"bank_hdr.acct_unit1","bank_hdr.acct_unit1"},
							{"bank_hdr.acct_unit2","bank_hdr.acct_unit2"},
							{"bank_hdr.acct_unit3","bank_hdr.acct_unit3"},
							{"bank_hdr.acct_unit4","bank_hdr.acct_unit4"},
							{"glbank.type","glbank.type"},
							{"glbank.check_date","glbank.check_date"},
							{"glbank.check_num","glbank.check_num"},
							{"glbank.voided","glbank.voided"},
							{"glbank.ref_type","glbank.ref_type"},
							{"glbank.ref_num","glbank.ref_num"},
							{"glbank.check_amt","glbank.check_amt"},
							{"glbank.bank_recon","glbank.bank_recon"},
							{"glbank.bank_amt","glbank.bank_amt"},
							{"glbank.post_date","glbank.post_date"},
							{"glbank.reason_code","glbank.reason_code"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "bank_hdr",
						fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN glbank ON glbank.bank_code = bank_hdr.bank_code"),
						whereClause: collectionLoadRequestFactory.Clause("(bank_hdr.bank_code BETWEEN {1} AND {3}) AND (glbank.check_date <= {2}) AND ({0} = 1 OR glbank.voided = 0)", IncludeVoidChecks, StartBankCode, EndTransDate, EndBankCode),
						orderByClause: collectionLoadRequestFactory.Clause(" bank_hdr.bank_code, glbank.check_num"));
					#endregion  LoadToRecord

					bank_hdr_crsLoadResponseForCursor = this.appDB.Load(bank_hdr_crsLoadRequestForCursor);
					bank_hdr_crs_CursorFetch_Status = bank_hdr_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
					bank_hdr_crs_CursorCounter = -1;

					//END
				}
				else
				{
					//BEGIN
					if (sQLUtil.SQLEqual(SortBy, "T") == true)
					{
						//BEGIN
						#region CRUD LoadToRecord
						bank_hdr_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
							{
								{"bank_hdr.bank_code","bank_hdr.bank_code"},
								{"bank_hdr.acct","bank_hdr.acct"},
								{"bank_hdr.acct_unit1","bank_hdr.acct_unit1"},
								{"bank_hdr.acct_unit2","bank_hdr.acct_unit2"},
								{"bank_hdr.acct_unit3","bank_hdr.acct_unit3"},
								{"bank_hdr.acct_unit4","bank_hdr.acct_unit4"},
								{"glbank.type","glbank.type"},
								{"glbank.check_date","glbank.check_date"},
								{"glbank.check_num","glbank.check_num"},
								{"glbank.voided","glbank.voided"},
								{"glbank.ref_type","glbank.ref_type"},
								{"glbank.ref_num","glbank.ref_num"},
								{"glbank.check_amt","glbank.check_amt"},
								{"glbank.bank_recon","glbank.bank_recon"},
								{"glbank.bank_amt","glbank.bank_amt"},
								{"glbank.post_date","glbank.post_date"},
								{"glbank.reason_code","glbank.reason_code"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "bank_hdr",
							fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN glbank ON glbank.bank_code = bank_hdr.bank_code"),
							whereClause: collectionLoadRequestFactory.Clause("(bank_hdr.bank_code BETWEEN {1} AND {3}) AND (glbank.check_date <= {2}) AND ({0} = 1 OR glbank.voided = 0)", IncludeVoidChecks, StartBankCode, EndTransDate, EndBankCode),
							orderByClause: collectionLoadRequestFactory.Clause(" bank_hdr.bank_code, glbank.type, glbank.check_num"));
						#endregion  LoadToRecord

						bank_hdr_crsLoadResponseForCursor = this.appDB.Load(bank_hdr_crsLoadRequestForCursor);
						bank_hdr_crs_CursorFetch_Status = bank_hdr_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
						bank_hdr_crs_CursorCounter = -1;

						//END
					}
					else
					{
						//BEGIN
						if (sQLUtil.SQLEqual(SortBy, "C") == true)
						{
							//BEGIN
							#region CRUD LoadToRecord
							bank_hdr_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
								{
									{"bank_hdr.bank_code","bank_hdr.bank_code"},
									{"bank_hdr.acct","bank_hdr.acct"},
									{"bank_hdr.acct_unit1","bank_hdr.acct_unit1"},
									{"bank_hdr.acct_unit2","bank_hdr.acct_unit2"},
									{"bank_hdr.acct_unit3","bank_hdr.acct_unit3"},
									{"bank_hdr.acct_unit4","bank_hdr.acct_unit4"},
									{"glbank.type","glbank.type"},
									{"glbank.check_date","glbank.check_date"},
									{"glbank.check_num","glbank.check_num"},
									{"glbank.voided","glbank.voided"},
									{"glbank.ref_type","glbank.ref_type"},
									{"glbank.ref_num","glbank.ref_num"},
									{"glbank.check_amt","glbank.check_amt"},
									{"glbank.bank_recon","glbank.bank_recon"},
									{"glbank.bank_amt","glbank.bank_amt"},
									{"glbank.post_date","glbank.post_date"},
									{"glbank.reason_code","glbank.reason_code"},
								},
								loadForChange: false, 
                                lockingType: LockingType.None,
                                tableName: "bank_hdr",
								fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN glbank ON glbank.bank_code = bank_hdr.bank_code"),
								whereClause: collectionLoadRequestFactory.Clause("(bank_hdr.bank_code BETWEEN {1} AND {3}) AND (glbank.check_date <= {2}) AND ({0} = 1 OR glbank.voided = 0)", IncludeVoidChecks, StartBankCode, EndTransDate, EndBankCode),
								orderByClause: collectionLoadRequestFactory.Clause(" bank_hdr.bank_code, glbank.type, glbank.check_date, glbank.check_num"));
							#endregion  LoadToRecord

							bank_hdr_crsLoadResponseForCursor = this.appDB.Load(bank_hdr_crsLoadRequestForCursor);
							bank_hdr_crs_CursorFetch_Status = bank_hdr_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
							bank_hdr_crs_CursorCounter = -1;

							//END
						}
						else
						{
							//BEGIN
							#region CRUD LoadToRecord
							bank_hdr_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
								{
									{"bank_hdr.bank_code","bank_hdr.bank_code"},
									{"bank_hdr.acct","bank_hdr.acct"},
									{"bank_hdr.acct_unit1","bank_hdr.acct_unit1"},
									{"bank_hdr.acct_unit2","bank_hdr.acct_unit2"},
									{"bank_hdr.acct_unit3","bank_hdr.acct_unit3"},
									{"bank_hdr.acct_unit4","bank_hdr.acct_unit4"},
									{"glbank.type","glbank.type"},
									{"glbank.check_date","glbank.check_date"},
									{"glbank.check_num","glbank.check_num"},
									{"glbank.voided","glbank.voided"},
									{"glbank.ref_type","glbank.ref_type"},
									{"glbank.ref_num","glbank.ref_num"},
									{"glbank.check_amt","glbank.check_amt"},
									{"glbank.bank_recon","glbank.bank_recon"},
									{"glbank.bank_amt","glbank.bank_amt"},
									{"glbank.post_date","glbank.post_date"},
									{"glbank.reason_code","glbank.reason_code"},
								},
								loadForChange: false,
                                lockingType: LockingType.None,
                                tableName: "bank_hdr",
								fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN glbank ON glbank.bank_code = bank_hdr.bank_code"),
								whereClause: collectionLoadRequestFactory.Clause("(bank_hdr.bank_code BETWEEN {1} AND {3}) AND (glbank.check_date <= {2}) AND ({0} = 1 OR glbank.voided = 0)", IncludeVoidChecks, StartBankCode, EndTransDate, EndBankCode),
								orderByClause: collectionLoadRequestFactory.Clause(" bank_hdr.bank_code"));
							#endregion  LoadToRecord

							bank_hdr_crsLoadResponseForCursor = this.appDB.Load(bank_hdr_crsLoadRequestForCursor);
							bank_hdr_crs_CursorFetch_Status = bank_hdr_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
							bank_hdr_crs_CursorCounter = -1;

							//END
						}
						//END
					}
					//END
				}
				//END
			}
			bank_hdr_crs_CursorCounter++;
			if (bank_hdr_crsLoadResponseForCursor.Items.Count > bank_hdr_crs_CursorCounter)
			{
				LookAheadBankHdrBankCode = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(0);
				LookAheadBankHdrAcct = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(1);
				LookAheadBankHdrAcctUnit1 = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(2);
				LookAheadBankHdrAcctUnit2 = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(3);
				LookAheadBankHdrAcctUnit3 = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(4);
				LookAheadBankHdrAcctUnit4 = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(5);
				LookAheadGlbankType = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(6);
				LookAheadGlbankCheckDate = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<DateTime?>(7);
				LookAheadGlbankCheckNum = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<int?>(8);
				LookAheadGlbankVoided = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<int?>(9);
				LookAheadGlbankRefType = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(10);
				LookAheadGlbankRefNum = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(11);
				LookAheadGlbankCheckAmt = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<decimal?>(12);
				LookAheadGlbankBankRecon = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<int?>(13);
				LookAheadGlbankBankAmt = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<decimal?>(14);
				LookAheadGlbankPostDate = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<DateTime?>(15);
				LookAheadGlbankReasonCode = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(16);
			}
			bank_hdr_crs_CursorFetch_Status = (bank_hdr_crs_CursorCounter == bank_hdr_crsLoadResponseForCursor.Items.Count ? -1 : 0);

			LookAheadBankHdrEof = (int?)((sQLUtil.SQLEqual(bank_hdr_crs_CursorFetch_Status, 0) == true ? 0 : 1));
			LastOfBankCode = 1;
			while (sQLUtil.SQLEqual(1, 1) == true)
			{
				//BEGIN
				if (sQLUtil.SQLEqual(LookAheadBankHdrEof, 1) == true)
				{
					break;
				}
				FirstOfBankCode = LastOfBankCode;
				BankHdrBankCode = LookAheadBankHdrBankCode;
				BankHdrAcct = LookAheadBankHdrAcct;
				BankHdrAcctUnit1 = LookAheadBankHdrAcctUnit1;
				BankHdrAcctUnit2 = LookAheadBankHdrAcctUnit2;
				BankHdrAcctUnit3 = LookAheadBankHdrAcctUnit3;
				BankHdrAcctUnit4 = LookAheadBankHdrAcctUnit4;
				GlbankType = LookAheadGlbankType;
				GlbankCheckDate = convertToUtil.ToDateTime(LookAheadGlbankCheckDate);
				GlbankCheckNum = LookAheadGlbankCheckNum;
				GlbankVoided = LookAheadGlbankVoided;
				GlbankRefType = LookAheadGlbankRefType;
				GlbankRefNum = LookAheadGlbankRefNum;
				GlbankCheckAmt = LookAheadGlbankCheckAmt;
				GlbankBankRecon = LookAheadGlbankBankRecon;
				GlbankBankAmt = LookAheadGlbankBankAmt;
				GlbankPostDate = convertToUtil.ToDateTime(LookAheadGlbankPostDate);
				GlbankReasonCode = LookAheadGlbankReasonCode;
				ReasonDescription = null;
				bank_hdr_crs_CursorCounter++;
				if (bank_hdr_crsLoadResponseForCursor.Items.Count > bank_hdr_crs_CursorCounter)
				{
					LookAheadBankHdrBankCode = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(0);
					LookAheadBankHdrAcct = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(1);
					LookAheadBankHdrAcctUnit1 = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(2);
					LookAheadBankHdrAcctUnit2 = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(3);
					LookAheadBankHdrAcctUnit3 = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(4);
					LookAheadBankHdrAcctUnit4 = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(5);
					LookAheadGlbankType = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(6);
					LookAheadGlbankCheckDate = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<DateTime?>(7);
					LookAheadGlbankCheckNum = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<int?>(8);
					LookAheadGlbankVoided = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<int?>(9);
					LookAheadGlbankRefType = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(10);
					LookAheadGlbankRefNum = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(11);
					LookAheadGlbankCheckAmt = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<decimal?>(12);
					LookAheadGlbankBankRecon = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<int?>(13);
					LookAheadGlbankBankAmt = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<decimal?>(14);
					LookAheadGlbankPostDate = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<DateTime?>(15);
					LookAheadGlbankReasonCode = bank_hdr_crsLoadResponseForCursor.Items[bank_hdr_crs_CursorCounter].GetValue<string>(16);
				}
				bank_hdr_crs_CursorFetch_Status = (bank_hdr_crs_CursorCounter == bank_hdr_crsLoadResponseForCursor.Items.Count ? -1 : 0);

				LookAheadBankHdrEof = (int?)((sQLUtil.SQLEqual(bank_hdr_crs_CursorFetch_Status, 0) == true ? 0 : 1));
				LastOfBankCode = convertToUtil.ToInt32((sQLUtil.SQLEqual(LookAheadBankHdrEof, 0) == true && stringUtil.IsNull(BankHdrBankCode == LookAheadBankHdrBankCode ? null : BankHdrBankCode, LookAheadBankHdrBankCode == BankHdrBankCode ? null : LookAheadBankHdrBankCode) == null ? 0 : 1));
				if (sQLUtil.SQLEqual(FirstOfBankCode, 1) == true)
				{
					//BEGIN
					TcAmtBankBal = 0;
					TcAmtPostBal = 0;
					if (TmpStartTransDate != null)
					{
						//BEGIN
						#region CRUD LoadToVariable
						var glbankLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_TcAmtBankBal,"isnull(SUM(CASE WHEN glbank.bank_recon = 0 THEN 0 WHEN glbank.bank_amt IS NULL THEN glbank.check_amt ELSE glbank.bank_amt END), 0)"},
								{_TcAmtPostBal,"isnull(SUM(glbank.check_amt), 0)"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "glbank",
							fromClause: collectionLoadRequestFactory.Clause(""),
							whereClause: collectionLoadRequestFactory.Clause("glbank.check_date < {1} AND glbank.bank_code = {0} AND glbank.voided = 0", BankHdrBankCode, StartTransDate),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						this.appDB.Load(glbankLoadRequest);
						TcAmtBankBal = _TcAmtBankBal;
						TcAmtPostBal = _TcAmtPostBal;
						#endregion  LoadToVariable

						__TcAmtBankBal = TcAmtBankBal;
						__TcAmtPostBal = TcAmtPostBal;
						//END
					}

					#region CRUD LoadToVariable
					var chartLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_ChartRowpointer,"chart.rowpointer"},
							{_ChartDescription,"chart.description"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "chart",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("chart.acct = {0}", BankHdrAcct),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					this.appDB.Load(chartLoadRequest);
					ChartRowpointer = _ChartRowpointer;
					ChartDescription = _ChartDescription;
					#endregion  LoadToVariable

					if (sQLUtil.SQLEqual(this.scalarFunction.Execute<int>("@@ROWCOUNT"), 0) == true)
					{
						ChartRowpointer = null;
					}
					if (ChartRowpointer != null)
					{
						TAcctDesc = ChartDescription;
					}
					else
					{
						#region CRUD ExecuteMethodCall

						var MsgApp = this.iMsgApp.MsgAppSp(Infobar: TAcctDesc
							, BaseMsg: "E=NotInMaster"
							, Parm1: "@chart");
						TAcctDesc = MsgApp.Infobar;

						#endregion ExecuteMethodCall
					}
					//END
				}
				Stdin = convertToUtil.ToInt32(stringUtil.CharIndex(GlbankType, BankRecTypes));
				if ((TmpStartTransDate == null || sQLUtil.SQLGreaterThanOrEqual(GlbankCheckDate, StartTransDate) == true) && (sQLUtil.SQLGreaterThan(Stdin, 0) == true) && (sQLUtil.SQLBetween(GlbankCheckNum, StartTransNum, EndTransNum) == true) && (sQLUtil.SQLEqual(IncludeReconciled, 1) == true || sQLUtil.SQLEqual(GlbankBankRecon, 0) == true))
				{
					//BEGIN
					if (sQLUtil.SQLEqual(GlbankVoided, 0) == true)
					{
						//BEGIN
						if (sQLUtil.SQLEqual(GlbankBankRecon, 1) == true)
						{
							TcAmtBankBal = (decimal?)(TcAmtBankBal + (GlbankBankAmt == null ? GlbankCheckAmt : GlbankBankAmt));
						}
						TcAmtPostBal = (decimal?)(TcAmtPostBal + GlbankCheckAmt);
						//END
					}
					if (sQLUtil.SQLEqual(DisplayRefFields, 1) == true)
					{
						//BEGIN
						RefNumLabel = "";
						RefName = "";
						if (GlbankRefNum != null && sQLUtil.SQLNotEqual(GlbankRefNum, "") == true)
						{
							//BEGIN
							if (stringUtil.In(GlbankRefType, new object[] { "A/P", "MAN CHK", "MAN CHQ", "WIRE PMT", "STD DRAFT", "INC DRAFT", "EFT PMT", "CASH PMT" }))
							{
								RefNumLabel = VendorLabel;
							}
							else
							{
								if (sQLUtil.SQLEqual(GlbankRefType, "P/R") == true)
								{
									RefNumLabel = EmployeeLabel;
								}
								else
								{
									if (sQLUtil.SQLEqual(GlbankRefType, "A/R") == true)
									{
										RefNumLabel = CustomerLabel;
									}
									else
									{
										RefNumLabel = OtherLabel;
									}
								}
							}
							//END
						}
						//END
					}

                    #region CRUD LoadResponseWithoutTable
                    var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                    {
                            { "bank_code", BankHdrBankCode},
                            { "account", BankHdrAcct},
                            { "acct_unit1", BankHdrAcctUnit1},
                            { "acct_unit2", BankHdrAcctUnit2},
                            { "acct_unit3", BankHdrAcctUnit3},
                            { "acct_unit4", BankHdrAcctUnit4},
                            { "acct_desc", TAcctDesc},
                            { "amt_post_bal_first", __TcAmtPostBal},
                            { "amt_bank_bal_first", __TcAmtBankBal},
                            { "type", GlbankType},
                            { "check_date", GlbankCheckDate},
                            { "check_num", GlbankCheckNum},
                            { "voided", GlbankVoided},
                            { "ref_type", GlbankRefType},
                            { "ref_num", GlbankRefNum},
                            { "check_amt", GlbankCheckAmt},
                            { "bank_recon", GlbankBankRecon},
                            { "bank_amt", GlbankBankAmt},
                            { "post_date", GlbankPostDate},
                            { "amt_post_bal", TcAmtPostBal},
                            { "amt_bank_bal", TcAmtBankBal},
                            { "lbl_reason_code", RCLabel},
                            { "reason_code", GlbankReasonCode},
                            { "reason_desc", ReasonDescription},
                            { "lbl_ref_num", RefNumLabel},
                            { "ref_name", RefName},
                            { "type_desc", TypeDesc},
                    });

                    var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
					Data = nonTableLoadResponse;
					#endregion CRUD LoadResponseWithoutTable

					#region CRUD InsertByRecords
					var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ReportSet",
						items: nonTableLoadResponse.Items);

					this.appDB.Insert(nonTableInsertRequest);
					#endregion InsertByRecords

					//END
				}
				//END
			}

			bank_hdr_crsLoadResponseForCursor = null;
			//Deallocate Cursor @bank_hdr_crs
			if (sQLUtil.SQLEqual(DisplayRefFields, 1) == true)
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ref_map TABLE (
						ref_type NVARCHAR (30),
						ref_name NVARCHAR (60),
						ref_num  NVARCHAR (7)  PRIMARY KEY (ref_type, ref_num));
					SELECT * into #tv_ref_map from @ref_map 
					ALTER TABLE #tv_ref_map ADD PRIMARY KEY (ref_type, ref_num) ");

				#region CRUD LoadArbitrary
				var tv_ref_mapLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "ref_type", "ref_type" },
						{ "ref_num", "ref_num" },
					},
					selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList  
						FROM #tv_ReportSet 
						WHERE ref_num IS NOT NULL 
						      AND ref_num != ''"));

				var tv_ref_mapLoadResponse = this.appDB.Load(tv_ref_mapLoadRequest);
				Data = tv_ref_mapLoadResponse;
				#endregion  LoadArbitrary

				#region CRUD InsertByRecords
				var tv_ref_mapInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ref_map",
					items: tv_ref_mapLoadResponse.Items);

				this.appDB.Insert(tv_ref_mapInsertRequest);
				#endregion InsertByRecords

				#region CRUD LoadToRecord
				var tv_ref_map1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"ref_name","#tv_ref_map.ref_name"},
						{"u0","vendaddr.name"},
					},
                    loadForChange: true,
                    lockingType: LockingType.UPDLock,
                    tableName: "#tv_ref_map",
                    fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN vendaddr ON vendaddr.vend_num = ref_num"),
					whereClause: collectionLoadRequestFactory.Clause("ref_type IN ('A/P', 'MAN CHK', 'MAN CHQ', 'WIRE PMT', 'STD DRAFT', 'INC DRAFT', 'EFT PMT', 'CASH PMT')"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tv_ref_map1LoadResponse = this.appDB.Load(tv_ref_map1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD UpdateByRecord
				foreach (var tv_ref_map1Item in tv_ref_map1LoadResponse.Items)
				{
					tv_ref_map1Item.SetValue<string>("ref_name", tv_ref_map1Item.GetValue<string>("u0"));
				};

				var tv_ref_map1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_ref_map",
					items: tv_ref_map1LoadResponse.Items);

				this.appDB.Update(tv_ref_map1RequestUpdate);
				#endregion UpdateByRecord

				#region CRUD LoadToRecord
				var tv_ref_map2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"ref_name","#tv_ref_map.ref_name"},
						{"u0","employee.name"},
					},
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    tableName: "#tv_ref_map",
                    fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN employee ON employee.emp_num = ref_num"),
					whereClause: collectionLoadRequestFactory.Clause("ref_type = 'P/R'"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tv_ref_map2LoadResponse = this.appDB.Load(tv_ref_map2LoadRequest);
				#endregion  LoadToRecord

				#region CRUD UpdateByRecord
				foreach (var tv_ref_map2Item in tv_ref_map2LoadResponse.Items)
				{
					tv_ref_map2Item.SetValue<string>("ref_name", tv_ref_map2Item.GetValue<string>("u0"));
				};

				var tv_ref_map2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_ref_map",
					items: tv_ref_map2LoadResponse.Items);

				this.appDB.Update(tv_ref_map2RequestUpdate);
				#endregion UpdateByRecord

				#region CRUD LoadToRecord
				var tv_ref_map3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"ref_name","#tv_ref_map.ref_name"},
						{"u0","custaddr.name"},
					},
                    loadForChange: true,
                    lockingType: LockingType.UPDLock, 
                    tableName: "#tv_ref_map",
                    fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN custaddr ON custaddr.cust_num = ref_num 
						AND custaddr.cust_seq = 0"),
					whereClause: collectionLoadRequestFactory.Clause("ref_type = 'A/R'"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tv_ref_map3LoadResponse = this.appDB.Load(tv_ref_map3LoadRequest);
				#endregion  LoadToRecord

				#region CRUD UpdateByRecord
				foreach (var tv_ref_map3Item in tv_ref_map3LoadResponse.Items)
				{
					tv_ref_map3Item.SetValue<string>("ref_name", tv_ref_map3Item.GetValue<string>("u0"));
				};

				var tv_ref_map3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_ref_map",
					items: tv_ref_map3LoadResponse.Items);

				this.appDB.Update(tv_ref_map3RequestUpdate);
				#endregion UpdateByRecord

				#region CRUD LoadToRecord
				var tv_ReportSetLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"ref_name","rs.ref_name"},
						{"u0","rm.ref_name"},
					},
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    tableName: "#tv_ReportSet",
                    fromClause: collectionLoadRequestFactory.Clause(@" AS rs INNER JOIN #tv_ref_map AS rm ON rm.ref_num = rs.ref_num 
						AND rm.ref_type = rs.ref_type"),
					whereClause: collectionLoadRequestFactory.Clause("rs.ref_num IS NOT NULL AND rs.ref_num != ''"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tv_ReportSetLoadResponse = this.appDB.Load(tv_ReportSetLoadRequest);
				#endregion  LoadToRecord

				#region CRUD UpdateByRecord
				foreach (var tv_ReportSetItem in tv_ReportSetLoadResponse.Items)
				{
					tv_ReportSetItem.SetValue<string>("ref_name", tv_ReportSetItem.GetValue<string>("u0"));
				};

				var tv_ReportSetRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_ReportSet",
					items: tv_ReportSetLoadResponse.Items);

				this.appDB.Update(tv_ReportSetRequestUpdate);
				#endregion UpdateByRecord

				//END
			}
			if (sQLUtil.SQLEqual(DisplayReasonCodes, 1) == true)
			{
				#region CRUD LoadToRecord
				var tv_ReportSet1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"reason_desc","rs.reason_desc"},
						{"u0","reason.description"},
					}, 
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    tableName: "#tv_ReportSet",
                    fromClause: collectionLoadRequestFactory.Clause(" AS rs INNER JOIN reason ON reason.reason_code = rs.reason_code"),
					whereClause: collectionLoadRequestFactory.Clause("rs.reason_code IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tv_ReportSet1LoadResponse = this.appDB.Load(tv_ReportSet1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD UpdateByRecord
				foreach (var tv_ReportSet1Item in tv_ReportSet1LoadResponse.Items)
				{
					tv_ReportSet1Item.SetValue<string>("reason_desc", tv_ReportSet1Item.GetValue<string>("u0"));
				};

				var tv_ReportSet1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_ReportSet",
					items: tv_ReportSet1LoadResponse.Items);

				this.appDB.Update(tv_ReportSet1RequestUpdate);
				#endregion UpdateByRecord
			}

			#region CRUD LoadToRecord
			var tv_ReportSet2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"seq","seq"},
					{"bank_code","bank_code"},
					{"account","account"},
					{"acct_unit1","acct_unit1"},
					{"acct_unit2","acct_unit2"},
					{"acct_unit3","acct_unit3"},
					{"acct_unit4","acct_unit4"},
					{"acct_desc","acct_desc"},
					{"amt_post_bal_first","amt_post_bal_first"},
					{"amt_bank_bal_first","amt_bank_bal_first"},
					{"type","type"},
					{"check_date","check_date"},
					{"check_num","check_num"},
					{"voided","voided"},
					{"ref_type","ref_type"},
					{"ref_num","ref_num"},
					{"check_amt","check_amt"},
					{"bank_recon","bank_recon"},
					{"bank_amt","bank_amt"},
					{"post_date","post_date"},
					{"amt_post_bal","amt_post_bal"},
					{"amt_bank_bal","amt_bank_bal"},
					{"lbl_reason_code","lbl_reason_code"},
					{"reason_code","reason_code"},
					{"reason_desc","reason_desc"},
					{"lbl_ref_num","lbl_ref_num"},
					{"ref_name","ref_name"},
					{"type_desc","type_desc"},
					{"rowpointer","rowpointer"},
					{"ReconAdjustTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'A' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconCheckTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'C' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconDepositTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'D' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconManualTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'M' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconOtherTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'O' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconDirectDepositTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'R' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconWireTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'W' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconStandardDraftTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'T' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconIncomingDraftTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'N' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconDraftDepositTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'E' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconEFTTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'F' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconCashTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1              AND type = 'H' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconTotalTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 1 THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconAdjustBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'A' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconCheckBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'C' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconDepositBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'D' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconManualBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'M' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconOtherBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'O' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconDirectDepositBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'R' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconWireBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'W' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconStandardDraftBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'T' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconIncomingDraftBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'N' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconDraftDepositBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'E' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconEFTBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'F' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconCashBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1                                         AND type = 'H' THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"ReconTotalBankAmt","SUM(CASE WHEN voided = 0 THEN (CASE WHEN bank_recon = 1 THEN ISNULL(bank_amt, check_amt) ELSE 0 END) ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconAdjustTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'A' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconCheckTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'C' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconDepositTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'D' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconManualTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'M' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconOtherTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'O' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconDirectDepositTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'R' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconWireTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'W' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconStandardDraftTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'T' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconIncomingDraftTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'N' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconDraftDepositTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'E' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconEFTTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'F' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconCashTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0              AND type = 'H' THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconTotalTransAmt","SUM(CASE WHEN voided = 0              AND bank_recon = 0 THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
					{"UnReconNetTransAmt","SUM(CASE WHEN voided = 0 THEN check_amt ELSE 0 END) OVER (PARTITION BY bank_code)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_ReportSet",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" seq"));
			var tv_ReportSet2LoadResponse = this.appDB.Load(tv_ReportSet2LoadRequest);
			#endregion  LoadToRecord

			Data = tv_ReportSet2LoadResponse;

			this.transactionFactory.CommitTransaction("");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_BankReconciliationSp(string AltExtGenSp,
			string StartBankCode = null,
			string EndBankCode = null,
			DateTime? StartTransDate = null,
			DateTime? EndTransDate = null,
			int? StartTransNum = null,
			int? EndTransNum = null,
			int? IncludeVoidChecks = null,
			int? IncludeReconciled = null,
			string SortBy = null,
			int? DisplayReasonCodes = null,
			int? DisplayRefFields = null,
			string BankRecTypes = null,
			int? StartDateOffset = null,
			int? EndDateOffset = null,
			int? DisplayHeader = null,
			string BGSessionId = null,
			string pSite = null,
			string BGUser = null)
		{
			BankCodeType _StartBankCode = StartBankCode;
			BankCodeType _EndBankCode = EndBankCode;
			GenericDateType _StartTransDate = StartTransDate;
			GenericDateType _EndTransDate = EndTransDate;
			GlCheckNumType _StartTransNum = StartTransNum;
			GlCheckNumType _EndTransNum = EndTransNum;
			FlagNyType _IncludeVoidChecks = IncludeVoidChecks;
			FlagNyType _IncludeReconciled = IncludeReconciled;
			Infobar _SortBy = SortBy;
			FlagNyType _DisplayReasonCodes = DisplayReasonCodes;
			FlagNyType _DisplayRefFields = DisplayRefFields;
			Infobar _BankRecTypes = BankRecTypes;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "StartBankCode", _StartBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndBankCode", _EndBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTransDate", _StartTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransDate", _EndTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTransNum", _StartTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTransNum", _EndTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeVoidChecks", _IncludeVoidChecks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeReconciled", _IncludeReconciled, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayReasonCodes", _DisplayReasonCodes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayRefFields", _DisplayRefFields, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankRecTypes", _BankRecTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
