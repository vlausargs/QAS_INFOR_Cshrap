//PROJECT NAME: Logistics
//CLASS NAME: Homepage_PastDueDatePOCount.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class Homepage_PastDueDatePOCount : IHomepage_PastDueDatePOCount
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		
		public Homepage_PastDueDatePOCount(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
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
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}
		
		public (int? ReturnCode,
			int? PastDueDatePOCount,
			int? NotPastDueDatePOCount,
			decimal? PastDueDatePOAmount,
			decimal? NotPastDueDatePOAmount) 
		Homepage_PastDueDatePOCountSp (int? PastDueDatePOCount,
			int? NotPastDueDatePOCount,
			decimal? PastDueDatePOAmount,
			decimal? NotPastDueDatePOAmount)
		{
			IntType _PastDueDatePOCount = PastDueDatePOCount;
			IntType _NotPastDueDatePOCount = NotPastDueDatePOCount;
			AmountType _PastDueDatePOAmount = PastDueDatePOAmount;
			AmountType _NotPastDueDatePOAmount = NotPastDueDatePOAmount;
			
			int? Severity = 0;
			StringType _ALTGEN_SpName = DBNull.Value;
			int? ALTGEN_Severity = null;

			if (existsChecker.Exists(
				tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause($"ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_PastDueDatePOCountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Homepage_PastDueDatePOCountSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord
				
				#region CRUD InsertByRecords
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName("Homepage_PastDueDatePOCountSp" + stringUtil.Char(95) + optional_module1Item.GetValue<string>("u0")));
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
					
					var ALTGEN = AltExtGen_Homepage_PastDueDatePOCountSp (_ALTGEN_SpName,
						PastDueDatePOCount,
						NotPastDueDatePOCount,
						PastDueDatePOAmount,
						NotPastDueDatePOAmount);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						PastDueDatePOCount = _PastDueDatePOCount;
						PastDueDatePOAmount = _PastDueDatePOAmount;
						NotPastDueDatePOCount = _NotPastDueDatePOCount;
						NotPastDueDatePOAmount = _NotPastDueDatePOAmount;
						return (ALTGEN_Severity, PastDueDatePOCount, NotPastDueDatePOCount, PastDueDatePOAmount, NotPastDueDatePOAmount);
						
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

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Homepage_PastDueDatePOCountSp") != null)
			{
				var EXTGEN = AltExtGen_Homepage_PastDueDatePOCountSp("dbo.EXTGEN_Homepage_PastDueDatePOCountSp",
					PastDueDatePOCount,
					NotPastDueDatePOCount,
					PastDueDatePOAmount,
					NotPastDueDatePOAmount);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.PastDueDatePOCount, EXTGEN.NotPastDueDatePOCount, EXTGEN.PastDueDatePOAmount, EXTGEN.NotPastDueDatePOAmount);
				}
			}
			
			#region CRUD LoadToVariable
			var poitemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PastDueDatePOCount,"COUNT(DISTINCT po.po_num)"},
					{_PastDueDatePOAmount,"SUM(poitem.item_cost * (poitem.qty_ordered - poitem.qty_received))"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"poitem",
				fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN po ON poitem.po_num = po.po_num"),
				whereClause: collectionLoadRequestFactory.Clause("poitem.stat = 'O' AND poitem.qty_received < poitem.qty_ordered AND poitem.due_date < GETDATE()"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(poitemLoadRequest);
			#endregion  LoadToVariable
			
			#region CRUD LoadToVariable
			var poitem1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_NotPastDueDatePOCount,"COUNT(DISTINCT po.po_num)"},
					{_NotPastDueDatePOAmount,"SUM(poitem.item_cost * (poitem.qty_ordered - poitem.qty_received))"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"poitem",
				fromClause: collectionLoadRequestFactory.Clause(" LEFT OUTER JOIN po ON poitem.po_num = po.po_num"),
				whereClause: collectionLoadRequestFactory.Clause("poitem.stat = 'O' AND poitem.qty_received < poitem.qty_ordered AND poitem.due_date >= GETDATE()"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			this.appDB.Load(poitem1LoadRequest);
			#endregion  LoadToVariable
			
			PastDueDatePOCount = _PastDueDatePOCount;
			PastDueDatePOAmount = _PastDueDatePOAmount;
			NotPastDueDatePOCount = _NotPastDueDatePOCount;
			NotPastDueDatePOAmount = _NotPastDueDatePOAmount;
			return (Severity, PastDueDatePOCount, NotPastDueDatePOCount, PastDueDatePOAmount, NotPastDueDatePOAmount);
		}

		public (int? ReturnCode, int? PastDueDatePOCount,
			int? NotPastDueDatePOCount,
			decimal? PastDueDatePOAmount,
			decimal? NotPastDueDatePOAmount) 
		AltExtGen_Homepage_PastDueDatePOCountSp(string AltExtGenSp,
			int? PastDueDatePOCount,
			int? NotPastDueDatePOCount,
			decimal? PastDueDatePOAmount,
			decimal? NotPastDueDatePOAmount)
		{
			IntType _PastDueDatePOCount = PastDueDatePOCount;
			IntType _NotPastDueDatePOCount = NotPastDueDatePOCount;
			AmountType _PastDueDatePOAmount = PastDueDatePOAmount;
			AmountType _NotPastDueDatePOAmount = NotPastDueDatePOAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "PastDueDatePOCount", _PastDueDatePOCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NotPastDueDatePOCount", _NotPastDueDatePOCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueDatePOAmount", _PastDueDatePOAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NotPastDueDatePOAmount", _NotPastDueDatePOAmount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PastDueDatePOCount = _PastDueDatePOCount;
				NotPastDueDatePOCount = _NotPastDueDatePOCount;
				PastDueDatePOAmount = _PastDueDatePOAmount;
				NotPastDueDatePOAmount = _NotPastDueDatePOAmount;
				
				return (Severity, PastDueDatePOCount, NotPastDueDatePOCount, PastDueDatePOAmount, NotPastDueDatePOAmount);
			}
		}
	}
}
