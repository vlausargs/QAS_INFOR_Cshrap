//PROJECT NAME: Material
//CLASS NAME: CLM_TranferLineSummary.cs

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

namespace CSI.Material
{
	public class CLM_TranferLineSummary : ICLM_TranferLineSummary
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IExecuteDynamicSQL iExecuteDynamicSQL;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IDoubleQuote iDoubleQuote;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public CLM_TranferLineSummary(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IDoubleQuote iDoubleQuote,
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
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.iDoubleQuote = iDoubleQuote;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_TranferLineSummarySp(
			string Whse,
			string PMTCodes,
			string FilterString = null,
			string PSiteGroup = null)
		{

			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			try
			{

				ICollectionLoadResponse Data = null;

				StringType _ALTGEN_SpName = DBNull.Value;
				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? Severity = null;
				string Whse2 = null;
				SiteType _Site = DBNull.Value;
				string Site = null;
				string SiteList = null;
				string Infobar = null;
				string SelectionClause = null;
				string FromClause = null;
				string WhereClause = null;
				string AdditionalClause = null;
				ICollectionLoadRequest site_group_crsLoadRequestForCursor = null;
				ICollectionLoadResponse site_group_crsLoadResponseForCursor = null;
				int site_group_crs_CursorFetch_Status = -1;
				int site_group_crs_CursorCounter = -1;
				if (existsChecker.Exists(tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_TranferLineSummarySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
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
						whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_TranferLineSummarySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
					#endregion  LoadToRecord

					#region CRUD InsertByRecords
					foreach (var optional_module1Item in optional_module1LoadResponse.Items)
					{
						optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_TranferLineSummarySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

						var ALTGEN = AltExtGen_CLM_TranferLineSummarySp(ALTGEN_SpName,
							Whse,
							PMTCodes,
							FilterString,
							PSiteGroup);
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
							tableName: "#tv_ALTGEN", 
                            loadForChange: true, 
                            lockingType: LockingType.None,
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
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_TranferLineSummarySp") != null)
				{
					var EXTGEN = AltExtGen_CLM_TranferLineSummarySp("dbo.EXTGEN_CLM_TranferLineSummarySp",
						Whse,
						PMTCodes,
						FilterString,
						PSiteGroup);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				this.sQLExpressionExecutor.Execute(@"CREATE TABLE #tempOutput (
					    Item    NVARCHAR (30) COLLATE DATABASE_DEFAULT,
					    Whse    NVARCHAR (4)  COLLATE DATABASE_DEFAULT,
					    SiteRef NVARCHAR (8)  COLLATE DATABASE_DEFAULT
					)");
				Severity = 0;
				Whse2 = stringUtil.IsNull(
					this.iDoubleQuote.DoubleQuoteFn(Whse),
					"%");
				PMTCodes = stringUtil.IsNull(
					this.iDoubleQuote.DoubleQuoteFn(PMTCodes),
					"");

				#region CRUD LoadArbitrary
				var tempOutputLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "Item", "trnitem.item" },
						{ "Whse", $"CASE WHEN {variableUtil.GetQuotedValue<string>(Whse)} IS NOT NULL THEN dbo.DoubleQuote({variableUtil.GetQuotedValue<string>(Whse)}) WHEN trnitem.qty_req > trnitem.qty_shipped THEN trnitem.from_whse WHEN trnitem.qty_req > trnitem.qty_received THEN trnitem.to_whse END" },
						{ "SiteRef", "trnitem.site_ref" },
					},
					selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
						FROM trnitem_all AS trnitem
						INNER JOIN
						item_all AS item
						ON item.item = trnitem.item
						AND item.site_ref = trnitem.site_ref
						WHERE trnitem.stat <> 'C'
						AND ((trnitem.from_site = trnitem.site_ref
								AND trnitem.from_Whse LIKE {1}
								AND trnitem.qty_req > trnitem.qty_shipped)
							OR (trnitem.to_site = trnitem.site_ref
								AND trnitem.to_Whse LIKE {1}
								AND trnitem.qty_req > trnitem.qty_received))
						AND CHARINDEX(item.p_m_t_code, {0} ) > 0
						ORDER BY item", PMTCodes, Whse2));

				var tempOutputLoadResponse = this.appDB.Load(tempOutputLoadRequest);
				Data = tempOutputLoadResponse;
				#endregion  LoadArbitrary

				#region CRUD InsertByRecords
				var tempOutputInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tempOutput",
					items: tempOutputLoadResponse.Items);

				this.appDB.Insert(tempOutputInsertRequest);
				#endregion InsertByRecords

				SelectionClause = "";
				FromClause = "";
				WhereClause = "";
				AdditionalClause = "";
				SiteList = null;
				if (PSiteGroup != null)
				{
					//BEGIN
					#region Cursor Statement

					#region CRUD LoadToRecord
					site_group_crsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"site_group.site","site_group.site"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "site_group",
						fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
						whereClause: collectionLoadRequestFactory.Clause("site_group.site_group = dbo.DoubleQuote({0})", PSiteGroup),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					#endregion  LoadToRecord

					#endregion Cursor Statement
					site_group_crsLoadResponseForCursor = this.appDB.Load(site_group_crsLoadRequestForCursor);
					site_group_crs_CursorFetch_Status = site_group_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
					site_group_crs_CursorCounter = -1;

					while (sQLUtil.SQLEqual(1, 1) == true)
					{
						//BEGIN
						site_group_crs_CursorCounter++;
						if (site_group_crsLoadResponseForCursor.Items.Count > site_group_crs_CursorCounter)
						{
							Site = site_group_crsLoadResponseForCursor.Items[site_group_crs_CursorCounter].GetValue<string>(0);
						}
						site_group_crs_CursorFetch_Status = (site_group_crs_CursorCounter == site_group_crsLoadResponseForCursor.Items.Count ? -1 : 0);

						if (sQLUtil.SQLNotEqual(site_group_crs_CursorFetch_Status, 0) == true)
						{

							break;

						}
						SiteList = stringUtil.Concat(stringUtil.IsNull(
							SiteList,
							""), "'", Site, "',");
						//END

					}
					//Deallocate Cursor site_group_crs
					WhereClause = stringUtil.Concat(" WHERE SiteRef IN (", stringUtil.Substring(
						SiteList,
						1,
						stringUtil.Len(SiteList) - 1), ")");
					//END

				}
				else
				{
					//BEGIN

					#region CRUD LoadToVariable
					var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_Site,"site"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        maximumRows: 1,
						tableName: "parms",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause(""),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
					if (parmsLoadResponse.Items.Count > 0)
					{
						Site = _Site;
					}
					#endregion  LoadToVariable

					WhereClause = stringUtil.Concat(" WHERE SiteRef = '", Site, "' ");
					//END

				}
				SelectionClause = "SELECT *  ";
				FromClause = " FROM #tempOutput";
				AdditionalClause = " ORDER BY SiteRef";

				this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause VeryLongListType
					,@FromClause VeryLongListType
					,@WhereClause VeryLongListType
					,@AdditionalClause VeryLongListType
					,@FilterString LongListType
					SELECT @SelectionClause AS SelectionClause,
					       @FromClause AS FromClause,
					       @WhereClause AS WhereClause,
					       @AdditionalClause AS AdditionalClause,
					       N'SiteRef' AS KeyColumns,
					       @FilterString AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");

				#region CRUD LoadArbitrary
				var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
						{"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
						{"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereClause)}"},
						{"AdditionalClause",$"{variableUtil.GetQuotedValue<string>(AdditionalClause)}"},
						{"KeyColumns","N'SiteRef'"},
						{"FilterString",$"{variableUtil.GetQuotedValue<string>(FilterString)}"},
					},
					selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

				var DynamicParametersLoadResponse = this.appDB.Load(DynamicParametersLoadRequest);
				Data = DynamicParametersLoadResponse;
				#endregion  LoadArbitrary

				#region CRUD InsertByRecords
				var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
					items: DynamicParametersLoadResponse.Items);

				this.appDB.Insert(DynamicParametersInsertRequest);
				#endregion InsertByRecords

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
				var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
					NeedGetMoreRows: 1,
					Infobar: Infobar);
				Severity = ExecuteDynamicSQL.ReturnCode;
				Data = ExecuteDynamicSQL.Data;
				Infobar = ExecuteDynamicSQL.Infobar;

				#endregion ExecuteMethodCall

				return (Data, Severity);

			}
			finally
			{
				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();
			}
		}
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_TranferLineSummarySp(
			string AltExtGenSp,
			string Whse,
			string PMTCodes,
			string FilterString = null,
			string PSiteGroup = null)
		{
			WhseType _Whse = Whse;
			StringType _PMTCodes = PMTCodes;
			LongListType _FilterString = FilterString;
			SiteGroupType _PSiteGroup = PSiteGroup;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCodes", _PMTCodes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSiteGroup", _PSiteGroup, ParameterDirection.Input);

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
