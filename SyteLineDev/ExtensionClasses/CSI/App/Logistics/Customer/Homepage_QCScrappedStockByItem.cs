//PROJECT NAME: Logistics
//CLASS NAME: Homepage_QCScrappedStockByItem.cs

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
	public class Homepage_QCScrappedStockByItem : IHomepage_QCScrappedStockByItem
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public Homepage_QCScrappedStockByItem(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
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
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_QCScrappedStockByItemSp(int? Count = 10)
		{
			ICollectionLoadResponse Data = null;

			StringType _ALTGEN_SpName = DBNull.Value;
			int? ALTGEN_Severity = null;
			int? Severity = null;

			if (existsChecker.Exists(
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_QCScrappedStockByItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_QCScrappedStockByItemSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Homepage_QCScrappedStockByItemSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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
							{_ALTGEN_SpName,$"[SpName]"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
						tableName: "#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause(""),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					this.appDB.Load(tv_ALTGEN1LoadRequest);
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_Homepage_QCScrappedStockByItemSp(_ALTGEN_SpName, Count);
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
					whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", _ALTGEN_SpName),
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_QCScrappedStockByItemSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_QCScrappedStockByItemSp("dbo.EXTGEN_Homepage_QCScrappedStockByItemSp", Count);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			Severity = 0;

			#region CRUD LoadArbitrary
			var jobtranLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"job.item","job.item"},
					{"jobtran.oper_num","jobtran.oper_num"},
					{"jobtran.wc","jobtran.wc"},
					{"ScrapQty","SUM(jobtran.qty_scrapped)"},
					{"CompleteQty","SUM(jobtran.qty_complete)"},
					{"ScrapPct","(SUM(jobtran.qty_scrapped) / (SUM(jobtran.qty_scrapped) + SUM(jobtran.qty_complete)) * 100)"},
					{"UM","item.u_m"},
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT TOP (COALESCE ({0}, 10)) @selectList  
					FROM jobtran 
					     INNER JOIN 
					     job 
					     ON job.job = jobtran.job 
					        AND job.suffix = jobtran.suffix 
					     INNER JOIN 
					     item 
					     ON item.item = job.item 
					GROUP BY job.item, jobtran.oper_num, jobtran.wc, jobtran.posted, item.u_m 
					HAVING jobtran.posted = 1 
					       AND SUM(jobtran.qty_scrapped) <> 0 
					ORDER BY (SUM(jobtran.qty_scrapped) / (SUM(jobtran.qty_scrapped) + SUM(jobtran.qty_complete)) * 100) DESC", Count));

			var jobtranLoadResponse = this.appDB.Load(jobtranLoadRequest);
			Data = jobtranLoadResponse;
			#endregion  LoadArbitrary

			return (Data, Severity);
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_QCScrappedStockByItemSp(string AltExtGenSp, int? Count = 10)
		{
			IntType _Count = Count;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Count", _Count, ParameterDirection.Input);

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
