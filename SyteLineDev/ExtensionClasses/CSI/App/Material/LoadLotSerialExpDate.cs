//PROJECT NAME: Material
//CLASS NAME: LoadLotSerialExpDate.cs

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
	public class LoadLotSerialExpDate : ILoadLotSerialExpDate
	{
		readonly IApplicationDB appDB;
		
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IVariableUtil variableUtil;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

        public LoadLotSerialExpDate(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IGetSiteDate iGetSiteDate,
			IVariableUtil variableUtil,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.variableUtil = variableUtil;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}
		
		public (
			int? ReturnCode,
			DateTime? ExpirationDate)
		LoadLotSerialExpDateSp (
			string Item,
			DateTime? ManufacturedDate = null,
			DateTime? ExpirationDate = null)
		{
			DateType _ExpirationDate = ExpirationDate;
			int? Severity = 0;
			
			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			DateTime? Today = null;
			if (existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('LoadLotSerialExpDateSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    tableName:"optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('LoadLotSerialExpDateSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord
				
				#region CRUD InsertByRecords
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("LoadLotSerialExpDateSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);
				
				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords
				
				while (existsChecker.Exists(tableName:"#tv_ALTGEN",
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
						tableName:"#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause(""),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
					if(tv_ALTGEN1LoadResponse.Items.Count > 0)
					{
						ALTGEN_SpName = _ALTGEN_SpName;
					}
					#endregion  LoadToVariable
					
					var ALTGEN = AltExtGen_LoadLotSerialExpDateSp (_ALTGEN_SpName,
						Item,
						ManufacturedDate,
						ExpirationDate);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						ExpirationDate = _ExpirationDate;
						return (ALTGEN_Severity, ExpirationDate);
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
                        tableName:"#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
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
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_LoadLotSerialExpDateSp") != null)
			{
				var EXTGEN = AltExtGen_LoadLotSerialExpDateSp("dbo.EXTGEN_LoadLotSerialExpDateSp",
					Item,
					ManufacturedDate,
					ExpirationDate);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.ExpirationDate);
				}
			}
			
			Today = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfSp(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
			ManufacturedDate = convertToUtil.ToDateTime(stringUtil.IsNull(
				ManufacturedDate,
				Today));
			
			#region CRUD LoadToVariable
			var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
                    {_ExpirationDate,$"DATEADD(DAY, item.shelf_life, " + $"'{ManufacturedDate.Value.Year}-{ManufacturedDate.Value.Month}-{ManufacturedDate.Value.Day}')"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"item",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("item.item = {0}",Item),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemLoadResponse = this.appDB.Load(itemLoadRequest);
			if(itemLoadResponse.Items.Count > 0)
			{
				ExpirationDate = _ExpirationDate;
			}
			#endregion  LoadToVariable
			
			return (Severity, ExpirationDate);
		}

		public (int? ReturnCode,
			DateTime? ExpirationDate)
		AltExtGen_LoadLotSerialExpDateSp(
			string AltExtGenSp,
			string Item,
			DateTime? ManufacturedDate = null,
			DateTime? ExpirationDate = null)
		{
			ItemType _Item = Item;
			DateType _ManufacturedDate = ManufacturedDate;
			DateType _ExpirationDate = ExpirationDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturedDate", _ManufacturedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpirationDate", _ExpirationDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExpirationDate = _ExpirationDate;
				
				return (Severity, ExpirationDate);
			}
		}
	}
}
