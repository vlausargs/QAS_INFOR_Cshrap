//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobHeader.cs

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
using System.Linq;
using CSI.Logistics.Customer;
using CSI.Material;
using CSI.Adapters;

namespace CSI.Reporting
{
	public class Rpt_JobHeader : IRpt_JobHeader
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly IEXTSSSFSRpt_JobHeader iEXTSSSFSRpt_JobHeader;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICopySessionVariables iCopySessionVariables;
		readonly IGetOrderInfoCustNum iGetOrderInfoCustNum;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly ITransactionFactory transactionFactory;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IReportNotesExist iReportNotesExist;
		readonly IApplyDateOffset iApplyDateOffset;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IHighAnyInt iHighAnyInt;
		readonly IStringUtil stringUtil;
		readonly ILowAnyInt iLowAnyInt;
		readonly IGetCode iGetCode;
		readonly ILeftPad iLeftPad;
		readonly ISQLValueComparerUtil sQLUtil;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
        public Rpt_JobHeader(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			IEXTSSSFSRpt_JobHeader iEXTSSSFSRpt_JobHeader,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICopySessionVariables iCopySessionVariables,
			IGetOrderInfoCustNum iGetOrderInfoCustNum,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			IGetIsolationLevel iGetIsolationLevel,
			ITransactionFactory transactionFactory,
			IIsAddonAvailable iIsAddonAvailable,
			IReportNotesExist iReportNotesExist,
			IApplyDateOffset iApplyDateOffset,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IHighAnyInt iHighAnyInt,
			IStringUtil stringUtil,
			ILowAnyInt iLowAnyInt,
			IGetCode iGetCode,
			ILeftPad iLeftPad,
			ISQLValueComparerUtil sQLUtil,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.iEXTSSSFSRpt_JobHeader = iEXTSSSFSRpt_JobHeader;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCopySessionVariables = iCopySessionVariables;
			this.iGetOrderInfoCustNum = iGetOrderInfoCustNum;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.transactionFactory = transactionFactory;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.iReportNotesExist = iReportNotesExist;
			this.iApplyDateOffset = iApplyDateOffset;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iHighAnyInt = iHighAnyInt;
			this.stringUtil = stringUtil;
			this.iLowAnyInt = iLowAnyInt;
			this.iGetCode = iGetCode;
			this.iLeftPad = iLeftPad;
			this.sQLUtil = sQLUtil;
            this.lowCharacter = lowCharacter;
            this.highCharacter = highCharacter;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobHeaderSp(string StartJob = null,
			string EndJob = null,
			int? StartSuffix = null,
			int? EndSuffix = null,
			string JobStat = null,
			string StartItem = null,
			string EndItem = null,
			string StartProdMix = null,
			string EndProdMix = null,
			DateTime? StartJobDate = null,
			DateTime? EndJobDate = null,
			int? JobHdrDate = null,
			int? PrintBCFmt = null,
			int? StartJobDateOffset = null,
			int? EndJobDateOffset = null,
			int? JobShowInternal = null,
			int? JobShowExternal = null,
			int? DisplayHeader = null,
			string BGSessionId = null,
			string pSite = null)
		{
			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			Guid? RptSessionID = null;
			string LowCharacter = null;
			string HighCharacter = null;
			Guid? job_rowpointer = null;
			int? job_noteexistsflag = null;
			string job_job = null;
			int? job_suffix = null;
			string job_description = null;
			string job_revision = null;
			string job_stat = null;
			string job_ord_type = null;
			string job_ord_num = null;
			int? job_ord_line = null;
			int? job_ord_release = null;
			decimal? job_qty_released = null;
			decimal? job_qty_complete = null;
			decimal? job_qty_scrapped = null;
			int? job_co_product_mix = null;
			DateTime? job_lst_trx_date = null;
			string job_prod_mix = null;
			string job_item = null;
			DateTime? job_job_date = null;
			string job_cust_num = null;
			string job_ref_job = null;
			int? job_ref_suf = null;
			int? job_ref_oper = null;
			int? job_ref_seq = null;
			string job_root_job = null;
			int? job_root_suf = null;
			DateTime? job_sch_start_date = null;
			DateTime? job_sch_end_date = null;
			QtyUnitNoNegType _tc_qtu_ordered = DBNull.Value;
			decimal? tc_qtu_ordered = null;
			DateType _t_due_date = DBNull.Value;
			DateTime? t_due_date = null;
			EstNumType _t_est_num = DBNull.Value;
			string t_est_num = null;
			DateType _t_order_date = DBNull.Value;
			DateTime? t_order_date = null;
			string t_status_desc = null;
			DescriptionType _t_prod_mix_desc = DBNull.Value;
			string t_prod_mix_desc = null;
			NameType _custaddr_name = DBNull.Value;
			string custaddr_name = null;
			int? rpt_set_fk = null;
			int? note_exists_flag = null;
			ICollectionLoadRequest job06_crsLoadRequestForCursor = null;
			ICollectionLoadResponse job06_crsLoadResponseForCursor = null;
			int job06_crs_CursorFetch_Status = -1;
			int job06_crs_CursorCounter = -1;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobHeaderSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobHeaderSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_JobHeaderSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Rpt_JobHeaderSp(_ALTGEN_SpName,
						StartJob,
						EndJob,
						StartSuffix,
						EndSuffix,
						JobStat,
						StartItem,
						EndItem,
						StartProdMix,
						EndProdMix,
						StartJobDate,
						EndJobDate,
						JobHdrDate,
						PrintBCFmt,
						StartJobDateOffset,
						EndJobDateOffset,
						JobShowInternal,
						JobShowExternal,
						DisplayHeader,
						BGSessionId,
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_JobHeaderSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_JobHeaderSp("dbo.EXTGEN_Rpt_JobHeaderSp",
					StartJob,
					EndJob,
					StartSuffix,
					EndSuffix,
					JobStat,
					StartItem,
					EndItem,
					StartProdMix,
					EndProdMix,
					StartJobDate,
					EndJobDate,
					JobHdrDate,
					PrintBCFmt,
					StartJobDateOffset,
					EndJobDateOffset,
					JobShowInternal,
					JobShowExternal,
					DisplayHeader,
					BGSessionId,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("JobHeaderReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(ContextName: "Rpt_JobHeaderSp"
				, SessionID: RptSessionID
				, Site: pSite);
			RptSessionID = InitSessionContext.SessionID;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CopySessionVariablesSp
			var CopySessionVariables = this.iCopySessionVariables.CopySessionVariablesSp(SessionId: BGSessionId);

			#endregion ExecuteMethodCall

			LowCharacter = convertToUtil.ToString(this.lowCharacter.LowCharacterFn());
			HighCharacter = convertToUtil.ToString(this.highCharacter.HighCharacterFn());
			StartJob = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("JobType", StartJob), LowCharacter);
			EndJob = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("JobType", EndJob), HighCharacter);
			StartSuffix = convertToUtil.ToInt32(stringUtil.IsNull(StartSuffix, this.iLowAnyInt.LowAnyIntFn("SuffixType")));
			EndSuffix = convertToUtil.ToInt32(stringUtil.IsNull(EndSuffix, this.iHighAnyInt.HighAnyIntFn("SuffixType")));
			JobStat = stringUtil.IsNull(JobStat, "FRSCH");
			StartItem = stringUtil.IsNull(StartItem, LowCharacter);
			EndItem = stringUtil.IsNull(EndItem, HighCharacter);
			StartProdMix = stringUtil.IsNull(StartProdMix, LowCharacter);
			EndProdMix = stringUtil.IsNull(EndProdMix, HighCharacter);
			JobHdrDate = (int?)(stringUtil.IsNull(JobHdrDate, 0));
			PrintBCFmt = (int?)(stringUtil.IsNull(PrintBCFmt, 0));

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(Date: StartJobDate
			, Offset: StartJobDateOffset
			, IsEndDate: 0);
			StartJobDate = ApplyDateOffset.Date;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
			var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(Date: EndJobDate
				, Offset: EndJobDateOffset
				, IsEndDate: 1);
			EndJobDate = ApplyDateOffset1.Date;

			#endregion ExecuteMethodCall

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @tt_rpt_set1 TABLE (
				    row_seq_set1   INT              IDENTITY,
				    job_prefix     NVARCHAR (20)   ,
				    job_suffix     SMALLINT        ,
				    status         NCHAR (1)       ,
				    stat_desc      NVARCHAR (40)   ,
				    prod_mix       NVARCHAR (7)    ,
				    prod_mix_desc  NVARCHAR (40)   ,
				    item1          NVARCHAR (30)   ,
				    job_date       DATETIME        ,
				    job_desc       NVARCHAR (40)   ,
				    revision       NVARCHAR (8)    ,
				    qty_ordered1   DECIMAL (19, 8) ,
				    released       DECIMAL (19, 8) ,
				    ord_ref        NVARCHAR (10)   ,
				    completed      DECIMAL (19, 8) ,
				    line           SMALLINT        ,
				    rel            SMALLINT        ,
				    scrapped       DECIMAL (19, 8) ,
				    order_date1    DATETIME        ,
				    last_trx_date  DATETIME        ,
				    due_date1      DATETIME        ,
				    estimate       NVARCHAR (10)   ,
				    cust_num1      NVARCHAR (7)    ,
				    start_date     DATETIME        ,
				    cust_name      NVARCHAR (60)   ,
				    end_date       DATETIME        ,
				    ref_job        NVARCHAR (20)   ,
				    ref_suf        SMALLINT        ,
				    oper           INT             ,
				    seq            SMALLINT        ,
				    root_job       NVARCHAR (20)   ,
				    root_suf       SMALLINT        ,
				    rowpointer     UNIQUEIDENTIFIER,
				    noteexistsflag TINYINT         );
				SELECT * into #tv_tt_rpt_set1 from @tt_rpt_set1 
				ALTER TABLE #tv_tt_rpt_set1 ADD PRIMARY KEY (row_seq_set1) ");

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @tt_rpt_set2 TABLE (
				    row_seq_set2 INT             IDENTITY,
				    rpt_set1_fk  INT            ,
				    item2        NVARCHAR (30)  ,
				    ord_num      NVARCHAR (10)  ,
				    ord_line     SMALLINT       ,
				    ord_rel      SMALLINT       ,
				    qty_released DECIMAL (19, 8),
				    qty_complete DECIMAL (19, 8),
				    qty_scrapped DECIMAL (19, 8),
				    lst_trx_date DATETIME       ,
				    cust_num2    NVARCHAR (7)   ,
				    item2_desc   NVARCHAR (40)  ,
				    order_date2  DATETIME       ,
				    due_date2    DATETIME       ,
				    qty_ordered2 DECIMAL (19, 8));
				SELECT * into #tv_tt_rpt_set2 from @tt_rpt_set2 
				ALTER TABLE #tv_tt_rpt_set2 ADD PRIMARY KEY (row_seq_set2) ");
			#region Cursor Statement

			#region CRUD LoadToRecord
			job06_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"job.rowpointer","job.rowpointer"},
					{"job.noteexistsflag","job.noteexistsflag"},
					{"job.job","job.job"},
					{"job.suffix","job.suffix"},
					{"job.description","job.description"},
					{"job.revision","job.revision"},
					{"job.stat","job.stat"},
					{"job.ord_type","job.ord_type"},
					{"job.ord_num","job.ord_num"},
					{"job.ord_line","job.ord_line"},
					{"job.ord_release","job.ord_release"},
					{"job.qty_released","job.qty_released"},
					{"job.qty_complete","job.qty_complete"},
					{"job.qty_scrapped","job.qty_scrapped"},
					{"job.co_product_mix","job.co_product_mix"},
					{"job.lst_trx_date","job.lst_trx_date"},
					{"job.prod_mix","job.prod_mix"},
					{"job.item","job.item"},
					{"job.job_date","job.job_date"},
					{"job.cust_num","job.cust_num"},
					{"job.ref_job","job.ref_job"},
					{"job.ref_suf","job.ref_suf"},
					{"job.ref_oper","job.ref_oper"},
					{"job.ref_seq","job.ref_seq"},
					{"job.root_job","job.root_job"},
					{"job.root_suf","job.root_suf"},
					{"job_sch.start_date","job_sch.start_date"},
					{"job_sch.end_date","job_sch.end_date"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "job",
				fromClause: collectionLoadRequestFactory.Clause(@" LEFT OUTER JOIN job_sch ON job_sch.job = job.job 
					AND job_sch.suffix = job.suffix"),
				whereClause: collectionLoadRequestFactory.Clause("job.type = 'J' AND job.job >= {8} AND job.job <= {11} AND job.suffix >= CASE WHEN job.job = {8} THEN {3} ELSE dbo.LowAnyInt('SuffixType') END AND job.suffix <= CASE WHEN job.job = {11} THEN {6} ELSE dbo.HighAnyInt('SuffixType') END AND job.item BETWEEN {7} AND {9} AND isnull(job.prod_mix, {0}) BETWEEN {1} AND {4} AND job.job_date BETWEEN {2} AND {5} AND CHARINDEX(job.stat, {10}) <> 0", LowCharacter, StartProdMix, StartJobDate, StartSuffix, EndProdMix, EndJobDate, EndSuffix, StartItem, StartJob, EndItem, JobStat, EndJob),
				orderByClause: collectionLoadRequestFactory.Clause(" job.job, job.suffix"));
			#endregion  LoadToRecord

			#endregion Cursor Statement
			job06_crsLoadResponseForCursor = this.appDB.Load(job06_crsLoadRequestForCursor);
			job06_crs_CursorFetch_Status = job06_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			job06_crs_CursorCounter = -1;

			while (sQLUtil.SQLEqual(1, 1) == true)
			{
				job06_crs_CursorCounter++;
				if (job06_crsLoadResponseForCursor.Items.Count > job06_crs_CursorCounter)
				{
					job_rowpointer = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<Guid?>(0);
					job_noteexistsflag = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<int?>(1);
					job_job = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(2);
					job_suffix = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<int?>(3);
					job_description = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(4);
					job_revision = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(5);
					job_stat = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(6);
					job_ord_type = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(7);
					job_ord_num = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(8);
					job_ord_line = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<int?>(9);
					job_ord_release = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<int?>(10);
					job_qty_released = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<decimal?>(11);
					job_qty_complete = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<decimal?>(12);
					job_qty_scrapped = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<decimal?>(13);
					job_co_product_mix = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<int?>(14);
					job_lst_trx_date = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<DateTime?>(15);
					job_prod_mix = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(16);
					job_item = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(17);
					job_job_date = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<DateTime?>(18);
					job_cust_num = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(19);
					job_ref_job = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(20);
					job_ref_suf = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<int?>(21);
					job_ref_oper = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<int?>(22);
					job_ref_seq = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<int?>(23);
					job_root_job = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<string>(24);
					job_root_suf = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<int?>(25);
					job_sch_start_date = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<DateTime?>(26);
					job_sch_end_date = job06_crsLoadResponseForCursor.Items[job06_crs_CursorCounter].GetValue<DateTime?>(27);
				}
				job06_crs_CursorFetch_Status = (job06_crs_CursorCounter == job06_crsLoadResponseForCursor.Items.Count ? -1 : 0);

				if (sQLUtil.SQLEqual(job06_crs_CursorFetch_Status, -1) == true)
				{
					break;
				}

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: GetCodeSp
				var GetCode = this.iGetCode.GetCodeSp(PClass: "job.stat"
					, PCode: job_stat
					, PDesc: t_status_desc);
				t_status_desc = GetCode.PDesc;

				#endregion ExecuteMethodCall

				tc_qtu_ordered = null;
				t_due_date = null;
				t_est_num = null;
				t_order_date = null;
				if (("O" == job_ord_type ? null : "O") == null)
				{
					#region CRUD LoadToVariable
					var coLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_t_est_num,"ISNULL(co.est_num, '')"},
							{_t_order_date,"co.order_date"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "co",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("co.co_num = {0}", job_ord_num),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var coLoadResponse = this.appDB.Load(coLoadRequest);
					if (coLoadResponse.Items.Count > 0)
					{
						t_est_num = _t_est_num;
						t_order_date = _t_order_date;
					}
					#endregion  LoadToVariable

					if (t_est_num == null)
					{
						#region CRUD LoadToVariable
						var cohLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_t_est_num,"ISNULL(coh.est_num, '')"},
								{_t_order_date,"coh.order_date"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "coh",
							fromClause: collectionLoadRequestFactory.Clause(""),
							whereClause: collectionLoadRequestFactory.Clause("coh.co_num = {0}", job_ord_num),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						var cohLoadResponse = this.appDB.Load(cohLoadRequest);
						if (cohLoadResponse.Items.Count > 0)
						{
							t_est_num = _t_est_num;
							t_order_date = _t_order_date;
						}
						#endregion  LoadToVariable
					}
					t_est_num = stringUtil.IsNull(t_est_num, "");

					#region CRUD LoadToVariable
					var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_tc_qtu_ordered,"ISNULL(coitem.qty_ordered, 0)"},
							{_t_due_date,"coitem.due_date"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "coitem",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("coitem.co_num = {2} AND coitem.co_line = {1} AND coitem.co_release = {0}", job_ord_release, job_ord_line, job_ord_num),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var coitemLoadResponse = this.appDB.Load(coitemLoadRequest);
					if (coitemLoadResponse.Items.Count > 0)
					{
						tc_qtu_ordered = _tc_qtu_ordered;
						t_due_date = _t_due_date;
					}
					#endregion  LoadToVariable

					if (tc_qtu_ordered == null)
					{
						#region CRUD LoadToVariable
						var citemhLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_tc_qtu_ordered,"ISNULL(citemh.qty_ordered, 0)"},
								{_t_due_date,"citemh.due_date"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "citemh",
							fromClause: collectionLoadRequestFactory.Clause(""),
							whereClause: collectionLoadRequestFactory.Clause("citemh.co_num = {2} AND citemh.co_line = {1} AND citemh.co_release = {0}", job_ord_release, job_ord_line, job_ord_num),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						var citemhLoadResponse = this.appDB.Load(citemhLoadRequest);
						if (citemhLoadResponse.Items.Count > 0)
						{
							tc_qtu_ordered = _tc_qtu_ordered;
							t_due_date = _t_due_date;
						}
						#endregion  LoadToVariable
					}
					tc_qtu_ordered = (decimal?)(stringUtil.IsNull<decimal?>(tc_qtu_ordered, 0));
				}
				else
				{
					if (("T" == job_ord_type ? null : "T") == null)
					{
						tc_qtu_ordered = 0;
						t_est_num = "";

						#region CRUD LoadToRecord
						var transferLoadRequestForScalarSubQuery = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
							{
								{"transfer.order_date","transfer.order_date"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "transfer",
							fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
							whereClause: collectionLoadRequestFactory.Clause("transfer.trn_num = {0}", job_ord_num),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						var transferLoadResponseForScalarSubQuery = this.appDB.Load(transferLoadRequestForScalarSubQuery);
						#endregion  LoadToRecord

						Data = transferLoadResponseForScalarSubQuery;

						t_order_date = convertToUtil.ToDateTime(stringUtil.IsNull<DateTime?>(((transferLoadResponseForScalarSubQuery.Items != null &&
						transferLoadResponseForScalarSubQuery.Items.Count != 0) ?
						(transferLoadResponseForScalarSubQuery.Items.FirstOrDefault().GetValue<DateTime?>("transfer.order_date")) : null), new DateTime(1900, 1, 1)));

						#region CRUD LoadToVariable
						var trnitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_tc_qtu_ordered,"ISNULL(trnitem.qty_req, 0)"},
								{_t_due_date,"trnitem.sch_ship_date"},
								{_t_est_num,"''"},
							},
							loadForChange: false,
                            lockingType: LockingType.None,
                            tableName: "trnitem",
							fromClause: collectionLoadRequestFactory.Clause(""),
							whereClause: collectionLoadRequestFactory.Clause("trnitem.trn_num = {1} AND trnitem.trn_line = {0}", job_ord_line, job_ord_num),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						var trnitemLoadResponse = this.appDB.Load(trnitemLoadRequest);
						if (trnitemLoadResponse.Items.Count > 0)
						{
							tc_qtu_ordered = _tc_qtu_ordered;
							t_due_date = _t_due_date;
							t_est_num = _t_est_num;
						}
						#endregion  LoadToVariable
					}
				}
				job_cust_num = this.iGetOrderInfoCustNum.GetOrderInfoCustNumFn(job_ord_type, job_ord_num, pSite);
				custaddr_name = null;

				#region CRUD LoadToVariable
				var custaddrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_custaddr_name,"ISNULL(custaddr.name, '')"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "custaddr",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("custaddr.cust_num = {0} AND custaddr.cust_seq = 0", job_cust_num),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var custaddrLoadResponse = this.appDB.Load(custaddrLoadRequest);
				if (custaddrLoadResponse.Items.Count > 0)
				{
					custaddr_name = _custaddr_name;
				}
				#endregion  LoadToVariable

				if ((sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("ServiceManagement"), 1) == true || sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("ServiceManagementM"), 1) == true || sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("ServiceManagement_MS"), 1) == true || sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("ServiceManagementM_MS"), 1) == true) && sQLUtil.SQLEqual(job_ord_type, "S") == true)
				{
					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: EXTSSSFSRpt_JobHeaderSp
					var EXTSSSFSRpt_JobHeader = this.iEXTSSSFSRpt_JobHeader.EXTSSSFSRpt_JobHeaderSp(Sro_Num: job_ord_num
						, Cust_Num: job_cust_num
						, Cust_Name: custaddr_name
						, Open_Date: t_order_date
						, Due_Date: t_due_date);
					job_cust_num = EXTSSSFSRpt_JobHeader.Cust_Num;
					custaddr_name = EXTSSSFSRpt_JobHeader.Cust_Name;
					t_order_date = EXTSSSFSRpt_JobHeader.Open_Date;
					t_due_date = EXTSSSFSRpt_JobHeader.Due_Date;

					#endregion ExecuteMethodCall
				}
				custaddr_name = stringUtil.IsNull(custaddr_name, "");
				t_prod_mix_desc = "";

				#region CRUD LoadToVariable
				var prod_mixLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_t_prod_mix_desc,"ISNULL(prod_mix.description, '')"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "prod_mix",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("prod_mix.prod_mix = {0}", job_prod_mix),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var prod_mixLoadResponse = this.appDB.Load(prod_mixLoadRequest);
				if (prod_mixLoadResponse.Items.Count > 0)
				{
					t_prod_mix_desc = _t_prod_mix_desc;
				}
				#endregion  LoadToVariable

				note_exists_flag = 0;
				if (sQLUtil.SQLEqual(JobShowInternal, 1) == true || sQLUtil.SQLEqual(JobShowExternal, 1) == true)
				{
					note_exists_flag = convertToUtil.ToInt32(this.iReportNotesExist.ReportNotesExistFn("job", job_rowpointer, JobShowInternal, JobShowExternal, job_noteexistsflag));
				}

				#region CRUD LoadResponseWithoutTable
				var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {
                        { "job_prefix", job_job},
                        { "job_suffix", job_suffix},
                        { "status", job_stat},
                        { "stat_desc", t_status_desc},
                        { "prod_mix", job_prod_mix},
                        { "prod_mix_desc", t_prod_mix_desc},
                        { "item1", job_item},
                        { "job_date", job_job_date},
                        { "job_desc", job_description},
                        { "revision", job_revision},
                        { "qty_ordered1", tc_qtu_ordered},
                        { "released", job_qty_released},
                        { "ord_ref", job_ord_num},
                        { "completed", job_qty_complete},
                        { "line", job_ord_line},
                        { "rel", job_ord_release},
                        { "scrapped", job_qty_scrapped},
                        { "order_date1", t_order_date},
                        { "last_trx_date", job_lst_trx_date},
                        { "due_date1", t_due_date},
                        { "estimate", t_est_num},
                        { "cust_num1", job_cust_num},
                        { "start_date", (sQLUtil.SQLEqual(JobHdrDate, 1) == true ? job_sch_start_date : null)},
                        { "cust_name", custaddr_name},
                        { "end_date", (sQLUtil.SQLEqual(JobHdrDate, 1) == true ? job_sch_end_date : null)},
                        { "ref_job", job_ref_job},
                        { "ref_suf", job_ref_suf},
                        { "oper", job_ref_oper},
                        { "seq", job_ref_seq},
                        { "root_job", job_root_job},
                        { "root_suf", job_root_suf},
                        { "rowpointer", job_rowpointer},
                        { "noteexistsflag", note_exists_flag},
                });

                var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
				Data = nonTableLoadResponse;
				#endregion CRUD LoadResponseWithoutTable

				#region CRUD InsertByRecords
				var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_rpt_set1",
					items: nonTableLoadResponse.Items);

				this.appDB.Insert(nonTableInsertRequest);
				#endregion InsertByRecords

				rpt_set_fk = this.scalarFunction.Execute<int>("@@IDENTITY");
				if (sQLUtil.SQLEqual(job_co_product_mix, 1) == true && sQLUtil.SQLEqual(PrintBCFmt, 0) == true)
				{
					#region CRUD LoadToRecord
					var tt_rpt_set2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"rpt_set1_fk",$"{variableUtil.GetValue<int?>(rpt_set_fk)}"},
							{"lst_trx_date",$"{job_lst_trx_date}"},
							{"item2","jobitem.item"},
							{"ord_num","jobitem.ord_num"},
							{"ord_line","jobitem.ord_line"},
							{"ord_rel","jobitem.ord_release"},
							{"qty_released","jobitem.qty_released"},
							{"qty_complete","jobitem.qty_complete"},
							{"qty_scrapped","jobitem.qty_scrapped"},
							{"cust_num2","jobitem.cust_num"},
							{"item2_desc","item.description"},
							{"order_date2","co.order_date"},
							{"due_date2","coitem.due_date"},
							{"qty_ordered2","coitem.qty_ordered"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "jobitem",
						fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN item ON item.item = jobitem.item LEFT OUTER JOIN co ON co.co_num = jobitem.ord_num LEFT OUTER JOIN coitem ON coitem.co_num = jobitem.ord_num 
							AND coitem.co_line = jobitem.ord_line 
							AND coitem.co_release = jobitem.ord_release"),
						whereClause: collectionLoadRequestFactory.Clause("jobitem.job = {1} AND jobitem.suffix = {0}", job_suffix, job_job),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var tt_rpt_set2LoadResponse = this.appDB.Load(tt_rpt_set2LoadRequest);
					#endregion  LoadToRecord

					#region CRUD InsertByRecords
					var tt_rpt_set2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_rpt_set2",
						items: tt_rpt_set2LoadResponse.Items);

					this.appDB.Insert(tt_rpt_set2InsertRequest);
					#endregion InsertByRecords
				}
			}
			//Deallocate Cursor job06_crs

			#region CRUD LoadToRecord
			var tv_tt_rpt_set1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"row_seq_set1","t1.row_seq_set1"},
					{"job_prefix","t1.job_prefix"},
					{"job_suffix","t1.job_suffix"},
					{"status","t1.status"},
					{"stat_desc","t1.stat_desc"},
					{"prod_mix","t1.prod_mix"},
					{"prod_mix_desc","t1.prod_mix_desc"},
					{"item1","t1.item1"},
					{"job_date","t1.job_date"},
					{"job_desc","t1.job_desc"},
					{"revision","t1.revision"},
					{"qty_ordered1","t1.qty_ordered1"},
					{"released","t1.released"},
					{"ord_ref","t1.ord_ref"},
					{"completed","t1.completed"},
					{"line","t1.line"},
					{"rel","t1.rel"},
					{"scrapped","t1.scrapped"},
					{"order_date1","t1.order_date1"},
					{"last_trx_date","t1.last_trx_date"},
					{"due_date1","t1.due_date1"},
					{"estimate","t1.estimate"},
					{"cust_num1","t1.cust_num1"},
					{"start_date","t1.start_date"},
					{"cust_name","t1.cust_name"},
					{"end_date","t1.end_date"},
					{"ref_job","t1.ref_job"},
					{"ref_suf","t1.ref_suf"},
					{"oper","t1.oper"},
					{"seq","t1.seq"},
					{"root_job","t1.root_job"},
					{"root_suf","t1.root_suf"},
					{"rowpointer","t1.rowpointer"},
					{"noteexistsflag","t1.noteexistsflag"},
					{"row_seq_set2","t2.row_seq_set2"},
					{"rpt_set1_fk","t2.rpt_set1_fk"},
					{"item2","t2.item2"},
					{"ord_num","t2.ord_num"},
					{"ord_line","t2.ord_line"},
					{"ord_rel","t2.ord_rel"},
					{"qty_released","t2.qty_released"},
					{"qty_complete","t2.qty_complete"},
					{"qty_scrapped","t2.qty_scrapped"},
					{"lst_trx_date","t2.lst_trx_date"},
					{"cust_num2","t2.cust_num2"},
					{"item2_desc","t2.item2_desc"},
					{"order_date2","t2.order_date2"},
					{"due_date2","t2.due_date2"},
					{"qty_ordered2","t2.qty_ordered2"},
					{"JobWithSuffix_BC","CAST (NULL AS NVARCHAR)"},
					{"DerJobWithSuffix","CAST (NULL AS NVARCHAR)"},
					{"DerRefJobWithSuffix","CAST (NULL AS NVARCHAR)"},
					{"DerRootJobWithSuffix","CAST (NULL AS NVARCHAR)"},
					{"DerOrderLineWithRelease","CAST (NULL AS NVARCHAR)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_tt_rpt_set1",
				fromClause: collectionLoadRequestFactory.Clause(" AS t1 LEFT OUTER JOIN #tv_tt_rpt_set2 AS t2 ON t2.rpt_set1_fk = t1.row_seq_set1"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" t1.row_seq_set1"));
			var tv_tt_rpt_set1LoadResponse = this.appDB.Load(tv_tt_rpt_set1LoadRequest);
			#endregion  LoadToRecord

			foreach (var tv_tt_rpt_set1Item in tv_tt_rpt_set1LoadResponse.Items)
			{
				tv_tt_rpt_set1Item.SetValue<int?>("row_seq_set1", tv_tt_rpt_set1Item.GetValue<int?>("row_seq_set1"));
				tv_tt_rpt_set1Item.SetValue<string>("job_prefix", tv_tt_rpt_set1Item.GetValue<string>("job_prefix"));
				tv_tt_rpt_set1Item.SetValue<int?>("job_suffix", tv_tt_rpt_set1Item.GetValue<int?>("job_suffix"));
				tv_tt_rpt_set1Item.SetValue<string>("status", tv_tt_rpt_set1Item.GetValue<string>("status"));
				tv_tt_rpt_set1Item.SetValue<string>("stat_desc", tv_tt_rpt_set1Item.GetValue<string>("stat_desc"));
				tv_tt_rpt_set1Item.SetValue<string>("prod_mix", tv_tt_rpt_set1Item.GetValue<string>("prod_mix"));
				tv_tt_rpt_set1Item.SetValue<string>("prod_mix_desc", tv_tt_rpt_set1Item.GetValue<string>("prod_mix_desc"));
				tv_tt_rpt_set1Item.SetValue<string>("item1", tv_tt_rpt_set1Item.GetValue<string>("item1"));
				tv_tt_rpt_set1Item.SetValue<DateTime?>("job_date", tv_tt_rpt_set1Item.GetValue<DateTime?>("job_date"));
				tv_tt_rpt_set1Item.SetValue<string>("job_desc", tv_tt_rpt_set1Item.GetValue<string>("job_desc"));
				tv_tt_rpt_set1Item.SetValue<string>("revision", tv_tt_rpt_set1Item.GetValue<string>("revision"));
				tv_tt_rpt_set1Item.SetValue<decimal?>("qty_ordered1", tv_tt_rpt_set1Item.GetValue<decimal?>("qty_ordered1"));
				tv_tt_rpt_set1Item.SetValue<decimal?>("released", tv_tt_rpt_set1Item.GetValue<decimal?>("released"));
				tv_tt_rpt_set1Item.SetValue<string>("ord_ref", tv_tt_rpt_set1Item.GetValue<string>("ord_ref"));
				tv_tt_rpt_set1Item.SetValue<decimal?>("completed", tv_tt_rpt_set1Item.GetValue<decimal?>("completed"));
				tv_tt_rpt_set1Item.SetValue<int?>("line", tv_tt_rpt_set1Item.GetValue<int?>("line"));
				tv_tt_rpt_set1Item.SetValue<int?>("rel", tv_tt_rpt_set1Item.GetValue<int?>("rel"));
				tv_tt_rpt_set1Item.SetValue<decimal?>("scrapped", tv_tt_rpt_set1Item.GetValue<decimal?>("scrapped"));
				tv_tt_rpt_set1Item.SetValue<DateTime?>("order_date1", tv_tt_rpt_set1Item.GetValue<DateTime?>("order_date1"));
				tv_tt_rpt_set1Item.SetValue<DateTime?>("last_trx_date", tv_tt_rpt_set1Item.GetValue<DateTime?>("last_trx_date"));
				tv_tt_rpt_set1Item.SetValue<DateTime?>("due_date1", tv_tt_rpt_set1Item.GetValue<DateTime?>("due_date1"));
				tv_tt_rpt_set1Item.SetValue<string>("estimate", tv_tt_rpt_set1Item.GetValue<string>("estimate"));
				tv_tt_rpt_set1Item.SetValue<string>("cust_num1", tv_tt_rpt_set1Item.GetValue<string>("cust_num1"));
				tv_tt_rpt_set1Item.SetValue<DateTime?>("start_date", tv_tt_rpt_set1Item.GetValue<DateTime?>("start_date"));
				tv_tt_rpt_set1Item.SetValue<string>("cust_name", tv_tt_rpt_set1Item.GetValue<string>("cust_name"));
				tv_tt_rpt_set1Item.SetValue<DateTime?>("end_date", tv_tt_rpt_set1Item.GetValue<DateTime?>("end_date"));
				tv_tt_rpt_set1Item.SetValue<string>("ref_job", tv_tt_rpt_set1Item.GetValue<string>("ref_job"));
				tv_tt_rpt_set1Item.SetValue<int?>("ref_suf", tv_tt_rpt_set1Item.GetValue<int?>("ref_suf"));
				tv_tt_rpt_set1Item.SetValue<int?>("oper", tv_tt_rpt_set1Item.GetValue<int?>("oper"));
				tv_tt_rpt_set1Item.SetValue<int?>("seq", tv_tt_rpt_set1Item.GetValue<int?>("seq"));
				tv_tt_rpt_set1Item.SetValue<string>("root_job", tv_tt_rpt_set1Item.GetValue<string>("root_job"));
				tv_tt_rpt_set1Item.SetValue<int?>("root_suf", tv_tt_rpt_set1Item.GetValue<int?>("root_suf"));
				tv_tt_rpt_set1Item.SetValue<Guid?>("rowpointer", tv_tt_rpt_set1Item.GetValue<Guid?>("rowpointer"));
				tv_tt_rpt_set1Item.SetValue<int?>("noteexistsflag", tv_tt_rpt_set1Item.GetValue<int?>("noteexistsflag"));
				tv_tt_rpt_set1Item.SetValue<int?>("row_seq_set2", tv_tt_rpt_set1Item.GetValue<int?>("row_seq_set2"));
				tv_tt_rpt_set1Item.SetValue<int?>("rpt_set1_fk", tv_tt_rpt_set1Item.GetValue<int?>("rpt_set1_fk"));
				tv_tt_rpt_set1Item.SetValue<string>("item2", tv_tt_rpt_set1Item.GetValue<string>("item2"));
				tv_tt_rpt_set1Item.SetValue<string>("ord_num", tv_tt_rpt_set1Item.GetValue<string>("ord_num"));
				tv_tt_rpt_set1Item.SetValue<int?>("ord_line", tv_tt_rpt_set1Item.GetValue<int?>("ord_line"));
				tv_tt_rpt_set1Item.SetValue<int?>("ord_rel", tv_tt_rpt_set1Item.GetValue<int?>("ord_rel"));
				tv_tt_rpt_set1Item.SetValue<decimal?>("qty_released", tv_tt_rpt_set1Item.GetValue<decimal?>("qty_released"));
				tv_tt_rpt_set1Item.SetValue<decimal?>("qty_complete", tv_tt_rpt_set1Item.GetValue<decimal?>("qty_complete"));
				tv_tt_rpt_set1Item.SetValue<decimal?>("qty_scrapped", tv_tt_rpt_set1Item.GetValue<decimal?>("qty_scrapped"));
				tv_tt_rpt_set1Item.SetValue<DateTime?>("lst_trx_date", tv_tt_rpt_set1Item.GetValue<DateTime?>("lst_trx_date"));
				tv_tt_rpt_set1Item.SetValue<string>("cust_num2", tv_tt_rpt_set1Item.GetValue<string>("cust_num2"));
				tv_tt_rpt_set1Item.SetValue<string>("item2_desc", tv_tt_rpt_set1Item.GetValue<string>("item2_desc"));
				tv_tt_rpt_set1Item.SetValue<DateTime?>("order_date2", tv_tt_rpt_set1Item.GetValue<DateTime?>("order_date2"));
				tv_tt_rpt_set1Item.SetValue<DateTime?>("due_date2", tv_tt_rpt_set1Item.GetValue<DateTime?>("due_date2"));
				tv_tt_rpt_set1Item.SetValue<decimal?>("qty_ordered2", tv_tt_rpt_set1Item.GetValue<decimal?>("qty_ordered2"));
				tv_tt_rpt_set1Item.SetValue<string>("JobWithSuffix_BC", stringUtil.Concat("*", stringUtil.Replace(stringUtil.Upper(stringUtil.RTrim(stringUtil.LTrim(stringUtil.Concat(tv_tt_rpt_set1Item.GetValue<string>("job_prefix"), stringUtil.IsNull(stringUtil.Concat("-", this.iLeftPad.LeftPadFn(Convert.ToString(tv_tt_rpt_set1Item.GetValue<int?>("job_suffix")), "0", 4)), ""))))), " ", "_"), "*"));
				tv_tt_rpt_set1Item.SetValue<string>("DerJobWithSuffix", stringUtil.Concat(tv_tt_rpt_set1Item.GetValue<string>("job_prefix"), stringUtil.IsNull(stringUtil.Concat("-", this.iLeftPad.LeftPadFn(Convert.ToString(tv_tt_rpt_set1Item.GetValue<int?>("job_suffix")), "0", 4)), "")));
				tv_tt_rpt_set1Item.SetValue<string>("DerRefJobWithSuffix", stringUtil.Concat(tv_tt_rpt_set1Item.GetValue<string>("ref_job"), stringUtil.IsNull(stringUtil.Concat("-", this.iLeftPad.LeftPadFn(Convert.ToString(tv_tt_rpt_set1Item.GetValue<int?>("ref_suf")), "0", 4)), "")));
				tv_tt_rpt_set1Item.SetValue<string>("DerRootJobWithSuffix", stringUtil.Concat(tv_tt_rpt_set1Item.GetValue<string>("root_job"), stringUtil.IsNull(stringUtil.Concat("-", this.iLeftPad.LeftPadFn(Convert.ToString(tv_tt_rpt_set1Item.GetValue<int?>("root_suf")), "0", 4)), "")));
				tv_tt_rpt_set1Item.SetValue<string>("DerOrderLineWithRelease", stringUtil.Concat(Convert.ToString(tv_tt_rpt_set1Item.GetValue<int?>("ord_line")), stringUtil.IsNull(stringUtil.Concat(" ", Convert.ToString(tv_tt_rpt_set1Item.GetValue<int?>("ord_rel"))), "")));
			};

			Data = tv_tt_rpt_set1LoadResponse;

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_JobHeaderSp(string AltExtGenSp,
			string StartJob = null,
			string EndJob = null,
			int? StartSuffix = null,
			int? EndSuffix = null,
			string JobStat = null,
			string StartItem = null,
			string EndItem = null,
			string StartProdMix = null,
			string EndProdMix = null,
			DateTime? StartJobDate = null,
			DateTime? EndJobDate = null,
			int? JobHdrDate = null,
			int? PrintBCFmt = null,
			int? StartJobDateOffset = null,
			int? EndJobDateOffset = null,
			int? JobShowInternal = null,
			int? JobShowExternal = null,
			int? DisplayHeader = null,
			string BGSessionId = null,
			string pSite = null)
		{
			JobType _StartJob = StartJob;
			JobType _EndJob = EndJob;
			SuffixType _StartSuffix = StartSuffix;
			SuffixType _EndSuffix = EndSuffix;
			StringType _JobStat = JobStat;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			ProdMixType _StartProdMix = StartProdMix;
			ProdMixType _EndProdMix = EndProdMix;
			DateType _StartJobDate = StartJobDate;
			DateType _EndJobDate = EndJobDate;
			ListYesNoType _JobHdrDate = JobHdrDate;
			ListYesNoType _PrintBCFmt = PrintBCFmt;
			DateOffsetType _StartJobDateOffset = StartJobDateOffset;
			DateOffsetType _EndJobDateOffset = EndJobDateOffset;
			ListYesNoType _JobShowInternal = JobShowInternal;
			ListYesNoType _JobShowExternal = JobShowExternal;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "StartJob", _StartJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJob", _EndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSuffix", _StartSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSuffix", _EndSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStat", _JobStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartProdMix", _StartProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProdMix", _EndProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartJobDate", _StartJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJobDate", _EndJobDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobHdrDate", _JobHdrDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBCFmt", _PrintBCFmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartJobDateOffset", _StartJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndJobDateOffset", _EndJobDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobShowInternal", _JobShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobShowExternal", _JobShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
