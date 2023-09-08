//PROJECT NAME: Production
//CLASS NAME: CLM_ResourcePlan.cs

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

namespace CSI.Production.APS
{
	public class CLM_ResourcePlan : ICLM_ResourcePlan
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IBuildXMLFilterString iBuildXMLFilterString;
		readonly IExecuteDynamicSQL iExecuteDynamicSQL;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public CLM_ResourcePlan(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IBuildXMLFilterString iBuildXMLFilterString,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			ISQLCollectionLoad sQLCollectionLoad,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iBuildXMLFilterString = iBuildXMLFilterString;
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ResourcePlanSp(
			int? AltNum = 0,
			string FilterString = null)
		{

			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			try
			{

				ICollectionLoadResponse Data = null;

				StringType _ALTGEN_SpName = DBNull.Value;
				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				string SQLStr = null;
				int? Severity = null;
				string RESPLAN = null;
				string RESRC = null;
				string JOBPLAN = null;
				string MATLPLAN = null;
				string JOBSTEP = null;
				string ORDER = null;
				string ORDPLAN = null;
				SiteType _Site = DBNull.Value;
				string Site = null;
				string Infobar = null;
				string SelectionClause = null;
				string FromClause = null;
				string WhereClause = null;
				string AdditionalClause = null;
				string KeyColumns = null;
				if (existsChecker.Exists(tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ResourcePlanSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
				)
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
						whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_ResourcePlanSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
					#endregion  LoadToRecord

					#region CRUD InsertByRecords
					foreach (var optional_module1Item in optional_module1LoadResponse.Items)
					{
						optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_ResourcePlanSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

						var ALTGEN = AltExtGen_CLM_ResourcePlanSp(ALTGEN_SpName,
							AltNum,
							FilterString);
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
							tableName: "#tv_ALTGEN", 
                            loadForChange: true, 
                            lockingType: LockingType.None,
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
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ResourcePlanSp") != null)
				{
					var EXTGEN = AltExtGen_CLM_ResourcePlanSp("dbo.EXTGEN_CLM_ResourcePlanSp",
						AltNum,
						FilterString);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				AltNum = (int?)(stringUtil.IsNull(
					AltNum,
					0));
				RESPLAN = stringUtil.Concat("RESPLAN", stringUtil.Substring(
					"000",
					1,
					3 - stringUtil.Len(AltNum)), Convert.ToString(AltNum));
				RESRC = stringUtil.Concat("RESRC", stringUtil.Substring(
					"000",
					1,
					3 - stringUtil.Len(AltNum)), Convert.ToString(AltNum));
				JOBPLAN = stringUtil.Concat("JOBPLAN", stringUtil.Substring(
					"000",
					1,
					3 - stringUtil.Len(AltNum)), Convert.ToString(AltNum));
				MATLPLAN = stringUtil.Concat("MATLPLAN", stringUtil.Substring(
					"000",
					1,
					3 - stringUtil.Len(AltNum)), Convert.ToString(AltNum));
				JOBSTEP = stringUtil.Concat("JOBSTEP", stringUtil.Substring(
					"000",
					1,
					3 - stringUtil.Len(AltNum)), Convert.ToString(AltNum));
				ORDER = stringUtil.Concat("ORDER", stringUtil.Substring(
					"000",
					1,
					3 - stringUtil.Len(AltNum)), Convert.ToString(AltNum));
				ORDPLAN = stringUtil.Concat("ORDPLAN", stringUtil.Substring(
					"000",
					1,
					3 - stringUtil.Len(AltNum)), Convert.ToString(AltNum));

				#region CRUD LoadToVariable
				var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_Site,"site"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "parms",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
				if (parmsLoadResponse.Items.Count > 0)
				{
					Site = _Site;
				}
				#endregion  LoadToVariable

				this.sQLExpressionExecutor.Execute(@"CREATE TABLE #DemandIDs (
					    DemandID   NVARCHAR (80)    COLLATE DATABASE_DEFAULT NULL,
					    RowPointer UNIQUEIDENTIFIER PRIMARY KEY
					)");
				SQLStr = stringUtil.Concat(" INSERT INTO #DemandIDs (", " DemandID", " , RowPointer", " )", " SELECT dbo.ApsGetDemandID(", stringUtil.QuoteName(ORDER), ".ORDERID)", " , ", stringUtil.QuoteName(ORDER), ".RowPointer", " FROM ", stringUtil.QuoteName(ORDER));

				var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr, "");
				Severity = execResult.Severity;
				/* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */

				SQLStr = stringUtil.Concat(" FROM ", "(SELECT ", "  STARTDATE = RESPLAN.STARTDATE", ", RESID = RESPLAN.RESID", ", InWorkflow = RESPLAN.InWorkflow", ", NoteExistsFlag = RESPLAN.NoteExistsFlag", ", DerMrpRef ", "= CASE WHEN MATLPLAN.PMATLTAG = 0 THEN DemandIDs.DemandID ", "ELSE  N'PLN '  + CONVERT(varchar, MATLPLAN.MATLTAG) ", "END ", ", DESCR = RESRC.DESCR ", ", PARTID = item.item", ", DerItemDescription = ", "CASE WHEN MATLPLAN.PMATLTAG <> 0 THEN item.description ", "WHEN ORDERs.OrderTable =  N'job'  AND job.suffix = 0 AND job.type =  N'S'  THEN job.description ", "ELSE item.description ", "END", ", DerStatus = ", "CASE WHEN ORDERs.OrderTable =  N'job'  THEN ", "CASE WHEN job.suffix = 0 AND job.type =  N'S'  THEN  N'P'  ", "ELSE job.stat ", "END ", "WHEN ORDERs.OrderTable =  N'rcpts'  THEN  N'P'  ", "WHEN ORDERs.OrderTable =  N'jobitem'  THEN jobitemjob.stat ", "ELSE  N'P'  ", "END", ", LOADSIZE = JOBPLAN.QUANTITY", ", UM = item.u_m", ", PRIORITY = ORDERs.PRIORITY", ", DUEDATE = ORDERs.DUEDATE", ", DerStartDate = ", "CASE WHEN job_sch.start_date IS NULL THEN MATLPLAN.STARTDATE ", "ELSE job_sch.start_date ", "END", ", DerEndDate = ", "CASE WHEN job_sch.end_date IS NULL THEN MATLPLAN.ENDDATE ", "ELSE job_sch.end_date ", "END", ", JobSchStartDate = job_sch.start_date", ", JobSchEndDate =job_sch.end_date", ", DerOperNum = jobroute.oper_num", ", DerWC = jobroute.wc", ", STATUSCD =  N'O' ", ", GROUPID = RESPLAN.GROUPID", ", DerHours = CONVERT(float, DATEDIFF(minute, RESPLAN.STARTDATE, RESPLAN.ENDDATE)) / CONVERT(float, 60)", ", ENDDATE = RESPLAN.ENDDATE", ", DaysLate = datediff(mi, ORDPLAN.DUEDATE, ORDPLAN.CALCDATE) / 1440.0", ", QtyReceived = jobroute.qty_received", ", DerQtyCompletedd = ", "CASE WHEN ORDERs.OrderTable =  N'job'  THEN jobroute.qty_complete ", "WHEN ORDERs.OrderTable =  N'rcpts'  THEN rcpts.orig_qty - rcpts.rcpt_qty ", "END", ", QtyMoved = jobroute.qty_moved", ", DerQtyScrapped = ", "CASE WHEN ORDERs.OrderTable =  N'job'  THEN jobroute.qty_scrapped ", "WHEN ORDERs.OrderTable =  N'rcpts'  THEN 0 ", "END", ", DerMoveHrs = ", "CASE WHEN ORDERs.OrderTable =  N'job'  THEN jrt_sch.move_hrs ", "WHEN ORDERs.OrderTable =  N'rcpts'  THEN curr_jrt_sch.move_hrs ", "END", ", DerFinishHours = ", "CASE WHEN ORDERs.OrderTable =  N'job'  THEN jrt_sch.finish_hrs ", "WHEN ORDERs.OrderTable =  N'rcpts'  THEN curr_jrt_sch.finish_hrs ", "END", ", DerFixedHrs = CASE WHEN ORDERs.OrderTable =  N'job'  THEN jrt_sch.sched_hrs ", "WHEN ORDERs.OrderTable =  N'rcpts'  THEN curr_jrt_sch.sched_hrs ", "END", ", DerOffsetHrs = ", "CASE WHEN ORDERs.OrderTable =  N'job'  THEN jrt_sch.offset_hrs ", "WHEN ORDERs.OrderTable =  N'rcpts'  THEN curr_jrt_sch.offset_hrs ", "END", ", DerRemainingRun = (JOBPLAN.DURATION - 0.0)", ", JobrouteEfficiency = jobroute.efficiency", ", Dept = wc.dept", ", Outside = wc.outside", ", RESPLAN.RecordDate", ", RESPLAN.RowPointer ", ", JOBPLAN.MATLTAG ", ", ORDERs.ORDERID ", ", DemandIDs.DemandID AS DerApsRef ", ", @Site AS SiteRef ");
				SQLStr = stringUtil.Concat(SQLStr, "FROM ", stringUtil.QuoteName(RESPLAN), " AS RESPLAN ", "LEFT OUTER JOIN ", stringUtil.QuoteName(RESRC), " AS RESRC ON RESRC.RESID = RESPLAN.RESID ", "INNER JOIN ", stringUtil.QuoteName(JOBPLAN), " AS JOBPLAN ON JOBPLAN.JOBTAG = RESPLAN.JOBTAG ", "INNER JOIN ", stringUtil.QuoteName(MATLPLAN), " AS MATLPLAN ON MATLPLAN.MATLTAG = JOBPLAN.MATLTAG ", "LEFT OUTER JOIN ", stringUtil.QuoteName(JOBSTEP), " AS JOBSTEP ON JOBSTEP.JSID = JOBPLAN.JSID AND JOBSTEP.PROCPLANID = MATLPLAN.PROCPLANID ", "LEFT OUTER JOIN jobroute AS jobroute ON jobroute.RowPointer = JOBSTEP.RefRowPointer ", "LEFT OUTER JOIN wc AS wc ON wc.wc = jobroute.wc ", "LEFT OUTER JOIN ", stringUtil.QuoteName(ORDER), " AS ORDERs ON ORDERs.ORDERID = MATLPLAN.ORDERID ", "LEFT OUTER JOIN coitem AS coitem ON coitem.RowPointer = ORDERs.OrderRowPointer ", "LEFT OUTER JOIN co AS co ON co.co_num = coitem.co_num ", "LEFT OUTER JOIN item AS item ON item.item = MATLPLAN.MATERIALID ", "LEFT OUTER JOIN job AS job ON job.Rowpointer = ORDERs.OrderRowPointer ", "LEFT OUTER JOIN jrt_sch AS curr_jrt_sch ON curr_jrt_sch.suffix = job.suffix AND curr_jrt_sch.job = job.job AND job.job = item.job AND job.suffix = 0 AND curr_jrt_sch.oper_num = jobroute.oper_num ", "LEFT OUTER JOIN job_sch AS job_sch ON job_sch.job = job.job AND job_sch.suffix = job.suffix ", "LEFT OUTER JOIN jobitem AS jobitem ON jobitem.RowPointer = ORDERs.OrderRowPointer ", "LEFT OUTER JOIN job AS jobitemjob ON jobitemjob.job = jobitem.job AND jobitemjob.suffix = jobitem.suffix AND jobitemjob.item = jobitem.item ", "LEFT OUTER JOIN jrt_sch AS jrt_sch ON jrt_sch.job = job.job AND jrt_sch.suffix = job.suffix AND jrt_sch.oper_num = jobroute.oper_num ", "LEFT JOIN #DemandIDs DemandIDs on ORDERs.RowPointer = DemandIDs.RowPointer ", "INNER JOIN ", stringUtil.QuoteName(ORDPLAN), " AS ORDPLAN ON ORDPLAN.ORDERID = MATLPLAN.ORDERID ", "LEFT OUTER JOIN rcpts AS rcpts ON rcpts.RowPointer = ORDERs.OrderRowPointer ", ") SS ");
				SelectionClause = "";
				FromClause = "";
				WhereClause = "";
				AdditionalClause = "";
				KeyColumns = "";
				SelectionClause = "SELECT *";
				FromClause = SQLStr;
				WhereClause = "WHERE 1 = 1 ";
				AdditionalClause = "ORDER BY RESID, STARTDATE";
				KeyColumns = "RESID, STARTDATE";

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
				var BuildXMLFilterString = this.iBuildXMLFilterString.BuildXMLFilterStringSp(
					PropertyName: "SiteRef",
					Value: Site,
					DataType: "SiteType",
					NameInParmList: "@Site",
					IsPropertyInWhereClause: 0,
					XmlFilterString: FilterString);
				Severity = BuildXMLFilterString.ReturnCode;
				FilterString = BuildXMLFilterString.XmlFilterString;

				#endregion ExecuteMethodCall

				if (this.scalarFunction.Execute<int?>(
					"OBJECT_ID",
					"tempdb..#DynamicParameters") != null)
				{
					this.sQLExpressionExecutor.Execute("DROP TABLE #DynamicParameters");

				}

				this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause VeryLongListType
					,@FromClause VeryLongListType
					,@WhereClause VeryLongListType
					,@AdditionalClause VeryLongListType
					,@KeyColumns VeryLongListType
					,@FilterString LongListType
					SELECT @SelectionClause AS SelectionClause,
					       @FromClause AS FromClause,
					       @WhereClause AS WhereClause,
					       @AdditionalClause AS AdditionalClause,
					       @KeyColumns AS KeyColumns,
					       @FilterString AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");

				#region CRUD LoadArbitrary
				var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
						{"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
						{"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereClause)}"},
						{"AdditionalClause",$"{variableUtil.GetQuotedValue<string>(AdditionalClause)}"},
						{"KeyColumns",$"{variableUtil.GetQuotedValue<string>(KeyColumns)}"},
						{"FilterString",$"{variableUtil.GetQuotedValue<string>(FilterString)}"},
					},
					selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

				var DynamicParametersLoadResponse = this.appDB.Load(DynamicParametersLoadRequest);
				Data = DynamicParametersLoadResponse;
				#endregion  LoadArbitrary

				#region CRUD InsertByRecords
				var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
					items: DynamicParametersLoadResponse.Items);

				this.appDB.Insert(DynamicParametersInsertRequest);
				#endregion InsertByRecords

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
				var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
					NeedGetMoreRows: 1,
					Infobar: Infobar);
				Severity = ExecuteDynamicSQL.ReturnCode;
				Data = ExecuteDynamicSQL.Data;
				Infobar = ExecuteDynamicSQL.Infobar;

				#endregion ExecuteMethodCall

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
		AltExtGen_CLM_ResourcePlanSp(
			string AltExtGenSp,
			int? AltNum = 0,
			string FilterString = null)
		{
			ApsAltNoType _AltNum = AltNum;
			LongListType _FilterString = FilterString;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

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
