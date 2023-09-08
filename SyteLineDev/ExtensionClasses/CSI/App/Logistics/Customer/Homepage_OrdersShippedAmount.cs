//PROJECT NAME: Logistics
//CLASS NAME: Homepage_OrdersShippedAmount.cs

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
using CSI.Finance;

namespace CSI.Logistics.Customer
{
	public class Homepage_OrdersShippedAmount : IHomepage_OrdersShippedAmount
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
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly IGetLabel iGetLabel;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMathUtil mathUtil;
		readonly ICurrCnvtSingleAmt2 iCurrCnvtSingleAmt2;

		public Homepage_OrdersShippedAmount(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			IGetLabel iGetLabel,
			ISQLValueComparerUtil sQLUtil,
			IMathUtil mathUtil,
			ICurrCnvtSingleAmt2 iCurrCnvtSingleAmt2)
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
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.iGetLabel = iGetLabel;
			this.sQLUtil = sQLUtil;
			this.mathUtil = mathUtil;
			this.iCurrCnvtSingleAmt2 = iCurrCnvtSingleAmt2;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_OrdersShippedAmountSp (string Range = "T")
		{
			ICollectionLoadResponse Data = null;
			
			int? Severity = 0;
			
			StringType _ALTGEN_SpName = DBNull.Value;
			int? ALTGEN_Severity = null;
			DateTime? StartDate = null;
			DateTime? EndDate = null;
			CurrCodeType _DomCurrCode = DBNull.Value;
			string DomCurrCode = null;
			string Label = null;

			if (existsChecker.Exists(
				tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_OrdersShippedAmountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    tableName:"optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_OrdersShippedAmountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord
				
				#region CRUD InsertByRecords
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Homepage_OrdersShippedAmountSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);
				
				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords
				
				while (existsChecker.Exists(
					tableName:"#tv_ALTGEN",
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
						tableName:"#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause(""),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					this.appDB.Load(tv_ALTGEN1LoadRequest);
					#endregion  LoadToVariable
					
					var ALTGEN = AltExtGen_Homepage_OrdersShippedAmountSp (_ALTGEN_SpName, Range);
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
                        tableName:"#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",_ALTGEN_SpName),
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_OrdersShippedAmountSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_OrdersShippedAmountSp("dbo.EXTGEN_Homepage_OrdersShippedAmountSp", Range);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

			if (sQLUtil.SQLEqual(Range, "T") == true)
			{
				StartDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")));
				Label = this.iGetLabel.GetLabelFn("@!Today");
			} 
			else if (sQLUtil.SQLEqual(Range, "3") == true)
			{
				StartDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(29));
				Label = stringUtil.Concat("30 ", this.iGetLabel.GetLabelFn("@!Days"));
			}
			else if (sQLUtil.SQLEqual(Range, "6") == true)
			{
				StartDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(59));
				Label = stringUtil.Concat("60 ", this.iGetLabel.GetLabelFn("@!Days"));
			}
			else if (sQLUtil.SQLEqual(Range, "9") == true)
			{
				StartDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(89));
				Label = stringUtil.Concat("90 ", this.iGetLabel.GetLabelFn("@!Days"));
			}
			else if (sQLUtil.SQLEqual(Range, "M") == true)
			{
				StartDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(179));
				Label = stringUtil.Concat("6 ", this.iGetLabel.GetLabelFn("@:MO_resource.planned_service_duration_units:O"));
			}
			else if (sQLUtil.SQLEqual(Range, "Y") == true)
			{
				StartDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(scalarFunction.Execute<DateTime>("GETDATE")) - TimeSpan.FromDays(364));
				Label = stringUtil.Concat("12 ", this.iGetLabel.GetLabelFn("@:MO_resource.planned_service_duration_units:O"));
			}

			EndDate = convertToUtil.ToDateTime(scalarFunction.Execute<DateTime>("GETDATE"));
			
			#region CRUD LoadToVariable
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_DomCurrCode,"curr_code"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"currparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(currparmsLoadRequest);
			#endregion  LoadToVariable

			DomCurrCode = _DomCurrCode;
			
			#region CRUD LoadToRecord
			var co_shipLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"currCode","co.curr_code"},
					{"exchRate","co.exch_rate"},
					{"qtyShipped","cos.qty_shipped"},
					{"qtyReturned","cos.qty_returned"},
					{"price","cos.price"},
					{"disc","coi.disc"},
					{"discAmount","co.disc_amount"},
				//{"col0",$"{variableUtil.GetValue<string>(Label)}"},
				//{"col1",$"(SUM(COALESCE (dbo.CurrCnvtSingleAmt2(co.curr_code, 0, 0, 1, NULL, 2, 0, 1, co.exch_rate, NULL, {variableUtil.GetValue<CurrCodeType>(_DomCurrCode)}, 0, (ROUND((((cos.qty_shipped - cos.qty_returned) * cos.price) * (1.0 - coi.disc / 100.0)), 2))), 0.0))) - ROUND(SUM(DISTINCT COALESCE (dbo.CurrCnvtSingleAmt2(co.curr_code, 0, 0, 1, NULL, 2, 0, 1, co.exch_rate, NULL, {variableUtil.GetValue<CurrCodeType>(_DomCurrCode)}, 0, ((co.disc_amount))), 0.0)), 2)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"co_ship",
				fromClause: collectionLoadRequestFactory.Clause(@" AS cos WITH (READUNCOMMITTED) INNER JOIN co ON co.co_num = cos.co_num INNER JOIN coitem AS coi ON coi.co_num = cos.co_num 
					AND coi.co_line = cos.co_line 
					AND coi.co_release = cos.co_release"),
				whereClause: collectionLoadRequestFactory.Clause("(co.type = 'R' OR co.type = 'B') AND cos.ship_date BETWEEN {0} AND {1}",StartDate,EndDate),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var co_shipLoadResponse = this.appDB.Load(co_shipLoadRequest);
			#endregion  LoadToRecord

			decimal? sumAmount1 = null;
			decimal? sumAmount2;
			if (co_shipLoadResponse.Items.Count > 0)
			{
				sumAmount1 = 0;
				sumAmount2 = 0;
				foreach (var co_shipItem in co_shipLoadResponse.Items)
				{
					sumAmount1 = sumAmount1 + ((stringUtil.Coalesce<decimal?>(this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(co_shipItem.GetValue<string>("currCode"), 0, 0, 1, null, 2, 0, 1, co_shipItem.GetValue<decimal?>("exchRate"), null, DomCurrCode, 0, (mathUtil.Round<decimal?>((((co_shipItem.GetValue<decimal?>("qtyShipped") - co_shipItem.GetValue<decimal?>("qtyReturned")) * co_shipItem.GetValue<decimal?>("price")) * (1.0M - co_shipItem.GetValue<decimal?>("disc") / 100.0M)), 2))), 0.0M)));
					sumAmount2 = sumAmount2 + ((stringUtil.Coalesce<decimal?>(this.iCurrCnvtSingleAmt2.CurrCnvtSingleAmt2Fn(co_shipItem.GetValue<string>("currCode"), 0, 0, 1, null, 2, 0, 1, co_shipItem.GetValue<decimal?>("exchRate"), null, DomCurrCode, 0, co_shipItem.GetValue<decimal?>("discAmount")), 0.0M)));
				};
				sumAmount2 = mathUtil.Round<decimal?>(sumAmount2, 2);
				sumAmount1 = sumAmount1 - sumAmount2;
			}

			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "col0", variableUtil.GetValue<string>(Label,true)},
					{ "col1", variableUtil.GetValue<decimal?>(sumAmount1, true)},
				});

			var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
			Data = nonTableLoadResponse;

			//Data = co_shipLoadResponse;
			return (Data, Severity);
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_OrdersShippedAmountSp(string AltExtGenSp, string Range = "T")
		{
			StringType _Range = Range;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "Range", _Range, ParameterDirection.Input);
				
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
