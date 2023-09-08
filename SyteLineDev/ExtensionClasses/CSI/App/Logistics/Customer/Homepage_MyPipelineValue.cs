//PROJECT NAME: Logistics
//CLASS NAME: Homepage_MyPipelineValue.cs

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
	public class Homepage_MyPipelineValue : IHomepage_MyPipelineValue
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

		public Homepage_MyPipelineValue(IApplicationDB appDB,
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

		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_MyPipelineValueSp(string Salesperson = null, int? IncludeDirectReports = 0)
		{
			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			//int? CurFiscalYear = null;
			DateType _FirstPeriodStart = DBNull.Value;
			DateTime? FirstPeriodStart = null;
			DateType _FirstPeriodEnd = DBNull.Value;
			DateTime? FirstPeriodEnd = null;
			DateType _FirstPeriodDesc = DBNull.Value;
			DateTime? FirstPeriodDesc = null;
			CurrCodeType _DomCurrCode = DBNull.Value;
			string DomCurrCode = null;
			decimal? ExchRate = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_MyPipelineValueSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_MyPipelineValueSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_MyPipelineValueSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Homepage_MyPipelineValueSp(_ALTGEN_SpName,
						Salesperson,
						IncludeDirectReports);
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
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_MyPipelineValueSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_MyPipelineValueSp("dbo.EXTGEN_Homepage_MyPipelineValueSp",
					Salesperson,
					IncludeDirectReports);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

			#region CRUD LoadToVariable
			var sales_periodLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_FirstPeriodStart,"start_date"},
					{_FirstPeriodEnd,"dbo.DayEndOf(end_date)"},
					{_FirstPeriodDesc,"end_date"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "sales_period",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("start_date < GETDATE() AND GETDATE() < dbo.DayEndOf(end_date)"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var sales_periodLoadResponse = this.appDB.Load(sales_periodLoadRequest);
			if (sales_periodLoadResponse.Items.Count > 0)
			{
				FirstPeriodStart = _FirstPeriodStart;
				FirstPeriodEnd = _FirstPeriodEnd;
				FirstPeriodDesc = _FirstPeriodDesc;
			}
			#endregion  LoadToVariable

			#region CRUD LoadToVariable
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_DomCurrCode,"curr_code"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "currparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (NOLOCK)"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
			if (currparmsLoadResponse.Items.Count > 0)
			{
				DomCurrCode = _DomCurrCode;
			}
			#endregion  LoadToVariable

			#region CRUD LoadArbitrary
			var PipelineLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"col0",$"CONVERT (NVARCHAR, close_date, 101)"},
					{"max_date","max_date"},
					{"total","total"},
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList  
					FROM (SELECT CONVERT (NVARCHAR, {2} , 110) AS close_date, 
					             COALESCE (MAX(projected_close_date), {3} ) AS max_date, 
					             COALESCE (SUM(dbo.CurrCnvtSingleAmt2(COALESCE (pro.curr_code, custaddr.curr_code), 0, 0, 1, NULL, 2, 0, 1, {6} , NULL, {4} , 0, opp.est_value)), 0.0) AS total 
					      FROM   opportunity AS opp 
					             LEFT OUTER JOIN 
					             prospect AS pro 
					             ON pro.prospect_id = opp.prospect_id 
					             LEFT OUTER JOIN 
					             customer AS cus 
					             ON cus.cust_num = opp.cust_num 
					                AND cus.cust_seq = 0 
					             LEFT OUTER JOIN 
					             custaddr AS custaddr 
					             ON custaddr.cust_num = cus.cust_num 
					                AND custaddr.cust_seq = 0 
					             INNER JOIN 
					             slsman 
					             ON opp.slsman = slsman.slsman 
					      WHERE  projected_close_date IS NOT NULL 
					             AND close_date IS NULL 
					             AND {1}  <= projected_close_date 
					             AND projected_close_date <= {3}  
					             AND (opp.slsman = {5}  
					                  OR ({0}  = 1 
					                      AND slsman.slsmangr = {5} ))) AS Pipeline 
					WHERE close_date IS NOT NULL 
					ORDER BY max_date", IncludeDirectReports, FirstPeriodStart, FirstPeriodDesc, FirstPeriodEnd, DomCurrCode, Salesperson, ExchRate));

			var PipelineLoadResponse = this.appDB.Load(PipelineLoadRequest);
			Data = PipelineLoadResponse;
			#endregion  LoadArbitrary

			return (Data, Severity);
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_MyPipelineValueSp(string AltExtGenSp,
			string Salesperson = null,
			int? IncludeDirectReports = 0)
		{
			SlsmanType _Salesperson = Salesperson;
			ListYesNoType _IncludeDirectReports = IncludeDirectReports;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Salesperson", _Salesperson, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeDirectReports", _IncludeDirectReports, ParameterDirection.Input);

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
