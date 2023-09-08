//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DirectDeposit.cs

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
using CSI.Adapters;
using CSI.Material;

namespace CSI.Reporting
{
	public class Rpt_DirectDeposit : IRpt_DirectDeposit
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
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
		readonly IApplyDateOffset iApplyDateOffset;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly IGetCode iGetCode;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly ILowString lowString;
        readonly IHighString highString;
		public Rpt_DirectDeposit(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
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
			IApplyDateOffset iApplyDateOffset,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			IGetCode iGetCode,
			ISQLValueComparerUtil sQLUtil,
            ILowString lowString,
            IHighString highString)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
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
			this.iApplyDateOffset = iApplyDateOffset;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.iGetCode = iGetCode;
			this.sQLUtil = sQLUtil;
            this.lowString = lowString;
            this.highString = highString;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_DirectDepositSp(DateTime? StartingTransDate = null,
			DateTime? EndingTransDate = null,
			string StartingEmpNum = null,
			string EndingEmpNum = null,
			int? ExOptdfDispPrenot = 0,
			int? ExOptdfDispPRec = 0,
			string ExOptdfEmplType = null,
			int? StartDateOffset = null,
			int? EndDateOffset = null,
			int? PDisplayHeader = 1,
			string StartEmpCategory = null,
			string EndEmpCategory = null,
			string pSite = null)
		{
			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			Guid? RptSessionID = null;
			int? Severity = null;
			string TDepType = null;
			decimal? TDepAmt = null;
			int? TRptPrnote = null;
			Guid? DepDtlRowPointer = null;
			int? DepDtlTransCode = null;
			string DepDtlEmpNum = null;
			DateTime? DepDtlCreateDate = null;
			decimal? DepDtlDepAmt = null;
			DateTime? DepDtlTransDate = null;
			int? DepDtlCreateSeq = null;
			RowPointerType _EmployeeRowPointer = DBNull.Value;
			Guid? EmployeeRowPointer = null;
			ListYesNoType _EmployeeDirDep = DBNull.Value;
			int? EmployeeDirDep = null;
			EmpTypeType _EmployeeEmpType = DBNull.Value;
			string EmployeeEmpType = null;
			int? DepDtlBankNum = null;
			string DepDtlDepType = null;
			EmpNameType _EmployeeName = DBNull.Value;
			string EmployeeName = null;
			decimal? EmpPrBnkDepAmt = null;
			decimal? DepDtlDepPct = null;
			SsnType _EmployeeSsn = DBNull.Value;
			string EmployeeSsn = null;
			string EmpPrBnkDepAccount = null;
			RowPointerType _PrbankRowPointer = DBNull.Value;
			Guid? PrbankRowPointer = null;
			NameType _PrbankName = DBNull.Value;
			string PrbankName = null;
			decimal? DepDtlMaxDepAmt = null;
			ICollectionLoadRequest dep_dtl_crsLoadRequestForCursor = null;
			ICollectionLoadResponse dep_dtl_crsLoadResponseForCursor = null;
			int dep_dtl_crs_CursorFetch_Status = -1;
			int dep_dtl_crs_CursorCounter = -1;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_DirectDepositSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
			{
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_DirectDepositSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_DirectDepositSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("")))
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

					var ALTGEN = AltExtGen_Rpt_DirectDepositSp(_ALTGEN_SpName,
						StartingTransDate,
						EndingTransDate,
						StartingEmpNum,
						EndingEmpNum,
						ExOptdfDispPrenot,
						ExOptdfDispPRec,
						ExOptdfEmplType,
						StartDateOffset,
						EndDateOffset,
						PDisplayHeader,
						StartEmpCategory,
						EndEmpCategory,
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
				}
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_DirectDepositSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_DirectDepositSp("dbo.EXTGEN_Rpt_DirectDepositSp",
					StartingTransDate,
					EndingTransDate,
					StartingEmpNum,
					EndingEmpNum,
					ExOptdfDispPrenot,
					ExOptdfDispPRec,
					ExOptdfEmplType,
					StartDateOffset,
					EndDateOffset,
					PDisplayHeader,
					StartEmpCategory,
					EndEmpCategory,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("DirectDepositReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(ContextName: "Rpt_DirectDepositSp"
				, SessionID: RptSessionID
				, Site: pSite);
			RptSessionID = InitSessionContext.SessionID;

			#endregion ExecuteMethodCall

			StartingEmpNum = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("EmpNumType", StartingEmpNum), this.lowString.LowStringFn("EmpNumType"));
			EndingEmpNum = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("EmpNumType", EndingEmpNum), this.highString.HighStringFn("EmpNumType"));
			ExOptdfEmplType = stringUtil.IsNull(ExOptdfEmplType, "HNS");
			StartEmpCategory = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("EmpCategoryType", StartEmpCategory), this.lowString.LowStringFn("EmpCategoryType"));
			EndEmpCategory = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("EmpCategoryType", EndEmpCategory), this.highString.HighStringFn("EmpCategoryType"));

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(Date: StartingTransDate
				, Offset: StartDateOffset
				, IsEndDate: 0);
			StartingTransDate = ApplyDateOffset.Date;

			#endregion ExecuteMethodCall


			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: EndingTransDate
				, Offset: EndDateOffset
				, IsEndDate: 1);
			EndingTransDate = ApplyDateOffset1.Date;

			#endregion ExecuteMethodCall

			Severity = 0;
			TDepAmt = 0;
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @ReportSet TABLE (
				    DepDtlTransDate    DATETIME       ,
				    DepDtlEmpNum       NVARCHAR (7)   ,
				    EmployeeName       NVARCHAR (50)  ,
				    PrbankName         NVARCHAR (60)  ,
				    EmployeeDepAmt     DECIMAL (18, 8),
				    EmployeeDepPct     DECIMAL (18, 8),
				    TRptPrnote         TINYINT        ,
				    TDepAmt            DECIMAL (18, 8),
				    DepDtlCreateDate   DATETIME       ,
				    DepDtlCreateSeq    TINYINT        ,
				    EmployeeSsn        NVARCHAR (11)  ,
				    EmployeeDepAccount NVARCHAR (20)  ,
				    TDepType           NVARCHAR (255) );
				SELECT * into #tv_ReportSet from @ReportSet ");
			#region Cursor Statement

			#region CRUD LoadToRecord
			dep_dtl_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"dep_dtl.RowPointer","dep_dtl.RowPointer"},
					{"dep_dtl.trans_code","dep_dtl.trans_code"},
					{"dep_dtl.emp_num","dep_dtl.emp_num"},
					{"dep_dtl.create_date","dep_dtl.create_date"},
					{"dep_dtl.dep_amt","dep_dtl.dep_amt"},
					{"dep_dtl.trans_date","dep_dtl.trans_date"},
					{"dep_dtl.create_seq","dep_dtl.create_seq"},
					{"dep_dtl.bank_num","dep_dtl.bank_num"},
					{"dep_dtl.dep_type","dep_dtl.dep_type"},
					{"dep_dtl.dep_pct","dep_dtl.dep_pct"},
					{"dep_dtl.max_dep_amt","dep_dtl.max_dep_amt"},
					{"emp_prbank.dep_account","emp_prbank.dep_account"},
					{"emp_prbank.dep_amt","emp_prbank.dep_amt"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "dep_dtl",
				fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN emp_prbank ON dep_dtl.emp_num = emp_prbank.emp_num 
					AND dep_dtl.bank_num = emp_prbank.bank_num 
					AND dep_dtl.account = emp_prbank.dep_account INNER JOIN employee ON dep_dtl.emp_num = employee.emp_num"),
				whereClause: collectionLoadRequestFactory.Clause("(dep_dtl.trans_date >= {0}) AND (dep_dtl.trans_date <= {2}) AND (dep_dtl.emp_num BETWEEN {3} AND {5}) AND (ISNULL(employee.emp_category, '') BETWEEN {1} AND {4})", StartingTransDate, StartEmpCategory, EndingTransDate, StartingEmpNum, EndEmpCategory, EndingEmpNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			#endregion  LoadToRecord

			#endregion Cursor Statement
			dep_dtl_crsLoadResponseForCursor = this.appDB.Load(dep_dtl_crsLoadRequestForCursor);
			dep_dtl_crs_CursorFetch_Status = dep_dtl_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			dep_dtl_crs_CursorCounter = -1;

			while (sQLUtil.SQLEqual(Severity, 0) == true)
			{
				dep_dtl_crs_CursorCounter++;
				if (dep_dtl_crsLoadResponseForCursor.Items.Count > dep_dtl_crs_CursorCounter)
				{
					DepDtlRowPointer = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<Guid?>(0);
					DepDtlTransCode = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<int?>(1);
					DepDtlEmpNum = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<string>(2);
					DepDtlCreateDate = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<DateTime?>(3);
					DepDtlDepAmt = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<decimal?>(4);
					DepDtlTransDate = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<DateTime?>(5);
					DepDtlCreateSeq = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<int?>(6);
					DepDtlBankNum = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<int?>(7);
					DepDtlDepType = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<string>(8);
					DepDtlDepPct = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<decimal?>(9);
					DepDtlMaxDepAmt = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<decimal?>(10);
					EmpPrBnkDepAccount = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<string>(11);
					EmpPrBnkDepAmt = dep_dtl_crsLoadResponseForCursor.Items[dep_dtl_crs_CursorCounter].GetValue<decimal?>(12);
				}
				dep_dtl_crs_CursorFetch_Status = (dep_dtl_crs_CursorCounter == dep_dtl_crsLoadResponseForCursor.Items.Count ? -1 : 0);

				if (sQLUtil.SQLEqual(dep_dtl_crs_CursorFetch_Status, -1) == true)
				{
					break;
				}
				TRptPrnote = convertToUtil.ToInt32(stringUtil.CharIndex(Convert.ToString((DepDtlTransCode % 10)), "38"));
				EmployeeRowPointer = null;
				EmployeeDirDep = 0;
				EmployeeEmpType = null;
				EmployeeName = null;
				EmployeeSsn = null;

				#region CRUD LoadToVariable
				var employeeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_EmployeeRowPointer,"employee.RowPointer"},
						{_EmployeeDirDep,"employee.dir_dep"},
						{_EmployeeEmpType,"employee.emp_type"},
						{_EmployeeName,"employee.name"},
						{_EmployeeSsn,"dbo.MaskSsnByHrParms(employee.ssn)"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "employee",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("employee.emp_num = {0}", DepDtlEmpNum),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var employeeLoadResponse = this.appDB.Load(employeeLoadRequest);
				if (employeeLoadResponse.Items.Count > 0)
				{
					EmployeeRowPointer = _EmployeeRowPointer;
					EmployeeDirDep = _EmployeeDirDep;
					EmployeeEmpType = _EmployeeEmpType;
					EmployeeName = _EmployeeName;
					EmployeeSsn = _EmployeeSsn;
				}
				#endregion  LoadToVariable

				if ((sQLUtil.SQLEqual(ExOptdfDispPrenot, 1) == true && sQLUtil.SQLEqual(TRptPrnote, 0) == true) || (sQLUtil.SQLEqual(EmployeeDirDep, 0) == true) || (sQLUtil.SQLEqual(ExOptdfDispPRec, 0) == true && DepDtlCreateDate != null) || (sQLUtil.SQLEqual(stringUtil.CharIndex(EmployeeEmpType, ExOptdfEmplType), 0) == true))
				{
					continue;
				}
				PrbankRowPointer = null;
				PrbankName = null;

				#region CRUD LoadToVariable
				var prbankLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_PrbankRowPointer,"prbank.RowPointer"},
						{_PrbankName,"prbank.name"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "prbank",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("prbank.bank_num = {0}", DepDtlBankNum),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var prbankLoadResponse = this.appDB.Load(prbankLoadRequest);
				if (prbankLoadResponse.Items.Count > 0)
				{
					PrbankRowPointer = _PrbankRowPointer;
					PrbankName = _PrbankName;
				}
				#endregion  LoadToVariable

				if (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(Convert.ToString((DepDtlTransCode % 10)), "78"), 0) == true)
				{
					TDepAmt = (decimal?)(-DepDtlDepAmt);
				}
				else
				{
					TDepAmt = DepDtlDepAmt;
				}

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: GetCodeSp
				var GetCode = this.iGetCode.GetCodeSp(PClass: "dep_dtl.dep_type"
					, PCode: DepDtlDepType
					, PDesc: TDepType);
				TDepType = GetCode.PDesc;

				#endregion ExecuteMethodCall

				#region CRUD LoadResponseWithoutTable
				var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
					{
						{ "DepDtlTransDate", variableUtil.GetValue<DateTime?>(DepDtlTransDate,true)},
						{ "DepDtlEmpNum", variableUtil.GetValue<string>(DepDtlEmpNum,true)},
						{ "EmployeeName", variableUtil.GetValue<string>(EmployeeName,true)},
						{ "PrbankName", variableUtil.GetValue<string>(PrbankName,true)},
						{ "EmployeeDepAmt", variableUtil.GetValue<decimal?>(EmpPrBnkDepAmt,true)},
						{ "EmployeeDepPct", variableUtil.GetValue<decimal?>(DepDtlDepPct,true)},
						{ "TRptPrnote", variableUtil.GetValue<int?>(TRptPrnote,true)},
						{ "TDepAmt", variableUtil.GetValue<decimal?>(TDepAmt,true)},
						{ "DepDtlCreateDate", variableUtil.GetValue<DateTime?>(DepDtlCreateDate,true)},
						{ "DepDtlCreateSeq", variableUtil.GetValue<int?>(DepDtlCreateSeq,true)},
						{ "EmployeeSsn", variableUtil.GetValue<string>(EmployeeSsn,true)},
						{ "EmployeeDepAccount", variableUtil.GetValue<string>(EmpPrBnkDepAccount,true)},
						{ "TDepType", variableUtil.GetValue<string>(TDepType,true)},
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
			//Deallocate Cursor dep_dtl_crs

			#region CRUD LoadColumn
			var tv_ReportSetLoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
				{
					"DepDtlTransDate",
					"DepDtlEmpNum",
					"EmployeeName",
					"PrbankName",
					"EmployeeDepAmt",
					"EmployeeDepPct",
					"TRptPrnote",
					"TDepAmt",
					"DepDtlCreateDate",
					"DepDtlCreateSeq",
					"EmployeeSsn",
					"EmployeeDepAccount",
					"TDepType",
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_ReportSet",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var tv_ReportSetLoadResponse = this.appDB.Load(tv_ReportSetLoadRequest);
			Data = tv_ReportSetLoadResponse;
			#endregion  LoadColumn

			this.transactionFactory.CommitTransaction("");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_DirectDepositSp(string AltExtGenSp,
			DateTime? StartingTransDate = null,
			DateTime? EndingTransDate = null,
			string StartingEmpNum = null,
			string EndingEmpNum = null,
			int? ExOptdfDispPrenot = 0,
			int? ExOptdfDispPRec = 0,
			string ExOptdfEmplType = null,
			int? StartDateOffset = null,
			int? EndDateOffset = null,
			int? PDisplayHeader = 1,
			string StartEmpCategory = null,
			string EndEmpCategory = null,
			string pSite = null)
		{
			DateType _StartingTransDate = StartingTransDate;
			DateType _EndingTransDate = EndingTransDate;
			EmpNumType _StartingEmpNum = StartingEmpNum;
			EmpNumType _EndingEmpNum = EndingEmpNum;
			FlagNyType _ExOptdfDispPrenot = ExOptdfDispPrenot;
			FlagNyType _ExOptdfDispPRec = ExOptdfDispPRec;
			Infobar _ExOptdfEmplType = ExOptdfEmplType;
			DateOffsetType _StartDateOffset = StartDateOffset;
			DateOffsetType _EndDateOffset = EndDateOffset;
			FlagNyType _PDisplayHeader = PDisplayHeader;
			EmpCategoryType _StartEmpCategory = StartEmpCategory;
			EmpCategoryType _EndEmpCategory = EndEmpCategory;
			SiteType _pSite = pSite;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "StartingTransDate", _StartingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDate", _EndingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingEmpNum", _StartingEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingEmpNum", _EndingEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfDispPrenot", _ExOptdfDispPrenot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfDispPRec", _ExOptdfDispPRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExOptdfEmplType", _ExOptdfEmplType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDateOffset", _StartDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOffset", _EndDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartEmpCategory", _StartEmpCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndEmpCategory", _EndEmpCategory, ParameterDirection.Input);
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
