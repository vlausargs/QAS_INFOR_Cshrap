//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobPickList.cs

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
using CSI.Production;
using CSI.Material;

namespace CSI.Reporting
{
	public class Rpt_JobPickList : IRpt_JobPickList
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IInitSessionContextWithUser iInitSessionContextWithUser;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICopySessionVariables iCopySessionVariables;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IAddProcessErrorLog iAddProcessErrorLog;
		readonly ITransactionFactory transactionFactory;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly IGetWinRegDecGroup iGetWinRegDecGroup;
		readonly IFixMaskForCrystal iFixMaskForCrystal;
		readonly IDefineVariable iDefineVariable;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IGetCodeDesc iGetCodeDesc;
		readonly IStringUtil stringUtil;
		readonly string iUserName;
		readonly IJobPick iJobPick;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly IFmtJob iFmtJob;

		public Rpt_JobPickList(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
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
			IAddProcessErrorLog iAddProcessErrorLog,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			IGetWinRegDecGroup iGetWinRegDecGroup,
			IFixMaskForCrystal iFixMaskForCrystal,
			IDefineVariable iDefineVariable,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IGetCodeDesc iGetCodeDesc,
			IStringUtil stringUtil,
			string iUserName,
			IJobPick iJobPick,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			IFmtJob iFmtJob)
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
			this.iCopySessionVariables = iCopySessionVariables;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iAddProcessErrorLog = iAddProcessErrorLog;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.iGetWinRegDecGroup = iGetWinRegDecGroup;
			this.iFixMaskForCrystal = iFixMaskForCrystal;
			this.iDefineVariable = iDefineVariable;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iGetCodeDesc = iGetCodeDesc;
			this.stringUtil = stringUtil;
			this.iUserName = iUserName;
			this.iJobPick = iJobPick;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iFmtJob = iFmtJob;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_JobPickListSp(
			string Job = null,
			int? Suffix = null,
			string Item = null,
			string Whse = null,
			DateTime? PostDate = null,
			int? StartingOperNum = null,
			int? EndingOperNum = null,
			int? SortByLoc = null,
			int? IncludeSerialNumbers = null,
			int? ReprintPickListItems = null,
			int? PostMaterialIssues = null,
			int? PageBetweenOperations = null,
			int? PrintSecondaryLocations = null,
			int? ExtendByScrapFactor = null,
			int? PrintBarCode = null,
			int? DisplayHeader = null,
			string PMessageLanguage = null,
			int? TaskID = null,
			decimal? UserID = null,
			string BGSessionId = null,
			string pSite = null)
		{
			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			string Infobar = null;
			int? Severity = null;
			Guid? ID = null;
			LongListType _UserName = DBNull.Value;
			string UserName = null;
			InputMaskType _QtyUnitFormat = DBNull.Value;
			string QtyUnitFormat = null;
			DecimalPlacesType _PlacesQtyUnit = DBNull.Value;
			int? PlacesQtyUnit = null;
			int? Counter = null;

			if (existsChecker.Exists(
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobPickListSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_JobPickListSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_JobPickListSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Rpt_JobPickListSp(_ALTGEN_SpName,
						Job,
						Suffix,
						Item,
						Whse,
						PostDate,
						StartingOperNum,
						EndingOperNum,
						SortByLoc,
						IncludeSerialNumbers,
						ReprintPickListItems,
						PostMaterialIssues,
						PageBetweenOperations,
						PrintSecondaryLocations,
						ExtendByScrapFactor,
						PrintBarCode,
						DisplayHeader,
						PMessageLanguage,
						TaskID,
						UserID,
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_JobPickListSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_JobPickListSp("dbo.EXTGEN_Rpt_JobPickListSp",
					Job,
					Suffix,
					Item,
					Whse,
					PostDate,
					StartingOperNum,
					EndingOperNum,
					SortByLoc,
					IncludeSerialNumbers,
					ReprintPickListItems,
					PostMaterialIssues,
					PageBetweenOperations,
					PrintSecondaryLocations,
					ExtendByScrapFactor,
					PrintBarCode,
					DisplayHeader,
					PMessageLanguage,
					TaskID,
					UserID,
					BGSessionId,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.sQLExpressionExecutor.Execute(@"CREATE TABLE #PickList (
				    hdr_Job               NVARCHAR (30)   COLLATE DATABASE_DEFAULT,
				    hdr_JobDate           DATETIME       ,
				    hdr_JobStat           NCHAR           COLLATE DATABASE_DEFAULT,
				    hdr_JobStatDesc       NVARCHAR (30)   COLLATE DATABASE_DEFAULT,
				    hdr_JobSchEndDate     DATETIME       ,
				    hdr_ProdMix           NVARCHAR (7)    COLLATE DATABASE_DEFAULT,
				    hdr_ProdMixDesc       NVARCHAR (40)   COLLATE DATABASE_DEFAULT,
				    hdr_JobItem           NVARCHAR (30)   COLLATE DATABASE_DEFAULT,
				    hdr_JobItemDesc       NVARCHAR (40)   COLLATE DATABASE_DEFAULT,
				    hdr_JobQtyReleased    DECIMAL (19, 8),
				    hdr_JobRevision       NVARCHAR (8)    COLLATE DATABASE_DEFAULT,
				    hdr_JobWhse           NVARCHAR (4)    COLLATE DATABASE_DEFAULT,
				    sub_JobMatlOperNum    INT            ,
				    sub_JobRouteWC        NVARCHAR (6)    COLLATE DATABASE_DEFAULT,
				    sub_WCDecription      NVARCHAR (40)   COLLATE DATABASE_DEFAULT,
				    sub_JrtSchStartDate   DATETIME       ,
				    sub_JrtSchEndDate     DATETIME       ,
				    det_OperNum           INT            ,
				    det_JobSequence       NVARCHAR (30)   COLLATE DATABASE_DEFAULT,
				    det_JobMatlItem       NVARCHAR (30)   COLLATE DATABASE_DEFAULT,
				    det_JobMatlDesciption NVARCHAR (40)   COLLATE DATABASE_DEFAULT,
				    det_JobMatlU_M        NVARCHAR (3)    COLLATE DATABASE_DEFAULT,
				    det_TotalRequired     DECIMAL (19, 8),
				    det_JobMatlQtyIssued  DECIMAL (19, 8),
				    det_QtyAvailable      DECIMAL (19, 8),
				    det_QtyToPick         DECIMAL (19, 8),
				    det_Location          NVARCHAR (100)  COLLATE DATABASE_DEFAULT,
				    det_LotDescription    NVARCHAR (40)   COLLATE DATABASE_DEFAULT,
				    det_JobPicked         TINYINT        ,
				    det_Reprint           BIT            ,
				    det_QtyRequiredToPick NVARCHAR (1)    COLLATE DATABASE_DEFAULT,
				    det_Exception         NVARCHAR (100)  COLLATE DATABASE_DEFAULT,
				    det_SerialNum         NVARCHAR (60)   COLLATE DATABASE_DEFAULT,
				    suba_CoProdExist      TINYINT        ,
				    coprod_item           NVARCHAR (30)   COLLATE DATABASE_DEFAULT,
				    coprod_itemdesc       NVARCHAR (40)   COLLATE DATABASE_DEFAULT,
				    coprod_QtyReleased    DECIMAL (19, 8),
				    coprod_U_M            NVARCHAR (3)    COLLATE DATABASE_DEFAULT,
				    nettable              TINYINT        ,
				    qty_unit_format       NVARCHAR (60)   COLLATE DATABASE_DEFAULT,
				    places_qty_unit       TINYINT        ,
				    sequence              INT             IDENTITY,
				    massaged_sequence     INT             DEFAULT 0,
				    det_JobmatlRevision   NVARCHAR (8)    COLLATE DATABASE_DEFAULT
				) ");

			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON ");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("JobPickList"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			}
			if (UserID != null)
			{
				#region CRUD LoadToVariable
				var UserNamesLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_UserName,"UserName"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "UserNames",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("UserID = {0}", UserID),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var UserNamesLoadResponse = this.appDB.Load(UserNamesLoadRequest);
				if (UserNamesLoadResponse.Items.Count > 0)
				{
					UserName = _UserName;
				}
				#endregion  LoadToVariable
			}
			else
			{
				UserName = convertToUtil.ToString(this.iUserName);
			}
			ID = Guid.NewGuid();

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextWithUserSp
			var InitSessionContextWithUser = this.iInitSessionContextWithUser.InitSessionContextWithUserSp(
				ContextName: "Rpt_JobPickListSp",
				UserName: UserName,
				SessionID: ID,
				Site: pSite);

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CopySessionVariablesSp
			var CopySessionVariables = this.iCopySessionVariables.CopySessionVariablesSp(SessionId: BGSessionId);

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: DefineVariableSp
			var DefineVariable = this.iDefineVariable.DefineVariableSp(
				VariableName: "MessageLanguage",
				VariableValue: PMessageLanguage,
				Infobar: Infobar);
			Severity = DefineVariable.ReturnCode;
			Infobar = DefineVariable.Infobar;

			#endregion ExecuteMethodCall

			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				goto ERROR_RETURN;
			}
			SortByLoc = (int?)(stringUtil.IsNull(
				SortByLoc,
				0));
			IncludeSerialNumbers = (int?)(stringUtil.IsNull(
				IncludeSerialNumbers,
				1));
			ReprintPickListItems = (int?)(stringUtil.IsNull(
				ReprintPickListItems,
				1));
			PostMaterialIssues = (int?)(stringUtil.IsNull(
				PostMaterialIssues,
				0));
			PageBetweenOperations = (int?)(stringUtil.IsNull(
				PageBetweenOperations,
				0));
			PrintSecondaryLocations = (int?)(stringUtil.IsNull(
				PrintSecondaryLocations,
				1));
			ExtendByScrapFactor = (int?)(stringUtil.IsNull(
				ExtendByScrapFactor,
				0));
			PrintBarCode = (int?)(stringUtil.IsNull(
				PrintBarCode,
				0));
			DisplayHeader = (int?)(stringUtil.IsNull(
				DisplayHeader,
				0));
			Job = this.iExpandKyByType.ExpandKyByTypeFn(
				"JobType",
				Job);

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: JobPickSp
			var JobPick = this.iJobPick.JobPickSp(
				Job: Job,
				Suffix: Suffix,
				Whse: Whse,
				StartingOperNum: StartingOperNum,
				EndingOperNum: EndingOperNum,
				SortByLoc: SortByLoc,
				IncludeSerialNumbers: IncludeSerialNumbers,
				ReprintPickListItems: ReprintPickListItems,
				PrintSecondaryLocations: PrintSecondaryLocations,
				ExtendByScrapFactor: ExtendByScrapFactor,
				PostMaterialIssues: PostMaterialIssues,
				PickQty: null,
				PostDate: PostDate,
				Counter: Counter,
				Infobar: Infobar);
			Severity = JobPick.ReturnCode;
			Counter = JobPick.Counter;
			Infobar = JobPick.Infobar;

			#endregion ExecuteMethodCall

			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				goto ERROR_RETURN;
			}

			#region CRUD ExecuteMethodCall

			var MsgApp = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "I=#Processed",
				Parm1: convertToUtil.ToString(Counter),
				Parm2: "@item");
			Infobar = MsgApp.Infobar;

		#endregion ExecuteMethodCall

		ERROR_RETURN:;
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				this.transactionFactory.RollbackTransaction("");
				this.transactionFactory.BeginTransaction("");
				ID = Guid.NewGuid();

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: InitSessionContextWithUserSp
				var InitSessionContextWithUser1 = this.iInitSessionContextWithUser.InitSessionContextWithUserSp(
					ContextName: "Rpt_JobPickListSp",
					UserName: UserName,
					SessionID: ID,
					Site: pSite);

				#endregion ExecuteMethodCall

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: CopySessionVariablesSp
				var CopySessionVariables1 = this.iCopySessionVariables.CopySessionVariablesSp(SessionId: BGSessionId);

				#endregion ExecuteMethodCall
			}
			if (TaskID != null)
			{
				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: AddProcessErrorLogSp
				var AddProcessErrorLog = this.iAddProcessErrorLog.AddProcessErrorLogSp(
					ProcessID: TaskID,
					InfobarText: Infobar,
					MessageSeverity: Severity);

				#endregion ExecuteMethodCall
			}

			#region CRUD LoadToRecord
			var PickList1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "massaged_sequence", "#PickList.massaged_sequence" },
					{ "u0", "CASE WHEN det_SerialNum IS NULL THEN sequence ELSE (SELECT TOP 1 sequence FROM #PickList AS pl WHERE  #PickList.det_JobMatlItem = pl.det_JobMatlItem AND #PickList.det_Location = pl.det_Location AND isnull(#PickList.det_LotDescription, '') = isnull(pl.det_LotDescription, '')) END" },
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName: "#PickList",
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var PickList1LoadResponse = this.appDB.Load(PickList1LoadRequest);
			#endregion  LoadToRecord

			#region CRUD UpdateByRecord
			foreach (var PickList1Item in PickList1LoadResponse.Items)
			{
				PickList1Item.SetValue<int?>("massaged_sequence", PickList1Item.GetValue<int?>("u0"));
			};

			var PickList1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#PickList",
				items: PickList1LoadResponse.Items);

			this.appDB.Update(PickList1RequestUpdate);
			#endregion UpdateByRecord

			if (sQLUtil.SQLEqual(this.scalarFunction.Execute<int>("@@rowcount"), 0) == true)
			{
				#region CRUD LoadResponseWithoutTable
				var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
					{
							{ "hdr_Job", variableUtil.GetValue<string>(this.iFmtJob.FmtJobSp(
								Job,
							Suffix),true)},
						{ "hdr_JobItem", variableUtil.GetValue<string>(Item,true)},
						{ "hdr_JobWhse", variableUtil.GetValue<string>(Whse,true)},
					});

				var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
				Data = nonTableLoadResponse;
				#endregion CRUD LoadResponseWithoutTable

				#region CRUD InsertByRecords
				var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#PickList",
					items: nonTableLoadResponse.Items);

				this.appDB.Insert(nonTableInsertRequest);
				#endregion InsertByRecords

				#region CRUD LoadToVariable
				var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_PlacesQtyUnit,"places_qty_unit"},
						{_QtyUnitFormat,"qty_unit_format"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "invparms",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
				if (invparmsLoadResponse.Items.Count > 0)
				{
					PlacesQtyUnit = _PlacesQtyUnit;
					QtyUnitFormat = _QtyUnitFormat;
				}
				#endregion  LoadToVariable

				QtyUnitFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
					QtyUnitFormat,
					this.iGetWinRegDecGroup.GetWinRegDecGroupFn());

				#region CRUD LoadToRecord
				var PickList2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"hdr_JobDate","#PickList.hdr_JobDate"},
						{"hdr_JobStat","#PickList.hdr_JobStat"},
						{"hdr_JobStatDesc","#PickList.hdr_JobStatDesc"},
						{"hdr_JobSchEndDate","#PickList.hdr_JobSchEndDate"},
						{"hdr_ProdMix","#PickList.hdr_ProdMix"},
						{"hdr_ProdMixDesc","#PickList.hdr_ProdMixDesc"},
						{"hdr_JobItemDesc","#PickList.hdr_JobItemDesc"},
						{"hdr_JobQtyReleased","#PickList.hdr_JobQtyReleased"},
						{"hdr_JobRevision","#PickList.hdr_JobRevision"},
						{"places_qty_unit","#PickList.places_qty_unit"},
						{"qty_unit_format","#PickList.qty_unit_format"},
						{"u0","job.job_date"},
						{"u1","job.stat"},
						{"u2","job.midnight_of_job_sch_end_date"},
						{"u3","job.prod_mix"},
						{"u4","prod_mix.description"},
						{"u5","item.description"},
						{"u6","job.qty_released"},
						{"u7","job.revision"},
					},
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    tableName: "#PickList",
                    fromClause: collectionLoadRequestFactory.Clause(@" AS #PickList, job 
						     LEFT OUTER JOIN 
						     item 
						     ON item.item = job.item 
						     LEFT OUTER JOIN 
						     prod_mix 
						     ON prod_mix.prod_mix = job.prod_mix"),
					whereClause: collectionLoadRequestFactory.Clause("job.job = {1} AND job.suffix = {0}", Suffix, Job),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var PickList2LoadResponse = this.appDB.Load(PickList2LoadRequest);
				#endregion  LoadToRecord

				#region CRUD UpdateByRecord
				foreach (var PickList2Item in PickList2LoadResponse.Items)
				{
					PickList2Item.SetValue<DateTime?>("hdr_JobDate", PickList2Item.GetValue<DateTime?>("u0"));
					PickList2Item.SetValue<string>("hdr_JobStat", PickList2Item.GetValue<string>("u1"));
					PickList2Item.SetValue<string>("hdr_JobStatDesc", this.iGetCodeDesc.GetCodeDescFn(
						"job.stat",
						PickList2Item.GetValue<string>("u1"),
						null));
					PickList2Item.SetValue<DateTime?>("hdr_JobSchEndDate", PickList2Item.GetValue<DateTime?>("u2"));
					PickList2Item.SetValue<string>("hdr_ProdMix", PickList2Item.GetValue<string>("u3"));
					PickList2Item.SetValue<string>("hdr_ProdMixDesc", PickList2Item.GetValue<string>("u4"));
					PickList2Item.SetValue<string>("hdr_JobItemDesc", PickList2Item.GetValue<string>("u5"));
					PickList2Item.SetValue<decimal?>("hdr_JobQtyReleased", PickList2Item.GetValue<decimal?>("u6"));
					PickList2Item.SetValue<string>("hdr_JobRevision", PickList2Item.GetValue<string>("u7"));
					PickList2Item.SetValue<int?>("places_qty_unit", PlacesQtyUnit);
					PickList2Item.SetValue<string>("qty_unit_format", QtyUnitFormat);
				};

				var PickList2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#PickList",
				items: PickList2LoadResponse.Items);

				this.appDB.Update(PickList2RequestUpdate);
				#endregion UpdateByRecord
			}

			#region CRUD LoadToRecord
			var PickList4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "det_JobmatlRevision", "#PickList.det_JobmatlRevision" },
					{ "u0", "jobmatl.revision" },
				},
                loadForChange: true,
                lockingType: LockingType.UPDLock, 
                tableName: "#PickList",
                fromClause: collectionLoadRequestFactory.Clause(" inner join jobmatl on jobmatl.job = {1} and jobmatl.suffix = {0} and sub_jobmatlopernum = jobmatl.oper_num and det_jobsequence = jobmatl.sequence and jobmatl.revision is not null and det_jobmatlrevision is null", Suffix, Job),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var PickList4LoadResponse = this.appDB.Load(PickList4LoadRequest);
			#endregion  LoadToRecord

			#region CRUD UpdateByRecord
			foreach (var PickList4Item in PickList4LoadResponse.Items)
			{
				PickList4Item.SetValue<string>("det_JobmatlRevision", PickList4Item.GetValue<string>("u0"));
			};

			var PickList4RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#PickList",
				items: PickList4LoadResponse.Items);

			this.appDB.Update(PickList4RequestUpdate);
			#endregion UpdateByRecord

			#region CRUD LoadToRecord
			var PickList6LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "det_JobmatlRevision", "#PickList.det_JobmatlRevision" },
					{ "u0", "jobmatl.revision" },
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName: "#PickList",
                fromClause: collectionLoadRequestFactory.Clause(" inner join jobmatl on jobmatl.job = {1} and jobmatl.suffix = {0} and det_opernum = jobmatl.oper_num and det_jobsequence = jobmatl.sequence and jobmatl.revision is not null and det_jobmatlrevision is null", Suffix, Job),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var PickList6LoadResponse = this.appDB.Load(PickList6LoadRequest);
			#endregion  LoadToRecord

			#region CRUD UpdateByRecord
			foreach (var PickList6Item in PickList6LoadResponse.Items)
			{
				PickList6Item.SetValue<string>("det_JobmatlRevision", PickList6Item.GetValue<string>("u0"));
			};

			var PickList6RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#PickList",
				items: PickList6LoadResponse.Items);

			this.appDB.Update(PickList6RequestUpdate);
			#endregion UpdateByRecord

			#region CRUD LoadToRecord
			var PickList7LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"hdr_Job","hdr_Job"},
					{"hdr_JobDate","hdr_JobDate"},
					{"hdr_JobStat","hdr_JobStat"},
					{"hdr_JobStatDesc","hdr_JobStatDesc"},
					{"hdr_JobSchEndDate","hdr_JobSchEndDate"},
					{"hdr_ProdMix","hdr_ProdMix"},
					{"hdr_ProdMixDesc","hdr_ProdMixDesc"},
					{"hdr_JobItem","hdr_JobItem"},
					{"hdr_JobItemDesc","hdr_JobItemDesc"},
					{"hdr_JobQtyReleased","hdr_JobQtyReleased"},
					{"hdr_JobRevision","hdr_JobRevision"},
					{"hdr_JobWhse","hdr_JobWhse"},
					{"sub_JobMatlOperNum","sub_JobMatlOperNum"},
					{"sub_JobRouteWC","sub_JobRouteWC"},
					{"sub_WCDecription","sub_WCDecription"},
					{"sub_JrtSchStartDate","sub_JrtSchStartDate"},
					{"sub_JrtSchEndDate","sub_JrtSchEndDate"},
					{"det_OperNum","det_OperNum"},
					{"det_JobSequence","det_JobSequence"},
					{"det_JobMatlItem","det_JobMatlItem"},
					{"det_JobMatlDesciption","det_JobMatlDesciption"},
					{"det_JobMatlU_M","det_JobMatlU_M"},
					{"det_TotalRequired","det_TotalRequired"},
					{"det_JobMatlQtyIssued","det_JobMatlQtyIssued"},
					{"det_QtyAvailable","det_QtyAvailable"},
					{"det_QtyToPick","det_QtyToPick"},
					{"det_Location","det_Location"},
					{"det_LotDescription","det_LotDescription"},
					{"det_JobPicked","det_JobPicked"},
					{"det_Reprint","det_Reprint"},
					{"det_QtyRequiredToPick","det_QtyRequiredToPick"},
					{"det_Exception","det_Exception"},
					{"det_SerialNum","det_SerialNum"},
					{"suba_CoProdExist","suba_CoProdExist"},
					{"coprod_item","coprod_item"},
					{"coprod_itemdesc","coprod_itemdesc"},
					{"coprod_QtyReleased","coprod_QtyReleased"},
					{"coprod_U_M","coprod_U_M"},
					{"nettable","nettable"},
					{"qty_unit_format","qty_unit_format"},
					{"places_qty_unit","places_qty_unit"},
					{"det_JobmatlRevision","det_JobmatlRevision"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#PickList",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" sub_JobMatlOperNum ASC"));
			var PickList7LoadResponse = this.appDB.Load(PickList7LoadRequest);
			#endregion  LoadToRecord

			Data = PickList7LoadResponse;

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: ID);

			#endregion ExecuteMethodCall

			this.transactionFactory.CommitTransaction("");

			return (Data, Severity);
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_JobPickListSp(
			string AltExtGenSp,
			string Job = null,
			int? Suffix = null,
			string Item = null,
			string Whse = null,
			DateTime? PostDate = null,
			int? StartingOperNum = null,
			int? EndingOperNum = null,
			int? SortByLoc = null,
			int? IncludeSerialNumbers = null,
			int? ReprintPickListItems = null,
			int? PostMaterialIssues = null,
			int? PageBetweenOperations = null,
			int? PrintSecondaryLocations = null,
			int? ExtendByScrapFactor = null,
			int? PrintBarCode = null,
			int? DisplayHeader = null,
			string PMessageLanguage = null,
			int? TaskID = null,
			decimal? UserID = null,
			string BGSessionId = null,
			string pSite = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			DateType _PostDate = PostDate;
			GenericIntType _StartingOperNum = StartingOperNum;
			GenericIntType _EndingOperNum = EndingOperNum;
			ListYesNoType _SortByLoc = SortByLoc;
			ListYesNoType _IncludeSerialNumbers = IncludeSerialNumbers;
			ListYesNoType _ReprintPickListItems = ReprintPickListItems;
			ListYesNoType _PostMaterialIssues = PostMaterialIssues;
			ListYesNoType _PageBetweenOperations = PageBetweenOperations;
			IntType _PrintSecondaryLocations = PrintSecondaryLocations;
			ListYesNoType _ExtendByScrapFactor = ExtendByScrapFactor;
			ListYesNoType _PrintBarCode = PrintBarCode;
			ListYesNoType _DisplayHeader = DisplayHeader;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			TaskNumType _TaskID = TaskID;
			TokenType _UserID = UserID;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostDate", _PostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOperNum", _StartingOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOperNum", _EndingOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SortByLoc", _SortByLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeSerialNumbers", _IncludeSerialNumbers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReprintPickListItems", _ReprintPickListItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PostMaterialIssues", _PostMaterialIssues, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBetweenOperations", _PageBetweenOperations, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintSecondaryLocations", _PrintSecondaryLocations, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExtendByScrapFactor", _ExtendByScrapFactor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintBarCode", _PrintBarCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
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
