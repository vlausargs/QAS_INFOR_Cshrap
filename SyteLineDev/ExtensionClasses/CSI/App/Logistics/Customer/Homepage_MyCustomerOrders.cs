//PROJECT NAME: Logistics
//CLASS NAME: Homepage_MyCustomerOrders.cs

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

namespace CSI.Logistics.Customer
{
	public class Homepage_MyCustomerOrders : IHomepage_MyCustomerOrders
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
		readonly IDateTimeUtil dateTimeUtil;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly IGetLabel iGetLabel;
		readonly ISQLValueComparerUtil sQLUtil;

		public Homepage_MyCustomerOrders(IApplicationDB appDB,
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
			IDateTimeUtil dateTimeUtil,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			IGetLabel iGetLabel,
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
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.iGetLabel = iGetLabel;
			this.sQLUtil = sQLUtil;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_MyCustomerOrdersSp(string TakenBy,
			DateTime? Date,
			string DateType = "D",
			string Salesperson = null,
			string ProjMgr = null,
			int? OnlyProj = 0)
		{
			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			int? ALTGEN_Severity = null;
			DateTime? MonthStart = null;
			DateTime? MonthEnd = null;
			DateTime? WeekStart = null;
			DateTime? WeekEnd = null;
			DateTime? Start = null;
			DateTime? End = null;
			IntType _InProgress = DBNull.Value;
			IntType _PastDue = DBNull.Value;
			IntType _Shipped = DBNull.Value;
			IntType _Hold = DBNull.Value;
			string InterpretInProcess = null;
			string InterpretShipped = null;
			string InterpretPastDue = null;
			string InterpretHold = null;

			if (existsChecker.Exists(
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_MyCustomerOrdersSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_MyCustomerOrdersSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Homepage_MyCustomerOrdersSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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
					this.appDB.Load(tv_ALTGEN1LoadRequest);
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_Homepage_MyCustomerOrdersSp(_ALTGEN_SpName,
						TakenBy,
						Date,
						DateType,
						Salesperson,
						ProjMgr,
						OnlyProj);
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
				}
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_MyCustomerOrdersSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_MyCustomerOrdersSp("dbo.EXTGEN_Homepage_MyCustomerOrdersSp",
					TakenBy,
					Date,
					DateType,
					Salesperson,
					ProjMgr,
					OnlyProj);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			Date = convertToUtil.ToDateTime(stringUtil.IsNull(Date, scalarFunction.Execute<DateTime>("GETDATE")));
			MonthStart = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Month", dateTimeUtil.DateDiff("Month", 0, Date), 0));
			MonthEnd = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", -1, dateTimeUtil.DateAdd("Month", dateTimeUtil.DateDiff("Month", 0, Date) + 1, 0)));
			WeekStart = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", -(dateTimeUtil.DatePart("Weekday", Date) - 1), Date));
			WeekEnd = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", 7 - (dateTimeUtil.DatePart("Weekday", Date)), Date));
			InterpretInProcess = this.iGetLabel.GetLabelFn("@!InProcess");
			InterpretShipped = this.iGetLabel.GetLabelFn("@!Shipped");
			InterpretPastDue = this.iGetLabel.GetLabelFn("@!PastDue");
			InterpretHold = this.iGetLabel.GetLabelFn("@!Hold");
			if (sQLUtil.SQLEqual(DateType, "D") == true)
			{
				Start = convertToUtil.ToDateTime(Date);
				End = convertToUtil.ToDateTime(Date);
			}
			else
			{
				if (sQLUtil.SQLEqual(DateType, "W") == true)
				{
					Start = convertToUtil.ToDateTime(WeekStart);
					End = convertToUtil.ToDateTime(WeekEnd);
				}
				else
				{
					if (sQLUtil.SQLEqual(DateType, "M") == true)
					{
						Start = convertToUtil.ToDateTime(MonthStart);
						End = convertToUtil.ToDateTime(MonthEnd);
					}
				}
			}

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @Orders TABLE (
				    OrderCount INT        ,
				    StatusType MessageType);
				SELECT * into #tv_Orders from @Orders ");

			#region CRUD LoadToVariable
			var coitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InProgress,"ISNULL(COUNT(coitem.co_line), 0)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "coitem",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN co ON co.co_num = coitem.co_num INNER JOIN custaddr ON co.cust_num = custaddr.cust_num 
					AND custaddr.cust_seq = 0 LEFT OUTER JOIN projtask AS p ON p.co_num = coitem.co_num 
					AND p.co_line = coitem.co_line 
					AND p.co_release = coitem.co_release LEFT OUTER JOIN proj ON p.proj_num = proj.proj_mgr"),
				whereClause: collectionLoadRequestFactory.Clause(@"(due_date BETWEEN {4} AND {5}) AND qty_ordered > qty_shipped AND coitem.stat = N'O' AND (co.credit_hold = 0 AND custaddr.credit_hold = 0) 
					AND ({2} IS NULL OR co.taken_by = {2}) AND ({0} IS NULL OR co.slsman = {0}) AND ({3} IS NULL OR proj.proj_mgr = {3}) AND ({1} = 0 OR ({1} = 1 AND proj.proj_num IS NOT NULL))"
					, Salesperson, OnlyProj, TakenBy, ProjMgr, Start, End),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(coitemLoadRequest);
			#endregion  LoadToVariable

			#region CRUD LoadResponseWithoutTable
			var nonTable7LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "ordercount", variableUtil.GetValue<IntType>(_InProgress,true)},
					{ "statustype", variableUtil.GetValue<string>(InterpretInProcess,true)},
				});

			var nonTable7LoadResponse = this.appDB.Load(nonTable7LoadRequest);
			Data = nonTable7LoadResponse;
			#endregion CRUD LoadResponseWithoutTable

			#region CRUD InsertByRecords
			var nonTable7InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Orders",
				items: nonTable7LoadResponse.Items);

			this.appDB.Insert(nonTable7InsertRequest);
			#endregion InsertByRecords

			#region CRUD LoadToVariable
			var coitem1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Shipped,"ISNULL(COUNT(coitem.co_line), 0)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "coitem",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN co ON co.co_num = coitem.co_num INNER JOIN custaddr ON co.cust_num = custaddr.cust_num 
					AND custaddr.cust_seq = 0 LEFT OUTER JOIN projtask AS p ON p.co_num = coitem.co_num 
					AND p.co_line = coitem.co_line 
					AND p.co_release = coitem.co_release LEFT OUTER JOIN proj ON p.proj_num = proj.proj_mgr"),
				whereClause: collectionLoadRequestFactory.Clause(@"(due_date BETWEEN {4} AND {5}) AND qty_ordered <= qty_shipped AND coitem.stat IN (N'O', N'F', N'C') 
					AND ({2} IS NULL OR co.taken_by = {2}) AND ({0} IS NULL OR co.slsman = {0}) AND ({3} IS NULL OR proj.proj_mgr = {3}) AND ({1} = 0 OR ({1} = 1 AND proj.proj_num IS NOT NULL))"
					, Salesperson, OnlyProj, TakenBy, ProjMgr, Start, End),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(coitem1LoadRequest);
			#endregion  LoadToVariable

			#region CRUD LoadResponseWithoutTable
			var nonTable8LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "ordercount", variableUtil.GetValue<IntType>(_Shipped,true)},
					{ "statustype", variableUtil.GetValue<string>(InterpretShipped,true)},
				});

			var nonTable8LoadResponse = this.appDB.Load(nonTable8LoadRequest);
			Data = nonTable8LoadResponse;
			#endregion CRUD LoadResponseWithoutTable

			#region CRUD InsertByRecords
			var nonTable8InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Orders",
				items: nonTable8LoadResponse.Items);

			this.appDB.Insert(nonTable8InsertRequest);
			#endregion InsertByRecords

			#region CRUD LoadToVariable
			var coitem2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PastDue,"ISNULL(COUNT(coitem.co_line), 0)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "coitem",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN co ON co.co_num = coitem.co_num INNER JOIN custaddr ON co.cust_num = custaddr.cust_num 
					AND custaddr.cust_seq = 0 LEFT OUTER JOIN projtask AS p ON p.co_num = coitem.co_num 
					AND p.co_line = coitem.co_line 
					AND p.co_release = coitem.co_release LEFT OUTER JOIN proj ON p.proj_num = proj.proj_mgr"),
				whereClause: collectionLoadRequestFactory.Clause(@"due_date < {4} AND qty_ordered > qty_shipped AND coitem.stat = N'O' AND (co.credit_hold = 0 AND custaddr.credit_hold = 0) 
					AND ({2} IS NULL OR co.taken_by = {2}) AND ({0} IS NULL OR co.slsman = {0}) AND ({3} IS NULL OR proj.proj_mgr = {3}) AND ({1} = 0 OR ({1} = 1 AND proj.proj_num IS NOT NULL))"
					, Salesperson, OnlyProj, TakenBy, ProjMgr, Start),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(coitem2LoadRequest);
			#endregion  LoadToVariable

			#region CRUD LoadResponseWithoutTable
			var nonTable9LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "ordercount", variableUtil.GetValue<IntType>(_PastDue,true)},
					{ "statustype", variableUtil.GetValue<string>(InterpretPastDue,true)},
				});

			var nonTable9LoadResponse = this.appDB.Load(nonTable9LoadRequest);
			Data = nonTable9LoadResponse;
			#endregion CRUD LoadResponseWithoutTable

			#region CRUD InsertByRecords
			var nonTable9InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Orders",
				items: nonTable9LoadResponse.Items);

			this.appDB.Insert(nonTable9InsertRequest);
			#endregion InsertByRecords

			#region CRUD LoadToVariable
			var coitem3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Hold,"ISNULL(COUNT(coitem.co_line), 0)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "coitem",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN co ON co.co_num = coitem.co_num INNER JOIN custaddr ON co.cust_num = custaddr.cust_num 
					AND custaddr.cust_seq = 0 LEFT OUTER JOIN projtask AS p ON p.co_num = coitem.co_num 
					AND p.co_line = coitem.co_line 
					AND p.co_release = coitem.co_release LEFT OUTER JOIN proj ON p.proj_num = proj.proj_mgr"),
				whereClause: collectionLoadRequestFactory.Clause(@"due_date <= {4} AND qty_ordered > qty_shipped AND coitem.stat = N'O' AND (co.credit_hold = 1 OR custaddr.credit_hold = 1) 
					AND ({2} IS NULL OR co.taken_by = {2}) AND ({0} IS NULL OR co.slsman = {0}) AND ({3} IS NULL OR proj.proj_mgr = {3}) AND ({1} = 0 OR ({1} = 1 AND proj.proj_num IS NOT NULL))"
					, Salesperson, OnlyProj, TakenBy, ProjMgr, End),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(coitem3LoadRequest);
			#endregion  LoadToVariable

			#region CRUD LoadResponseWithoutTable
			var nonTable10LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "ordercount", variableUtil.GetValue<IntType>(_Hold,true)},
					{ "statustype", variableUtil.GetValue<string>(InterpretHold,true)},
				});

			var nonTable10LoadResponse = this.appDB.Load(nonTable10LoadRequest);
			Data = nonTable10LoadResponse;
			#endregion CRUD LoadResponseWithoutTable

			#region CRUD InsertByRecords
			var nonTable10InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Orders",
				items: nonTable10LoadResponse.Items);

			this.appDB.Insert(nonTable10InsertRequest);
			#endregion InsertByRecords

			#region CRUD LoadToRecord
			var tv_OrdersLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"ordercount","ordercount"},
					{"statustype","statustype"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_Orders",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_OrdersLoadResponse = this.appDB.Load(tv_OrdersLoadRequest);
			#endregion  LoadToRecord

			Data = tv_OrdersLoadResponse;

			return (Data, Severity);
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_MyCustomerOrdersSp(string AltExtGenSp,
			string TakenBy,
			DateTime? Date,
			string DateType = "D",
			string Salesperson = null,
			string ProjMgr = null,
			int? OnlyProj = 0)
		{
			TakenByType _TakenBy = TakenBy;
			DateType _Date = Date;
			StringType _DateType = DateType;
			SlsmanType _Salesperson = Salesperson;
			NameType _ProjMgr = ProjMgr;
			ListYesNoType _OnlyProj = OnlyProj;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "TakenBy", _TakenBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateType", _DateType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Salesperson", _Salesperson, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjMgr", _ProjMgr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OnlyProj", _OnlyProj, ParameterDirection.Input);

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
