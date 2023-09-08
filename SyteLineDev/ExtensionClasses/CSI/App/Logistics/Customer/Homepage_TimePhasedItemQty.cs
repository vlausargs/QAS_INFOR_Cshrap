//PROJECT NAME: Logistics
//CLASS NAME: Homepage_TimePhasedItemQty.cs

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
	public class Homepage_TimePhasedItemQty : IHomepage_TimePhasedItemQty
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public Homepage_TimePhasedItemQty(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
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
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
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
		Homepage_TimePhasedItemQtySp(
			string Item,
			string Whse)
		{
			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			QtyUnitType _QtyOnHand = DBNull.Value;
			decimal? QtyOnHand = null;
			QtyUnitType _QtySumUp = DBNull.Value;
			decimal? QtySumUp = null;
			int? Year = null;
			int? Month = null;
			int? CurrentYear = null;
			int? CurrentMonth = null;
			int? MonthCount = null;
			ICollectionLoadRequest QtyBalCursorLoadRequestForCursor = null;
			ICollectionLoadResponse QtyBalCursorLoadResponseForCursor = null;
			int QtyBalCursor_CursorFetch_Status = -1;
			int QtyBalCursor_CursorCounter = -1;

			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_TimePhasedItemQtySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_TimePhasedItemQtySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_TimePhasedItemQtySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Homepage_TimePhasedItemQtySp(_ALTGEN_SpName,
						Item,
						Whse);
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_TimePhasedItemQtySp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_TimePhasedItemQtySp("dbo.EXTGEN_Homepage_TimePhasedItemQtySp",
					Item,
					Whse);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @MatlTranQty AS TABLE (
				    Year  INT        ,
				    Month INT        ,
				    Qty   QtyUnitType);
				SELECT * into #tv_MatlTranQty from @MatlTranQty ");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @QtyBalance AS TABLE (
				    Year      INT        ,
				    Month     INT        ,
				    TranQty   QtyUnitType,
				    QtyOnHand QtyUnitType);
				SELECT * into #tv_QtyBalance from @QtyBalance ");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @Result AS TABLE (
				    Caption MessageType,
				    Qty     QtyUnitType,
				    Year    INT        ,
				    Month   INT        );
				SELECT * into #tv_Result from @Result ");
			CurrentYear = (int?)(dateTimeUtil.DatePart("Year", scalarFunction.Execute<DateTime>("GETDATE")));
			CurrentMonth = (int?)(dateTimeUtil.DatePart("Month", scalarFunction.Execute<DateTime>("GETDATE")));

			#region CRUD LoadToVariable
			var itemwhseLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_QtyOnHand,"qty_on_hand"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "itemwhse",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("item = {0} AND whse = {1}", Item, Whse),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemwhseLoadResponse = this.appDB.Load(itemwhseLoadRequest);
			if (itemwhseLoadResponse.Items.Count > 0)
			{
				QtyOnHand = _QtyOnHand;
			}
			#endregion  LoadToVariable

			#region CRUD LoadToRecord
			var matltranLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Year","CAST (NULL AS INT)"},
					{"Month","CAST (NULL AS INT)"},
					{"Qty","matltran.qty"},
					{"u0","matltran.trans_date"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "matltran",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("trans_date >= DATEADD(YY, -1, DATEADD(MM, 1, GETDATE())) AND item = {0} AND whse = {1}", Item, Whse),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var matltranLoadResponse = this.appDB.Load(matltranLoadRequest);
			#endregion  LoadToRecord

			#region CRUD InsertByRecords
			foreach (var matltranItem in matltranLoadResponse.Items)
			{
				matltranItem.SetValue<int?>("Year", dateTimeUtil.DatePart("Year", matltranItem.GetValue<DateTime?>("u0")));
				matltranItem.SetValue<int?>("Month", dateTimeUtil.DatePart("Month", matltranItem.GetValue<DateTime?>("u0")));
				matltranItem.SetValue<decimal?>("Qty", matltranItem.GetValue<decimal?>("Qty"));
			};

			var matltranRequiredColumns = new List<string>() { "Year", "Month", "Qty" };

			matltranLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(matltranLoadResponse, matltranRequiredColumns);

			var matltranInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_MatlTranQty",
				items: matltranLoadResponse.Items);

			this.appDB.Insert(matltranInsertRequest);
			#endregion InsertByRecords

			#region CRUD LoadArbitrary
			var tv_QtyBalanceLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "Year", "Year" },
					{ "Month", "Month" },
					{ "TranQty", "SUM(Qty)" },
					{ "QtyOnHand", $"{variableUtil.GetValue<decimal?>(QtyOnHand)}" },
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList  
					FROM #tv_MatlTranQty 
					GROUP BY Year, Month"));

			var tv_QtyBalanceLoadResponse = this.appDB.Load(tv_QtyBalanceLoadRequest);
			Data = tv_QtyBalanceLoadResponse;
			#endregion  LoadArbitrary


			#region CRUD InsertByRecords
			var tv_QtyBalanceInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_QtyBalance",
				items: tv_QtyBalanceLoadResponse.Items);

			this.appDB.Insert(tv_QtyBalanceInsertRequest);
			#endregion InsertByRecords

			MonthCount = 1;
			while (sQLUtil.SQLBool((sQLUtil.SQLLessThanOrEqual(MonthCount, 12))))
			{
				if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(tableName: "#tv_QtyBalance",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("Year = {1} AND Month = {0}", CurrentMonth, CurrentYear)))))
				{
					#region CRUD LoadResponseWithoutTable
					var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
					{
						{ "Year", variableUtil.GetValue<int?>(CurrentYear,true)},
						{ "Month", variableUtil.GetValue<int?>(CurrentMonth,true)},
						{ "TranQty", variableUtil.GetValue<decimal?>(0,true)},
						{ "QtyOnHand", variableUtil.GetValue<decimal?>(QtyOnHand,true)},
					});

					var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
					Data = nonTableLoadResponse;
					#endregion CRUD LoadResponseWithoutTable

					#region CRUD InsertByRecords
					var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_QtyBalance",
						items: nonTableLoadResponse.Items);

					this.appDB.Insert(nonTableInsertRequest);
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
				MonthCount = (int?)(MonthCount + 1);
			}
			#region Cursor Statement

			#region CRUD LoadToRecord
			QtyBalCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Year","Year"},
					{"Month","Month"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_QtyBalance",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			#endregion  LoadToRecord

			#endregion Cursor Statement
			QtyBalCursorLoadResponseForCursor = this.appDB.Load(QtyBalCursorLoadRequestForCursor);
			QtyBalCursor_CursorFetch_Status = QtyBalCursorLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			QtyBalCursor_CursorCounter = -1;

			QtyBalCursor_CursorCounter++;
			if (QtyBalCursorLoadResponseForCursor.Items.Count > QtyBalCursor_CursorCounter)
			{
				Year = QtyBalCursorLoadResponseForCursor.Items[QtyBalCursor_CursorCounter].GetValue<int?>(0);
				Month = QtyBalCursorLoadResponseForCursor.Items[QtyBalCursor_CursorCounter].GetValue<int?>(1);
			}
			QtyBalCursor_CursorFetch_Status = (QtyBalCursor_CursorCounter == QtyBalCursorLoadResponseForCursor.Items.Count ? -1 : 0);

			while (sQLUtil.SQLEqual(QtyBalCursor_CursorFetch_Status, 0) == true)
			{
				//BEGIN

				#region CRUD LoadToVariable
				var tv_QtyBalance3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_QtySumUp,"ISNULL(SUM(TranQty), 0)"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#tv_QtyBalance",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("Year = {1} AND Month > {0} OR Year > {1}", Month, Year),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tv_QtyBalance3LoadResponse = this.appDB.Load(tv_QtyBalance3LoadRequest);
				if (tv_QtyBalance3LoadResponse.Items.Count > 0)
				{
					QtySumUp = _QtySumUp;
				}
				#endregion  LoadToVariable

				this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_QtyBalance ADD tempTableId INT IDENTITY");

				#region CRUD LoadToRecord
				var tv_QtyBalance4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"QtyOnHand","#tv_QtyBalance.QtyOnHand"},
				},
                loadForChange: true, 
                tableName: "#tv_QtyBalance",
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("Year = {1} AND Month = {0}", Month, Year),
				orderByClause: collectionLoadRequestFactory.Clause(""));
				var tv_QtyBalance4LoadResponse = this.appDB.Load(tv_QtyBalance4LoadRequest);
				#endregion  LoadToRecord


				#region CRUD UpdateByRecord
				foreach (var tv_QtyBalance4Item in tv_QtyBalance4LoadResponse.Items)
				{
					tv_QtyBalance4Item.SetValue<decimal?>("QtyOnHand", QtyOnHand - QtySumUp);
				};

				var tv_QtyBalance4RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_QtyBalance",
				items: tv_QtyBalance4LoadResponse.Items);

				this.appDB.Update(tv_QtyBalance4RequestUpdate);
				#endregion UpdateByRecord

				this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_QtyBalance DROP COLUMN tempTableId");
				QtyBalCursor_CursorCounter++;
				if (QtyBalCursorLoadResponseForCursor.Items.Count > QtyBalCursor_CursorCounter)
				{
					Year = QtyBalCursorLoadResponseForCursor.Items[QtyBalCursor_CursorCounter].GetValue<int?>(0);
					Month = QtyBalCursorLoadResponseForCursor.Items[QtyBalCursor_CursorCounter].GetValue<int?>(1);
				}
				QtyBalCursor_CursorFetch_Status = (QtyBalCursor_CursorCounter == QtyBalCursorLoadResponseForCursor.Items.Count ? -1 : 0);
			}
			//Deallocate Cursor QtyBalCursor

			#region CRUD LoadToRecord
			var tv_QtyBalance5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Caption","CAST (NULL AS NVARCHAR)"},
					{"Qty","#tv_QtyBalance.QtyOnHand"},
					{"Year","#tv_QtyBalance.Year"},
					{"Month","#tv_QtyBalance.Month"},
					{"u0","#tv_QtyBalance.Year"},
					{"u1","#tv_QtyBalance.Month"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_QtyBalance",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_QtyBalance5LoadResponse = this.appDB.Load(tv_QtyBalance5LoadRequest);
			#endregion  LoadToRecord

			#region CRUD InsertByRecords
			foreach (var tv_QtyBalance5Item in tv_QtyBalance5LoadResponse.Items)
			{
				tv_QtyBalance5Item.SetValue<string>("Caption", stringUtil.Concat(Convert.ToString(tv_QtyBalance5Item.GetValue<int?>("u0")), "-", Convert.ToString(tv_QtyBalance5Item.GetValue<int?>("u1"))));
				tv_QtyBalance5Item.SetValue<decimal?>("Qty", tv_QtyBalance5Item.GetValue<decimal?>("Qty"));
				tv_QtyBalance5Item.SetValue<int?>("Year", tv_QtyBalance5Item.GetValue<int?>("u0"));
				tv_QtyBalance5Item.SetValue<int?>("Month", tv_QtyBalance5Item.GetValue<int?>("u1"));
			};

			var tv_QtyBalance5RequiredColumns = new List<string>() { "Caption", "Qty", "Year", "Month" };

			tv_QtyBalance5LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(tv_QtyBalance5LoadResponse, tv_QtyBalance5RequiredColumns);

			var tv_QtyBalance5InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Result",
				items: tv_QtyBalance5LoadResponse.Items);

			this.appDB.Insert(tv_QtyBalance5InsertRequest);
			#endregion InsertByRecords


			#region CRUD LoadToRecord
			var tv_ResultLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Caption","Caption"},
					{"Qty","Qty"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_Result",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" Year, Month"));
			var tv_ResultLoadResponse = this.appDB.Load(tv_ResultLoadRequest);
			#endregion  LoadToRecord

			Data = tv_ResultLoadResponse;

			return (Data, Severity);

		}
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Homepage_TimePhasedItemQtySp(
			string AltExtGenSp,
			string Item,
			string Whse)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);

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
