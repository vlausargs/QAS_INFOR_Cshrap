//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobTransactions.cs

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
using CSI.Material;
using CSI.Production;
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Rpt_JobTransactions : IRpt_JobTransactions
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IDefineVariable iDefineVariable;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IGetAllCodes iGetAllCodes;
        readonly IStringUtil stringUtil;
        readonly IGetLabel iGetLabel;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IConvertSecondsToTimeAsStr convertSecondsToTimeAsStr;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly ICache mgSessionVariableBasedCache;
        readonly IQueryLanguage queryLanguage;
        readonly ISortOrderFactory sortOrderFactory;
        readonly IBookmarkFactory bookmarkFactory;
        readonly LoadType loadType;
        readonly int recordCap;
        string orderByStr;
        Dictionary<string, SortOrderDirection> dicJobTranOrder;
        readonly IRpt_JobTransactionsBuildClause rpt_JobTransactionsBuildClause;

        public Rpt_JobTransactions(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            IApplyDateOffset iApplyDateOffset,
            IDefineVariable iDefineVariable,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IGetAllCodes iGetAllCodes,
            IStringUtil stringUtil,
            IGetLabel iGetLabel,
            ISQLValueComparerUtil sQLUtil,
            IConvertSecondsToTimeAsStr convertSecondsToTimeAsStr,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            ICache mgSessionVariableBasedCache,
            IQueryLanguage queryLanguage,
            ISortOrderFactory sortOrderFactory,
            IBookmarkFactory bookmarkFactory,
            IRpt_JobTransactionsBuildClause rpt_JobTransactionsBuildClause)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iDefineVariable = iDefineVariable;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iGetAllCodes = iGetAllCodes;
            this.stringUtil = stringUtil;
            this.iGetLabel = iGetLabel;
            this.sQLUtil = sQLUtil;
            this.convertSecondsToTimeAsStr = convertSecondsToTimeAsStr;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.queryLanguage = queryLanguage;
            this.sortOrderFactory = sortOrderFactory;
            this.bookmarkFactory = bookmarkFactory;
            this.rpt_JobTransactionsBuildClause = rpt_JobTransactionsBuildClause;
            this.recordCap = bunchedLoadCollection.RecordCap;
            if (recordCap == -1)
            {
                recordCap = 200;
            }
            else if (recordCap == 0)
            {
                recordCap = int.MaxValue - 1;
            }

            this.loadType = bunchedLoadCollection.LoadType;
            dicJobTranOrder = new Dictionary<string, SortOrderDirection>();
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Rpt_JobTransactionsSp(
            string TransactionType = null,
            string PayType = null,
            string Posted = null,
            string EmployeeType = null,
            int? ShowDetail = null,
            string BackflushTransaction = null,
            string EmployeeStarting = null,
            string EmployeeEnding = null,
            string JobStarting = null,
            string JobEnding = null,
            int? SuffixStarting = null,
            int? SuffixEnding = null,
            DateTime? TransactionDateStarting = null,
            DateTime? TransactionDateEnding = null,
            decimal? TransactionNumberStarting = null,
            decimal? TransactionNumberEnding = null,
            string ShiftStarting = null,
            string ShiftEnding = null,
            string ReasonStarting = null,
            string ReasonEnding = null,
            string UserInitialStarting = null,
            string UserInitialEnding = null,
            string ResourceStarting = null,
            string ResourceEnding = null,
            string SortByTEJ = null,
            int? TransactionDateStartingOffset = null,
            int? TransactionDateEndingOffset = null,
            int? ViewCost = null,
            int? DisplayHeader = null,
            string PMessageLanguage = null,
            string pSite = null,
            string BGUser = null)
        {
            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {
                ICollectionLoadResponse Data = null;
                int? Severity = 0;
                int? returnCode = 0;
                string variableValue = null;
                string infobar = null;

                IBookmark currentRowBookmark = null;

                if (loadType == LoadType.Next)
                {
                    currentRowBookmark = mgSessionVariableBasedCache.Get<Bookmark>("Bookmark");
                }

                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                string Infobar = null;
                int? t_backflush = null;
                string t_move_to_txt = null;
                string t_new_txt = null;
                ListHrsMinType _RptInHrs = DBNull.Value;
                int? RptInHrs = null;
                string WhseLabel = null;
                string LotLabel = null;
                string LocLabel = null;
                string YesLabel = null;
                string NoLabel = null;
                string IssueLabel = null;
                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobTransactionsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
                {
                    //BEGIN
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobTransactionsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_JobTransactionsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
                        var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
                        if (tv_ALTGEN1LoadResponse.Items.Count > 0)
                        {
                            ALTGEN_SpName = _ALTGEN_SpName;
                        }
                        #endregion  LoadToVariable

                        var ALTGEN = AltExtGen_Rpt_JobTransactionsSp(ALTGEN_SpName,
                            TransactionType,
                            PayType,
                            Posted,
                            EmployeeType,
                            ShowDetail,
                            BackflushTransaction,
                            EmployeeStarting,
                            EmployeeEnding,
                            JobStarting,
                            JobEnding,
                            SuffixStarting,
                            SuffixEnding,
                            TransactionDateStarting,
                            TransactionDateEnding,
                            TransactionNumberStarting,
                            TransactionNumberEnding,
                            ShiftStarting,
                            ShiftEnding,
                            ReasonStarting,
                            ReasonEnding,
                            UserInitialStarting,
                            UserInitialEnding,
                            ResourceStarting,
                            ResourceEnding,
                            SortByTEJ,
                            TransactionDateStartingOffset,
                            TransactionDateEndingOffset,
                            ViewCost,
                            DisplayHeader,
                            PMessageLanguage,
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
                        //END
                    }
                    //END
                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_JobTransactionsSp") != null)
                {
                    var EXTGEN = AltExtGen_Rpt_JobTransactionsSp("dbo.EXTGEN_Rpt_JobTransactionsSp",
                        TransactionType,
                        PayType,
                        Posted,
                        EmployeeType,
                        ShowDetail,
                        BackflushTransaction,
                        EmployeeStarting,
                        EmployeeEnding,
                        JobStarting,
                        JobEnding,
                        SuffixStarting,
                        SuffixEnding,
                        TransactionDateStarting,
                        TransactionDateEnding,
                        TransactionNumberStarting,
                        TransactionNumberEnding,
                        ShiftStarting,
                        ShiftEnding,
                        ReasonStarting,
                        ReasonEnding,
                        UserInitialStarting,
                        UserInitialEnding,
                        ResourceStarting,
                        ResourceEnding,
                        SortByTEJ,
                        TransactionDateStartingOffset,
                        TransactionDateEndingOffset,
                        ViewCost,
                        DisplayHeader,
                        PMessageLanguage,
                        pSite,
                        BGUser);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                this.transactionFactory.BeginTransaction("");
                this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
                if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("JobTransactionsReport"), "COMMITTED") == true)
                {
                    this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
                }
                else
                {
                    this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                }

                #region CRUD ExecuteMethodCall
                //Please Generate the bounce for this stored procedure: DefineVariableSp
                var DefineVariable = this.iDefineVariable.DefineVariableSp(
                    VariableName: "MessageLanguage",
                    VariableValue: PMessageLanguage,
                    Infobar: Infobar);
                Infobar = DefineVariable.Infobar;
                #endregion ExecuteMethodCall

                DisplayHeader = (int?)(stringUtil.IsNull(
                    DisplayHeader,
                    1));
                TransactionType = stringUtil.IsNull(
                    TransactionType,
                    "SRMCQD");
                PayType = stringUtil.IsNull(
                    PayType,
                    "ROD");
                Posted = stringUtil.IsNull(
                    Posted,
                    "B");
                EmployeeType = stringUtil.IsNull(
                    EmployeeType,
                    "HNS");
                ShowDetail = (int?)(stringUtil.IsNull(
                    ShowDetail,
                    0));
                BackflushTransaction = stringUtil.IsNull(
                    BackflushTransaction,
                    "B");
                SortByTEJ = stringUtil.IsNull(
                    SortByTEJ,
                    "T");
                ViewCost = (int?)(stringUtil.IsNull(
                    ViewCost,
                    0));
                if (EmployeeStarting != null)
                {
                    EmployeeStarting = this.iExpandKyByType.ExpandKyByTypeFn(
                        "EmpNumType",
                        EmployeeStarting);
                }
                if (EmployeeEnding != null)
                {
                    EmployeeEnding = this.iExpandKyByType.ExpandKyByTypeFn(
                        "EmpNumType",
                        EmployeeEnding);
                }
                if (JobStarting != null)
                {
                    JobStarting = this.iExpandKyByType.ExpandKyByTypeFn(
                        "JobType",
                        JobStarting);
                }
                if (JobEnding != null)
                {
                    JobEnding = this.iExpandKyByType.ExpandKyByTypeFn(
                        "JobType",
                        JobEnding);
                }
                if (TransactionDateStarting != null)
                {
                    #region CRUD ExecuteMethodCall
                    //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                    var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                        Date: TransactionDateStarting,
                        Offset: TransactionDateStartingOffset,
                        IsEndDate: 0);
                    TransactionDateStarting = ApplyDateOffset.Date;
                    #endregion ExecuteMethodCall
                }
                if (TransactionDateEnding != null)
                {
                    #region CRUD ExecuteMethodCall
                    //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                    var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
                        Date: TransactionDateEnding,
                        Offset: TransactionDateEndingOffset,
                        IsEndDate: 1);
                    TransactionDateEnding = ApplyDateOffset1.Date;
                    #endregion ExecuteMethodCall
                }
                if (sQLUtil.SQLEqual(BackflushTransaction, "Y") == true)
                {
                    t_backflush = 1;
                }
                else
                {
                    if (sQLUtil.SQLEqual(BackflushTransaction, "N") == true)
                    {
                        t_backflush = 0;
                    }
                    else
                    {
                        t_backflush = null;
                    }
                }
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#Rptset") == null)
                {
                    this.sQLExpressionExecutor.Execute(@"Declare
					@TransNum bigint
					,@Posted InfobarType
					,@TransDate DateType
					,@TypeDesc NVARCHAR (30)
					,@EmpNum EmpNumType
					,@JobRate PayRateType
					,@Shift ShiftType
					,@Job JobType
					,@Suffix NVARCHAR (4)
					,@OperNum OperNumType
					,@IndCode IndCodeType
					,@Backflush ListYesNoType
					,@ReasonCode ReasonCodeType
					,@Hours DECIMAL (9,3)
					,@Tot CostPrcType
					,@Completed QtyUnitType
					,@Scrapped QtyUnitType
					,@MoveTo QtyUnitType
					,@Loc_Oper LocType
					,@UserCode UserCodeType
					,@CloseJob ListYesNoType
					,@CompleteOp ListYesNoType
					,@StartTime NVARCHAR (8)
					,@EndTime NVARCHAR (8)
					,@PayType InfobarType
					,@PayRate PayRateType
					,@JobCostRate PayRateType
					,@TotalCost CostPrcType
					,@ToLoc NVARCHAR (200)
					,@EmployeeName NVARCHAR (200)
					,@Item ItemType
					,@GroupField NVARCHAR (20)
					,@ItemDesc DescriptionType
					,@ResourceStarting ApsResourceType
					,@TransNumString NVARCHAR (12)
					SELECT @TransNum AS TransNum,
					@Posted AS Posted,
					@TransDate AS TransDate,
					@TypeDesc AS TypeDesc,
					@EmpNum AS EmpNum,
					@JobRate AS JobRate,
					@Shift AS Shift,
					@Job AS Job,
					@Suffix AS Suffix,
					@OperNum AS OperNum,
					@IndCode AS IndCode,
					@Backflush AS Backflush,
					@ReasonCode AS ReasonCode,
					@Hours AS Hours,
					@Tot AS Tot,
					@Completed AS Completed,
					@Scrapped AS Scrapped,
					@MoveTo AS MoveTo,
					@Loc_Oper AS Loc_Oper,
					@UserCode AS UserCode,
					@CloseJob AS CloseJob,
					@CompleteOp AS CompleteOp,
					@StartTime AS StartTime,
					@EndTime AS EndTime,
					@PayType AS PayType,
					@PayRate AS PayRate,
					@JobCostRate AS JobCostRate,
					@TotalCost AS TotalCost,
					@ToLoc AS ToLoc,
					@EmployeeName AS EmployeeName,
					@Item AS Item,
					@GroupField AS GroupField,
					@ItemDesc AS ItemDesc,
					@ResourceStarting AS ResourceId,
					@ItemDesc AS ResourceDescr,
					@TransNumString AS TransNumString
					INTO   #Rptset
					WHERE  1 = 2");
                }

                List<string> rptsetColumnName = new List<string> { "TransNum"
                                                            ,"Posted"
                                                            ,"TransDate"
                                                            ,"TypeDesc"
                                                            ,"EmpNum"
                                                            ,"JobRate"
                                                            ,"Shift"
                                                            ,"Job"
                                                            ,"Suffix"
                                                            ,"OperNum"
                                                            ,"IndCode"
                                                            ,"Backflush"
                                                            ,"ReasonCode"
                                                            ,"Hours"
                                                            ,"Tot"
                                                            ,"Completed"
                                                            ,"Scrapped"
                                                            ,"MoveTo"
                                                            ,"Loc_Oper"
                                                            ,"UserCode"
                                                            ,"CloseJob"
                                                            ,"CompleteOp"
                                                            ,"StartTime"
                                                            ,"EndTime"
                                                            ,"PayType"
                                                            ,"PayRate"
                                                            ,"JobCostRate"
                                                            ,"TotalCost"
                                                            ,"ToLoc"
                                                            ,"EmployeeName"
                                                            ,"Item"
                                                            ,"GroupField"
                                                            ,"ItemDesc"
                                                            ,"ResourceId"
                                                            ,"ResourceDescr"
                                                            ,"TransNumString"};

                WhseLabel = stringUtil.Concat(this.iGetLabel.GetLabelFn("@jobtran.whse"), ":");
                LotLabel = stringUtil.Concat(this.iGetLabel.GetLabelFn("@jobtran.lot"), ":");
                LocLabel = stringUtil.Concat(this.iGetLabel.GetLabelFn("@location.loc"), ":");
                YesLabel = stringUtil.Concat(this.iGetLabel.GetLabelFn("@:ListYesNo:1"), ":");
                NoLabel = stringUtil.Concat(this.iGetLabel.GetLabelFn("@:ListYesNo:0"), ":");
                IssueLabel = stringUtil.Concat(this.iGetLabel.GetLabelFn("@!Issue"), ":");
                t_move_to_txt = this.iGetLabel.GetLabelFn("@:JobtranType:M");
                t_new_txt = stringUtil.Concat("[", this.iGetLabel.GetLabelFn("@:FaStatus:N"), "]");

                #region CRUD LoadToVariable
                var sfcparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_RptInHrs,"rpt_in_hrs"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "sfcparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("sfcparms.parm_key = 0"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var sfcparmsLoadResponse = this.appDB.Load(sfcparmsLoadRequest);
                if (sfcparmsLoadResponse.Items.Count > 0)
                {
                    RptInHrs = _RptInHrs;
                }
                #endregion  LoadToVariable

                #region CRUD LoadToRecord
                orderByStr = "jt.trans_num";
                dicJobTranOrder.Clear();
                if (SortByTEJ == "T")
                {
                    orderByStr = "jt.trans_num";
                    dicJobTranOrder.Add("jt.trans_num", SortOrderDirection.Ascending);
                }
                else if (SortByTEJ == "E")
                {
                    orderByStr = "jt.emp_num, jt.posted, jt.trans_date, jt.trans_num";
                    dicJobTranOrder.Add("jt.emp_num", SortOrderDirection.Ascending);
                    dicJobTranOrder.Add("jt.posted", SortOrderDirection.Ascending);
                    dicJobTranOrder.Add("jt.trans_date", SortOrderDirection.Ascending);
                    dicJobTranOrder.Add("jt.trans_num", SortOrderDirection.Ascending);
                }
                else if (SortByTEJ == "J")
                {
                    orderByStr = "jt.job, jt.suffix, jt.posted, jt.trans_date, jt.trans_num";
                    dicJobTranOrder.Add("jt.job", SortOrderDirection.Ascending);
                    dicJobTranOrder.Add("jt.suffix", SortOrderDirection.Ascending);
                    dicJobTranOrder.Add("jt.posted", SortOrderDirection.Ascending);
                    dicJobTranOrder.Add("jt.trans_date", SortOrderDirection.Ascending);
                    dicJobTranOrder.Add("jt.trans_num", SortOrderDirection.Ascending);
                }
                else
                {
                    orderByStr = "jt.trans_num";
                    dicJobTranOrder.Add("jt.trans_num", SortOrderDirection.Ascending);
                }

                IParameterizedCommand whereClause = rpt_JobTransactionsBuildClause.GetWhereClause(TransactionType, PayType, Posted, EmployeeStarting, EmployeeEnding, JobStarting, JobEnding, SuffixStarting, SuffixEnding, TransactionDateStarting, TransactionDateEnding, TransactionNumberStarting, TransactionNumberEnding, ShiftStarting, ShiftEnding, ReasonStarting, ReasonEnding, UserInitialStarting, UserInitialEnding, ResourceStarting, ResourceEnding, SortByTEJ, t_backflush);
                if (currentRowBookmark != null)
                {
                    whereClause = queryLanguage.AppendBookmark(whereClause, currentRowBookmark);
                }

                var Rptset1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    { "jt.trans_num", "jt.trans_num" },
                    { "jt.posted", "jt.posted" },
                    { "jt.trans_date", "jt.trans_date" },
                    { "TypeDesc", "jt.trans_type" },
                    { "jt.emp_num", "jt.emp_num" },
                    { "JobRate", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ViewCost)} = 0 THEN 0 WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 1 THEN NULL ELSE isnull(jt.job_rate, CASE WHEN jt.pay_rate = 'R' THEN emp.mfg_reg_rate WHEN jt.pay_rate = 'O' THEN emp.mfg_ot_rate ELSE emp.mfg_dt_rate END) END" },
                    { "Shift", "jt.shift" },
                    { "jt.job", "jt.job" },
                    { "jt.suffix", "REPLICATE('0', 4 - LEN(CONVERT(NVARCHAR(4), jt.suffix))) + CONVERT(NVARCHAR(4), jt.suffix)" },
                    { "OperNum", "CASE WHEN jt.ind_code IS NULL THEN jt.oper_num ELSE NULL END" },
                    { "IndCode", "jt.ind_code" },
                    { "Backflush", "jt.backflush" },
                    { "ReasonCode", "jt.reason_code" },
                    { "Hours", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULLIF (jt.a_hrs, 0) ELSE CASE WHEN CHARINDEX(jt.trans_type, 'SRIQCDEU') > 0 THEN jt.a_hrs ELSE 0 END END" },
                    { "Tot", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ViewCost)} = 0 THEN 0 WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULLIF (jt.a_$, 0) ELSE CASE WHEN CHARINDEX(jt.trans_type, 'SRID') > 0 THEN jt.a_$ ELSE 0 END END" },
                    { "Completed", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULLIF (jt.qty_complete, 0) ELSE CASE WHEN CHARINDEX(jt.trans_type, 'RMCEU') > 0 THEN jt.qty_complete ELSE 0 END END" },
                    { "Scrapped", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULLIF (jt.qty_scrapped, 0) ELSE CASE WHEN CHARINDEX(jt.trans_type, 'RMCEU') > 0 THEN jt.qty_scrapped ELSE 0 END END" },
                    { "MoveTo", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULLIF (jt.qty_moved, 0) ELSE CASE WHEN CHARINDEX(jt.trans_type, 'RMQCEU') > 0 THEN jt.qty_moved ELSE 0 END END" },
                    { "Loc_Oper", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN isnull(CONVERT(NVARCHAR, jt.next_oper), jt.loc) ELSE CONVERT(NVARCHAR, jt.next_oper) END" },
                    { "UserCode", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULL ELSE jt.user_code END" },
                    { "CloseJob", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULL ELSE jt.close_job END" },
                    { "CompleteOp", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULL ELSE jt.complete_op END" },
                    { "StartTime", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULL ELSE CASE WHEN jt.start_time IS NULL THEN NULL ELSE CASE WHEN {variableUtil.GetQuotedValue<int?>(RptInHrs)} = 1 THEN CONVERT(DECIMAL(5, 2), jt.start_time / 3600.00) ELSE CONVERT(DECIMAL(15, 2), jt.start_time) END END END" },
                    { "EndTime", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULL ELSE CASE WHEN jt.end_time IS NULL THEN NULL ELSE CASE WHEN {variableUtil.GetQuotedValue<int?>(RptInHrs)} = 1 THEN CONVERT(DECIMAL(5, 2), jt.end_time / 3600.00) ELSE CONVERT(DECIMAL(15, 2), jt.end_time) END END END" },
                    { "PayType", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULL ELSE jt.pay_rate END" },
                    { "PayRate", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0"
                    + $"          OR {variableUtil.GetQuotedValue<int?>(ViewCost)} = 0 THEN NULL ELSE CASE WHEN CHARINDEX(jt.trans_type, 'SRID') > 0 THEN jt.pr_rate ELSE 0 END END" },
                    { "JobCostRate", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0"
                    + $"          OR {variableUtil.GetQuotedValue<int?>(ViewCost)} = 0 THEN NULL ELSE CASE WHEN CHARINDEX(jt.trans_type, 'SRID') > 0 THEN jt.job_rate ELSE 0 END END" },
                    { "TotalCost", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0"
                    + $"          OR {variableUtil.GetQuotedValue<int?>(ViewCost)} = 0 THEN NULL ELSE CASE WHEN CHARINDEX(jt.trans_type, 'SRID') > 0 THEN jt.a_$ ELSE 0 END END" },
                    { "ToLoc", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0 THEN NULL ELSE CASE WHEN NOT (CHARINDEX(jt.trans_type, 'RMCDEU') > 0"
                        + $"                                                        AND jt.next_oper IS NULL"
                    + $"                                                        AND jt.qty_moved > 0) THEN '' ELSE {variableUtil.GetQuotedValue<string>(t_move_to_txt)} + ' ' + {variableUtil.GetQuotedValue<string>(WhseLabel)} + ' ' + jt.whse + ' ' + {variableUtil.GetQuotedValue<string>(LocLabel)} + ' ' + jt.loc + ' ' + CASE WHEN item.lot_tracked = 1 THEN {variableUtil.GetQuotedValue<string>(LotLabel)} + ' ' + jt.lot + ' ' ELSE '' END + CASE WHEN EXISTS (SELECT 1"
                        + $"                                                                                                                                                                                                                                                                                         FROM   itemloc"
                        + $"                                                                                                                                                                                                                                                                                         WHERE  itemloc.whse = jt.whse"
                        + $"                                                                                                                                                                                                                                                                                                AND itemloc.item = j.item"
                    + $"                                                                                                                                                                                                                                                                                                AND itemloc.loc = jt.loc) THEN '' ELSE {variableUtil.GetQuotedValue<string>(t_new_txt)} + ' ' END + {variableUtil.GetQuotedValue<string>(IssueLabel)} + ' ' + CASE WHEN jt.issue_parent = 1 THEN {variableUtil.GetQuotedValue<string>(YesLabel)} ELSE {variableUtil.GetQuotedValue<string>(NoLabel)} END END END" },
                    { "EmployeeName", $"CASE WHEN {variableUtil.GetQuotedValue<int?>(ShowDetail)} = 0"
                    + $"          AND {variableUtil.GetQuotedValue<string>(SortByTEJ)} != 'E' THEN NULL ELSE emp.name END" },
                    { "Item", $"CASE WHEN {variableUtil.GetQuotedValue<string>(SortByTEJ)} != 'J' THEN NULL ELSE j.item END" },
                    { "GroupField", $"CASE WHEN {variableUtil.GetQuotedValue<string>(SortByTEJ)} = 'T' THEN CONVERT (NVARCHAR (1), jt.posted) WHEN {variableUtil.GetQuotedValue<string>(SortByTEJ)} = 'E' THEN emp.emp_num ELSE jt.job + '-' + REPLICATE('0', 4 - LEN(CONVERT (NVARCHAR (4), jt.suffix))) + CONVERT (NVARCHAR (4), jt.suffix) END" },
                    { "ItemDesc", "null" },
                    { "ResourceId", "jt.RESID" },
                    { "ResourceDescr", "res.DESCR" },
                    { "TransNumString", "null" },
                },
                maximumRows: recordCap + 1,
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "jobtran",
                fromClause: collectionLoadRequestFactory.Clause(@" as jt left outer join job as j on j.job = jt.job
				and j.suffix = jt.suffix
				and j.type = 'j' left outer join item on item.item = j.item left outer join employee as emp on emp.emp_num = jt.emp_num
				and charindex(emp.emp_type, {0}) > 0 left outer join resrc000 as res on res.resid = jt.resid", EmployeeType),
                whereClause: whereClause,
                orderByClause: collectionLoadRequestFactory.Clause(orderByStr));
                var Rptset1LoadResponse = this.appDB.Load(Rptset1LoadRequest);
                #endregion LoadToRecord

                if (RptInHrs != 1)
                {
                    foreach (var Rptset1Item in Rptset1LoadResponse.Items)
                    {
                        int? startTime = Rptset1Item.GetValue<int?>("StartTime");
                        int? endTime = Rptset1Item.GetValue<int?>("EndTime");
                        Rptset1Item.SetValue<string>("StartTime", convertSecondsToTimeAsStr.ConvertSecondsToTimeAsStrFn(startTime));
                        Rptset1Item.SetValue<string>("EndTime", convertSecondsToTimeAsStr.ConvertSecondsToTimeAsStrFn(endTime));
                    }
                }

                #region CRUD InsertByRecords
                Rptset1LoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(Rptset1LoadResponse, rptsetColumnName);
                var Rptset1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#Rptset",
                    items: Rptset1LoadResponse.Items);

                this.appDB.Insert(Rptset1InsertRequest);
                #endregion InsertByRecords

                if (sQLUtil.SQLEqual(SortByTEJ, "J") == true)
                {
                    //BEGIN
                    #region CRUD LoadToRecord
                    var RptSetLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"TransNum","jti.trans_num"},
                        {"ReasonCode","jti.reason_code"},
                        {"Completed","jti.qty_complete"},
                        {"Scrapped","jti.qty_scrapped"},
                        {"MoveTo","jti.qty_moved"},
                        {"ItemDesc","Item.description"},
                        {"Item","jti.item"},
                        {"Job","rs.job"},
                        {"Suffix","rs.suffix"},
                        {"TypeDesc","CAST (NULL AS NVARCHAR)"},
                        {"GroupField","rs.GroupField"},
                        {"u0","jti.next_oper"},
                        {"u1","jti.loc"},
                        {"u2","jti.lot"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "#RptSet",
                    fromClause: collectionLoadRequestFactory.Clause(@" AS rs INNER JOIN jobtranitem AS jti ON jti.trans_num = rs.TransNum INNER JOIN item ON item.item = jti.item INNER JOIN jobtran AS jt ON jt.trans_num = jti.trans_num
					AND CHARINDEX(jt.trans_type, 'DIQS') = 0"),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                    var RptSetLoadResponse = this.appDB.Load(RptSetLoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var RptSetItem in RptSetLoadResponse.Items)
                    {
                        RptSetItem.SetValue<decimal?>("TransNum", RptSetItem.GetValue<decimal?>("TransNum"));
                        RptSetItem.SetValue<string>("ReasonCode", RptSetItem.GetValue<string>("ReasonCode"));
                        RptSetItem.SetValue<decimal?>("Completed", RptSetItem.GetValue<decimal?>("Completed"));
                        RptSetItem.SetValue<decimal?>("Scrapped", RptSetItem.GetValue<decimal?>("Scrapped"));
                        RptSetItem.SetValue<decimal?>("MoveTo", RptSetItem.GetValue<decimal?>("MoveTo"));
                        RptSetItem.SetValue<string>("ItemDesc", RptSetItem.GetValue<string>("ItemDesc"));
                        RptSetItem.SetValue<string>("Item", RptSetItem.GetValue<string>("Item"));
                        RptSetItem.SetValue<string>("Job", RptSetItem.GetValue<string>("Job"));
                        RptSetItem.SetValue<string>("Suffix", RptSetItem.GetValue<string>("Suffix"));
                        RptSetItem.SetValue<string>("TypeDesc", (RptSetItem.GetValue<int?>("u0") != null ? Convert.ToString(RptSetItem.GetValue<int?>("u0")) :
                        sQLUtil.SQLNotEqual(stringUtil.IsNull(
                            RptSetItem.GetValue<string>("Item"),
                            ""), "") == true ? convertToUtil.ToString(RptSetItem.GetValue<string>("u1")) : convertToUtil.ToString(RptSetItem.GetValue<string>("u2"))));
                        RptSetItem.SetValue<string>("GroupField", RptSetItem.GetValue<string>("GroupField"));
                    };

                    var RptSetRequiredColumns = new List<string>() { "TransNum", "ReasonCode", "Completed", "Scrapped", "MoveTo", "ItemDesc", "Item", "Job", "Suffix", "TypeDesc", "GroupField" };

                    RptSetLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(RptSetLoadResponse, RptSetRequiredColumns);

                    var RptSetInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#Rptset",
                        items: RptSetLoadResponse.Items);

                    this.appDB.Insert(RptSetInsertRequest);
                    #endregion InsertByRecords
                    //END
                }

                this.sQLExpressionExecutor.Execute(@"CREATE TABLE #Codes (
				CodeClass NVARCHAR (200) COLLATE DATABASE_DEFAULT,
				CodeCode  NVARCHAR (200) COLLATE DATABASE_DEFAULT,
				CodeDesc  NVARCHAR (500) COLLATE DATABASE_DEFAULT,
				AltDesc   NVARCHAR (500) COLLATE DATABASE_DEFAULT,
				LocCode   NVARCHAR (500) COLLATE DATABASE_DEFAULT,
				BaseCode  NVARCHAR (500) COLLATE DATABASE_DEFAULT PRIMARY KEY (CodeClass, CodeCode)
				)");

                #region CRUD InsertByMethodCall
                //Please Generate the bounce for this stored procedure:GetAllCodesSp
                var CodesExecResult = this.iGetAllCodes.GetAllCodesSp(
                    Class1: "jobtran.pay_rate",
                    Class2: "jobtran.trans_type");
                var CodesLoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(CodesExecResult.Data,
                new List<string>() { "CodeClass",
                    "CodeCode",
                    "CodeDesc",
                    "AltDesc",
                    "LocCode",
                "BaseCode" });
                var CodesInsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#Codes",
                    items: CodesLoadResponse.Items);

                this.appDB.Insert(CodesInsertRequest);
                #endregion InsertByMethodCall

                #region CRUD LoadToRecord
                orderByStr = "TransNum";
                if (SortByTEJ == "T")
                {
                    orderByStr = "TransNum";
                }
                else if (SortByTEJ == "E")
                {
                    orderByStr = "EmpNum,Posted,TransDate,TransNum";
                }
                else if (SortByTEJ == "J")
                {
                    orderByStr = "Job,Suffix,Posted,TransDate,TransNum";
                }
                else
                {
                    orderByStr = "TransNum";
                }

                var Rptset3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"TranNum","CAST (NULL AS NVARCHAR)"},
                    {"Posted","r.Posted"},
                    {"TransDate","r.TransDate"},
                    {"TypeDesc","CAST (NULL AS NVARCHAR)"},
                    {"EmpNum","r.EmpNum"},
                    {"JobRate","r.JobRate"},
                    {"Shift","r.Shift"},
                    {"Job","r.Job"},
                    {"Suffix","r.Suffix"},
                    {"OperNum","r.OperNum"},
                    {"IndCode","r.IndCode"},
                    {"Backflush","r.Backflush"},
                    {"ReasonCode","r.ReasonCode"},
                    {"Hours","r.Hours"},
                    {"Tot","r.Tot"},
                    {"Completed","r.Completed"},
                    {"Scrapped","r.Scrapped"},
                    {"MoveTo","r.MoveTo"},
                    {"Loc_Oper","r.Loc_Oper"},
                    {"UserCode","r.UserCode"},
                    {"CloseJob","r.CloseJob"},
                    {"CompleteOp","r.CompleteOp"},
                    {"StartTime","r.StartTime"},
                    {"EndTime","r.EndTime"},
                    {"PayType","CAST (NULL AS NVARCHAR)"},
                    {"PayRate","r.PayRate"},
                    {"JobCostRate","r.JobCostRate"},
                    {"TotalCost","r.TotalCost"},
                    {"ToLoc","r.ToLoc"},
                    {"EmployeeName","r.EmployeeName"},
                    {"Item","r.Item"},
                    {"GroupField","r.GroupField"},
                    {"ItemDesc","r.ItemDesc"},
                    {"ResourceId","r.ResourceId"},
                    {"DESCR","RS.DESCR"},
                    {"TransNumString","r.TransNumString"},
                    {"u0","r.TransNum"},
                    {"u1","c2.CodeDesc"},
                    {"u2","c.CodeDesc"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#Rptset",
                fromClause: collectionLoadRequestFactory.Clause(@" AS r LEFT OUTER JOIN #Codes AS c ON c.CodeClass = 'jobtran.pay_rate'
				AND c.CodeCode = r.PayType LEFT OUTER JOIN #Codes AS c2 ON c2.CodeClass = 'jobtran.trans_type'
				AND c2.CodeCode = r.TypeDesc LEFT OUTER JOIN RESRC000 AS RS ON RS.RESID = R.ResourceId"),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(orderByStr));
                var Rptset3LoadResponse = this.appDB.Load(Rptset3LoadRequest);
                #endregion  LoadToRecord

                foreach (var Rptset3Item in Rptset3LoadResponse.Items)
                {
                    Rptset3Item.SetValue<string>("TranNum", Convert.ToString(Rptset3Item.GetValue<long?>("u0")));
                    Rptset3Item.SetValue<string>("Posted", Rptset3Item.GetValue<string>("Posted"));
                    Rptset3Item.SetValue<DateTime?>("TransDate", Rptset3Item.GetValue<DateTime?>("TransDate"));
                    Rptset3Item.SetValue<string>("TypeDesc", Convert.ToString(stringUtil.IsNull(
                        Rptset3Item.GetValue<string>("u1"),
                        "")));
                    Rptset3Item.SetValue<string>("EmpNum", Rptset3Item.GetValue<string>("EmpNum"));
                    Rptset3Item.SetValue<decimal?>("JobRate", Rptset3Item.GetValue<decimal?>("JobRate"));
                    Rptset3Item.SetValue<string>("Shift", Rptset3Item.GetValue<string>("Shift"));
                    Rptset3Item.SetValue<string>("Job", Rptset3Item.GetValue<string>("Job"));
                    Rptset3Item.SetValue<string>("Suffix", Rptset3Item.GetValue<string>("Suffix"));
                    Rptset3Item.SetValue<int?>("OperNum", Rptset3Item.GetValue<int?>("OperNum"));
                    Rptset3Item.SetValue<string>("IndCode", Rptset3Item.GetValue<string>("IndCode"));
                    Rptset3Item.SetValue<int?>("Backflush", Rptset3Item.GetValue<int?>("Backflush"));
                    Rptset3Item.SetValue<string>("ReasonCode", Rptset3Item.GetValue<string>("ReasonCode"));
                    Rptset3Item.SetValue<decimal?>("Hours", Rptset3Item.GetValue<decimal?>("Hours"));
                    Rptset3Item.SetValue<decimal?>("Tot", Rptset3Item.GetValue<decimal?>("Tot"));
                    Rptset3Item.SetValue<decimal?>("Completed", Rptset3Item.GetValue<decimal?>("Completed"));
                    Rptset3Item.SetValue<decimal?>("Scrapped", Rptset3Item.GetValue<decimal?>("Scrapped"));
                    Rptset3Item.SetValue<decimal?>("MoveTo", Rptset3Item.GetValue<decimal?>("MoveTo"));
                    Rptset3Item.SetValue<string>("Loc_Oper", Rptset3Item.GetValue<string>("Loc_Oper"));
                    Rptset3Item.SetValue<string>("UserCode", Rptset3Item.GetValue<string>("UserCode"));
                    Rptset3Item.SetValue<int?>("CloseJob", Rptset3Item.GetValue<int?>("CloseJob"));
                    Rptset3Item.SetValue<int?>("CompleteOp", Rptset3Item.GetValue<int?>("CompleteOp"));
                    Rptset3Item.SetValue<string>("StartTime", Rptset3Item.GetValue<string>("StartTime"));
                    Rptset3Item.SetValue<string>("EndTime", Rptset3Item.GetValue<string>("EndTime"));
                    Rptset3Item.SetValue<string>("PayType", Convert.ToString(stringUtil.IsNull(
                        Rptset3Item.GetValue<string>("u2"),
                        "")));
                    Rptset3Item.SetValue<decimal?>("PayRate", Rptset3Item.GetValue<decimal?>("PayRate"));
                    Rptset3Item.SetValue<decimal?>("JobCostRate", Rptset3Item.GetValue<decimal?>("JobCostRate"));
                    Rptset3Item.SetValue<decimal?>("TotalCost", Rptset3Item.GetValue<decimal?>("TotalCost"));
                    Rptset3Item.SetValue<string>("ToLoc", Rptset3Item.GetValue<string>("ToLoc"));
                    Rptset3Item.SetValue<string>("EmployeeName", Rptset3Item.GetValue<string>("EmployeeName"));
                    Rptset3Item.SetValue<string>("Item", Rptset3Item.GetValue<string>("Item"));
                    Rptset3Item.SetValue<string>("GroupField", Rptset3Item.GetValue<string>("GroupField"));
                    Rptset3Item.SetValue<string>("ItemDesc", Rptset3Item.GetValue<string>("ItemDesc"));
                    Rptset3Item.SetValue<string>("ResourceId", Rptset3Item.GetValue<string>("ResourceId"));
                    Rptset3Item.SetValue<string>("DESCR", Rptset3Item.GetValue<string>("DESCR"));
                    Rptset3Item.SetValue<string>("TransNumString", stringUtil.Concat(Convert.ToString(Rptset3Item.GetValue<long?>("u0")), (sQLUtil.SQLEqual(Rptset3Item.GetValue<string>("Posted"), "1") == true ? "" : "*")));
                };

                Data = Rptset3LoadResponse;

                this.sQLExpressionExecutor.Execute("DROP TABLE #Codes");
                this.transactionFactory.CommitTransaction("");

                List<string> rptsetColumnName2 = new List<string> { "jt.trans_num"
                                                            ,"jt.posted"
                                                            ,"jt.trans_date"
                                                            ,"TypeDesc"
                                                            ,"jt.emp_num"
                                                            ,"JobRate"
                                                            ,"Shift"
                                                            ,"jt.job"
                                                            ,"jt.suffix"
                                                            ,"OperNum"
                                                            ,"IndCode"
                                                            ,"Backflush"
                                                            ,"ReasonCode"
                                                            ,"Hours"
                                                            ,"Tot"
                                                            ,"Completed"
                                                            ,"Scrapped"
                                                            ,"MoveTo"
                                                            ,"Loc_Oper"
                                                            ,"UserCode"
                                                            ,"CloseJob"
                                                            ,"CompleteOp"
                                                            ,"StartTime"
                                                            ,"EndTime"
                                                            ,"PayType"
                                                            ,"PayRate"
                                                            ,"JobCostRate"
                                                            ,"TotalCost"
                                                            ,"ToLoc"
                                                            ,"EmployeeName"
                                                            ,"Item"
                                                            ,"GroupField"
                                                            ,"ItemDesc"
                                                            ,"ResourceId"
                                                            ,"ResourceDescr"
                                                            ,"TransNumString"
                                                            , "u0"
                                                            , "u1"
                                                            , "u2"};

                // Only save bookmark when rows are more than 2.
                // Otherwise, there is impossible to get next page.
                if (Rptset3LoadResponse.Items.Count >= 2)
                {
                    Rptset3LoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(Rptset3LoadResponse, rptsetColumnName2);
                    IRecordReadOnly bookmarkRow = Rptset3LoadResponse.Items[Rptset3LoadResponse.Items.Count - 2];
                    ISortOrder jobTranOrder = sortOrderFactory.Create(dicJobTranOrder);
                    IBookmark bookmark = bookmarkFactory.Create(bookmarkRow, jobTranOrder);
                    mgSessionVariableBasedCache.Insert("Bookmark", (ICachable)bookmark);

                    if (Rptset3LoadResponse.Items.Count > recordCap + 1)
                    {
                        defineProcessVariable.DefineProcessVariableSp("RecordCap", Convert.ToString(Rptset3LoadResponse.Items.Count - 1), "");
                    }

                    (returnCode, variableValue, infobar) = getVariable.GetVariableSp("Bookmark", "", 0, "", "");
                    if (!string.IsNullOrEmpty(variableValue))
                    {
                        defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
                    }
                }

                return (Data, Severity);
            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Rpt_JobTransactionsSp(
            string AltExtGenSp,
            string TransactionType = null,
            string PayType = null,
            string Posted = null,
            string EmployeeType = null,
            int? ShowDetail = null,
            string BackflushTransaction = null,
            string EmployeeStarting = null,
            string EmployeeEnding = null,
            string JobStarting = null,
            string JobEnding = null,
            int? SuffixStarting = null,
            int? SuffixEnding = null,
            DateTime? TransactionDateStarting = null,
            DateTime? TransactionDateEnding = null,
            decimal? TransactionNumberStarting = null,
            decimal? TransactionNumberEnding = null,
            string ShiftStarting = null,
            string ShiftEnding = null,
            string ReasonStarting = null,
            string ReasonEnding = null,
            string UserInitialStarting = null,
            string UserInitialEnding = null,
            string ResourceStarting = null,
            string ResourceEnding = null,
            string SortByTEJ = null,
            int? TransactionDateStartingOffset = null,
            int? TransactionDateEndingOffset = null,
            int? ViewCost = null,
            int? DisplayHeader = null,
            string PMessageLanguage = null,
            string pSite = null,
            string BGUser = null)
        {
            InfobarType _TransactionType = TransactionType;
            InfobarType _PayType = PayType;
            InfobarType _Posted = Posted;
            InfobarType _EmployeeType = EmployeeType;
            FlagNyType _ShowDetail = ShowDetail;
            InfobarType _BackflushTransaction = BackflushTransaction;
            EmpNumType _EmployeeStarting = EmployeeStarting;
            EmpNumType _EmployeeEnding = EmployeeEnding;
            JobType _JobStarting = JobStarting;
            JobType _JobEnding = JobEnding;
            SuffixType _SuffixStarting = SuffixStarting;
            SuffixType _SuffixEnding = SuffixEnding;
            DateType _TransactionDateStarting = TransactionDateStarting;
            DateType _TransactionDateEnding = TransactionDateEnding;
            HugeTransNumType _TransactionNumberStarting = TransactionNumberStarting;
            HugeTransNumType _TransactionNumberEnding = TransactionNumberEnding;
            ShiftType _ShiftStarting = ShiftStarting;
            ShiftType _ShiftEnding = ShiftEnding;
            ReasonCodeType _ReasonStarting = ReasonStarting;
            ReasonCodeType _ReasonEnding = ReasonEnding;
            UserCodeType _UserInitialStarting = UserInitialStarting;
            UserCodeType _UserInitialEnding = UserInitialEnding;
            ApsResourceType _ResourceStarting = ResourceStarting;
            ApsResourceType _ResourceEnding = ResourceEnding;
            InfobarType _SortByTEJ = SortByTEJ;
            DateOffsetType _TransactionDateStartingOffset = TransactionDateStartingOffset;
            DateOffsetType _TransactionDateEndingOffset = TransactionDateEndingOffset;
            ListYesNoType _ViewCost = ViewCost;
            ListYesNoType _DisplayHeader = DisplayHeader;
            MessageLanguageType _PMessageLanguage = PMessageLanguage;
            SiteType _pSite = pSite;
            UsernameType _BGUser = BGUser;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "TransactionType", _TransactionType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Posted", _Posted, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmployeeType", _EmployeeType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BackflushTransaction", _BackflushTransaction, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmployeeStarting", _EmployeeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmployeeEnding", _EmployeeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SuffixStarting", _SuffixStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SuffixEnding", _SuffixEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransactionDateStarting", _TransactionDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransactionDateEnding", _TransactionDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransactionNumberStarting", _TransactionNumberStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransactionNumberEnding", _TransactionNumberEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShiftStarting", _ShiftStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShiftEnding", _ShiftEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReasonStarting", _ReasonStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReasonEnding", _ReasonEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserInitialStarting", _UserInitialStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserInitialEnding", _UserInitialEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ResourceStarting", _ResourceStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ResourceEnding", _ResourceEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SortByTEJ", _SortByTEJ, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransactionDateStartingOffset", _TransactionDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransactionDateEndingOffset", _TransactionDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ViewCost", _ViewCost, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
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
