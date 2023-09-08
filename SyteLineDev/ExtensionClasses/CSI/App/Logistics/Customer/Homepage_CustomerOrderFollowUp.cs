//PROJECT NAME: Logistics
//CLASS NAME: Homepage_CustomerOrderFollowUp.cs

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

namespace CSI.Logistics.Customer
{
	public class Homepage_CustomerOrderFollowUp : IHomepage_CustomerOrderFollowUp
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IVariableUtil variableUtil;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly IDayEndOf iDayEndOf;
		readonly ISQLValueComparerUtil sQLUtil;

		public Homepage_CustomerOrderFollowUp(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IGetSiteDate iGetSiteDate,
			IDateTimeUtil dateTimeUtil,
			IVariableUtil variableUtil,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			IDayEndOf iDayEndOf,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.dateTimeUtil = dateTimeUtil;
			this.variableUtil = variableUtil;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.iDayEndOf = iDayEndOf;
			this.sQLUtil = sQLUtil;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Homepage_CustomerOrderFollowUpSp()
		{
			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			DateTime? PeriodStart1 = null;
			DateTime? PeriodStart2 = null;
			DateTime? PeriodEnd1 = null;
			DateTime? PeriodEnd2 = null;
			DateTime? Today = null;

			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_CustomerOrderFollowUpSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_CustomerOrderFollowUpSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_CustomerOrderFollowUpSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Homepage_CustomerOrderFollowUpSp(_ALTGEN_SpName);
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_CustomerOrderFollowUpSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_CustomerOrderFollowUpSp("dbo.EXTGEN_Homepage_CustomerOrderFollowUpSp");
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			this.sQLExpressionExecutor.Execute(@"CREATE TABLE #results (
				    co_num        NVARCHAR (10) COLLATE DATABASE_DEFAULT,
				    co_line       SMALLINT     ,
				    co_release    SMALLINT     ,
				    co_type       NVARCHAR (1)  COLLATE DATABASE_DEFAULT,
				    due_date      DATETIME     ,
				    due_date_char DATETIME     ,
				    cust_num      NVARCHAR (7)  COLLATE DATABASE_DEFAULT,
				    cust_name     NVARCHAR (60) COLLATE DATABASE_DEFAULT,
				    days_late     INT          
				) ");
			this.sQLExpressionExecutor.Execute(@"ALTER TABLE #results
				    ADD Seq INT IDENTITY (1, 1) ");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @Coitem TABLE (
				    co_num     CoNumType    ,
				    co_line    CoLineType   ,
				    co_release CoReleaseType,
				    co_type    CoTypeType   ,
				    due_date   DateType     ,
				    cust_num   CustNumType  ,
				    cust_name  NameType     ,
				    days_late  INT          ,
				    sequence   INT           IDENTITY);
				SELECT * into #tv_Coitem from @Coitem 
				ALTER TABLE #tv_Coitem ADD PRIMARY KEY (sequence) ");

			Severity = 0;
			Today = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
			PeriodStart1 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", -1, Today));
			PeriodStart2 = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", 1, PeriodStart1));
			PeriodEnd1 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, PeriodStart2)));
			PeriodEnd2 = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(dateTimeUtil.DateAdd("Day", -1, dateTimeUtil.DateAdd("Day", 1, PeriodStart2))));
			PeriodStart1 = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(convertToUtil.ToDateTime("1/1/1753")));

			#region CRUD LoadToRecord
			var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"co_num","coitem.co_num"},
					{"co_line","coitem.co_line"},
					{"co_release","coitem.co_release"},
					{"co_type","co.type"},
					{"due_date","coitem.due_date"},
					{"cust_num","custaddr.cust_num"},
					{"cust_name","custaddr.name"},
					{"days_late","CAST (NULL AS INT)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "coitem",
				fromClause: collectionLoadRequestFactory.Clause(@" WITH (READUNCOMMITTED) INNER JOIN co ON co.co_num = coitem.co_num 
					AND co.type IN ('R', 'B') INNER JOIN custaddr WITH (READUNCOMMITTED) ON custaddr.cust_num = coitem.co_cust_num 
					AND custaddr.cust_seq = 0"),
				whereClause: collectionLoadRequestFactory.Clause("coitem.due_date BETWEEN {0} AND {1} AND coitem.qty_shipped < coitem.qty_ordered AND coitem.stat NOT IN ('F', 'C')", PeriodStart1, PeriodEnd2),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var coitemLoadResponse = this.appDB.Load(coitemLoadRequest);
			#endregion  LoadToRecord


			#region CRUD InsertByRecords
			foreach (var coitemItem in coitemLoadResponse.Items)
			{
				coitemItem.SetValue<string>("co_num", coitemItem.GetValue<string>("co_num"));
				coitemItem.SetValue<int?>("co_line", coitemItem.GetValue<int?>("co_line"));
				coitemItem.SetValue<int?>("co_release", coitemItem.GetValue<int?>("co_release"));
				coitemItem.SetValue<string>("co_type", coitemItem.GetValue<string>("co_type"));
				coitemItem.SetValue<DateTime?>("due_date", coitemItem.GetValue<DateTime?>("due_date"));
				coitemItem.SetValue<string>("cust_num", coitemItem.GetValue<string>("cust_num"));
				coitemItem.SetValue<string>("cust_name", coitemItem.GetValue<string>("cust_name"));
				coitemItem.SetValue<int?>("days_late", dateTimeUtil.DateDiff("Day", coitemItem.GetValue<DateTime?>("due_date"), scalarFunction.Execute<DateTime>("GETDATE")));
			};

			var coitemRequiredColumns = new List<string>() { "co_num", "co_line", "co_release", "co_type", "due_date", "cust_num", "cust_name", "days_late" };

			coitemLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(coitemLoadResponse, coitemRequiredColumns);

			var coitemInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_coitem",
				items: coitemLoadResponse.Items);

			this.appDB.Insert(coitemInsertRequest);
			#endregion InsertByRecords


			#region CRUD LoadToRecord
			var resultsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"co_num","co_num"},
					{"co_line","co_line"},
					{"co_release","co_release"},
					{"co_type","co_type"},
					{"due_date","due_date"},
					{"due_date_char","due_date"},
					{"cust_num","cust_num"},
					{"cust_name","cust_name"},
					{"days_late","days_late"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#tv_coitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var resultsLoadResponse = this.appDB.Load(resultsLoadRequest);
			#endregion  LoadToRecord

			#region CRUD InsertByRecords
			var resultsInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#results",
				items: resultsLoadResponse.Items);

			this.appDB.Insert(resultsInsertRequest);
			#endregion InsertByRecords

			#region CRUD LoadColumn
			var results1LoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string>()
				{
					"co_num",
					"co_line",
					"co_release",
					"co_type",
					"due_date",
					"due_date_char",
					"cust_num",
					"cust_name",
					"days_late",
					"Seq",
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#results",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" due_date"));

			var results1LoadResponse = this.appDB.Load(results1LoadRequest);
			Data = results1LoadResponse;
			#endregion  LoadColumn

			return (Data, Severity);
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Homepage_CustomerOrderFollowUpSp(
			string AltExtGenSp)
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

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
