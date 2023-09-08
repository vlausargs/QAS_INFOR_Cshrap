//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustomerTop5SalesCRUD.cs

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
	public class CLM_CustomerTop5SalesCRUD : ICLM_CustomerTop5SalesCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		
		public CLM_CustomerTop5SalesCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CustomerTop5SalesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_CustomerTop5SalesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
		}
		
		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);
			
			this.appDB.Insert(optional_module1InsertRequest);
		}
		
		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}
		
		public (string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			
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
			var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
			if(tv_ALTGEN1LoadResponse.Items.Count > 0)
			{
				ALTGEN_SpName = _ALTGEN_SpName;
			}
			
			int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
			return (ALTGEN_SpName, rowCount);
		}
		
		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
				tableName:"#tv_ALTGEN", 
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}
		
		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}
		
		public (string, int? rowCount) CurrparmsLoad(string DomCurrCode)
		{
			CurrCodeType _DomCurrCode = DBNull.Value;
			
			var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_DomCurrCode,"curr_code"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"currparms",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
			if(currparmsLoadResponse.Items.Count > 0)
			{
				DomCurrCode = _DomCurrCode;
			}
			
			int rowCount = currparmsLoadResponse.Items.Count;
			return (DomCurrCode, rowCount);
		}
		
		public ICollectionLoadResponse Tv_Top1duedateSelect()
		{
			var tv_Top1DueDateLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "CoNum", "co_num" },
					{ "DueDate", "max(due_date)" },
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM coitem
					GROUP BY co_num"));
			
			return this.appDB.Load(tv_Top1DueDateLoadRequest);
		}
		
		public void Tv_Top1duedateInsert(ICollectionLoadResponse tv_Top1DueDateLoadResponse)
		{
			var tv_Top1DueDateInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Top1DueDate",
				items: tv_Top1DueDateLoadResponse.Items);
			
			this.appDB.Insert(tv_Top1DueDateInsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Top5salesSelect(string DomCurrCode)
		{
			var tv_Top5SalesLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "CoNum", "co.co_num" },
					{ "Name", "custaddr.name" },
					{ "DueDate", "tdd.DueDate" },
					{ "DomesticPrice", "COALESCE (Result1, 0.0)" },
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT TOP 5 @selectList
					FROM co
					INNER JOIN
					custaddr
					ON custaddr.cust_num = co.cust_num
					AND custaddr.cust_seq = co.cust_seq
					LEFT OUTER JOIN
					#tv_Top1DueDate AS tdd
					ON tdd.CoNum = co.co_num CROSS APPLY dbo.CurrCnvtSingleAmt(co.curr_code, 0, 0, 1, NULL, 2, 0, 1, co.exch_rate, NULL, {0}, 0, co.price)
					WHERE co.type IN ('R', 'B')
					AND co.stat IN ('P', 'O')
					AND EXISTS (SELECT 1
						FROM   coitem
						WHERE  coitem.co_num = co.co_num
						AND coitem.stat IN ('P', 'O'))
					ORDER BY DomesticPrice DESC", DomCurrCode));
			
			return this.appDB.Load(tv_Top5SalesLoadRequest);
		}
		
		public void Tv_Top5salesInsert(ICollectionLoadResponse tv_Top5SalesLoadResponse)
		{
			var tv_Top5SalesInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Top5Sales",
				items: tv_Top5SalesLoadResponse.Items);
			
			this.appDB.Insert(tv_Top5SalesInsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Top5sales1Select(DateTime? SiteDate)
		{
			var tv_Top5Sales1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"CoNum","#tv_Top5Sales.CoNum"},
					{"Name","#tv_Top5Sales.Name"},
					{"DueDate","#tv_Top5Sales.DueDate"},
					{"col0","CAST (NULL AS NVARCHAR)"},
					{"DomesticPrice","#tv_Top5Sales.DomesticPrice"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"#tv_Top5Sales",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_Top5Sales1LoadRequest);
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_CustomerTop5SalesSp(
			string AltExtGenSp)
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
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
