//PROJECT NAME: Logistics
//CLASS NAME: CLM_SalespersonForecastOpps.cs

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
	public class CLM_SalespersonForecastOpps : ICLM_SalespersonForecastOpps
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
		readonly IDataTypeUtil dataTypeUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public CLM_SalespersonForecastOpps(IApplicationDB appDB,
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
		IDataTypeUtil dataTypeUtil,
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
			this.dataTypeUtil = dataTypeUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public (ICollectionLoadResponse Data,
			int? ReturnCode) 
		CLM_SalespersonForecastOppsSP(string ForecastId,
			int? IncludeDirReports,
			string FilterString)
		{
			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			try
			{
				ICollectionLoadResponse Data = null;

				StringType _ALTGEN_SpName = DBNull.Value;
				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				SlsmanType _SlsPerson = DBNull.Value;
				string SlsPerson = null;
				string SlsPersonReport = null;
				SalesPeriodIdType _SalesPeriodId = DBNull.Value;
				string SalesPeriodId = null;
				int? Severity = null;
				SequenceType _ForcastSeq = DBNull.Value;
				decimal? ForcastSeq = null;
				ICollectionLoadResponse SlsPersonCursorLoadResponseForCursor = null;
				ICollectionLoadStatementRequest SlsPersonCursorLoadStatementRequestForCursor = null;
				int SlsPersonCursor_CursorFetch_Status = -1;
				int SlsPersonCursor_CursorCounter = -1;
				string Infobar = null;
				string SelectionClause = null;
				string FromClause = null;
				string WhereClause = null;
				string AdditionalClause = null;
				string KeyColumns = null;

				if (existsChecker.Exists(
					tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_SalespersonForecastOppsSP' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
						whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_SalespersonForecastOppsSP' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
					#endregion  LoadToRecord

					#region CRUD InsertByRecords
					foreach (var optional_module1Item in optional_module1LoadResponse.Items)
					{
						optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_SalespersonForecastOppsSP", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
						var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
						if (tv_ALTGEN1LoadResponse.Items.Count > 0)
						{
							ALTGEN_SpName = _ALTGEN_SpName;
						}
						#endregion  LoadToVariable

						var ALTGEN = AltExtGen_CLM_SalespersonForecastOppsSP(_ALTGEN_SpName,
							ForecastId,
							IncludeDirReports,
							FilterString);
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
					}
				}

				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_SalespersonForecastOppsSP") != null)
				{
					var EXTGEN = AltExtGen_CLM_SalespersonForecastOppsSP("dbo.EXTGEN_CLM_SalespersonForecastOppsSP",
						ForecastId,
						IncludeDirReports,
						FilterString);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tt_forcasts_opportunity") != null)
				{
					this.sQLExpressionExecutor.Execute("DROP TABLE #tt_forcasts_opportunity ");
				}
				Severity = 0;

				#region CRUD LoadToVariable
				var sales_forecastASsfLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_SlsPerson,"sf.slsman"},
						{_SalesPeriodId,"sf.sales_period_id"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "sales_forecast AS sf",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("sf.forecast_id = {0}", ForecastId),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var sales_forecastASsfLoadResponse = this.appDB.Load(sales_forecastASsfLoadRequest);
				if (sales_forecastASsfLoadResponse.Items.Count > 0)
				{
					SlsPerson = _SlsPerson;
					SalesPeriodId = _SalesPeriodId;
				}
				#endregion  LoadToVariable

				this.sQLExpressionExecutor.Execute(@"SELECT sfo.opp_id AS OppId,
                	        sfo.description AS Description,
                	        sfo.est_value AS EstValue,
                	        sfo.committed_value AS CommittedValue,
                	        sfo.chance_to_close AS ChanceToClose,
                	        sfo.opp_status AS OppStatus,
                	        sfo.opp_stage AS OppStages,
                	        sfo.slsman AS Slsman
                	 INTO   #tt_forcasts_opportunity
                	 FROM   sales_forecast_opportunity AS sfo
                	        LEFT OUTER JOIN
                	        sales_forecast AS sf
                	        ON sf.forecast_id = sfo.forecast_id
                	        LEFT OUTER JOIN
                	        slsman AS sls
                	        ON sls.slsman = sf.slsman
                	        LEFT OUTER JOIN
                	        sales_period AS sp
                	        ON sp.sales_period_id = sf.sales_period_id
                	 WHERE  1 = 0 ");

                this.sQLExpressionExecutor.Execute(@"INSERT
                	 INTO   #tt_forcasts_opportunity
                	 SELECT sfo.opp_id AS OppId,
                	        sfo.description AS Description,
                	        sfo.est_value AS EstValue,
                	        sfo.committed_value AS CommittedValue,
                	        sfo.chance_to_close AS ChanceToClose,
                	        sfo.opp_status AS OppStatus,
                	        sfo.opp_stage AS OppStages,
                	        sfo.slsman AS Slsman
                	FROM sales_forecast_opportunity AS sfo
                	        LEFT OUTER JOIN
                	        sales_forecast AS sf
                	        ON sf.forecast_id = sfo.forecast_id
                	        LEFT OUTER JOIN
                	        slsman AS sls
                	        ON sls.slsman = sf.slsman
                	        LEFT OUTER JOIN
                	        sales_period AS sp
                	        ON sp.sales_period_id = sf.sales_period_id
                	 WHERE  sf.forecast_id = CAST({0} as nvarchar(7)) ", ForecastId);

                #region Cursor Statement

                #region CRUD LoadArbitrary
                SlsPersonCursorLoadStatementRequestForCursor = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"sls.slsman","sls.slsman"},
					},
					selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList  
						FROM sales_forecast AS sf 
						     LEFT OUTER JOIN 
						     slsman AS sls 
						     ON sls.slsman = sf.slsman 
						WHERE sf.status = 'S' 
						      AND sls.slsmangr = {2}  
						      AND {0}  = 1 
						      AND sf.sales_period_id = {1}", IncludeDirReports, SalesPeriodId, SlsPerson));

				#endregion  LoadArbitrary

				#endregion Cursor Statement
				Severity = 0;
				SlsPersonCursorLoadResponseForCursor = this.appDB.Load(SlsPersonCursorLoadStatementRequestForCursor);
				SlsPersonCursor_CursorFetch_Status = SlsPersonCursorLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				SlsPersonCursor_CursorCounter = -1;

				while (sQLUtil.SQLEqual(Severity, 0) == true)
				{
					SlsPersonCursor_CursorCounter++;
					if (SlsPersonCursorLoadResponseForCursor.Items.Count > SlsPersonCursor_CursorCounter)
					{
						SlsPersonReport = SlsPersonCursorLoadResponseForCursor.Items[SlsPersonCursor_CursorCounter].GetValue<string>(0);
					}
					SlsPersonCursor_CursorFetch_Status = (SlsPersonCursor_CursorCounter == SlsPersonCursorLoadResponseForCursor.Items.Count ? -1 : 0);

					if (sQLUtil.SQLEqual(SlsPersonCursor_CursorFetch_Status, -1) == true)
					{
						break;
					}

					#region CRUD LoadArbitrary
					var sales_forecast2LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
						{
							{_ForcastSeq,"MAX(sf.forecast_seq)"},
						},
						selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList  
							FROM sales_forecast AS sf 
							WHERE sf.slsman = {1}  
							      AND sf.status = 'S' 
							      AND {0}  = 1 
							      AND sf.sales_period_id = {2}  
							GROUP BY sf.sales_period_id", IncludeDirReports, SlsPersonReport, SalesPeriodId));

					var sales_forecast2LoadResponse = this.appDB.Load(sales_forecast2LoadRequest);
					ForcastSeq = _ForcastSeq;
					#endregion  LoadArbitrary

					#region CRUD LoadToRecord
					var tt_forcasts_opportunity1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"OppId","sfo.opp_id"},
							{"Description","sfo.description"},
							{"EstValue","sfo.est_value"},
							{"CommittedValue","sfo.committed_value"},
							{"ChanceToClose","sfo.chance_to_close"},
							{"OppStatus","sfo.opp_status"},
							{"OppStages","sfo.opp_stage"},
							{"Slsman","sfo.slsman"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "sales_forecast_opportunity",
						fromClause: collectionLoadRequestFactory.Clause(" AS sfo LEFT OUTER JOIN sales_forecast AS sf ON sf.forecast_id = sfo.forecast_id LEFT OUTER JOIN slsman AS sls ON sls.slsman = sf.slsman LEFT OUTER JOIN sales_period AS sp ON sp.sales_period_id = sf.sales_period_id"),
						whereClause: collectionLoadRequestFactory.Clause("sf.slsman = {1} AND sf.status = 'S' AND {0} = 1 AND sf.sales_period_id = {2} AND {3} = sf.forecast_seq", IncludeDirReports, SlsPersonReport, SalesPeriodId, ForcastSeq),
						orderByClause: collectionLoadRequestFactory.Clause(" forecast_seq DESC"));
					var tt_forcasts_opportunity1LoadResponse = this.appDB.Load(tt_forcasts_opportunity1LoadRequest);
					#endregion  LoadToRecord

					#region CRUD InsertByRecords
					var tt_forcasts_opportunity1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tt_forcasts_opportunity",
						items: tt_forcasts_opportunity1LoadResponse.Items);

					this.appDB.Insert(tt_forcasts_opportunity1InsertRequest);
					#endregion InsertByRecords
				}

				//Deallocate Cursor SlsPersonCursor
				SelectionClause = "";
				FromClause = "";
				WhereClause = "";
				AdditionalClause = "";
				SelectionClause = "SELECT *";
				FromClause = " FROM #tt_forcasts_opportunity";
				WhereClause = "WHERE 1=1";
				AdditionalClause = "ORDER BY OppId";
				KeyColumns = "OppId";

				this.sQLExpressionExecutor.Execute(@"Declare
					 @SelectionClause VeryLongListType
					 ,@FromClause VeryLongListType
					 ,@WhereClause VeryLongListType
					 ,@AdditionalClause VeryLongListType
					 ,@KeyColumns LongListType
					 ,@FilterString NVARCHAR (4000)
					 SELECT @SelectionClause AS SelectionClause,
					        @FromClause AS FromClause,
					        @WhereClause AS WhereClause,
					        @AdditionalClause AS AdditionalClause,
					        @KeyColumns AS KeyColumns,
					        @FilterString AS FilterString
					 INTO   #DynamicParameters
					 WHERE 1 = 2");

				#region CRUD LoadArbitrary
				var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SelectionClause",$"{variableUtil.GetValue<string>(SelectionClause)}"},
						{"FromClause",$"{variableUtil.GetValue<string>(FromClause)}"},
						{"WhereClause",$"{variableUtil.GetValue<string>(WhereClause)}"},
						{"AdditionalClause",$"{variableUtil.GetValue<string>(AdditionalClause)}"},
						{"KeyColumns",$"{variableUtil.GetValue<string>(KeyColumns)}"},
						{"FilterString",$"{variableUtil.GetValue<string>(FilterString)}"},
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
				var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(NeedGetMoreRows: 1
					, Infobar: Infobar);
				Severity = ExecuteDynamicSQL.ReturnCode;
				Data = ExecuteDynamicSQL.Data;
				Infobar = ExecuteDynamicSQL.Infobar;

				#endregion ExecuteMethodCall

				this.sQLExpressionExecutor.Execute("DROP TABLE #tt_forcasts_opportunity ");

				return (Data, Severity);
			}
			finally
			{
				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();
			}
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_SalespersonForecastOppsSP(string AltExtGenSp,
			string ForecastId,
			int? IncludeDirReports,
			string FilterString)
		{
			SalesForecastIdType _ForecastId = ForecastId;
			FlagNyType _IncludeDirReports = IncludeDirReports;
			StringType _FilterString = FilterString;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "ForecastId", _ForecastId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeDirReports", _IncludeDirReports, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);

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
