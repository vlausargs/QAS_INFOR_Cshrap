//PROJECT NAME: Logistics
//CLASS NAME: Homepage_SROsAmountandTime.cs

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

namespace CSI.Logistics.Customer
{
	public class Homepage_SROsAmountandTime : IHomepage_SROsAmountandTime
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public Homepage_SROsAmountandTime(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IDateTimeUtil dateTimeUtil,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.dateTimeUtil = dateTimeUtil;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Homepage_SROsAmountandTimeSp(
			int? MonthCount = 6,
			string DisplayCategory = "A")
		{
			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? CurrentYear = null;
			int? CurrentMonth = null;
			int? Count = null;

			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_SROsAmountandTimeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_SROsAmountandTimeSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_SROsAmountandTimeSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Homepage_SROsAmountandTimeSp(_ALTGEN_SpName,
						MonthCount,
						DisplayCategory);
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_SROsAmountandTimeSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_SROsAmountandTimeSp("dbo.EXTGEN_Homepage_SROsAmountandTimeSp",
					MonthCount,
					DisplayCategory);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @LaborTran AS TABLE (
				    Year  INT           ,
				    Month INT           ,
				    Hrs   TotalHoursType);
				SELECT * into #tv_LaborTran from @LaborTran ");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @TotalHrs AS TABLE (
				    Year     INT           ,
				    Month    INT           ,
				    TotalHrs TotalHoursType);
				SELECT * into #tv_TotalHrs from @TotalHrs ");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @SROsAmount AS TABLE (
				    Year  INT       ,
				    Month INT       ,
				    Amt   AmountType);
				SELECT * into #tv_SROsAmount from @SROsAmount ");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @SROsTotalAmount AS TABLE (
				    Year     INT       ,
				    Month    INT       ,
				    TotalAmt AmountType);
				SELECT * into #tv_SROsTotalAmount from @SROsTotalAmount ");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @Result AS TABLE (
				    Year  INT       ,
				    Month INT       ,
				    Value AmountType);
				SELECT * into #tv_Result from @Result ");
			CurrentYear = (int?)(dateTimeUtil.DatePart("Year", scalarFunction.Execute<DateTime>("GETDATE")));
			CurrentMonth = (int?)(dateTimeUtil.DatePart("Month", scalarFunction.Execute<DateTime>("GETDATE")));

			#region CRUD LoadToRecord
			var fs_sro_laborLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Year","CAST (NULL AS INT)"},
					{"Month","CAST (NULL AS INT)"},
					{"Hrs","fs_sro_labor.hrs_worked"},
					{"u0","fs_sro_labor.trans_date"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "fs_sro_labor",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("trans_date >= DATEADD(YY, -1, DATEADD(MM, 1, GETDATE())) AND posted = 1"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var fs_sro_laborLoadResponse = this.appDB.Load(fs_sro_laborLoadRequest);
			#endregion  LoadToRecord

			#region CRUD InsertByRecords
			foreach (var fs_sro_laborItem in fs_sro_laborLoadResponse.Items)
			{
				fs_sro_laborItem.SetValue<int?>("Year", dateTimeUtil.DatePart("Year", fs_sro_laborItem.GetValue<DateTime?>("u0")));
				fs_sro_laborItem.SetValue<int?>("Month", dateTimeUtil.DatePart("Month", fs_sro_laborItem.GetValue<DateTime?>("u0")));
				fs_sro_laborItem.SetValue<decimal?>("Hrs", fs_sro_laborItem.GetValue<decimal?>("Hrs"));
			};

			var fs_sro_laborRequiredColumns = new List<string>() { "Year", "Month", "Hrs" };

			fs_sro_laborLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(fs_sro_laborLoadResponse, fs_sro_laborRequiredColumns);

			var fs_sro_laborInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_LaborTran",
				items: fs_sro_laborLoadResponse.Items);

			this.appDB.Insert(fs_sro_laborInsertRequest);
			#endregion InsertByRecords

			#region CRUD LoadArbitrary
			var tv_TotalHrsLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "Year", "Year" },
					{ "Month", "Month" },
					{ "TotalHrs", "SUM(Hrs)" },
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList  
					FROM #tv_LaborTran 
					GROUP BY Year, Month"));

			var tv_TotalHrsLoadResponse = this.appDB.Load(tv_TotalHrsLoadRequest);
			Data = tv_TotalHrsLoadResponse;
			#endregion  LoadArbitrary

			#region CRUD InsertByRecords
			var tv_TotalHrsInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TotalHrs",
				items: tv_TotalHrsLoadResponse.Items);

			this.appDB.Insert(tv_TotalHrsInsertRequest);
			#endregion InsertByRecords

			#region CRUD LoadToRecord
			var fs_sroLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Year","CAST (NULL AS INT)"},
					{"Month","CAST (NULL AS INT)"},
					{"Amt","fs_sro.total_price"},
					{"u0","fs_sro.open_date"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "fs_sro",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("open_date >= DATEADD(YY, -1, DATEADD(MM, 1, GETDATE())) AND sro_stat <> 'T' AND sro_stat <> 'E'"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var fs_sroLoadResponse = this.appDB.Load(fs_sroLoadRequest);
			#endregion  LoadToRecord

			#region CRUD InsertByRecords
			foreach (var fs_sroItem in fs_sroLoadResponse.Items)
			{
				fs_sroItem.SetValue<int?>("Year", dateTimeUtil.DatePart("Year", fs_sroItem.GetValue<DateTime?>("u0")));
				fs_sroItem.SetValue<int?>("Month", dateTimeUtil.DatePart("Month", fs_sroItem.GetValue<DateTime?>("u0")));
				fs_sroItem.SetValue<decimal?>("Amt", fs_sroItem.GetValue<decimal?>("Amt"));
			};

			var fs_sroRequiredColumns = new List<string>() { "Year", "Month", "Amt" };

			fs_sroLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(fs_sroLoadResponse, fs_sroRequiredColumns);

			var fs_sroInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_SROsAmount",
				items: fs_sroLoadResponse.Items);

			this.appDB.Insert(fs_sroInsertRequest);
			#endregion InsertByRecords

			#region CRUD LoadArbitrary
			var tv_SROsTotalAmountLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "Year", "Year" },
					{ "Month", "Month" },
					{ "TotalAmt", "SUM(Amt)" },
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList  
					FROM #tv_SROsAmount 
					GROUP BY Year, Month"));

			var tv_SROsTotalAmountLoadResponse = this.appDB.Load(tv_SROsTotalAmountLoadRequest);
			Data = tv_SROsTotalAmountLoadResponse;
			#endregion  LoadArbitrary

			#region CRUD InsertByRecords
			var tv_SROsTotalAmountInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_SROsTotalAmount",
				items: tv_SROsTotalAmountLoadResponse.Items);

			this.appDB.Insert(tv_SROsTotalAmountInsertRequest);
			#endregion InsertByRecords

			Count = 1;
			while (sQLUtil.SQLBool((sQLUtil.SQLLessThanOrEqual(Count, 12))))
			{
				if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(tableName: "#tv_TotalHrs",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("Year = {1} AND Month = {0}", CurrentMonth, CurrentYear)))))
				{
					#region CRUD LoadResponseWithoutTable
					var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
					{
						{ "Year", variableUtil.GetValue<int?>(CurrentYear,true)},
						{ "Month", variableUtil.GetValue<int?>(CurrentMonth,true)},
						{ "TotalHrs", variableUtil.GetValue<decimal?>(0,true)},
					});

					var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
					Data = nonTableLoadResponse;
					#endregion CRUD LoadResponseWithoutTable

					#region CRUD InsertByRecords
					var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_TotalHrs",
					items: nonTableLoadResponse.Items);

					this.appDB.Insert(nonTableInsertRequest);
					#endregion InsertByRecords
				}

				if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(tableName: "#tv_SROsTotalAmount",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("Year = {1} AND Month = {0}", CurrentMonth, CurrentYear)))))
				{
					#region CRUD LoadResponseWithoutTable
					var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
					{
						{ "Year", variableUtil.GetValue<int?>(CurrentYear,true)},
						{ "Month", variableUtil.GetValue<int?>(CurrentMonth,true)},
						{ "TotalAmt", variableUtil.GetValue<decimal?>(0,true)},
					});

					var nonTable1LoadResponse = this.appDB.Load(nonTable1LoadRequest);
					Data = nonTable1LoadResponse;
					#endregion CRUD LoadResponseWithoutTable

					#region CRUD InsertByRecords
					var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_SROsTotalAmount",
						items: nonTable1LoadResponse.Items);

					this.appDB.Insert(nonTable1InsertRequest);
					#endregion InsertByRecords
				}
				if (sQLUtil.SQLGreaterThan(CurrentMonth, 1) == true)
				{
					CurrentMonth = (int?)(CurrentMonth - 1);
				}
				else
				{
					CurrentMonth = 12;
					CurrentYear = (int?)(CurrentYear - 1);
				}
				Count = (int?)(Count + 1);
			}
			if (sQLUtil.SQLEqual(DisplayCategory, "T") == true)
			{
				#region CRUD LoadToRecord
				var ResultLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"Year","Year"},
						{"Month","Month"},
						{"Value","TotalHrs"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    maximumRows: MonthCount,
					tableName: "#tv_TotalHrs",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(" Year DESC, Month DESC"));
				var ResultLoadResponse = this.appDB.Load(ResultLoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				var ResultInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Result",
				items: ResultLoadResponse.Items);

				this.appDB.Insert(ResultInsertRequest);
				#endregion InsertByRecords
			}
			if (sQLUtil.SQLEqual(DisplayCategory, "A") == true)
			{
				#region CRUD LoadToRecord
				var Result1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"Year","Year"},
						{"Month","Month"},
						{"Value","TotalAmt"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    maximumRows: MonthCount,
					tableName: "#tv_SROsTotalAmount",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(" Year DESC, Month DESC"));
				var Result1LoadResponse = this.appDB.Load(Result1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				var Result1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Result",
					items: Result1LoadResponse.Items);

				this.appDB.Insert(Result1InsertRequest);
				#endregion InsertByRecords
			}

			#region CRUD LoadToRecord
			var tv_ResultLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Caption","CAST (NULL AS NVARCHAR)"},
					{"TotalAmtOrHrs","#tv_Result.Value"},
					{"u0","#tv_Result.Year"},
					{"u1","#tv_Result.Month"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_Result",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" Year, Month"));
			var tv_ResultLoadResponse = this.appDB.Load(tv_ResultLoadRequest);
			#endregion  LoadToRecord

			foreach (var tv_ResultItem in tv_ResultLoadResponse.Items)
			{
				tv_ResultItem.SetValue<string>("Caption", stringUtil.Concat(Convert.ToString(tv_ResultItem.GetValue<int?>("u0")), "-", Convert.ToString(tv_ResultItem.GetValue<int?>("u1"))));
				tv_ResultItem.SetValue<decimal?>("TotalAmtOrHrs", tv_ResultItem.GetValue<decimal?>("TotalAmtOrHrs"));
			};

			Data = tv_ResultLoadResponse;

			return (Data, Severity);
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Homepage_SROsAmountandTimeSp(
			string AltExtGenSp,
			int? MonthCount = 6,
			string DisplayCategory = "A")
		{
			IntType _MonthCount = MonthCount;
			StringType _DisplayCategory = DisplayCategory;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "MonthCount", _MonthCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayCategory", _DisplayCategory, ParameterDirection.Input);

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
