//PROJECT NAME: Logistics
//CLASS NAME: Home_Accounts.cs

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
	public class Home_Accounts : IHome_Accounts
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IBuildXMLFilterString iBuildXMLFilterString;
		readonly IExecuteDynamicSQL iExecuteDynamicSQL;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IDoubleQuote iDoubleQuote;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly IDayEndOf iDayEndOf;
		readonly ISQLValueComparerUtil sQLUtil;

		public Home_Accounts(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IBuildXMLFilterString iBuildXMLFilterString,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IDoubleQuote iDoubleQuote,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			IDayEndOf iDayEndOf,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iBuildXMLFilterString = iBuildXMLFilterString;
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iDoubleQuote = iDoubleQuote;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.iDayEndOf = iDayEndOf;
			this.sQLUtil = sQLUtil;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) Home_AccountsSp(string FilterString = null,
			DateTime? StartDate = null,
			DateTime? EndDate = null,
			string SiteGroup = null)
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
				string Infobar = null;
				string SelectionClause = null;
				string FromClause = null;
				string WhereClause = null;
				string AdditionalClause = null;
				SiteType _Site = DBNull.Value;
				string Site = null;

				if (existsChecker.Exists(
					tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_AccountsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
						whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Home_AccountsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
					#endregion  LoadToRecord

					#region CRUD InsertByRecords
					foreach (var optional_module1Item in optional_module1LoadResponse.Items)
					{
						optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Home_AccountsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
						ALTGEN_SpName = _ALTGEN_SpName;
						#endregion  LoadToVariable

						var ALTGEN = AltExtGen_Home_AccountsSp(_ALTGEN_SpName,
							FilterString,
							StartDate,
							EndDate,
							SiteGroup);
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
						//END
					}
					//END
				}

				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_AccountsSp") != null)
				{
					var EXTGEN = AltExtGen_Home_AccountsSp("dbo.EXTGEN_Home_AccountsSp",
						FilterString,
						StartDate,
						EndDate,
						SiteGroup);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @journals TABLE (
						id JournalIdType PRIMARY KEY);
					SELECT * into #tv_journals from @journals 
					ALTER TABLE #tv_journals ADD PRIMARY KEY (id) ");

				this.sQLExpressionExecutor.Execute(@"CREATE TABLE #accounts (
						LedgerAcct            NVARCHAR (12) COLLATE DATABASE_DEFAULT,
						LedgerAcctDescription NVARCHAR (60) COLLATE DATABASE_DEFAULT,
						SiteRef               NVARCHAR (8)  COLLATE DATABASE_DEFAULT
					) ");
				Severity = 0;

				#region CRUD LoadToRecord
				var journalsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"id","id"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "jour_hdr",
					fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
					whereClause: collectionLoadRequestFactory.Clause("type = N'U' OR id = N'General'"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var journalsLoadResponse = this.appDB.Load(journalsLoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				var journalsInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_journals",
					items: journalsLoadResponse.Items);

				this.appDB.Insert(journalsInsertRequest);
				#endregion InsertByRecords

				StartDate = convertToUtil.ToDateTime(this.iDoubleQuote.DoubleQuoteFn(convertToUtil.ToString(StartDate)));
				EndDate = convertToUtil.ToDateTime(this.iDoubleQuote.DoubleQuoteFn(convertToUtil.ToString(EndDate)));
				StartDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(StartDate));
				EndDate = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(EndDate));

				#region CRUD LoadArbitrary
				var accountsLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{ "LedgerAcct", "acct" },
						{ "SiteRef", "site_ref" },
					},
					selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList  
						FROM ledger_all AS ledger WITH (READUNCOMMITTED) 
						     INNER JOIN 
						     #tv_journals AS j 
						     ON j.id = ledger.from_id 
						WHERE ledger.trans_date BETWEEN {0}  AND {1}", StartDate, EndDate));

				var accountsLoadResponse = this.appDB.Load(accountsLoadRequest);
				Data = accountsLoadResponse;
				#endregion  LoadArbitrary

				#region CRUD InsertByRecords
				var accountsInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#accounts",
					items: accountsLoadResponse.Items);

				this.appDB.Insert(accountsInsertRequest);
				#endregion InsertByRecords

				this.sQLExpressionExecutor.Execute("ALTER TABLE #accounts ADD tempTableId INT IDENTITY");

				#region CRUD LoadToRecord
				var accounts1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"LedgerAcctDescription","#accounts.LedgerAcctDescription"},
						{"u0","chart.description"},
					}, 
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    tableName: "#accounts",
                    fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN chart_all AS chart WITH (READUNCOMMITTED) ON chart.acct = #accounts.LedgerAcct"),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var accounts1LoadResponse = this.appDB.Load(accounts1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD UpdateByRecord
				foreach (var accounts1Item in accounts1LoadResponse.Items)
				{
					accounts1Item.SetValue<string>("LedgerAcctDescription", accounts1Item.GetValue<string>("u0"));
				};

				var accounts1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#accounts",
					items: accounts1LoadResponse.Items);

				this.appDB.Update(accounts1RequestUpdate);
				#endregion UpdateByRecord

				this.sQLExpressionExecutor.Execute("ALTER TABLE #accounts DROP COLUMN tempTableId");
				SelectionClause = "";
				FromClause = "";
				WhereClause = "";
				AdditionalClause = "";
				SelectionClause = "SELECT *  ";
				FromClause = " FROM #accounts";
				if (SiteGroup == null)
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
					this.appDB.Load(parmsLoadRequest);
					Site = _Site;
					#endregion  LoadToVariable

					WhereClause = stringUtil.Concat(" WHERE SiteRef = '", Site, "'");
					//END
				}
				else
				{
					//BEGIN
					WhereClause = " WHERE SiteRef IN (select site from site_group where site_group.site_group = @SiteGroup )";

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: BuildXMLFilterStringSp
					var BuildXMLFilterString = this.iBuildXMLFilterString.BuildXMLFilterStringSp(PropertyName: "SiteGroup"
						, Value: SiteGroup
						, DataType: "SiteGroupType"
						, NameInParmList: "@SiteGroup"
						, IsPropertyInWhereClause: 0
						, XmlFilterString: FilterString);
					Severity = BuildXMLFilterString.ReturnCode;
					FilterString = BuildXMLFilterString.XmlFilterString;

					#endregion ExecuteMethodCall
					//END
				}
				AdditionalClause = " ORDER BY SiteRef, LedgerAcct";

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
					        N'SiteRef, LedgerAcct' AS KeyColumns,
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
						{"KeyColumns","N'SiteRef, LedgerAcct'"},
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

				return (Data, Severity);
			}
			finally
			{
				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();
			}
		}
		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_AccountsSp(string AltExtGenSp,
			string FilterString = null,
			DateTime? StartDate = null,
			DateTime? EndDate = null,
			string SiteGroup = null)
		{
			LongListType _FilterString = FilterString;
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			SiteGroupType _SiteGroup = SiteGroup;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);

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
