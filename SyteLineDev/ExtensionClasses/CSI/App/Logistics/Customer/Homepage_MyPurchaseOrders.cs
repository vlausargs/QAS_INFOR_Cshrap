//PROJECT NAME: Logistics
//CLASS NAME: Homepage_MyPurchaseOrders.cs

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
	public class Homepage_MyPurchaseOrders : IHomepage_MyPurchaseOrders
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
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

		public Homepage_MyPurchaseOrders(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
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

		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_MyPurchaseOrdersSp(string Buyer = null,
			DateTime? Date = null,
			string DateType = "D",
			string TakenBy = null,
			string Salesperson = null,
			int? OnlyCo = 0,
			string ProjMgr = null,
			int? OnlyProj = 0)
		{
			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			DateTime? MonthStart = null;
			DateTime? MonthEnd = null;
			DateTime? WeekStart = null;
			DateTime? WeekEnd = null;
			DateTime? Start = null;
			DateTime? End = null;
			IntType _InProcess = DBNull.Value;
			int? InProcess = null;
			IntType _PastDue = DBNull.Value;
			int? PastDue = null;
			IntType _Received = DBNull.Value;
			int? Received = null;
			string InterpretInProcess = null;
			string InterpretReceived = null;
			string InterpretPastDue = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause($"ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_MyPurchaseOrdersSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_MyPurchaseOrdersSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_MyPurchaseOrdersSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Homepage_MyPurchaseOrdersSp(_ALTGEN_SpName,
						Buyer,
						Date,
						DateType,
						TakenBy,
						Salesperson,
						OnlyCo,
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
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_MyPurchaseOrdersSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_MyPurchaseOrdersSp("dbo.EXTGEN_Homepage_MyPurchaseOrdersSp",
					Buyer,
					Date,
					DateType,
					TakenBy,
					Salesperson,
					OnlyCo,
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
			InterpretReceived = this.iGetLabel.GetLabelFn("@!Received");
			InterpretPastDue = this.iGetLabel.GetLabelFn("@!PastDue");
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
			var poitemASpLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_InProcess,$"ISNULL(COUNT(p.po_line), 0)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "poitem AS p",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN po ON po.po_num = p.po_num INNER JOIN vendaddr ON po.vend_num = vendaddr.vend_num LEFT OUTER JOIN coitem AS c ON p.ref_type = N'O' 
					AND p.ref_num = c.co_num 
					AND p.ref_line_suf = c.co_line 
					AND p.ref_release = c.ref_release LEFT OUTER JOIN co ON co.co_num = c.co_num LEFT OUTER JOIN projmatl AS matl ON p.ref_type = N'K' 
					AND p.ref_num = matl.proj_num 
					AND p.ref_line_suf = matl.task_num 
					AND p.ref_release = matl.seq LEFT OUTER JOIN proj ON proj.proj_num = matl.proj_num"),
				whereClause: collectionLoadRequestFactory.Clause("(p.due_date BETWEEN {5} AND {8}) AND p.due_date >= {7} AND p.qty_ordered > p.qty_received AND po.stat = N'O' AND ({6} IS NULL OR po.buyer = {6}) AND ({2} IS NULL OR proj.proj_mgr = {2}) AND ({1} = 0 OR ({1} = 1 AND proj.proj_num IS NOT NULL)) AND ({3} IS NULL OR co.taken_by = {3}) AND ({0} IS NULL OR co.slsman = {0}) AND ({4} = 0 OR ({4} = 1 AND co.co_num IS NOT NULL))", Salesperson, OnlyProj, ProjMgr, TakenBy, OnlyCo, Start, Buyer, Date, End),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var poitemASpLoadResponse = this.appDB.Load(poitemASpLoadRequest);
			if (poitemASpLoadResponse.Items.Count > 0)
			{
				InProcess = _InProcess;
			}
			#endregion  LoadToVariable

			#region CRUD LoadResponseWithoutTable
			var nonTable7LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "ordercount", variableUtil.GetValue<int?>(InProcess,true)},
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
			var poitemASp1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_Received,$"ISNULL(COUNT(po_line), 0)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "poitem AS p",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN po ON po.po_num = p.po_num INNER JOIN vendaddr ON po.vend_num = vendaddr.vend_num LEFT OUTER JOIN coitem AS c ON p.ref_type = N'O' 
					AND p.ref_num = c.co_num 
					AND p.ref_line_suf = c.co_line 
					AND p.ref_release = c.ref_release LEFT OUTER JOIN co ON co.co_num = c.co_num LEFT OUTER JOIN projmatl AS matl ON p.ref_type = N'K' 
					AND p.ref_num = matl.proj_num 
					AND p.ref_line_suf = matl.task_num 
					AND p.ref_release = matl.seq LEFT OUTER JOIN proj ON proj.proj_num = matl.proj_num"),
				whereClause: collectionLoadRequestFactory.Clause("(p.due_date BETWEEN {5} AND {7}) AND p.qty_ordered <= p.qty_received AND po.stat = N'O' AND ({6} IS NULL OR po.buyer = {6}) AND ({2} IS NULL OR proj.proj_mgr = {2}) AND ({1} = 0 OR ({1} = 1 AND proj.proj_num IS NOT NULL)) AND ({3} IS NULL OR co.taken_by = {3}) AND ({0} IS NULL OR co.slsman = {0}) AND ({4} = 0 OR ({4} = 1 AND co.co_num IS NOT NULL))", Salesperson, OnlyProj, ProjMgr, TakenBy, OnlyCo, Start, Buyer, End),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var poitemASp1LoadResponse = this.appDB.Load(poitemASp1LoadRequest);
			if (poitemASp1LoadResponse.Items.Count > 0)
			{
				Received = _Received;
			}
			#endregion  LoadToVariable

			#region CRUD LoadResponseWithoutTable
			var nonTable8LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "ordercount", variableUtil.GetValue<int?>(Received,true)},
					{ "statustype", variableUtil.GetValue<string>(InterpretReceived,true)},
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
			var poitemASp2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PastDue,$"ISNULL(COUNT(po_line), 0)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "poitem AS p",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN po ON po.po_num = p.po_num INNER JOIN vendaddr ON po.vend_num = vendaddr.vend_num LEFT OUTER JOIN coitem AS c ON p.ref_type = N'O' 
					AND p.ref_num = c.co_num 
					AND p.ref_line_suf = c.co_line 
					AND p.ref_release = c.ref_release LEFT OUTER JOIN co ON co.co_num = c.co_num LEFT OUTER JOIN projmatl AS matl ON p.ref_type = N'K' 
					AND p.ref_num = matl.proj_num 
					AND p.ref_line_suf = matl.task_num 
					AND p.ref_release = matl.seq LEFT OUTER JOIN proj ON proj.proj_num = matl.proj_num"),
				whereClause: collectionLoadRequestFactory.Clause("p.due_date < {6} AND p.qty_ordered > p.qty_received AND po.stat = N'O' AND ({5} IS NULL OR po.buyer = {5}) AND ({2} IS NULL OR proj.proj_mgr = {2}) AND ({1} = 0 OR ({1} = 1 AND proj.proj_num IS NOT NULL)) AND ({3} IS NULL OR co.taken_by = {3}) AND ({0} IS NULL OR co.slsman = {0}) AND ({4} = 0 OR ({4} = 1 AND co.co_num IS NOT NULL))", Salesperson, OnlyProj, ProjMgr, TakenBy, OnlyCo, Buyer, Date),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var poitemASp2LoadResponse = this.appDB.Load(poitemASp2LoadRequest);
			if (poitemASp2LoadResponse.Items.Count > 0)
			{
				PastDue = _PastDue;
			}
			#endregion  LoadToVariable

			#region CRUD LoadResponseWithoutTable
			var nonTable9LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "ordercount", variableUtil.GetValue<int?>(PastDue,true)},
					{ "statustype", variableUtil.GetValue<string>((InterpretPastDue),true)},
				});

			var nonTable9LoadResponse = this.appDB.Load(nonTable9LoadRequest);
			Data = nonTable9LoadResponse;
			#endregion CRUD LoadResponseWithoutTable

			#region CRUD InsertByRecords
			var nonTable9InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Orders",
				items: nonTable9LoadResponse.Items);

			this.appDB.Insert(nonTable9InsertRequest);
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

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_MyPurchaseOrdersSp(string AltExtGenSp,
			string Buyer = null,
			DateTime? Date = null,
			string DateType = "D",
			string TakenBy = null,
			string Salesperson = null,
			int? OnlyCo = 0,
			string ProjMgr = null,
			int? OnlyProj = 0)
		{
			UsernameType _Buyer = Buyer;
			DateType _Date = Date;
			StringType _DateType = DateType;
			TakenByType _TakenBy = TakenBy;
			SlsmanType _Salesperson = Salesperson;
			ListYesNoType _OnlyCo = OnlyCo;
			NameType _ProjMgr = ProjMgr;
			ListYesNoType _OnlyProj = OnlyProj;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateType", _DateType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TakenBy", _TakenBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Salesperson", _Salesperson, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OnlyCo", _OnlyCo, ParameterDirection.Input);
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
