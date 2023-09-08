//PROJECT NAME: Logistics
//CLASS NAME: Homepage_RMAAmount.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class Homepage_RMAAmount : IHomepage_RMAAmount
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IInterpretText iInterpretText;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IVariableUtil variableUtil;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public Homepage_RMAAmount(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IInterpretText iInterpretText,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IDateTimeUtil dateTimeUtil,
			IVariableUtil variableUtil,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.iInterpretText = iInterpretText;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.variableUtil = variableUtil;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_RMAAmountSp(int? DaysBefore = 30)
		{
			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			string AmtToReturnLabel = null;
			string AmtNotReturnedLabel = null;
			AmountType _AmtToReturn = DBNull.Value;
			decimal? AmtToReturn = null;
			AmountType _AmtNotReturned = DBNull.Value;
			decimal? AmtNotReturned = null;
			DateTime? CutoffDate = null;
			string Infobar = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_RMAAmountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_RMAAmountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Homepage_RMAAmountSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Homepage_RMAAmountSp(_ALTGEN_SpName, DaysBefore);
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_RMAAmountSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_RMAAmountSp("dbo.EXTGEN_Homepage_RMAAmountSp", DaysBefore);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			AmtToReturnLabel = "FORMAT(sAllAmt)";
			AmtNotReturnedLabel = "FORMAT(sNotReturnedAmt)";
			_AmtToReturn = 0;
			AmtToReturn = 0;
			_AmtNotReturned = 0;
			AmtNotReturned = 0;
			CutoffDate = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", -1 * DaysBefore, this.iMidnightOf.MidnightOfFn(scalarFunction.Execute<DateTime>("GETDATE"))));

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InterpretTextSp
			var InterpretText = this.iInterpretText.InterpretTextSp(Text: AmtToReturnLabel
				, InterpretedText: AmtToReturnLabel
				, Infobar: Infobar);
			AmtToReturnLabel = InterpretText.InterpretedText;
			Infobar = InterpretText.Infobar;

			#endregion ExecuteMethodCall

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InterpretTextSp
			var InterpretText1 = this.iInterpretText.InterpretTextSp(Text: AmtNotReturnedLabel
				, InterpretedText: AmtNotReturnedLabel
				, Infobar: Infobar);
			AmtNotReturnedLabel = InterpretText1.InterpretedText;
			Infobar = InterpretText1.Infobar;

			#endregion ExecuteMethodCall

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @RmaAmtTable AS TABLE (
				    RmaNum         RmaNumType ,
				    RmaLine        RmaLineType,
				    AmtToReturn    AmountType ,
				    AmtNotReturned AmountType ,
				    QtyToReturn    QtyUnitType,
				    QtyNotReturned QtyUnitType);
				SELECT * into #tv_RmaAmtTable from @RmaAmtTable ");

			#region CRUD LoadToRecord
			var rmaitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"RmaNum","rmaitem.rma_num"},
					{"RmaLine","rmaitem.rma_line"},
					{"AmtToReturn","CAST (NULL AS DECIMAL)"},
					{"AmtNotReturned","CAST (NULL AS INT)"},
					{"QtyToReturn","CAST (NULL AS DECIMAL)"},
					{"QtyNotReturned","CAST (NULL AS DECIMAL)"},
					{"u0","rmaitem.qty_to_return_conv"},
					{"u1","rmaitem.unit_credit_conv"},
					{"u2","rmaitem.restock_fee_amt"},
					{"u3","rmaitem.return_item"},
					{"u4","rmaitem.qty_credited"},
					{"u5","rmaitem.qty_received"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "rmaitem",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("rma_num IN (SELECT rma_num FROM rma WHERE rma_date >= {0}) AND stat = 'O'", CutoffDate),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var rmaitemLoadResponse = this.appDB.Load(rmaitemLoadRequest);
			#endregion  LoadToRecord

			#region CRUD InsertByRecords
			foreach (var rmaitemItem in rmaitemLoadResponse.Items)
			{
				rmaitemItem.SetValue<string>("RmaNum", rmaitemItem.GetValue<string>("RmaNum"));
				rmaitemItem.SetValue<int?>("RmaLine", rmaitemItem.GetValue<int?>("RmaLine"));
				rmaitemItem.SetValue<decimal?>("AmtToReturn", stringUtil.IsNull<decimal?>(rmaitemItem.GetValue<decimal?>("u0"), 0) * stringUtil.IsNull<decimal?>(rmaitemItem.GetValue<decimal?>("u1"), 0) - stringUtil.IsNull<decimal?>(rmaitemItem.GetValue<decimal?>("u2"), 0));
				rmaitemItem.SetValue<int?>("AmtNotReturned", 0);
				rmaitemItem.SetValue<decimal?>("QtyToReturn", stringUtil.IsNull<decimal?>(rmaitemItem.GetValue<decimal?>("u0"), 0));
				rmaitemItem.SetValue<decimal?>("QtyNotReturned", (sQLUtil.SQLEqual(rmaitemItem.GetValue<int?>("u3"), 1) == true ? stringUtil.IsNull<decimal?>(rmaitemItem.GetValue<decimal?>("u0"), 0) - (sQLUtil.SQLGreaterThan(rmaitemItem.GetValue<decimal?>("u4"), 0) == true ? rmaitemItem.GetValue<decimal?>("u4") : stringUtil.IsNull<decimal?>(rmaitemItem.GetValue<decimal?>("u5"), 0)) : 0));
			};

			var rmaitemRequiredColumns = new List<string>() { "RmaNum", "RmaLine", "AmtToReturn", "AmtNotReturned", "QtyToReturn", "QtyNotReturned" };

			rmaitemLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(rmaitemLoadResponse, rmaitemRequiredColumns);

			var rmaitemInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_RmaAmtTable",
				items: rmaitemLoadResponse.Items);

			this.appDB.Insert(rmaitemInsertRequest);
			#endregion InsertByRecords

			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_RmaAmtTable ADD tempTableId INT IDENTITY");

			#region CRUD LoadToRecord
			var tv_RmaAmtTableLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"AmtNotReturned","#tv_RmaAmtTable.AmtNotReturned"},
					{"u0","AmtToReturn"},
					{"u1","QtyNotReturned"},
					{"u2","QtyToReturn"},
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
				tableName: "#tv_RmaAmtTable", 
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause($"QtyToReturn > 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_RmaAmtTableLoadResponse = this.appDB.Load(tv_RmaAmtTableLoadRequest);
			#endregion  LoadToRecord


			#region CRUD UpdateByRecord
			foreach (var tv_RmaAmtTableItem in tv_RmaAmtTableLoadResponse.Items)
			{
				tv_RmaAmtTableItem.SetValue<decimal?>("AmtNotReturned", tv_RmaAmtTableItem.GetValue<decimal?>("u0") * (tv_RmaAmtTableItem.GetValue<decimal?>("u1") / tv_RmaAmtTableItem.GetValue<decimal?>("u2")));
			};

			var tv_RmaAmtTableRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_RmaAmtTable",
				items: tv_RmaAmtTableLoadResponse.Items);

			this.appDB.Update(tv_RmaAmtTableRequestUpdate);
			#endregion UpdateByRecord

			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_RmaAmtTable DROP COLUMN tempTableId");

			#region CRUD LoadToVariable
			var tv_RmaAmtTable1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_AmtToReturn,"SUM(AmtToReturn)"},
					{_AmtNotReturned,"SUM(AmtNotReturned)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#tv_RmaAmtTable",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_RmaAmtTable1LoadResponse = this.appDB.Load(tv_RmaAmtTable1LoadRequest);
			if (tv_RmaAmtTable1LoadResponse.Items.Count > 0)
			{
				AmtToReturn = _AmtToReturn;
				AmtNotReturned = _AmtNotReturned;
			}
			#endregion  LoadToVariable

			UnionUtil unionTable = new UnionUtil(UnionType.Union);

			#region CRUD LoadResponseWithoutTable
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "Caption", variableUtil.GetValue<string>(AmtToReturnLabel,true)},
					{ "Amount", stringUtil.IsNull<decimal?>(AmtToReturn, 0)},
					{ "Type", "A"},
				});

			var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
			Data = nonTableLoadResponse;
			#endregion CRUD LoadResponseWithoutTable
			unionTable.Add(nonTableLoadResponse);

			#region CRUD LoadResponseWithoutTable
			var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "Caption", variableUtil.GetValue<string>(AmtNotReturnedLabel,true)},
					{ "Amount", stringUtil.IsNull<decimal?>(AmtNotReturned, 0)},
					{ "Type", "N"},
				});

			var nonTable1LoadResponse = this.appDB.Load(nonTable1LoadRequest);
			Data = nonTable1LoadResponse;
			#endregion CRUD LoadResponseWithoutTable
			unionTable.Add(nonTable1LoadResponse);
			var unionTableResult = unionTable.Process();
			Data = unionTableResult;

			return (Data, Severity);
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_RMAAmountSp(string AltExtGenSp, int? DaysBefore = 30)
		{
			IntType _DaysBefore = DaysBefore;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "DaysBefore", _DaysBefore, ParameterDirection.Input);

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
