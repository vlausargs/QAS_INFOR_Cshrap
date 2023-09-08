//PROJECT NAME: Finance
//CLASS NAME: PerUnit.cs

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
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class PerUnit : IPerUnit
	{
		readonly IApplicationDB appDB;

		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ITruncateTable iTruncateTable;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IHighAnyInt iHighAnyInt;
		readonly IStringUtil stringUtil;
		readonly ILowAnyInt iLowAnyInt;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;

		public PerUnit(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ITruncateTable iTruncateTable,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IHighAnyInt iHighAnyInt,
			IStringUtil stringUtil,
			ILowAnyInt iLowAnyInt,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.iTruncateTable = iTruncateTable;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iHighAnyInt = iHighAnyInt;
			this.stringUtil = stringUtil;
			this.iLowAnyInt = iLowAnyInt;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}

		public (
			int? ReturnCode,
			string Infobar)
		PerUnitSp(
			int? StartingSortMethod,
			int? EndingSortMethod,
			string Infobar)
		{

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			int? Counter = null;
			int? CanTruncate = null;
			string PerSortSf1 = null;
			string PerSortSf2 = null;
			string PerSortSf3 = null;
			string PerSortSf4 = null;
			string PerSortSf5 = null;
			int? PerSortSortMethod = null;
			int? PerSortFldPos__1 = null;
			int? PerSortFldPos__2 = null;
			int? PerSortFldPos__3 = null;
			int? PerSortFldPos__4 = null;
			int? PerSortFldPos__5 = null;
			SiteType _Site = DBNull.Value;
			string Site = null;
			ICollectionLoadRequest per_sortCrsLoadRequestForCursor = null;
			ICollectionLoadResponse per_sortCrsLoadResponseForCursor = null;
			int per_sortCrs_CursorFetch_Status = -1;
			int per_sortCrs_CursorCounter = -1;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('PerUnitSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
			)
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('PerUnitSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("PerUnitSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""))
				)
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
					var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
					if (tv_ALTGEN1LoadResponse.Items.Count > 0)
					{
						ALTGEN_SpName = _ALTGEN_SpName;
					}
					#endregion  LoadToVariable

					var ALTGEN = AltExtGen_PerUnitSp(ALTGEN_SpName,
						StartingSortMethod,
						EndingSortMethod,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

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
					//END

				}
				//END

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_PerUnitSp") != null)
			{
				var EXTGEN = AltExtGen_PerUnitSp("dbo.EXTGEN_PerUnitSp",
					StartingSortMethod,
					EndingSortMethod,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @per_unit TABLE (
				    sort_method TINYINT       ,
				    hierarchy   NVARCHAR (255),
				    acct        NVARCHAR (12) ,
				    acct_unit1  NVARCHAR (4)  ,
				    acct_unit2  NVARCHAR (4)  ,
				    acct_unit3  NVARCHAR (4)  ,
				    acct_unit4  NVARCHAR (4)  );
				SELECT * into #tv_per_unit from @per_unit");
			Severity = 0;
			StartingSortMethod = convertToUtil.ToInt32(stringUtil.IsNull(
				StartingSortMethod,
				this.iLowAnyInt.LowAnyIntFn("SortMethodType")));
			EndingSortMethod = convertToUtil.ToInt32(stringUtil.IsNull(
				EndingSortMethod,
				this.iHighAnyInt.HighAnyIntFn("SortMethodType")));
			CanTruncate = 0;
			if (sQLUtil.SQLBool(sQLUtil.SQLLessThan(StartingSortMethod, 2)))
			{
				if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(tableName: "per_unit",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("per_unit.sort_method > {0}", EndingSortMethod))
					)))
				{
					CanTruncate = 1;

				}

			}
			if (sQLUtil.SQLEqual(CanTruncate, 0) == true)
			{
				/*Needs to load at least one column from the table: per_unit for delete, Loads the record based on its where and from clause, then deletes it by record.*/
				#region CRUD LoadToRecord
				var per_unit1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"per_unit.sort_method","per_unit.sort_method"},
					},
                    loadForChange: true, 
                    lockingType: LockingType.None,
                    tableName: "per_unit",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("per_unit.sort_method BETWEEN {0} AND {1}", StartingSortMethod, EndingSortMethod),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var per_unit1LoadResponse = this.appDB.Load(per_unit1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD DeleteByRecord
				var per_unit1DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "per_unit",
					items: per_unit1LoadResponse.Items);
				this.appDB.Delete(per_unit1DeleteRequest);
				#endregion DeleteByRecord

			}
			else
			{
				//BEGIN

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: TruncateTableSp
				var TruncateTable = this.iTruncateTable.TruncateTableSp(TableName: "per_unit");

				#endregion ExecuteMethodCall

				#region CRUD LoadToVariable
				var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_Site,"site"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "parms",
					fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
				if (parmsLoadResponse.Items.Count > 0)
				{
					Site = _Site;
				}
				#endregion  LoadToVariable

				/*Needs to load at least one column from the table: per_unit_all for delete, Loads the record based on its where and from clause, then deletes it by record.*/
				#region CRUD LoadToRecord
				var per_unit_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"site_ref","site_ref"},
					},
                    loadForChange: true, 
                    lockingType: LockingType.None,
                    tableName: "per_unit_all",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("site_ref = {0}", Site),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var per_unit_allLoadResponse = this.appDB.Load(per_unit_allLoadRequest);
				#endregion  LoadToRecord

				#region CRUD DeleteByRecord
				var per_unit_allDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "per_unit_all",
					items: per_unit_allLoadResponse.Items);
				this.appDB.Delete(per_unit_allDeleteRequest);
				#endregion DeleteByRecord

				//END

			}
			#region Cursor Statement

			#region CRUD LoadToRecord
			per_sortCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"sf1","per_sort.sf1"},
					{"col0","CAST (NULL AS NVARCHAR)"},
					{"col1","CAST (NULL AS NVARCHAR)"},
					{"col2","CAST (NULL AS NVARCHAR)"},
					{"col3","CAST (NULL AS NVARCHAR)"},
					{"sort_method","per_sort.sort_method"},
					{"fld_pos##1","per_sort.fld_pos##1"},
					{"fld_pos##2","per_sort.fld_pos##2"},
					{"fld_pos##3","per_sort.fld_pos##3"},
					{"fld_pos##4","per_sort.fld_pos##4"},
					{"fld_pos##5","per_sort.fld_pos##5"},
					{"u0","per_sort.sf2"},
					{"u1","per_sort.sf3"},
					{"u2","per_sort.sf4"},
					{"u3","per_sort.sf5"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "per_sort",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("per_sort.sort_method BETWEEN {0} AND {1} AND per_sort.index_active = 1", StartingSortMethod, EndingSortMethod),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			#endregion  LoadToRecord

			#endregion Cursor Statement
			per_sortCrsLoadResponseForCursor = this.appDB.Load(per_sortCrsLoadRequestForCursor);
			foreach (var per_sortItem in per_sortCrsLoadResponseForCursor.Items)
			{
				per_sortItem.SetValue<string>("sf1", per_sortItem.GetValue<string>("sf1"));
				per_sortItem.SetValue<string>("col0", stringUtil.IsNull(
					per_sortItem.GetValue<string>("u0"),
					""));
				per_sortItem.SetValue<string>("col1", stringUtil.IsNull(
					per_sortItem.GetValue<string>("u1"),
					""));
				per_sortItem.SetValue<string>("col2", stringUtil.IsNull(
					per_sortItem.GetValue<string>("u2"),
					""));
				per_sortItem.SetValue<string>("col3", stringUtil.IsNull(
					per_sortItem.GetValue<string>("u3"),
					""));
				per_sortItem.SetValue<int?>("sort_method", per_sortItem.GetValue<int?>("sort_method"));
				per_sortItem.SetValue<int?>("fld_pos##1", per_sortItem.GetValue<int?>("fld_pos##1"));
				per_sortItem.SetValue<int?>("fld_pos##2", per_sortItem.GetValue<int?>("fld_pos##2"));
				per_sortItem.SetValue<int?>("fld_pos##3", per_sortItem.GetValue<int?>("fld_pos##3"));
				per_sortItem.SetValue<int?>("fld_pos##4", per_sortItem.GetValue<int?>("fld_pos##4"));
				per_sortItem.SetValue<int?>("fld_pos##5", per_sortItem.GetValue<int?>("fld_pos##5"));
			};

			per_sortCrs_CursorFetch_Status = per_sortCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			per_sortCrs_CursorCounter = -1;

			while (sQLUtil.SQLEqual(Severity, 0) == true)
			{
				//BEGIN
				per_sortCrs_CursorCounter++;
				if (per_sortCrsLoadResponseForCursor.Items.Count > per_sortCrs_CursorCounter)
				{
					PerSortSf1 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<string>(0);
					PerSortSf2 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<string>(1);
					PerSortSf3 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<string>(2);
					PerSortSf4 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<string>(3);
					PerSortSf5 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<string>(4);
					PerSortSortMethod = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<int?>(5);
					PerSortFldPos__1 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<int?>(6);
					PerSortFldPos__2 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<int?>(7);
					PerSortFldPos__3 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<int?>(8);
					PerSortFldPos__4 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<int?>(9);
					PerSortFldPos__5 = per_sortCrsLoadResponseForCursor.Items[per_sortCrs_CursorCounter].GetValue<int?>(10);
				}
				per_sortCrs_CursorFetch_Status = (per_sortCrs_CursorCounter == per_sortCrsLoadResponseForCursor.Items.Count ? -1 : 0);

				if (sQLUtil.SQLEqual(per_sortCrs_CursorFetch_Status, -1) == true)
				{

					break;

				}
				UnionUtil unionTable = new UnionUtil(UnionType.Union);

				#region CRUD LoadArbitrary
				var tv_per_unit1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "sort_method", $"{PerSortSortMethod}" },
						{ "hierarchy", "isnull(pertot.hierarchy, '')" },
						{ "acct", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<string>(PerSortSf1)} = 'A' THEN sf1 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf2)} = 'A' THEN sf2 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf3)} = 'A' THEN sf3 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf4)} = 'A' THEN sf4 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf5)} = 'A' THEN sf5 ELSE '' END, '')" },
						{ "acct_unit1", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<string>(PerSortSf1)} = '1' THEN sf1 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf2)} = '1' THEN sf2 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf3)} = '1' THEN sf3 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf4)} = '1' THEN sf4 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf5)} = '1' THEN sf5 ELSE '' END, '')" },
						{ "acct_unit2", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<string>(PerSortSf1)} = '2' THEN sf1 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf2)} = '2' THEN sf2 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf3)} = '2' THEN sf3 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf4)} = '2' THEN sf4 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf5)} = '2' THEN sf5 ELSE '' END, '')" },
						{ "acct_unit3", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<string>(PerSortSf1)} = '3' THEN sf1 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf2)} = '3' THEN sf2 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf3)} = '3' THEN sf3 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf4)} = '3' THEN sf4 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf5)} = '3' THEN sf5 ELSE '' END, '')" },
						{ "acct_unit4", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<string>(PerSortSf1)} = '4' THEN sf1 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf2)} = '4' THEN sf2 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf3)} = '4' THEN sf3 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf4)} = '4' THEN sf4 WHEN {variableUtil.GetQuotedValue<string>(PerSortSf5)} = '4' THEN sf5 ELSE '' END, '')" },
					},
					selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM pertot
						WHERE sort_method = {0}", PerSortSortMethod));

				var tv_per_unit1LoadResponse = this.appDB.Load(tv_per_unit1LoadRequest);
				#endregion  LoadArbitrary

				unionTable.Add(tv_per_unit1LoadResponse);

				#region CRUD LoadArbitrary
				var tv_per_unit2LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "sort_method", $"{PerSortSortMethod}" },
						{ "hierarchy", "isnull(chart_bp.hierarchy, '')" },
						{ "acct", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<int?>(PerSortFldPos__1)} > 0 THEN chart.acct ELSE '' END, '')" },
						{ "acct_unit1", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<int?>(PerSortFldPos__2)} > 0 THEN chart_bp.acct_unit1 ELSE '' END, '')" },
						{ "acct_unit2", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<int?>(PerSortFldPos__3)} > 0 THEN chart_bp.acct_unit2 ELSE '' END, '')" },
						{ "acct_unit3", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<int?>(PerSortFldPos__4)} > 0 THEN chart_bp.acct_unit3 ELSE '' END, '')" },
						{ "acct_unit4", $"isnull(CASE WHEN {variableUtil.GetQuotedValue<int?>(PerSortFldPos__5)} > 0 THEN chart_bp.acct_unit4 ELSE '' END, '')" },
					},
					selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM chart_bp
						INNER JOIN
						chart WITH (READUNCOMMITTED)
						ON chart.acct = chart_bp.acct"));

				var tv_per_unit2LoadResponse = this.appDB.Load(tv_per_unit2LoadRequest);
				#endregion  LoadArbitrary

				unionTable.Add(tv_per_unit2LoadResponse);
				var unionTableResult = unionTable.Process();

				#region CRUD InsertByRecords
				var unionTableResultInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_per_unit",
					items: unionTableResult.Items);

				this.appDB.Insert(unionTableResultInsertRequest);
				#endregion InsertByRecords

				//END

			}
			//Deallocate Cursor per_sortCrs

			#region CRUD LoadToRecord
			var per_unit2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"sort_method","#tv_per_unit.sort_method"},
					{"hierarchy","#tv_per_unit.hierarchy"},
					{"acct","#tv_per_unit.acct"},
					{"acct_unit1","#tv_per_unit.acct_unit1"},
					{"acct_unit2","#tv_per_unit.acct_unit2"},
					{"acct_unit3","#tv_per_unit.acct_unit3"},
					{"acct_unit4","#tv_per_unit.acct_unit4"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#tv_per_unit",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var per_unit2LoadResponse = this.appDB.Load(per_unit2LoadRequest);
			#endregion  LoadToRecord

			#region CRUD InsertByRecords
			var per_unit2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "per_unit",
				items: per_unit2LoadResponse.Items);

			this.appDB.Insert(per_unit2InsertRequest);
			#endregion InsertByRecords

			Counter = per_unit2LoadResponse.Items.Count;

			#region CRUD ExecuteMethodCall

			var MsgApp = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "I=#Processed",
				Parm1: convertToUtil.ToString(Counter),
				Parm2: "@per_unit");
			Infobar = MsgApp.Infobar;

			#endregion ExecuteMethodCall

			return (Severity, Infobar);

		}
		public (int? ReturnCode,
			string Infobar)
		AltExtGen_PerUnitSp(
			string AltExtGenSp,
			int? StartingSortMethod,
			int? EndingSortMethod,
			string Infobar)
		{
			SortMethodType _StartingSortMethod = StartingSortMethod;
			SortMethodType _EndingSortMethod = EndingSortMethod;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "StartingSortMethod", _StartingSortMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingSortMethod", _EndingSortMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}

	}
}
