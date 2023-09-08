//PROJECT NAME: Admin
//CLASS NAME: Home_BGTaskAnalysis.cs

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

namespace CSI.Admin
{
	public class Home_BGTaskAnalysis : IHome_BGTaskAnalysis
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		ICollectionInsertRequestFactory collectionInsertRequestFactory;
		ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		ICollectionLoadRequestFactory collectionLoadRequestFactory;
		ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IScalarFunction scalarFunction;
		IExistsChecker existsChecker;
		IConvertToUtil convertToUtil;
		IVariableUtil variableUtil;
        readonly IMidnightOf iMidnightOf;
		IStringUtil stringUtil;
        readonly IHighDate iHighDate;
        readonly IDayEndOf iDayEndOf;
        readonly ILowDate iLowDate;
		ISQLValueComparerUtil sQLUtil;

		public Home_BGTaskAnalysis(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			IHighDate iHighDate,
			IDayEndOf iDayEndOf,
			ILowDate iLowDate,
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
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.iHighDate = iHighDate;
			this.iDayEndOf = iDayEndOf;
			this.iLowDate = iLowDate;
			this.sQLUtil = sQLUtil;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Home_BGTaskAnalysisSp(string FilterString,
			DateTime? StartDate = null,
			DateTime? EndDate = null,
			string DatabaseName = null,
			string Site = null)
		{
			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			try
			{
				ICollectionLoadResponse Data = null;

				StringType _ALTGEN_SpName = DBNull.Value;
				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				string Infobar = null;
				string SelectionClause = null;
				string WhereClause = null;
				int? Severity = null;
				string OrderByClause = null;
				string FromClause = null;
				string KeyColumns = null;

				if (existsChecker.Exists(
					tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_BGTaskAnalysisSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
						whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_BGTaskAnalysisSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
					#endregion  LoadToRecord

					#region CRUD InsertByRecords
					foreach (var optional_module1Item in optional_module1LoadResponse.Items)
					{
						optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_BGTaskAnalysisSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

						var ALTGEN = AltExtGen_Home_BGTaskAnalysisSp(_ALTGEN_SpName,
							FilterString,
							StartDate,
							EndDate,
							DatabaseName,
							Site);
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

				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_BGTaskAnalysisSp") != null)
				{
					var EXTGEN = AltExtGen_Home_BGTaskAnalysisSp("dbo.EXTGEN_Home_BGTaskAnalysisSp",
						FilterString,
						StartDate,
						EndDate,
						DatabaseName,
						Site);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				StartDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(stringUtil.IsNull(StartDate, this.iLowDate.LowDateFn())));
				EndDate = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(stringUtil.IsNull(EndDate, this.iHighDate.HighDateFn())));
				this.sQLExpressionExecutor.Execute(@"CREATE TABLE #BGTaskTable (
						TaskName            NVARCHAR (50) COLLATE DATABASE_DEFAULT,
						DerRunCount         BIGINT       ,
						DerTotalSuccSeconds BIGINT       ,
						DerAvgSuccSeconds   BIGINT       ,
						DerMinSuccSeconds   BIGINT       ,
						DerMaxSuccSeconds   BIGINT       ,
						DerFailedCount      BIGINT       ,
						UbDelayTotalSeconds BIGINT       ,
						UbDelayAvgSeconds   BIGINT       ,
						UbDelayMinSeconds   BIGINT       ,
						UbDelayMaxSeconds   BIGINT       
					) ");

				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @buf TABLE (
						TaskName            BGTaskNameType,
						success             BIT           ,
						DerRunCount         BIGINT        ,
						DerTotalSuccSeconds BIGINT        ,
						DerAvgSuccSeconds   BIGINT        ,
						DerMinSuccSeconds   BIGINT        ,
						DerMaxSuccSeconds   BIGINT        ,
						UbDelayTotalSeconds BIGINT        ,
						UbDelayAvgSeconds   BIGINT        ,
						UbDelayMinSeconds   BIGINT        ,
						UbDelayMaxSeconds   BIGINT         PRIMARY KEY (TaskName, success));
					SELECT * into #tv_buf from @buf 
					ALTER TABLE #tv_buf ADD PRIMARY KEY (TaskName, success) ");

				#region CRUD LoadArbitrary
				var tv_bufLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "TaskName", "TaskName" },
						{ "success", "success" },
						{ "DerRunCount", "count(*)" },
						{ "DerTotalSuccSeconds", "sum(run_time)" },
						{ "DerAvgSuccSeconds", "avg(run_time)" },
						{ "DerMinSuccSeconds", "min(run_time)" },
						{ "DerMaxSuccSeconds", "max(run_time)" },
						{ "UbDelayTotalSeconds", "sum(delay_time)" },
						{ "UbDelayAvgSeconds", "avg(delay_time)" },
						{ "UbDelayMinSeconds", "min(delay_time)" },
						{ "UbDelayMaxSeconds", "max(delay_time)" },
					},
					selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList  
						FROM (SELECT TaskName, 
						             ISNULL(DATEDIFF(ss, StartDate, CompletionDate), 0) AS run_time, 
						             ISNULL(DATEDIFF(ss, SubmissionDate, StartDate), 0) AS delay_time, 
						             CASE WHEN TaskErrorMsg IS NULL 
						                       AND CompletionDate IS NOT NULL THEN 1 WHEN TaskErrorMsg IS NOT NULL 
						                                                                  OR CompletionDate IS NULL THEN 0 ELSE 2 END AS success 
						      FROM   BGTaskHistory WITH (READUNCOMMITTED) 
						      WHERE  SubmissionDate BETWEEN {0}  AND {1} ) AS subt 
						GROUP BY TaskName, success", StartDate, EndDate));

				var tv_bufLoadResponse = this.appDB.Load(tv_bufLoadRequest);
				Data = tv_bufLoadResponse;
				#endregion  LoadArbitrary

				#region CRUD InsertByRecords
				var tv_bufInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_buf",
					items: tv_bufLoadResponse.Items);

				this.appDB.Insert(tv_bufInsertRequest);
				#endregion InsertByRecords

				#region CRUD LoadToRecord
				var tv_buf1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"TaskName","b1.TaskName"},
						{"DerRunCount","b1.DerRunCount"},
						{"DerTotalSuccSeconds","b1.DerTotalSuccSeconds"},
						{"DerAvgSuccSeconds","b1.DerAvgSuccSeconds"},
						{"DerMinSuccSeconds","b1.DerMinSuccSeconds"},
						{"DerMaxSuccSeconds","b1.DerMaxSuccSeconds"},
						{"DerFailedCount","CAST (NULL AS NVARCHAR)"},
						{"UbDelayTotalSeconds","b1.UbDelayTotalSeconds"},
						{"UbDelayAvgSeconds","b1.UbDelayAvgSeconds"},
						{"UbDelayMinSeconds","b1.UbDelayMinSeconds"},
						{"UbDelayMaxSeconds","b1.UbDelayMaxSeconds"},
						{"u0","b2.DerRunCount"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_buf",
					fromClause: collectionLoadRequestFactory.Clause(" AS b1 LEFT OUTER JOIN #tv_buf AS b2 ON b2.TaskName = b1.TaskName "
					+ "AND b2.success = 0"),
					whereClause: collectionLoadRequestFactory.Clause($"b1.success = 1"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tv_buf1LoadResponse = this.appDB.Load(tv_buf1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var tv_buf1Item in tv_buf1LoadResponse.Items)
				{
					tv_buf1Item.SetValue<string>("TaskName", tv_buf1Item.GetValue<string>("TaskName"));
					tv_buf1Item.SetValue<long?>("DerRunCount", tv_buf1Item.GetValue<long?>("DerRunCount"));
					tv_buf1Item.SetValue<long?>("DerTotalSuccSeconds", tv_buf1Item.GetValue<long?>("DerTotalSuccSeconds"));
					tv_buf1Item.SetValue<long?>("DerAvgSuccSeconds", tv_buf1Item.GetValue<long?>("DerAvgSuccSeconds"));
					tv_buf1Item.SetValue<long?>("DerMinSuccSeconds", tv_buf1Item.GetValue<long?>("DerMinSuccSeconds"));
					tv_buf1Item.SetValue<long?>("DerMaxSuccSeconds", tv_buf1Item.GetValue<long?>("DerMaxSuccSeconds"));
					tv_buf1Item.SetValue<long?>("DerFailedCount", stringUtil.IsNull(tv_buf1Item.GetValue<long?>("u0"), 0));
					tv_buf1Item.SetValue<long?>("UbDelayTotalSeconds", tv_buf1Item.GetValue<long?>("UbDelayTotalSeconds"));
					tv_buf1Item.SetValue<long?>("UbDelayAvgSeconds", tv_buf1Item.GetValue<long?>("UbDelayAvgSeconds"));
					tv_buf1Item.SetValue<long?>("UbDelayMinSeconds", tv_buf1Item.GetValue<long?>("UbDelayMinSeconds"));
					tv_buf1Item.SetValue<long?>("UbDelayMaxSeconds", tv_buf1Item.GetValue<long?>("UbDelayMaxSeconds"));
				};

				var tv_buf1RequiredColumns = new List<string>() { "TaskName", "DerRunCount", "DerTotalSuccSeconds", "DerAvgSuccSeconds", "DerMinSuccSeconds", "DerMaxSuccSeconds", "DerFailedCount", "UbDelayTotalSeconds", "UbDelayAvgSeconds", "UbDelayMinSeconds", "UbDelayMaxSeconds" };

				tv_buf1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(tv_buf1LoadResponse, tv_buf1RequiredColumns);

				var tv_buf1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#BGTaskTable",
					items: tv_buf1LoadResponse.Items);

				this.appDB.Insert(tv_buf1InsertRequest);
				#endregion InsertByRecords

				SelectionClause = @"SELECT
					  TaskName
					, DerRunCount
					, DerTotalSuccSeconds
					, DerAvgSuccSeconds
					, DerMinSuccSeconds
					, DerMaxSuccSeconds
					, DerFailedCount
					, UbDelayTotalSeconds
					, UbDelayAvgSeconds
					, UbDelayMinSeconds
					, UbDelayMaxSeconds";
				FromClause = "FROM #BGTaskTable";
				OrderByClause = "ORDER BY DerRunCount DESC, TaskName ASC";
				KeyColumns = "DerRunCount DESC, TaskName ASC";
				if (FilterString == null)
				{
					WhereClause = "WHERE 1=1";
				}
				else
				{
					WhereClause = "";
				}

				this.sQLExpressionExecutor.Execute(@"Declare
					 @SelectionClause LongListType
					 ,@FromClause LongListType
					 ,@WhereClause LongListType
					 ,@OrderByClause LongListType
					 ,@KeyColumns LongListType
					 ,@FilterString LongListType
					 SELECT @SelectionClause AS SelectionClause,
							@FromClause AS FromClause,
							@WhereClause AS WhereClause,
							@OrderByClause AS AdditionalClause,
							@KeyColumns AS KeyColumns,
							@FilterString AS FilterString
					 INTO   #DynamicParameters
					 WHERE 1 = 2");

				#region CRUD LoadArbitrary
				var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SelectionClause",$"{variableUtil.GetValue<string>(SelectionClause)}"},
						{"FromClause",$"{variableUtil.GetValue<string>(FromClause)}"},
						{"WhereClause",$"{variableUtil.GetValue<string>(WhereClause)}"},
						{"AdditionalClause",$"{variableUtil.GetValue<string>(OrderByClause)}"},
						{"KeyColumns",$"{variableUtil.GetValue<string>(KeyColumns)}"},
						{"FilterString",$"{variableUtil.GetValue<string>(FilterString)}"},
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
				var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(NeedGetMoreRows: 1
					, Infobar: Infobar);
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

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_BGTaskAnalysisSp(string AltExtGenSp,
			string FilterString,
			DateTime? StartDate = null,
			DateTime? EndDate = null,
			string DatabaseName = null,
			string Site = null)
		{
			LongListType _FilterString = FilterString;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			StringType _DatabaseName = DatabaseName;
			SiteType _Site = Site;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DatabaseName", _DatabaseName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);

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
