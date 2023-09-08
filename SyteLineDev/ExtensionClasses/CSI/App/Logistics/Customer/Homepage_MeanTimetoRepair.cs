//PROJECT NAME: Logistics
//CLASS NAME: Homepage_MeanTimetoRepair.cs

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
	public class Homepage_MeanTimetoRepair : IHomepage_MeanTimetoRepair
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IVariableUtil variableUtil;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly IGetLabel iGetLabel;
		readonly ISQLValueComparerUtil sQLUtil;

		public Homepage_MeanTimetoRepair(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IDateTimeUtil dateTimeUtil,
			IVariableUtil variableUtil,
			IMidnightOf iMidnightOf,
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
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.variableUtil = variableUtil;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.iGetLabel = iGetLabel;
			this.sQLUtil = sQLUtil;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Homepage_MeanTimetoRepairSp(int? DaysBefore = 30)
		{
			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			int? ALTGEN_Severity = null;
			string HoursLabel = null;
			IntType _SroCount = DBNull.Value;
			TotalHoursType _AvgWorkHrs = DBNull.Value;
			DateTime? CutoffDate = null;

			if (existsChecker.Exists(
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_MeanTimetoRepairSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_MeanTimetoRepairSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Homepage_MeanTimetoRepairSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_Homepage_MeanTimetoRepairSp(_ALTGEN_SpName, DaysBefore);
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_MeanTimetoRepairSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_MeanTimetoRepairSp("dbo.EXTGEN_Homepage_MeanTimetoRepairSp", DaysBefore);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			_SroCount = 0;
			_AvgWorkHrs = 0;
			HoursLabel = this.iGetLabel.GetLabelFn("@prhrs.hrs");
			CutoffDate = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", -1 * DaysBefore, this.iMidnightOf.MidnightOfFn(scalarFunction.Execute<DateTime>("GETDATE"))));

			#region CRUD LoadToVariable
			var fs_sroLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_SroCount,"COUNT(sro_num)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "fs_sro",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("start_date >= {0}", CutoffDate),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(fs_sroLoadRequest);
			#endregion  LoadToVariable

			if (sQLUtil.SQLNotEqual(_SroCount, 0) == true)
			{
				//BEGIN

				#region CRUD LoadToVariable
				var fs_sro_laborLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_AvgWorkHrs,$"ISNULL(SUM(hrs_worked) / {variableUtil.GetValue<IntType>(_SroCount)}, 0)"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "fs_sro_labor",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("posted = 1 AND sro_num IN (SELECT sro_num FROM fs_sro WHERE start_date >= {0})", CutoffDate),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				this.appDB.Load(fs_sro_laborLoadRequest);
				#endregion  LoadToVariable

				//END
			}

			#region CRUD LoadResponseWithoutTable
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
				{
					{ "Caption", variableUtil.GetValue<string>(HoursLabel,true)},
					{ "Hours", variableUtil.GetValue<TotalHoursType>(_AvgWorkHrs,true)},
				});

			var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
			Data = nonTableLoadResponse;
			#endregion CRUD LoadResponseWithoutTable

			return (Data, Severity);
		}
		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Homepage_MeanTimetoRepairSp(string AltExtGenSp, int? DaysBefore = 30)
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
