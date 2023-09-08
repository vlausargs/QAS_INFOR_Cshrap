//PROJECT NAME: Admin
//CLASS NAME: GetSiteTableToPurge.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;

namespace CSI.Admin
{
	public class GetSiteTableToPurge : IGetSiteTableToPurge
	{
		readonly IApplicationDB appDB;
		
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IVariableUtil variableUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		
		public GetSiteTableToPurge(IApplicationDB appDB,
		ICollectionLoadRequestFactory collectionLoadRequestFactory,
		IVariableUtil variableUtil,
		ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.variableUtil = variableUtil;
			this.sQLUtil = sQLUtil;
		}
		
		public (int? ReturnCode,
		string TableName,
		int? OriginRowAmount,
		int? PendingTableRemaining) GetSiteTableToPurgeSp (string DeleteSite,
		string TableName,
		int? OriginRowAmount,
		int? PendingTableRemaining)
		{	
			TableNameType _TableName = TableName;
			IntType _PendingTableRemaining = PendingTableRemaining;
			
			int? Severity = 0;
			
			LongListType _SiteFilter = DBNull.Value;
			string SiteFilter = null;
			IntType _RowCount = DBNull.Value;
			TableName = null;
			OriginRowAmount = 0;
			PendingTableRemaining = 0;
			SiteFilter = "1=0";
			
			#region CRUD LoadToVariable
			var tmp_site_mgmt_table_dataLoadRequest = collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>(){{_TableName,$"table_name"},},
			    loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
			    tableName:"tmp_site_mgmt_table_data",
			    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
		        whereClause: collectionLoadRequestFactory.Clause("site = {0} AND status = 'P'", DeleteSite), // and table_name = 'coitem_mst'
                orderByClause: collectionLoadRequestFactory.Clause(""));
			var tmp_site_mgmt_table_dataLoadResponse = this.appDB.Load(tmp_site_mgmt_table_dataLoadRequest);
			if(tmp_site_mgmt_table_dataLoadResponse.Items.Count > 0)
			{
				TableName = _TableName;
			}
			#endregion  LoadToVariable
			
			if (TableName!= null)
			{
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
                #endregion  LoadToRecord

                foreach (var colItem in columnsLoadResponse.Items)
                {
                    SiteFilter = SiteFilter + $" OR {colItem.GetValue<string>("isc.COLUMN_NAME")} = '{DeleteSite}'";
                }
			}

            if (SiteFilter != "1=0")
			{
				#region CRUD LoadToVariable
				var TableNameLoadRequest = collectionLoadRequestFactory.SQLLoad(
                    columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>(){{_RowCount,$"COUNT(1)"},},
				    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName:TableName,
				    fromClause: collectionLoadRequestFactory.Clause(""),
				    whereClause: collectionLoadRequestFactory.Clause(SiteFilter),
				    orderByClause: collectionLoadRequestFactory.Clause(""));
				var TableNameLoadResponse = this.appDB.Load(TableNameLoadRequest);
				if(TableNameLoadResponse.Items.Count > 0)
				{
                    OriginRowAmount = _RowCount;
				}
                 
                #endregion  LoadToVariable

                #region CRUD LoadToVariable
                var tmp_site_mgmt_table_data1LoadRequest = collectionLoadRequestFactory.SQLLoad(
                    columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>(){{_PendingTableRemaining,$"count(1)"},},
				    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName:"tmp_site_mgmt_table_data",
				    fromClause: collectionLoadRequestFactory.Clause(""),
			        whereClause: collectionLoadRequestFactory.Clause("site = {0} AND status = 'P'",DeleteSite),
				    orderByClause: collectionLoadRequestFactory.Clause(""));

				var tmp_site_mgmt_table_data1LoadResponse = this.appDB.Load(tmp_site_mgmt_table_data1LoadRequest);
				if(tmp_site_mgmt_table_data1LoadResponse.Items.Count > 0)
				{
					PendingTableRemaining = _PendingTableRemaining;
				}
				#endregion  LoadToVariable
			}
			
			TableName = _TableName;
			PendingTableRemaining = _PendingTableRemaining;
			return (Severity, TableName, OriginRowAmount, PendingTableRemaining);
		}
		
	}
}
