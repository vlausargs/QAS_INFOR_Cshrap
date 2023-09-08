//PROJECT NAME: Admin
//CLASS NAME: PurgeTable.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;
using System.Diagnostics;
using CSI.Data.SQL;
using CSI.Logger;

namespace CSI.Admin
{
	public class PurgeTable : IPurgeTable
	{
		readonly IApplicationDB appDB;
		
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ILogger logger;
		
		public PurgeTable(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ILogger logger)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.logger = logger;
		}
		
		public (
			int? ReturnCode,
			int? RowAmount,
			int? CanRetry,
			string Infobar)
		PurgeTableSp (
			string TableName,
			string DeleteSite,
			int? ForcePurge = 0,
			int? RowAmount = null,
			int? CanRetry = null,
			string Infobar = null) {

			int? Severity = 0;
			int? ErrorNum = null;
			string ErrorMsg = null;
			IntType _RowCount = DBNull.Value;
			int? RowCount = null;
			IntType _Count = DBNull.Value;
            int? TableRecordCount = null;
			string SiteFilter = null;
			string FKName = null;
			string FKTable = null;
			ICollectionLoadResponse CrsSqlLoadResponseForCursor = null;
			ICollectionLoadStatementRequest CrsSqlLoadStatementRequestForCursor = null;
			int CrsSql_CursorFetch_Status = -1;
			int CrsSql_CursorCounter = -1;

			SiteFilter = "1=0";
			CanRetry = 0;
			RowCount = 0;
			ErrorNum = 0;
			ErrorMsg = null;
			if (!existsChecker.Exists(
			            tableName:"tmp_site_mgmt_table_data",
			            fromClause: collectionLoadRequestFactory.Clause(" AS smt WITH (READUNCOMMITTED)"),
			            whereClause: collectionLoadRequestFactory.Clause("site = {0} AND table_name = {1} AND status = 'P'",DeleteSite,TableName)))
			{ 
				return (Severity = 16 , RowAmount, CanRetry, Infobar); 
			}
			 
            // UPDATE tmp_site_mgmt_table_data SET status = 'I' WHERE site = @DeleteSite AND table_name = @TableName AND status = 'P'
            #region CRUD LoadToRecord
            var tmp_site_mgmt_table_data1LoadRequest = collectionLoadRequestFactory.SQLLoad(
                    columnExpressionByColumnName: new Dictionary<string, string>(){{"status","tmp_site_mgmt_table_data.status"},},
                    loadForChange: true, 
                    lockingType: LockingType.UPDLock,
                    tableName:"tmp_site_mgmt_table_data",
                    fromClause: collectionLoadRequestFactory.Clause(""),
			        whereClause: collectionLoadRequestFactory.Clause("site = {0} AND table_name = {1} AND status = 'P'",DeleteSite,TableName),
			        orderByClause: collectionLoadRequestFactory.Clause(""));
			var tmp_site_mgmt_table_data1LoadResponse = this.appDB.Load(tmp_site_mgmt_table_data1LoadRequest);
			#endregion  LoadToRecord

			#region CRUD UpdateByRecord
			foreach(var tmp_site_mgmt_table_data1Item in tmp_site_mgmt_table_data1LoadResponse.Items){
				tmp_site_mgmt_table_data1Item.SetValue<string>("status", "I");
			};
			
			var tmp_site_mgmt_table_data1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "tmp_site_mgmt_table_data",
			items: tmp_site_mgmt_table_data1LoadResponse.Items);
			
			this.appDB.Update(tmp_site_mgmt_table_data1RequestUpdate);
            #endregion UpdateByRecord

            // SET SiteFilter
            #region CRUD LoadToRecord
            var columnsLoadRequest = collectionLoadRequestFactory.SQLLoad(
                    columnExpressionByColumnName: new Dictionary<string, string>(){{"isc.COLUMN_NAME","isc.COLUMN_NAME"},},
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "INFORMATION_SCHEMA.columns",
                    fromClause: collectionLoadRequestFactory.Clause(" AS isc INNER JOIN INFORMATION_SCHEMA.tables AS ist ON ist.table_name = isc.table_name"),
                    whereClause: collectionLoadRequestFactory.Clause("ist.TABLE_TYPE = N'Base Table' AND isc.DOMAIN_NAME LIKE N'SiteType' AND ist.table_name = {0}", TableName),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
            var columnsLoadResponse = this.appDB.Load(columnsLoadRequest);

            foreach (var colItem in columnsLoadResponse.Items)
            {
                SiteFilter = SiteFilter + $" OR {colItem.GetValue<string>("isc.COLUMN_NAME")} = '{DeleteSite}'";
            }
            #endregion  LoadToRecord

            // Count record per filter.
            #region CRUD LoadToVariable
            var TableNameLoadRequest = collectionLoadRequestFactory.SQLLoad(
                    columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>(){{_RowCount,$"COUNT(*)"},},
			        loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName:TableName,
			        fromClause: collectionLoadRequestFactory.Clause(""),
			        whereClause: collectionLoadRequestFactory.Clause(SiteFilter),
			        orderByClause: collectionLoadRequestFactory.Clause(""));
			var TableNameLoadResponse = this.appDB.Load(TableNameLoadRequest);
			if(TableNameLoadResponse.Items.Count > 0)
			{
				RowCount = _RowCount;
			}
			#endregion  LoadToVariable
			
			if (ForcePurge == 1)
			{
				//BEGIN
				#region Cursor Statement
				
				#region CRUD LoadArbitrary
				CrsSqlLoadStatementRequestForCursor = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"FKName","fk.name"},
					{"FKTable",$"OBJECT_NAME(fkc.parent_object_id)"},
				},
				selectStatement: collectionLoadRequestFactory.Clause("SELECT Distinct @selectList  "
				+ "FROM sys.foreign_keys AS fk "
				+ "     INNER JOIN "
				+ "     sys.foreign_key_columns AS fkc "
				+ "     ON fk.object_id = fkc.constraint_object_id "
				+ "     INNER JOIN "
				+ "     sys.tables AS tbl "
				+ "     ON tbl.[object_id] = fkc.referenced_object_id "
				+ "WHERE tbl.[name] = {0}", TableName));
				
				#endregion  LoadArbitrary
				
				#endregion Cursor Statement
				CrsSqlLoadResponseForCursor = this.appDB.Load(CrsSqlLoadStatementRequestForCursor);
				CrsSql_CursorFetch_Status = CrsSqlLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				CrsSql_CursorCounter = -1;
				
				while (true)
				{
					CrsSql_CursorCounter++;
					if(CrsSqlLoadResponseForCursor.Items.Count > CrsSql_CursorCounter)
					{
						FKName = CrsSqlLoadResponseForCursor.Items[CrsSql_CursorCounter].GetValue<string>(0);
						FKTable = CrsSqlLoadResponseForCursor.Items[CrsSql_CursorCounter].GetValue<string>(1);
					}
					if (CrsSql_CursorCounter == CrsSqlLoadResponseForCursor.Items.Count)
					{
						break;
					}
					this.sQLExpressionExecutor.Execute($"ALTER TABLE {FKTable} NOCHECK CONSTRAINT {FKName}");
				}
			}

			logger.SQL("IDORunTime", $"{101}");
			try
			{
				this.sQLExpressionExecutor.Execute($"ALTER TABLE {TableName} DISABLE TRIGGER ALL");
                this.sQLExpressionExecutor.Execute($"DELETE FROM {TableName} WITH(TABLOCK, HOLDLOCK) WHERE {SiteFilter}");
                this.sQLExpressionExecutor.Execute($"ALTER TABLE {TableName} ENABLE TRIGGER ALL");
			}
			catch(Exception ex)
			{
				DbException dbException = (DbException)appDB.GetDbException(ex);
				ErrorNum = (int?)(dbException.ErrorNumber);
                ErrorMsg = dbException.ErrorMessage;

			    logger.SQL("IDORunTime", $"{ErrorMsg}");
			}
             
            logger.SQL("IDORunTime", $"{127}"); 
			var TableName2LoadRequest = collectionLoadRequestFactory.SQLLoad(
                    columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>(){{_RowCount,$"COUNT(*)"},},
			        loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName:TableName,
			        fromClause: collectionLoadRequestFactory.Clause(""),
			        whereClause: collectionLoadRequestFactory.Clause(SiteFilter),
			        orderByClause: collectionLoadRequestFactory.Clause(""));
			var TableName2LoadResponse = this.appDB.Load(TableName2LoadRequest);
			if(TableName2LoadResponse.Items.Count > 0)
			{
                TableRecordCount = _RowCount;
			}

            if (TableRecordCount < RowCount)
            {
                CanRetry = 1;
            }

            if (TableRecordCount == 0)
			{
				#region CRUD LoadToRecord
				var tmp_site_mgmt_table_data2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"col0",$"1"},
				},
                loadForChange: true, 
                lockingType: LockingType.None,
                tableName:"tmp_site_mgmt_table_data",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("site = {0} AND table_name = {1}", DeleteSite, TableName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
				var tmp_site_mgmt_table_data2LoadResponse = this.appDB.Load(tmp_site_mgmt_table_data2LoadRequest);
				#endregion  LoadToRecord
				
				
				#region CRUD DeleteByRecord
				var tmp_site_mgmt_table_data2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "tmp_site_mgmt_table_data",
				items: tmp_site_mgmt_table_data2LoadResponse.Items);
				this.appDB.Delete(tmp_site_mgmt_table_data2DeleteRequest);
				#endregion DeleteByRecord
			}

			if (ErrorNum != 0)
			{
				#region CRUD LoadToRecord
				var tmp_site_mgmt_table_data3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"status","tmp_site_mgmt_table_data.status"},
					{"error_msg","tmp_site_mgmt_table_data.error_msg"},
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName:"tmp_site_mgmt_table_data",
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("site = {0} AND table_name = {1}",DeleteSite,TableName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
				var tmp_site_mgmt_table_data3LoadResponse = this.appDB.Load(tmp_site_mgmt_table_data3LoadRequest);
				#endregion  LoadToRecord

				#region CRUD UpdateByRecord
				foreach(var tmp_site_mgmt_table_data3Item in tmp_site_mgmt_table_data3LoadResponse.Items){
					tmp_site_mgmt_table_data3Item.SetValue<string>("status", "F");
					tmp_site_mgmt_table_data3Item.SetValue<string>("error_msg", ErrorMsg);
				};
				
				var tmp_site_mgmt_table_data3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "tmp_site_mgmt_table_data",
				items: tmp_site_mgmt_table_data3LoadResponse.Items);
				
				this.appDB.Update(tmp_site_mgmt_table_data3RequestUpdate);
				#endregion UpdateByRecord
			}

		logger.SQL("IDORunTime", $"{ErrorMsg}");

			if (ForcePurge == 1)
			{ 
                CrsSql_CursorCounter = -1;
                while (true)
                {
                    CrsSql_CursorCounter++;
                    if (CrsSqlLoadResponseForCursor.Items.Count > CrsSql_CursorCounter)
                    {
                        FKName = CrsSqlLoadResponseForCursor.Items[CrsSql_CursorCounter].GetValue<string>(0);
                        FKTable = CrsSqlLoadResponseForCursor.Items[CrsSql_CursorCounter].GetValue<string>(1);
                    }
                    if (CrsSql_CursorCounter == CrsSqlLoadResponseForCursor.Items.Count)
                    {
                        break;
                    }
                    this.sQLExpressionExecutor.Execute($"ALTER TABLE {FKTable} CHECK CONSTRAINT {FKName}");
                }
            }

			return (Severity, TableRecordCount, CanRetry, Infobar);
		}
		
	}
}
