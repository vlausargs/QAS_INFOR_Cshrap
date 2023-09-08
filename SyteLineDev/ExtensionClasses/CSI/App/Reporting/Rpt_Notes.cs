//PROJECT NAME: Reporting
//CLASS NAME: Rpt_Notes.cs

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
using CSI.CRUD.Reporting;

namespace CSI.Reporting
{
	public class Rpt_Notes : IRpt_Notes
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		ICollectionInsertRequestFactory collectionInsertRequestFactory;
		ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		ICollectionLoadRequestFactory collectionLoadRequestFactory;
		ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
		IExistsChecker existsChecker;
		IStringUtil stringUtil;
		ISQLValueComparerUtil sQLUtil;
		IRpt_NotesCRUD rpt_NotesCRUD;

		public Rpt_Notes(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
		ICollectionInsertRequestFactory collectionInsertRequestFactory,
		ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
		ICollectionLoadRequestFactory collectionLoadRequestFactory,
		ICollectionLoadResponseUtil collectionLoadResponseUtil,
		ISQLExpressionExecutor sQLExpressionExecutor,
		IScalarFunction scalarFunction,
		IExistsChecker existsChecker,
		IStringUtil stringUtil,
		ISQLValueComparerUtil sQLUtil,
		IRpt_NotesCRUD rpt_NotesCRUD)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.rpt_NotesCRUD = rpt_NotesCRUD;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_NotesSp (Guid? pRefRowPointer = null, int? pShowExternal = 1, int? pShowInternal = 1)
		{
			ICollectionLoadResponse Data = null;
			
			StringType _ALTGEN_SpName = DBNull.Value;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			if (existsChecker.Exists(
				tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_NotesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_NotesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord
				
				#region CRUD InsertByRecords
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Rpt_NotesSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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
					//BEGIN
					
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
					
					var ALTGEN = AltExtGen_Rpt_NotesSp (_ALTGEN_SpName,
						pRefRowPointer,
						pShowExternal,
						pShowInternal);
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
					//END
				}
				//END
			}

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_NotesSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_NotesSp("dbo.EXTGEN_Rpt_NotesSp",
					pRefRowPointer,
					pShowExternal,
					pShowInternal);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			Severity = 0;

			#region CRUD LoadArbitrary
			var ReportNotesViewLoadResponse = rpt_NotesCRUD.Load(pRefRowPointer, pShowExternal, pShowInternal);
			Data = ReportNotesViewLoadResponse;
			#endregion  LoadArbitrary
			
			return (Data, Severity);
			
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Rpt_NotesSp(string AltExtGenSp,
			Guid? pRefRowPointer = null,
			int? pShowExternal = 1,
			int? pShowInternal = 1)
		{
			RowPointerType _pRefRowPointer = pRefRowPointer;
			ListYesNoType _pShowExternal = pShowExternal;
			ListYesNoType _pShowInternal = pShowInternal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "pRefRowPointer", _pRefRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowExternal", _pShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowInternal", _pShowInternal, ParameterDirection.Input);
				
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
